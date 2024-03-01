using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.ViewModels
{
    public class CategoryAddVm 
    {
        [Required(ErrorMessage = "نام الزامی است ")]
        public string Title { get; set; }
    }
    public class CategoryEditVm 
    {
        [Required(ErrorMessage = "نام الزامی است ")]
        public string Title { get; set; }
        public int Id { get; set; }
    }
}
