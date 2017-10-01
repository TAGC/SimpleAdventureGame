using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace experiment
{
    internal abstract class JsonDiscriminatorConverter<T> : CustomCreationConverter<T> where T : class
    {
        private readonly IDictionary<string, Type> _possibleTypes;
        private readonly string _discriminatorField;

        protected JsonDiscriminatorConverter(IEnumerable<Type> possibleTypes, string discriminatorField)
        {
            _possibleTypes = possibleTypes.ToDictionary(it => it.Name);
            _discriminatorField = discriminatorField;
        }

        public override T Create(Type objectType) => throw new NotSupportedException();

        public override object ReadJson(JsonReader reader, Type _, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var target = Create(jObject);
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private T Create(JToken jObject)
        {
            string typeName = jObject.Value<string>(_discriminatorField) ??
                throw new JsonSerializationException($"Discriminator field does not exist");

            if (_possibleTypes.TryGetValue(typeName, out var tType))
            {
                return (T)Activator.CreateInstance(tType);
            }

            throw new JsonSerializationException($"Unrecognised type: {typeName}");
        }
    }
}