using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestEase;

using Take.Api.GitChallenge.Models;

namespace Take.Api.GitChallenge.Facades.Services
{
    [Header("User-Agent", "RestEase")]
    public interface IRestease
    {
        [Get("/orgs/takenet/repos")]
        Task<List<Repository>> SearchReposAsync();

    }
}
