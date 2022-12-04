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
    public class QualificationController : ControllerBase
    {
        private readonly AutorepairContext _context;
        public QualificationController(AutorepairContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Получение всех должностей для механиков
        /// </summary>
        /// <returns>JSON</returns>
        // GET: api/<QualificationController>
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Qualification> Get()
        {
            return _context.Qualifications.ToList();
        }

        /// <summary>
        /// Получение должности по ИД
        /// </summary>
        /// <param name="id">Код должности</param>
        /// <returns>JSON</returns>
        // GET api/<QualificationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Qualification qualification = _context.Qualifications.FirstOrDefault(q => q.QualificationId == id);
            if (qualification == null)
                return NotFound();
            return new ObjectResult(qualification);
        }

        /// <summary>
        /// Добавить новую должность
        /// </summary>
        /// <param name="qualification">Модель должности</param>
        /// <returns>True/False</returns>
        // POST api/<QualificationController>
        [HttpPost]
        public IActionResult Post([FromBody] Qualification qualification)
        {
            if (qualification == null)
            {
                return BadRequest();
            }

            _context.Qualifications.Add(qualification);
            _context.SaveChanges();
            return Ok(qualification);
        }

        /// <summary>
        /// Обновление должности
        /// </summary>
        /// <param name="id">Код должности</param>
        /// <param name="qualification">Модель должности</param>
        /// <returns>True false</returns>
        // PUT api/<QualificationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Qualification qualification)
        {
            if (qualification == null)
            {
                return BadRequest();
            }
            if (!_context.Qualifications.Any(q => q.QualificationId == qualification.QualificationId))
            {
                return NotFound();
            }
            _context.Update(qualification);
            _context.SaveChanges();
            return Ok(qualification);
        }

        /// <summary>
        /// Удаление должности
        /// </summary>
        /// <param name="id">Код должности</param>
        /// <returns>true false</returns>
        // DELETE api/<QualificationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Qualification qualification = _context.Qualifications.FirstOrDefault(q => q.QualificationId == id);
            if (qualification == null)
            {
                return NotFound();
            }
            _context.Qualifications.Remove(qualification);
            _context.SaveChanges();
            return Ok(qualification);
        }
    }
}
