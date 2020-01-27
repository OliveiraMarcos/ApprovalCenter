using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApprovalCenter.Application.DataTranferObject
{
    public class CategoryDTO: BaseDTO
    {
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(500)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Date Create")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Date Edit")]
        public DateTime DateEdit { get; set; }
    }
}
