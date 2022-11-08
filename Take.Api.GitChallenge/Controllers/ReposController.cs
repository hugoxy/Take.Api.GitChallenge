using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Take.Api.GitChallenge.Facades.Interfaces;
using Take.Api.GitChallenge.Models;

namespace Take.Api.GitChallenge.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ReposController : ControllerBase
    {
        private readonly IRepos _repos;

        public ReposController (IRepos repos)
        {
            _repos = repos;
        }
        [HttpGet]
        [Route("/repos")]
        public async Task<IActionResult> SearchReposAsync()
        {
            try
            {
                List<Repository> repos = await _repos.SearchReposAsync();
                return (Ok(repos));
            }
            catch (Exception)
            {
                return BadRequest("Algo inesperado aconteceu");
            }
        }

    }
}
