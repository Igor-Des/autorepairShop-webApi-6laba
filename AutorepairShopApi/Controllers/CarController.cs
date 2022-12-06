using AutorepairShopApi.Data;
using Autorepair.Shared.Models;
using Autorepair.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutorepairShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AutorepairContext _context;
        public CarController(AutorepairContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех автомобилей
        /// </summary>
        /// <returns>JSON</returns>
        // GET: api/<CarController>
        [HttpGet]
        [Produces("application/json")]
        public List<CarViewModel> Get()
        {
            IQueryable<CarViewModel> cars = _context.Cars.Include(own => own.Owner).Select(c =>
                new CarViewModel
                {
                   CarId = c.CarId,
                   Brand = c.Brand,
                   Power = c.Power,
                   Color = c.Color,
                   StateNumber = c.StateNumber,
                   Year = c.Year,
                   OwnerFIO = c.Owner.FirstName + " " + c.Owner.MiddleName + " " + c.Owner.LastName,
                   OwnerId = c.OwnerId,
                   VIN = c.VIN,
                   EngineNumber = c.EngineNumber,
                   AdmissionDate = c.AdmissionDate
                }).OrderBy(c => c.CarId);
            return cars.ToList();
        }

        /// <summary>
        /// Получение одной машины
        /// </summary>
        /// <param name="id">Код автомобиля</param>
        /// <returns>JSON</returns>
        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Car car = _context.Cars.FirstOrDefault(c => c.CarId == id);
            if (car == null)
                return NotFound();
            return new ObjectResult(car);
        }

        /// <summary>
        /// Добавление нового автомобиля
        /// </summary>
        /// <param name="car"></param>
        /// <returns>true/false</returns>
        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok(car);
        }

        /// <summary>
        /// Обновление автомобиля по id
        /// </summary>
        /// <param name="id">Код автомобиля</param>
        /// <param name="car">Объект авто</param>
        /// <returns>true/false</returns>
        // PUT api/<CarController>/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!_context.Cars.Any(c => c.CarId == car.CarId))
            {
                return NotFound();
            }
            _context.Update(car);
            _context.SaveChanges();
            return Ok(car);
        }

        /// <summary>
        /// Удаление автомобиля по ИД
        /// </summary>
        /// <param name="id">Код автомобиля</param>
        /// <returns>true/false</returns>
        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car car = _context.Cars.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return Ok(car);
        }
    }
}
