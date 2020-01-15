using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AnagramFinder.Domains.ViewModels
{
    [BindProperties(SupportsGet = true)]
    public class FindAnagramsViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(1400)]
        public string Word { get; set; }
    }
}
