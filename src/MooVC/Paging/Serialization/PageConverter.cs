#if NET6_0_OR_GREATER
namespace MooVC.Paging.Serialization;

using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using MooVC.Linq;
using static MooVC.Paging.Serialization.PageConverter_Resources;

/// <summary>
/// Provides serialization support for <see cref="Page{T}"/>.
/// </summary>
public sealed class PageConverter
    : JsonConverter<object>
{
    private const string DirectiveKey = nameof(Page<object>.Directive);
    private const string TotalKey = nameof(Page<object>.Total);
    private const string ValuesKey = "$values";

    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Page<>);
    }

    /// <inheritdoc/>
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ulong? total = default;
        Directive directive = default;
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
                    case DirectiveKey:
                        directive = JsonSerializer.Deserialize<Directive>(ref reader, options);
                        break;

                    case TotalKey:
                        total = reader.GetUInt64();
                        break;

                    case ValuesKey:
                        values = JsonSerializer.Deserialize(ref reader, type.MakeArrayType(), options)!;
                        break;
                }
            }
        }

        return Activator.CreateInstance(typeToConvert, directive, total, values)!;
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        Type type = value.GetType();
        Directive directive = GetValue<Directive>(DirectiveKey, type, value);
        ulong? total = GetValue<ulong?>(TotalKey, type, value);
        IEnumerator enumerator = ((IEnumerable)value).GetEnumerator();
        object[] values = enumerator.ToArray();

        writer.WriteStartObject();

        writer.WritePropertyName(DirectiveKey);
        JsonSerializer.Serialize(writer, directive, options);

        if (total.HasValue)
        {
            writer.WritePropertyName(TotalKey);
            writer.WriteNumberValue(total.Value);
        }

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