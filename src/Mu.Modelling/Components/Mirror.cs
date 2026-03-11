namespace Mu.Modelling.Components;

using System.Collections.Immutable;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Graphify;
using MooVC.Modelling;

internal sealed class Mirror
    : IVisitor<Model, File>
{
    private static readonly DefaultHttpClientFactory DefaultHttpClientFactory = new();
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    private readonly IHttpClientFactory _httpClientFactory;

    public Mirror()
        : this(DefaultHttpClientFactory)
    {
    }

    internal Mirror(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async IAsyncEnumerable<File> Observe(Model model, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        Model.Options.GithubOptions options = model.Options.Github;

        if (!options.IsConfigured)
        {
            yield break;
        }

        HttpClient httpClient = _httpClientFactory.CreateClient(nameof(Mirror));
        ImmutableArray<string> paths = await GetPaths(httpClient, options, cancellationToken).ConfigureAwait(false);

        foreach (string relativePath in paths)
        {
            string content = await GetFileContent(httpClient, options, relativePath, cancellationToken).ConfigureAwait(false);
            string extension = GetExtension(relativePath);
            string path = GetPath(relativePath);

            yield return new File(content, extension, Path.GetFileNameWithoutExtension(relativePath), path);
        }
    }

    private static Uri BuildUri(Model.Options.GithubOptions options, string path)
    {
        return new Uri(new Uri(options.ApiBaseAddress, UriKind.Absolute), path);
    }

    private static HttpRequestMessage CreateRequest(HttpMethod method, Model.Options.GithubOptions options, string path)
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

    private static async Task<string> GetFileContent(HttpClient httpClient, Model.Options.GithubOptions options, string path, CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = CreateRequest(HttpMethod.Get, options, options.ContentsPath(path));
        using HttpResponseMessage response = await httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        FileResponse? file = await JsonSerializer.DeserializeAsync<FileResponse>(
            await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false),
            JsonSerializerOptions,
            cancellationToken)
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

    private static async Task<ImmutableArray<string>> GetPaths(HttpClient httpClient, Model.Options.GithubOptions options, CancellationToken cancellationToken)
    {
        var results = ImmutableArray.CreateBuilder<string>();
        var queue = new Queue<string>();
        queue.Enqueue(string.Empty);

        while (queue.TryDequeue(out string? path))
        {
            using HttpRequestMessage request = CreateRequest(HttpMethod.Get, options, options.ContentsPath(path));
            using HttpResponseMessage response = await httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            ImmutableArray<ContentResponse> items = await JsonSerializer.DeserializeAsync<ImmutableArray<ContentResponse>>(
                await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false),
                JsonSerializerOptions,
                cancellationToken)
                .ConfigureAwait(false);

            foreach (ContentResponse item in items)
            {
                if (item.Type == "dir")
                {
                    queue.Enqueue(item.Path);
                    continue;
                }

                if (item.Type == "file" && !string.IsNullOrWhiteSpace(item.Path))
                {
                    results.Add(item.Path);
                }
            }
        }

        return [.. results];
    }

    private sealed record ContentResponse(string Path, string Type);

    private sealed class DefaultHttpClientFactory
        : IHttpClientFactory
    {
        private static readonly HttpClient SharedHttpClient = new();

        public HttpClient CreateClient(string name)
        {
            return SharedHttpClient;
        }
    }

    private sealed record FileResponse(string Content, string Encoding);
}