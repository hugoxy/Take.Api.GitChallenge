using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Take.Api.GitChallenge.Models;

namespace Take.Api.GitChallenge.Facades.Interfaces
{
    public interface IRepos
    {
        Task<List<Repository>> SearchReposAsync();
    }
}
