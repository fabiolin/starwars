using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using starwars.Infra.Entities;
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
    public class FilmController : ControllerBase
    {
        private readonly ILogger<FilmController> _logger;
        private readonly IFilmRepository _filmRepository;
        private readonly IHttpClientFactory _clientFactory;

        public FilmController(ILogger<FilmController> logger, IFilmRepository filmRepository, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _filmRepository = filmRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var films = await _filmRepository.GetAllAsync();

                return Ok(films);
            }
            catch (Exception ex)
            {
                Console.Write("Erro: " + ex.ToString());
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var film = await _filmRepository.GetAsync(id);

                return Ok(film);
            }
            catch (Exception ex)
            {
                Console.Write("Erro: " + ex.ToString());
            }

            return BadRequest();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Film film)
        {
            try
            {
                var result = _filmRepository.SaveAsync(film);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Erro: " + ex.ToString());
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(Film film)
        {
            try
            {
                var result = _filmRepository.Update(film);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Erro: " + ex.ToString());
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var film = await _filmRepository.GetAsync(id);
                if (film != null)
                {
                    _filmRepository.Delete(film);
                    return Ok();
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
