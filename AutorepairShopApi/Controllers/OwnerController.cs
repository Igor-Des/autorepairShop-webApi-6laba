using AutorepairShopApi.Data;
using Autorepair.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutorepairShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly AutorepairContext _context;
        public OwnerController(AutorepairContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Список всех владельцев авто
        /// </summary>
        /// <returns>JSON</returns>
        // GET: api/<OwnerController>
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Owner> Get()
        {
            return _context.Owners.ToList();
        }


        /// <summary>
        /// Получение данных о владельце по его ИД
        /// </summary>
        /// <param name="id">Код владельца</param>
        /// <returns>JSON</returns>
        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Owner owner = _context.Owners.FirstOrDefault(o => o.OwnerId == id);
            if (owner == null)
                return NotFound();
            return new ObjectResult(owner);
        }

        /// <summary>
        /// Добавление нового владельца авто
        /// </summary>
        /// <param name="owner">Модель владельца</param>
        /// <returns>True/False</returns>
        // POST api/<OwnerController>
        [HttpPost]
        public IActionResult Post([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }

            _context.Owners.Add(owner);
            _context.SaveChanges();
            return Ok(owner);
        }

        /// <summary>
        /// Обновление владельца авто
        /// </summary>
        /// <param name="id">Код владельца авто</param>
        /// <param name="owner">Модель данных с владельцем</param>
        /// <returns>True/False</returns>
        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }
            if (!_context.Owners.Any(o => o.OwnerId == owner.OwnerId))
            {
                return NotFound();
            }
            _context.Update(owner);
            _context.SaveChanges();
            return Ok(owner);
        }

        /// <summary>
        /// Удаление владельца авто по Ид
        /// </summary>
        /// <param name="id">Код владельца авто</param>
        /// <returns>True/False</returns>
        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Owner owner = _context.Owners.FirstOrDefault(o => o.OwnerId == id);
            if (owner == null)
            {
                return NotFound();
            }
            _context.Owners.Remove(owner);
            _context.SaveChanges();
            return Ok(owner);
        }
    }
}
