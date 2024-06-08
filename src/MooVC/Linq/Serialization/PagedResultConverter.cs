#if NET6_0_OR_GREATER
namespace MooVC.Linq.Serialization;

using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using MooVC.Collections;
using MooVC.Linq;
using static MooVC.Linq.Serialization.PagedResultConverter_Resources;

/// <summary>
/// Provides serialization support for <see cref="PagedResult{T}"/>.
/// </summary>
public sealed class PagedResultConverter
    : JsonConverter<object>
{
    private const string RequestKey = nameof(PagedResult<object>.Request);
    private const string TotalKey = nameof(PagedResult<object>.Total);
    private const string ValuesKey = "$values";

    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(PagedResult<>);
    }

    /// <inheritdoc/>
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ulong total = default;
        Paging? request = default;
        object? values = default;
        Type type = typeToConvert.GetGenericArguments()[0];

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string? name = reader.GetString();
                _ = reader.Read();

                switch (name)
                {
                    case TotalKey:
                        total = reader.GetUInt64();
                        break;

                    case RequestKey:
                        request = JsonSerializer.Deserialize<Paging>(ref reader, options);
                        break;

                    case ValuesKey:
                        values = JsonSerializer.Deserialize(ref reader, type.MakeArrayType(), options)!;
                        break;
                }
            }
        }

        return Activator.CreateInstance(typeToConvert, request, total, values)!;
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        Type type = value.GetType();
        ulong total = GetValue<ulong>(TotalKey, type, value);
        Paging request = GetValue<Paging>(RequestKey, type, value);
        IEnumerator enumerator = ((IEnumerable)value).GetEnumerator();
        object[] values = enumerator.ToArray();

        writer.WriteStartObject();

        writer.WritePropertyName(TotalKey);
        writer.WriteNumberValue(total);

        writer.WritePropertyName(RequestKey);
        JsonSerializer.Serialize(writer, request, options);

        writer.WritePropertyName(ValuesKey);
        JsonSerializer.Serialize(writer, values, options);

        writer.WriteEndObject();
    }

    private static T GetValue<T>(string key, Type type, object value)
    {
        PropertyInfo? property = type.GetProperty(key)
            ?? throw new JsonException(GetValueFailure.Format(key, type));

        return (T)property.GetValue(value)!;
    }
}
#endif