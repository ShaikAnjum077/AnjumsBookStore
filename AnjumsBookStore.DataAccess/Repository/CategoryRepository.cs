using AnjumsBookStore.DataAccess.Data;
using AnjumsBookStore.DataAccess.Repository.IRepository;
using AnjumsBookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnjumsBookStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        // modify the database w/ the db context
        private readonly ApplicationDbContext _db;      // get the db instance using the constructor and DI 
        
        public CategoryRepository(ApplicationDbContext db) : base(db)     // use hot keys C-T-O-R to build the constructor
        {
            _db = db;
        }
    }
}
