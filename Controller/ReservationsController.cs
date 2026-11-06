using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayReservationAPI.Data;
using RailwayReservationAPI.Models;

namespace RailwayReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Reservations.ToListAsync();

            return Ok(data);
        }

        // GET BY ID

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _context.Reservations.FindAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // INSERT

        [HttpPost]
        public async Task<IActionResult> Create(
            Reservation reservation)
        {
            _context.Reservations.Add(reservation);

            await _context.SaveChangesAsync();

            return Ok(reservation);
        }

        // UPDATE

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            Reservation reservation)
        {
            var data = await _context.Reservations.FindAsync(id);

            if (data == null)
                return NotFound();

            data.FirstName = reservation.FirstName;
            data.LastName = reservation.LastName;
            data.Age = reservation.Age;
            data.Gender = reservation.Gender;
            data.MobileNumber = reservation.MobileNumber;
            data.JourneyStart = reservation.JourneyStart;
            data.JourneyEnd = reservation.JourneyEnd;

            await _context.SaveChangesAsync();

            return Ok(data);
        }

        // DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Reservations.FindAsync(id);

            if (data == null)
                return NotFound();

            _context.Reservations.Remove(data);

            await _context.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}