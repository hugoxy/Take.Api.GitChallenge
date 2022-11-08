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
    internal class ReposFacades : IRepos
    {
        public async Task<List<Repository>> SearchReposAsync()
        {
            try
            {
                IRestease api = RestEase.RestClient.For<IRestease>(Constants.ENDPOINT_API_GIT);
                List<Repository>repos = await api.SearchReposAsync();
                List<Repository> repositories = new List<Repository>();

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
