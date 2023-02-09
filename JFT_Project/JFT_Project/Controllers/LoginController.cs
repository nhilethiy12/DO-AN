using JFT_Project.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JFT_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JFTProjectContext _context = new JFTProjectContext();
        public LoginController(JFTProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginModel>>> GetAdmin()
        {
            return await _context.Login.ToListAsync();
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel admin)
        {
            var adminAvailabel = _context.Login.Where(a => a.AdminName == admin.AdminName && a.Password == admin.Password).FirstOrDefault();
            if (adminAvailabel == null)
            {
                return BadRequest(new { message = "Login or password is incorrect" });
            }
            return Ok(adminAvailabel);
        }
    }
}
