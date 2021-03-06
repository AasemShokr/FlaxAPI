// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FlaxEngine.Json.JsonCustomSerializers
{
    internal class ExtendedDefaultContractResolver : DefaultContractResolver
    {
        private readonly Type _flaxType = typeof(Object);

        private readonly Type[] _attributesIgnoreList =
        {
            typeof(UnmanagedCallAttribute),
            typeof(NonSerializedAttribute),
            typeof(NoSerializeAttribute)
        };

        /// <inheritdoc />
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);

            // Override contract for Flax objects
            if (_flaxType.IsAssignableFrom(objectType))
            {
                ((JsonObjectContract)contract).ItemReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            }

            return contract;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var result = new List<JsonProperty>(fields.Length + properties.Length);

            for (int i = 0; i < fields.Length; i++)
            {
                var f = fields[i];
                var attributes = f.GetCustomAttributes();

                // Serialize non-public fields only with a proper attribute
                if (!f.IsPublic && !attributes.Any(x => x is SerializeAttribute))
                    continue;

                // Check if has attribute to skip serialization
                bool noSerialize = false;
                foreach (var attribute in attributes)
                {
                    if (_attributesIgnoreList.Contains(attribute.GetType()))
                    {
                        noSerialize = true;
                        break;
                    }
                }

                if (noSerialize)
                    continue;

                var jsonProperty = CreateProperty(f, memberSerialization);
                jsonProperty.Writable = true;
                jsonProperty.Readable = true;

                if (_flaxType.IsAssignableFrom(f.FieldType))
                {
                    jsonProperty.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    jsonProperty.Converter = JsonSerializer.ObjectConverter;
                }

                result.Add(jsonProperty);
            }

            for (int i = 0; i < properties.Length; i++)
            {
                var p = properties[i];

                // Serialize only properties with read/write
                if (!(p.CanRead && p.CanWrite && p.GetIndexParameters().GetLength(0) == 0))
                    continue;

                var attributes = p.GetCustomAttributes();

                // Check if has attribute to skip serialization
                bool noSerialize = false;
                foreach (var attribute in attributes)
                {
                    if (_attributesIgnoreList.Contains(attribute.GetType()))
                    {
                        noSerialize = true;
                        break;
                    }
                }

                if (noSerialize)
                    continue;

                var jsonProperty = CreateProperty(p, memberSerialization);
                jsonProperty.Writable = true;
                jsonProperty.Readable = true;

                if (_flaxType.IsAssignableFrom(p.PropertyType))
                {
                    jsonProperty.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    jsonProperty.Converter = JsonSerializer.ObjectConverter;
                }

                result.Add(jsonProperty);
            }

            return result;
        }
    }
}
