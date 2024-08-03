using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Api.Entities;
using TodoList.Models;
using TodoList.Models.Enums;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly TodoListDbContext _context;

        public ProceduresController(TodoListDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetDoctors")]
        public async Task<ActionResult<IEnumerable<UserSP>>> GetDoctors()
        {
            var users = await _context.Doctors
                .FromSqlRaw("EXEC [dbo].[GetDoctors]")
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("GetReceptionist")]
        public async Task<ActionResult<IEnumerable<UserSP>>> GetReceptionist()
        {
            var users = await _context.Doctors
                .FromSqlRaw("EXEC [dbo].[GetReceptionist]")
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("GetCashier")]
        public async Task<ActionResult<IEnumerable<UserSP>>> GetCashier()
        {
            var users = await _context.Doctors
                .FromSqlRaw("EXEC [dbo].[GetCashier]")
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("GetPharmacist")]
        public async Task<ActionResult<IEnumerable<UserSP>>> GetPharmacist()
        {
            var users = await _context.Doctors
                .FromSqlRaw("EXEC [dbo].[GetPharmacist]")
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("CountDoctor")]
        public async Task<ActionResult<int>> CountDoctor()
        {
            var result = await _context.Set<CountDoctorModel>()
                .FromSqlRaw("CountDoctor")
                .ToListAsync();
            return Ok(result);
        }
    }
}
