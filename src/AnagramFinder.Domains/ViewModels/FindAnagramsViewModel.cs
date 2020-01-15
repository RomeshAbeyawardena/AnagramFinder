using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AnagramFinder.Domains.ViewModels
{
    [BindProperties(SupportsGet = true)]
    public class FindAnagramsViewModel
    {
        [Required]
        public string Word { get; set; }
    }
}
