using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Take.Api.GitChallenge.Facades.Interfaces;
using Take.Api.GitChallenge.Models;
using Take.Api.GitChallenge.Facades.Services;
//using Take.Api.GitChallenge.Services;

namespace Take.Api.GitChallenge.Facades.Facades
{
    class ReposFacades : IRepos
    {
        public async Task<List<Repository>> SearchReposAsync()
        {
            try
            {
                List<Repository> repos = new List<Repository>();
                List<Repository> repositories = new List<Repository>();
                IRestease api = RestEase.RestClient.For<IRestease>(Constants.ENDPOINT_API_GIT);
                repos = await api.SearchReposAsync();

                for (int i = 0; i < Constants.NUMBER_OBJECTS_SCANNED; i++)
                {
                    if (repos[i].Language == "C#")
                    {
                        repositories.Add(repos[i]);
                    }
                }
                return repositories;
            }
            catch (Exception)
            {
                return (null);
            }
        }
    }
}
