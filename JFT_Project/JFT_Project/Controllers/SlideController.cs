using JFT_Project.DTOS;
using JFT_Project.ViewModel;
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

namespace JFT_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly JFTProjectContext _context = new JFTProjectContext();
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "slides");
        private static List<SlidedtoRecord> fileDB = new List<SlidedtoRecord>();
        public SlideController(JFTProjectContext context)
        {
            _context = context;
        }

        // GET: api/slide
        [HttpGet]
        public List<SlidedtoRecord> GetAllFiles()
        {
            //getting data from inmemory obj
            //return fileDB;
            //getting data from SQL DB
            return _context.Slidedto.Select(n => new SlidedtoRecord
            {
                SlideId = n.SlideId,
                FileName = n.SlideImage,
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Slidedto>> GetSlide(int? id)
        {
            var slide = _context.Slidedto.Where(c => c.SlideId == id).FirstOrDefault();
            if (slide == null)
            {
                return null;
            }
            else
            {
                return slide;
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PostAsync([FromForm] SlidedtoModel model)
        {
            try
            {
                SlidedtoRecord file = await SaveFileAsync(model.SlideImage);

                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    

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
        private void SaveToDB(SlidedtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Slidedto fileData = new Slidedto();
            fileData.SlideImage = record.FileName;

            _context.Slidedto.Add(fileData);
            _context.SaveChanges();

        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PutAsync(int id, [FromForm] SlidedtoModel model)
        {
            try
            {

                SlidedtoRecord file = await SaveFileAsync(model.SlideImage);
                if (!string.IsNullOrEmpty(file.FilePath))
                {

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
        private void SaveToDBId(int id, SlidedtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Slidedto fileData = _context.Slidedto.Where(b => b.SlideId == id).FirstOrDefault();
            fileData.SlideImage = record.FileName;
            _context.SaveChanges();

        }

        [HttpDelete("{id}")]
        public bool DeleteSlide(int id)
        {
            try
            {

                Slidedto slide = _context.Slidedto.Where(c => c.SlideId == id).FirstOrDefault();

                _context.Entry(slide).State = EntityState.Deleted;
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<SlidedtoRecord> SaveFileAsync(IFormFile myFile)
        {
            SlidedtoRecord file = new SlidedtoRecord();
            if (myFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var fileName = ContentDispositionHeaderValue.Parse(myFile.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(AppDirectory, fileName);

                file.SlideId = fileDB.Count() + 1;
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
