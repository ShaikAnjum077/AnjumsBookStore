using AnjumsBooksStore.DataAccess.Data;
using AnjumsBooksStore.DataAccess.Repository.IRepository;
using AnjumsBooksStore.Models;
using AnjumsBooksStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnjumsBooksStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IProductRepository _productRepository;

        public ProductController(IUnitOfWork unitOfWork, ApplicationDbContext db, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _db = db;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var productVM = new ProductVM();
            productVM.Categories = GetSelectListItemsCategories(_unitOfWork.Category.GetAll());
            productVM.CoverTypes = GetSelectListItemsCoverTypes(_unitOfWork.CoverType.GetAll());
            return View(productVM);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var dbProduct = new Product();
                dbProduct.Title = productVM.Title;
                dbProduct.LastPrice = productVM.LastPrice;
                dbProduct.ISBN = productVM.ISBN;
                dbProduct.Description = productVM.Description;
                dbProduct.CategoryId = productVM.CategoryId;
                dbProduct.CoverTypeId = productVM.CoverTypeId;
                dbProduct.Author = productVM.Author;
                dbProduct.ImageUrl = productVM.ImageUrl;
                _db.Products.Add(dbProduct);
                _db.SaveChanges();
            }
            else
            {
                productVM.Categories = GetSelectListItemsCategories(_unitOfWork.Category.GetAll());
                productVM.CoverTypes = GetSelectListItemsCoverTypes(_unitOfWork.CoverType.GetAll());
                return View(productVM);
            }                

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == id);
            if (objFromDb != null)
            {
                ProductVM productVM = new ProductVM();
                productVM.Title = objFromDb.Title;
                productVM.LastPrice = objFromDb.LastPrice;
                productVM.ISBN = objFromDb.ISBN;
                productVM.Description = objFromDb.Description;
                productVM.CategoryId = objFromDb.CategoryId;
                productVM.CoverTypeId = objFromDb.CoverTypeId;
                productVM.Author = objFromDb.Author;
                productVM.Id = objFromDb.Id;
                productVM.ImageUrl = objFromDb.ImageUrl;
                productVM.Categories = GetSelectListItemsCategories(_unitOfWork.Category.GetAll());
                productVM.CoverTypes = GetSelectListItemsCoverTypes(_unitOfWork.CoverType.GetAll());
                return View(productVM);
            }
            else
                return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var dbProduct = new Product();
                dbProduct.Title = productVM.Title;
                dbProduct.LastPrice = productVM.LastPrice;
                dbProduct.ISBN = productVM.ISBN;
                dbProduct.Description = productVM.Description;
                dbProduct.CategoryId = productVM.CategoryId;
                dbProduct.CoverTypeId = productVM.CoverTypeId;
                dbProduct.Author = productVM.Author;
                dbProduct.Id = productVM.Id;
                dbProduct.ImageUrl = productVM.ImageUrl;
                _productRepository.Update(dbProduct);
            }   
            else
            {
                productVM.Categories = GetSelectListItemsCategories(_unitOfWork.Category.GetAll());
                productVM.CoverTypes = GetSelectListItemsCoverTypes(_unitOfWork.CoverType.GetAll());
                return View(productVM);
            }
                

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == id);
            _db.Products.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _productRepository.GetProducts();
            return Json(new { data = allObj });
        }

        #endregion

        #region Non-Action methods

        [NonAction]
        private IEnumerable<SelectListItem> GetSelectListItemsCategories(IEnumerable<Models.Category> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        [NonAction]
        private IEnumerable<SelectListItem> GetSelectListItemsCoverTypes(IEnumerable<Models.CoverType> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        #endregion

    }
}
