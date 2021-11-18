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
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IUnitOfWork unitOfWork, ApplicationDbContext db, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _db = db;
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
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


        [HttpGet]
        public IActionResult Upsert(int id)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == id);
            return View(objFromDb);
        }


        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
                _categoryRepository.Update(category);
            else
                return View(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == id);
            _db.Categories.Remove(objFromDb);
            _db.SaveChanges();
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
