using AnagramFinder.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramFinder.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        public string GenerateUrlWithQueryString(string baseUrl, params KeyValuePair<string, object>[] parameters)
        {
            var queryStringParameters = new StringBuilder("?");
            var index = 0;
            foreach(var (key, value) in parameters)
            {
                var isLast = index == parameters.Length  - 1;
                queryStringParameters.AppendFormat("{0}={1}{2}", key, value, isLast ? string.Empty : "&");
                index++;
            }
            return string.Format("{0}{1}", baseUrl, queryStringParameters);
        }
    }
}
