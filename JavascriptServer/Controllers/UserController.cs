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
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;
        
        public UserController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            try
            {
                await _applicationContext.AddAsync(user);
                await _applicationContext.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<User> Get([FromRoute] int id)
        {
            var entities = _applicationContext.Set<User>();

            return await entities.FirstAsync(s => s.Id == id);
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            try
            {
                _applicationContext.Update(user);
                _applicationContext.SaveChanges();

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("{id}/adresses")]
        public async Task<IEnumerable<Adress>> Put([FromRoute]int id)
        {
            try
            {
                var entities = _applicationContext.Set<Adress>();

                return await entities.Where(s => s.UserId == id).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}