using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.ViewModels
{
    public class PostAddVm 
    {
        [Required(ErrorMessage = "نام الزامی است ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "متن محتوا الزامی است ")]
        public string Content { get; set; }
    }
    
}
