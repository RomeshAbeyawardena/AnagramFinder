using System;
using System.Collections.Generic;

namespace AnagramFinder.Contracts.Services
{
    public interface IHttpRequestService
    {
        Uri GenerateQueryString(Uri baseUrl, params KeyValuePair<string,  object>[] parameters);
    }
}
