using AnagramFinder.Contracts.Services;
using AnagramFinder.Domains;
using AnagramFinder.Domains.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.App.Data
{
    public class AnagramHttpService : HttpClient
    {
        
    }

    public class AnagramService
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IJsonService _jsonService;
        private readonly HttpClient _httpClient;

        public AnagramService(IHttpClientFactory httpClientFactory, IJsonService jsonService, IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
            _jsonService = jsonService;
            _httpClient = httpClientFactory.CreateClient(Constants.AnagramFinderApi);;
        }

        public async Task<FindAnagramResponse> FindAnagram(string word, CancellationToken cancellationToken = default)
        {
            var requestUrl = _httpRequestService.GenerateUrlWithQueryString(
                Constants.RequestFindAnagram, new KeyValuePair<string, object>("Word", word));
            var request = await _httpClient.GetAsync(requestUrl, cancellationToken);
            
            if(!request.IsSuccessStatusCode)
                return null;
            
            return _jsonService.ConvertFromJsonStream<FindAnagramResponse>(await request.Content.ReadAsStreamAsync());
        }
    }
}
