using FleetAPI.Models;
using FleetAPI.Services.Data;
using Microsoft.AspNetCore.Mvc;

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
        // TODO: Implement this

        throw new NotImplementedException();
    }

    // POST: v1/cars
    [HttpPost]
    public IActionResult CreateCar(Car car)
    {

        // TODO: Implement this

        throw new NotImplementedException();
    }

    // DELETE: v1/cars/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCar(int id)
    {


        // TODO: Implement this

        throw new NotImplementedException();
    }

    // PATCH: v1/cars/{id}/{available|rented}
    [HttpPatch("{id}/{status}")]
    public IActionResult SetStatus(int id, string status)
    {

        // TODO: Implement this

        throw new NotImplementedException();
    }
}
