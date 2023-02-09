
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
    public class CollectionsController : ControllerBase
    {
        private readonly JFTProjectContext _context = new JFTProjectContext();
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "collections");
        private static List<CollectiondtoRecord> fileDB = new List<CollectiondtoRecord>();
        public CollectionsController(JFTProjectContext context)
        {
            _context = context;
        }

        // GET: api/Collections
        [HttpGet]
        public List<CollectiondtoRecord> GetAllFiles()
        {
            //getting data from inmemory obj
            //return fileDB;
            //getting data from SQL DB
            return _context.Collectionsdto.Select(n => new CollectiondtoRecord
            {
                CollectionId = n.CollectionId,
                CollectionName = n.CollectionName,
                BrandId = n.BrandId,
                ProductId = n.ProductId,
                ProductId2 = n.ProductId2,
                ProductName1 = n.ProductName1,
                ProductName2 = n.ProductName2,
                PricePro1 = n.PricePro1,
                PricePro2 = n.PricePro2,
                Price = n.Price,
                Detail = n.Detail,
                ImageName = n.CollectionImage,
                ImageName2 = n.CollectionImage2,
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collectionsdto>> GetCollection(int? id)
        {
            var collection = _context.Collectionsdto.Where(c => c.CollectionId == id).FirstOrDefault();
            if (collection == null)
            {
                return null;
            }
            else
            {
                return collection;
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PostAsync([FromForm] CollectiondtoModel model)
        {
            try
            {
                CollectiondtoRecord file = await SaveFileAsync(model.CollectionImage);
                CollectiondtoRecord file2 = await SaveFileAsync(model.CollectionImage);

                if (!string.IsNullOrEmpty(file.FilePath) && !string.IsNullOrEmpty(file2.FilePath2))
                {
                    file.CollectionName = model.CollectionName;
                    file.BrandId = model.BrandId;
                    file.ProductId = model.ProductId;
                    file.ProductId2 = model.ProductId2;
                    file.ProductName1 = model.ProductName1;
                    file.ProductName2 = model.ProductName2;
                    file.PricePro1 = model.PricePro1;
                    file.PricePro2 = model.PricePro2;
                    file.Price = model.Price;
                    file.Detail = model.Detail;

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
        private void SaveToDB(CollectiondtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Collectionsdto fileData = new Collectionsdto();
            fileData.CollectionImage = record.ImageName;
            fileData.CollectionImage2 = record.ImageName2;
            fileData.CollectionName = record.CollectionName;
            fileData.BrandId = record.BrandId;
            fileData.ProductId = record.ProductId;
            fileData.ProductId2 = record.ProductId2;
            fileData.ProductName1 = record.ProductName1;
            fileData.ProductName2 = record.ProductName2;
            fileData.PricePro1 = record.PricePro1;
            fileData.PricePro2 = record.PricePro2;
            fileData.Price = record.Price;
            fileData.Detail = record.Detail;
            _context.Collectionsdto.Add(fileData);
            _context.SaveChanges();

        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PutAsync(int id, [FromForm] CollectiondtoModel model)
        {
            try
            {

                CollectiondtoRecord file = await SaveFileAsync(model.CollectionImage);
                CollectiondtoRecord file2 = await SaveFileAsync(model.CollectionImage);

                if (!string.IsNullOrEmpty(file.FilePath) && !string.IsNullOrEmpty(file2.FilePath2))
                {
                    file.CollectionName = model.CollectionName;
                    file.BrandId = model.BrandId;
                    file.ProductId = model.ProductId;
                    file.ProductId2 = model.ProductId2;
                    file.ProductName1 = model.ProductName1;
                    file.ProductName2 = model.ProductName2;
                    file.PricePro1 = model.PricePro1;
                    file.PricePro2 = model.PricePro2;
                    file.Price = model.Price;
                    file.Detail = model.Detail;
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
        private void SaveToDBId(int id, CollectiondtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Collectionsdto fileData = _context.Collectionsdto.Where(b => b.CollectionId == id).FirstOrDefault();
            fileData.CollectionImage = record.ImageName;
            fileData.CollectionImage2 = record.ImageName2;
            fileData.CollectionName = record.CollectionName;
            fileData.BrandId = record.BrandId;
            fileData.ProductId = record.ProductId;
            fileData.ProductId2 = record.ProductId2;
            fileData.ProductName1 = record.ProductName1;
            fileData.ProductName2 = record.ProductName2;
            fileData.PricePro1 = record.PricePro1;
            fileData.PricePro2 = record.PricePro2;
            fileData.Price = record.Price;
            fileData.Detail = record.Detail;
            _context.SaveChanges();

        }

        [HttpDelete("{id}")]
        public bool DeleteCollection(int id)
        {
            try
            {

                Collectionsdto collection = _context.Collectionsdto.Where(c => c.CollectionId == id).FirstOrDefault();

                _context.Entry(collection).State = EntityState.Deleted;
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task<CollectiondtoRecord> SaveFileAsync(IFormFile myFile)
        {
            CollectiondtoRecord file = new CollectiondtoRecord();
            if (myFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var ImageName = ContentDispositionHeaderValue.Parse(myFile.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(AppDirectory, ImageName);

                file.CollectionId = fileDB.Count() + 1;
                file.ImageName = ImageName;
                file.ImageName2 = ImageName;
                file.FilePath = path;
                file.FilePath2 = path;
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
