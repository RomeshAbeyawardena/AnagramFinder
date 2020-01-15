using AnagramFinder.Contracts.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder.Services
{
    public class JsonService : IJsonService
    {
        public TOutput ConvertFromJsonStream<TOutput>(Stream stream)
        {
            TOutput output = default;
            using (var streamReader = new StreamReader(stream))
            {
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    var jsonSerializer = new JsonSerializer();
                    output = jsonSerializer.Deserialize<TOutput>(jsonTextReader);
                }
            }

            return output;
        }
    }
}
