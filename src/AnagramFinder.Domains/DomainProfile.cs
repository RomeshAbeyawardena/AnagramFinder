using AnagramFinder.Domains.Requests;
using AnagramFinder.Domains.ViewModels;
using AutoMapper;

namespace AnagramFinder.Domains
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<FindAnagramsViewModel, FindAnagramRequest>();
        }
    }
}
