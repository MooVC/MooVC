namespace Mu.Modelling.Components;

using System.Collections.Immutable;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Graphify;
using MooVC.Modelling;
using static Mu.Modelling.Options;

internal sealed class Mirror(IHttpClientFactory factory)
    : IVisitor<Model, File>
{
    private const string Directory = "dir";
    private const string File = "file";

    public async IAsyncEnumerable<File> Observe(Model model, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        GithubOptions options = model.Options.Github;

        if (!options.IsConfigured)
        {
            yield break;
        }

        HttpClient httpClient = factory.CreateClient(nameof(Mirror));
        ImmutableArray<string> paths = await GetPaths(httpClient, options, cancellationToken)
            .ConfigureAwait(false);

        foreach (string relativePath in paths)
        {
            string content = await GetFileContent(httpClient, options, relativePath, cancellationToken)
                .ConfigureAwait(false);

            string extension = GetExtension(relativePath);
            string path = GetPath(relativePath);

            yield return new File(content, extension, Path.GetFileNameWithoutExtension(relativePath), path);
        }
    }

    private static Uri BuildUri(GithubOptions options, string path)
    {
        return new Uri(new Uri(options.ApiBaseAddress, UriKind.Absolute), path);
    }

    private static HttpRequestMessage CreateRequest(HttpMethod method, GithubOptions options, string path)
    {
        HttpRequestMessage request = new(method, BuildUri(options, path));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Mu", "1.0"));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));

        if (!string.IsNullOrWhiteSpace(options.Token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", options.Token);
        }

        return request;
    }

    private static string DecodeContent(string content, string encoding)
    {
        if (!string.Equals(encoding, "base64", StringComparison.OrdinalIgnoreCase))
        {
            return content;
        }

        byte[] bytes = Convert.FromBase64String(content.Replace("\n", string.Empty, StringComparison.Ordinal));
        return Encoding.UTF8.GetString(bytes);
    }

    private static string GetExtension(string relativePath)
    {
        string extension = Path.GetExtension(relativePath);

        return string.IsNullOrEmpty(extension)
            ? string.Empty
            : extension[1..];
    }

    private static async Task<string> GetFileContent(HttpClient httpClient, GithubOptions options, string path, CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = CreateRequest(HttpMethod.Get, options, options.ContentsPath(path));

        using HttpResponseMessage response = await httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);

        _ = response.EnsureSuccessStatusCode();

        Stream stream = await response.Content
            .ReadAsStreamAsync(cancellationToken)
            .ConfigureAwait(false);

        FileResponse? file = await JsonSerializer
            .DeserializeAsync<FileResponse>(stream, options.Json, cancellationToken)
            .ConfigureAwait(false);

        if (file is null || string.IsNullOrWhiteSpace(file.Content))
        {
            return string.Empty;
        }

        return DecodeContent(file.Content, file.Encoding);
    }

    private static string GetPath(string relativePath)
    {
        string? path = Path.GetDirectoryName(relativePath);

        if (string.IsNullOrWhiteSpace(path))
        {
            return string.Empty;
        }

        return string.Concat(path.Replace('\\', '/'), "/");
    }

    private static async Task<ImmutableArray<string>> GetPaths(HttpClient httpClient, GithubOptions options, CancellationToken cancellationToken)
    {
        ImmutableArray<string>.Builder results = ImmutableArray.CreateBuilder<string>();
        var queue = new Queue<string>();
        queue.Enqueue(string.Empty);

        while (queue.TryDequeue(out string? path))
        {
            path = options.ContentsPath(path);

            using HttpRequestMessage request = CreateRequest(HttpMethod.Get, options, path);

            using HttpResponseMessage response = await httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                .ConfigureAwait(false);

            _ = response.EnsureSuccessStatusCode();

            Stream stream = await response.Content
                .ReadAsStreamAsync(cancellationToken)
                .ConfigureAwait(false);

            ImmutableArray<ContentResponse> items = await JsonSerializer
                .DeserializeAsync<ImmutableArray<ContentResponse>>(stream, options.Json, cancellationToken)
                .ConfigureAwait(false);

            foreach (ContentResponse item in items)
            {
                if (item.Type == Directory)
                {
                    queue.Enqueue(item.Path);
                    continue;
                }

                if (item.Type == File && !string.IsNullOrWhiteSpace(item.Path))
                {
                    results.Add(item.Path);
                }
            }
        }

        return [.. results];
    }

    private sealed record ContentResponse(string Path, string Type);

    private sealed record FileResponse(string Content, string Encoding);
}