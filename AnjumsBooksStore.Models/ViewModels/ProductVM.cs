using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnjumsBooksStore.Models.ViewModels
{
    public class ProductVM
    {
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name ="Price")]
        public double LastPrice { get; set; }

        [Required]
        public string Author { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        
        [Required]
        [Display(Name = "Cover Type")]
        public int CoverTypeId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> CoverTypes { get; set; }


        public string CoverTypeName { get; set; }
    }
}
