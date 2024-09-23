using FleetAPI.Models;
using FleetAPI.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace FleetAPI.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CarRentalContext _context;

    public CarsController(CarRentalContext context)
    {
        _context = context;
    }

    // GET: v1/cars?status=available|rented
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars(string status = Car.STATUS_AVAILABLE)
    {
        try
        {
            return await _context.Cars.Where(c => c.Status == status).ToListAsync();
        }
        catch (Exception ex)
        {
            // You should log this...
            throw; // returns server error (Statuscode 500)
        }
    }

    // POST: v1/cars
    [HttpPost]
    public IActionResult CreateCar(Car car)
    {
        try
        {
            Car entity = _context.Cars.Add(car).Entity;
            _context.SaveChanges();

            return Created($"v1/cars/{entity.Id}", entity);
        }
        catch (Exception ex)
        {
            // You should log this...
            throw; // returns server error (Statuscode 500)
        }
    }

    // DELETE: v1/cars/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCar(int id) {

        try
        {
            Car car = _context.Cars.Single(c => c.Id == id);
            _context.Cars.Remove(car);
            int changed = _context.SaveChanges();
            return Ok(changed == 1);
        }
        catch(Exception ex)
        {
            // You should log this...
            return BadRequest(ex.Message);
        }
    }

    // PATCH: v1/cars/{id}/{available|rented}
    [HttpPatch("{id}/{status}")]
    public IActionResult SetStatus(int id, string status)
    {
        try
        {
            Car car = _context.Cars.Single(c => c.Id == id);
            car.Status = status;
            int changed = _context.SaveChanges();
            return Ok(changed == 1);
        }
        catch (Exception ex)
        {
            // You should log this...
            return BadRequest(ex.Message);
        }
    }
}
