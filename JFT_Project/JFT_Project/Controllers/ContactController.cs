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
    public class ContactController : ControllerBase
    {
        private readonly JFTProjectContext _context = new JFTProjectContext();

        public ContactController(JFTProjectContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactdto>>> GetContacts()
        {
            return await _context.Contactdto.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contactdto>> GetContact(int id)
        {
            var Contactdto = _context.Contactdto.Where(b => b.CusId == id).FirstOrDefault();
            if (Contactdto == null)
            {
                return null;
            }
            else
            {
                return Contactdto;
            }
        }

        [HttpPost]
        public bool CreateContact(Contactdto Contactdto)
        {
            try
            {
                _context.Contactdto.Add(Contactdto);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut("{id}")]

        public void PutContact(int? id, Contactdto Contact)
        {
            var pro = _context.Contactdto.Where(b => b.CusId == id).FirstOrDefault();
            pro.FirstName = Contact.FirstName;
            pro.LastName = Contact.LastName;
            pro.CompanyName = Contact.CompanyName;
            pro.Content = Contact.Content;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public bool DeleteContact(int id)
        {
            try
            {

                Contactdto Contact = _context.Contactdto.Where(b => b.CusId == id).FirstOrDefault();

                _context.Entry(Contact).State = EntityState.Deleted;
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
