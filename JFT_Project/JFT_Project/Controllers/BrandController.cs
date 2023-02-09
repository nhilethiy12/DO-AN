using JFT_Project.DTOS;
using JFT_Project.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BranddtoModel = JFT_Project.ViewModel.BranddtoModel;

namespace JFT_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly JFTProjectContext _context = new JFTProjectContext();
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "brands");
        private static List<BranddtoRecord> fileDB = new List<BranddtoRecord>();
        public BrandController(JFTProjectContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Customers
        [HttpGet]
        public List<BranddtoRecord> GetAllFiles()
        {
            //getting data from inmemory obj
            //return fileDB;
            //getting data from SQL DB
            return _context.Branddto.Select(n => new BranddtoRecord
            {
                BrandId = n.BrandId,
                BrandName = n.BrandName,
                FileName = n.BrandImage,
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branddto>> Getbrand(int id)
        {
            var Branddto = _context.Branddto.Where(b => b.BrandId == id).FirstOrDefault();
            if (Branddto == null)
            {
                return null;
            }
            else
            {
                return Branddto;
            }
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PostAsync([FromForm] BranddtoModel model)
        {
            try
            {
                BranddtoRecord file = await SaveFileAsync(model.BrandImage);

                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    file.BrandName = model.BrandName;
                    
                    //Save to Inmemory object
                    //fileDB.Add(file);
                    //Save to SQL Server DB
                    SaveToDB(file);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                };
            }
        }
        private void SaveToDB(BranddtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Branddto fileData = new Branddto();
            fileData.BrandImage = record.FileName;
            fileData.BrandName = record.BrandName;

            _context.Branddto.Add(fileData);
            _context.SaveChanges();

        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PutAsync(int id, [FromForm] BranddtoModel model)
        {
            try
            {

                BranddtoRecord file = await SaveFileAsync(model.BrandImage);
                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    file.BrandName = model.BrandName;
                    //Save to Inmemory object
                    //fileDB.Add(file);
                    //Save to SQL Server DB
                    SaveToDBId(id, file);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                };
            }
        }
        private void SaveToDBId(int id, BranddtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Branddto fileData = _context.Branddto.Where(b => b.BrandId == id).FirstOrDefault();
            fileData.BrandImage = record.FileName;
            fileData.BrandName = record.BrandName;
            _context.SaveChanges();

        }


        [HttpDelete("{id}")]
        public bool DeleteBrand(int id)
        {
            try
            {
                Branddto brand = _context.Branddto.Where(b => b.BrandId == id).FirstOrDefault();
                _context.Entry(brand).State = EntityState.Deleted;
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<BranddtoRecord> SaveFileAsync(IFormFile myFile)
        {
            BranddtoRecord file = new BranddtoRecord();
            if (myFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var fileName = ContentDispositionHeaderValue.Parse(myFile.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(AppDirectory, fileName);

                file.BrandId = fileDB.Count() + 1;
                file.FileName = fileName;
                file.FilePath = path;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }

                return file;
            }
            return file;
        }
    }
}

