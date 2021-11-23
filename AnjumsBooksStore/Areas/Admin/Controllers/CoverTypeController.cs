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
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly ICoverTypeRepository _coverTypeRepository;

        public CoverTypeController(IUnitOfWork unitOfWork, ApplicationDbContext db, ICoverTypeRepository coverTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _db = db;
            _coverTypeRepository = coverTypeRepository;
        }


        [HttpGet]
        public IActionResult AddCoverType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCoverType(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _db.CoverType.Add(coverType);
                _db.SaveChanges();
            }
            else
                return View(coverType);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Upsert(int id)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == id);
            return View(objFromDb);
        }


        [HttpPost]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
                _coverTypeRepository.Update(coverType);
            else
                return View(coverType);

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
            var allObj = _unitOfWork.CoverType.GetAll();
            return Json(new { data = allObj });
        }
        #endregion


    }
}

