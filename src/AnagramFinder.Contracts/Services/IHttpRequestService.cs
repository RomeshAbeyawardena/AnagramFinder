using System;
using System.Collections.Generic;

namespace AnagramFinder.Contracts.Services
{
    public interface IHttpRequestService
    {
        string GenerateUrlWithQueryString(string baseUrl, params KeyValuePair<string, object>[] parameters);
    }
}
