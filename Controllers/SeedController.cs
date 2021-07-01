using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using starwars.Infra.Repository;
using starwars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace starwars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ILogger<SeedController> _logger;
        private readonly IFilmRepository _seedRepository;
        private readonly IHttpClientFactory _clientFactory;

        public SeedController(ILogger<SeedController> logger, IFilmRepository seedRepository, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _seedRepository = seedRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://swapi.dev/api/films/")
                };

                var client = _clientFactory.CreateClient();
                client.Timeout = TimeSpan.FromMinutes(5);

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {

                    var result = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<FilmList>(result);

                    foreach(var film in model.results)
                    {
                        _seedRepository.SaveAsync(new Infra.Entities.Film
                        {
                            CreatedAt = film.CreatedAt,
                            director = film.director,
                            episode_id = film.episode_id,
                            Id = film.Id,
                            IsDeleted = false,
                            opening_crawl = film.opening_crawl,
                            producer = film.producer,
                            release_date = film.release_date,
                            title = film.title,
                            url = film.url
                        });
                    }

                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Erro: " + ex.ToString());
            }

            return BadRequest();
        }
    }
}
