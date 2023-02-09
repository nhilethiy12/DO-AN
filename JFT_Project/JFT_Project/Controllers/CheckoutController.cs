using JFT_Project.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JFT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly JFTProjectContext _context = new JFTProjectContext();

        public CheckoutController(JFTProjectContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkoutdto>>> GetCheckouts()
        {
            return await _context.Checkoutdto.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Checkoutdto>> GetCheckout(int id)
        {
            var Checkoutdto = _context.Checkoutdto.Where(b => b.CusId == id).FirstOrDefault();
            if (Checkoutdto == null)
            {
                return null;
            }
            else
            {
                return Checkoutdto;
            }
        }

        [HttpPost]
        public bool CreateCheckout(Checkoutdto Checkoutdto)
        {
            try
            {
                _context.Checkoutdto.Add(Checkoutdto);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        


    }
}
