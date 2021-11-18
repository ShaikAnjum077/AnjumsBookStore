using AnjumsBooksStore.DataAccess.Data;
using AnjumsBooksStore.DataAccess.Repository.IRepository;
using AnjumsBooksStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnjumsBooksStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public CategoryController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            else
                return View(category);
            
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }
        #endregion


    }
}
