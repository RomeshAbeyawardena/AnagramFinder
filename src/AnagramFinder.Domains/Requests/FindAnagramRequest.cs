using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder.Domains.Requests
{
    public class FindAnagramRequest : IRequest<FindAnagramResponse>
    {
        public string Word { get; }
    }
}
