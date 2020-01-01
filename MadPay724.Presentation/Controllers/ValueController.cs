using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Auth.Interface;
using MadPay724.Services.Auth.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MadPay724.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {

        private readonly IUnitOfWork<MadPayDBContext> _db;
        private readonly IAuthService _authService;

        public ValueController(IUnitOfWork<MadPayDBContext> dbContext, IAuthService authService)
        {
            _db = dbContext;
            _authService = authService;
        }
        // GET: api/Value
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var user = new User()
            {
                Address = "",
                City = "",
                DateOfBirth = "",
                Gender = "",
                IsActive = true,
                Name = "",
                PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, },
                PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, },
                PhonNumber = "",
                Status = true,
                UserName = ""

            };
            //await _db.UserRepository.InsertAsync(user);
            //await _db.SaveAsync();

            //var model = await _db.UserRepository.GetAllAsync();

            var u = await _authService.Register(user, "asdfgh");

            return Ok(u);
        }

        // GET: api/Value/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<string> Get(int id)
        {
            return "value";
        }

        // POST: api/Value
        [HttpPost]
        public async Task<string> Post([FromBody] string value)
        {
            return null;
        }

        // PUT: api/Value/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] string value)
        {
            return null;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return null;
        }
    }
}
