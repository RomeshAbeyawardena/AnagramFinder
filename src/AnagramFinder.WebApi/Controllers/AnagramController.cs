using AnagramFinder.Contracts.Services;
using ControllerBase = DotNetInsights.Shared.Services.Abstractions.ControllerBase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AnagramFinder.Domains.ViewModels;
using AnagramFinder.Domains.Requests;

namespace AnagramFinder.WebApi.Controllers
{
    public class AnagramController : ControllerBase
    {
        private readonly IMediatorService _mediatorService;

        public AnagramController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<ActionResult> FindAnagrams(FindAnagramsViewModel findAnagramsViewModel)
        {
            var findAnagramRequest = Map<FindAnagramsViewModel,FindAnagramRequest>(findAnagramsViewModel);
            return Ok(await _mediatorService.Send<FindAnagramRequest, FindAnagramResponse>(findAnagramRequest));
        }
    }
}
