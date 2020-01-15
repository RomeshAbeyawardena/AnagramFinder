using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder.Contracts.Services
{
    public interface IJsonService
    {
        TOutput ConvertFromJsonStream<TOutput>(Stream stream);
    }
}
