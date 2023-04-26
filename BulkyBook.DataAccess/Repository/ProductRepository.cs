using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       
        public void Update(Product obj)
        {
            var objFromDB = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDB != null) 
            { 
                objFromDB.Title = obj.Title;
                objFromDB.ISBN = obj.ISBN;
                objFromDB.Description = obj.Description;
                objFromDB.Price = obj.Price;
                objFromDB.ListPrice = obj.ListPrice;
                objFromDB.CategoryId = obj.CategoryId;
                objFromDB.Price50 = obj.Price50;
                objFromDB.Price100 = obj.Price100;
                objFromDB.Author= obj.Author;
                objFromDB.CoverTypeId=obj.CoverTypeId;
                if (obj.ImageUrl != null)
                { 
                    objFromDB.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
