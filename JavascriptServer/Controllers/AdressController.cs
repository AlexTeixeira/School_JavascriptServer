using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavascriptServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JavascriptServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;

        public AdressController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [HttpPost]
        public async Task<Adress> Post([FromBody] Adress adress)
        {
            try
            {
                await _applicationContext.AddAsync(adress);
                await _applicationContext.SaveChangesAsync();

                return adress;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Adress> Get([FromRoute] int id)
        {
            try
            {
                var entities = _applicationContext.Set<Adress>();

                return await entities.FirstAsync(s => s.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            try
            {
                var entities = _applicationContext.Set<Adress>();
                var adress = await entities.FirstAsync(s => s.Id == id);
                entities.Remove(adress);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Adress>> GetAll()
        {
            try
            {
                var entities = _applicationContext.Set<Adress>();

                return await entities.Where(s => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut]
        public Adress Put([FromBody] Adress adress)
        {
            try
            {
                _applicationContext.Update(adress);
                _applicationContext.SaveChanges();

                return adress;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}