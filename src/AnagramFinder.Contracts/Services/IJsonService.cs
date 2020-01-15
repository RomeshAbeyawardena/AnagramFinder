using System.IO;

namespace AnagramFinder.Contracts.Services
{
    public interface IJsonService
    {
        TOutput ConvertFromJsonStream<TOutput>(Stream stream);
    }
}
