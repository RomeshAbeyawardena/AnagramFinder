using AnagramFinder.App.Data;
using AnagramFinder.Domains.Requests;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AnagramFinder.App.Pages
{
    public class AnagramHelper : ComponentBase
    {
        [Inject]
        private AnagramService AnagramService { get; set; }
        
        protected FindAnagramResponse Response = null;
        protected string Word { get; set; }
        protected async Task FindAnagrams()
        {
            Response = await AnagramService.FindAnagram(Word);
        }
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}
