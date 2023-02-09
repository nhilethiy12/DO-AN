using JFT_Project.DTOS;
using Microsoft.AspNetCore.Authorization;
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

namespace JFT_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");
        private static List<ProductdtoRecord> fileDB = new List<ProductdtoRecord>();
        private readonly JFTProjectContext _context = new JFTProjectContext();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(JFTProjectContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public List<ProductdtoRecord> GetAllFiles()
        {
            //getting data from inmemory obj
            //return fileDB;
            //getting data from SQL DB
            return _context.Productdto.Select(n => new ProductdtoRecord
            {
                ProductId = n.ProductId,
                ProductName = n.ProductName,
                Price = n.Price,
                Qnt = n.Qnt,
                Qnt1 = n.Qnt1,
                Detail = n.Detail,
                FileName = n.ProductImage,
                BrandId = n.BrandId
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Productdto>> GetProduct(int id)
        {
            var product = _context.Productdto.Where(p => p.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return null;
            }
            else
            {
                return product;
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PostAsync([FromForm] ProductdtoModel model)
        {
            try
            {
                ProductdtoRecord file = await SaveFileAsync(model.ProductImage);

                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    file.ProductName = model.ProductName;
                    file.Price = model.Price;
                    file.Qnt = model.Qnt;
                    file.Qnt1 = model.Qnt1;
                    file.Detail = model.Detail;
                    file.BrandId = model.BrandId;
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
        private void SaveToDB(ProductdtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Productdto fileData = new Productdto();
            fileData.ProductImage = record.FileName;
            fileData.ProductName = record.ProductName;
            fileData.Price = record.Price;
            fileData.Qnt = record.Qnt;
            fileData.Qnt1 = record.Qnt1;
            fileData.Detail = record.Detail;
            fileData.BrandId = record.BrandId;

            _context.Productdto.Add(fileData);
            _context.SaveChanges();
           
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PutAsync(int id, [FromForm] ProductdtoModel model)
        {
            try
            {

                ProductdtoRecord file = await SaveFileAsync(model.ProductImage);
                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    file.ProductName = model.ProductName;
                    file.Price = model.Price;
                    file.Qnt1 = model.Qnt1;
                    file.Detail = model.Detail;
                    file.BrandId = model.BrandId;
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
        private void SaveToDBId(int id,ProductdtoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            Productdto fileData = _context.Productdto.Where(b => b.ProductId == id).FirstOrDefault();
            fileData.ProductImage = record.FileName;
            fileData.ProductName = record.ProductName;
            fileData.Price = record.Price;
            fileData.Qnt1 = record.Qnt1;
            fileData.Detail = record.Detail;
            fileData.BrandId = record.BrandId;
            _context.SaveChanges();

        }

        [HttpGet("brandId/{brandId}")]
        public async Task<ActionResult<IEnumerable<Productdto>>> GetBrandProducts(int brandId)
        {
            return await _context.Productdto.Where(b => b.BrandId == brandId).ToListAsync();
        }

        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            try
            {

                Productdto product = _context.Productdto.Where(x => x.ProductId == id).FirstOrDefault();

                _context.Entry(product).State = EntityState.Deleted;
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<ProductdtoRecord> SaveFileAsync(IFormFile myFile)
        {
            ProductdtoRecord file = new ProductdtoRecord();
            if (myFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var fileName = ContentDispositionHeaderValue.Parse(myFile.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(AppDirectory, fileName);

                file.ProductId = fileDB.Count() + 1;
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
