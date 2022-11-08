using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Take.Api.GitChallenge.Models
{
    public class Repositorie
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public string Url { get; set; }

    }
}
