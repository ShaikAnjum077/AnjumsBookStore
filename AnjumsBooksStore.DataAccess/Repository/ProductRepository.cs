using AnjumsBooksStore.DataAccess.Data;
using AnjumsBooksStore.DataAccess.Repository.IRepository;
using AnjumsBooksStore.Models;
using AnjumsBooksStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnjumsBooksStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product product)
        {
            //use.NET LINQ to retrieve the first or default category objects,
            //then pass the id as a generic entity which matches the category ID

            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objFromDb != null) // save changer if not null
            {
                if (objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Author = product.Author;
                objFromDb.LastPrice = product.LastPrice;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.ImageUrl = product.ImageUrl;
                objFromDb.CoverTypeId = product.CoverTypeId;
                _db.SaveChanges();
            }
        }

        public IEnumerable<ProductVM> GetProducts()
        {
            var products = _db.Products.ToList();
            var categories = _db.Categories.ToList();
            var coverTypes = _db.CoverType.ToList();
            List<ProductVM> productVMs = new List<ProductVM>();
            ProductVM productVM = null;
            foreach(var item in products)
            {
                productVM = new ProductVM();
                productVM.Id = item.Id;
                productVM.Title = item.Title;
                productVM.LastPrice = item.LastPrice;
                productVM.ISBN = item.ISBN;
                productVM.Author = item.Author;
                productVM.CategoryName = categories.Where(i => i.Id == item.CategoryId).Select(i => i.Name).FirstOrDefault();
                productVM.CoverTypeName = coverTypes.Where(i => i.Id == item.CoverTypeId).Select(i => i.Name).FirstOrDefault();

                productVMs.Add(productVM);
            }
            return productVMs;
        }
    }
}
