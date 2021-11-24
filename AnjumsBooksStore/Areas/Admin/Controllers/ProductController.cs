using AnjumsBooksStore.DataAccess.Data;
using AnjumsBooksStore.DataAccess.Repository.IRepository;
using AnjumsBooksStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnjumsBooksStore.Areas.Admin.Controllers
{
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
    }
}
