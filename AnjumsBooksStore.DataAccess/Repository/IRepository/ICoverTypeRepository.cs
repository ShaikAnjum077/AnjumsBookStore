﻿using AnjumsBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnjumsBooksStore.DataAccess.Repository.IRepository
{
    interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType category);
    }
}