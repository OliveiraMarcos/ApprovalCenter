using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApprovalCenter.Application.DataTranferObject
{
    public class ApprovalDTO : BaseDTO
    {
        [Required(ErrorMessage = "The Subject is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Subject")]
        public string Subject { get;  set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(500)]
        [DisplayName("Description")]
        public string Description { get;  set; }

        [DisplayName("Is Approval")]
        public bool? IsApproval { get;  set; }

        [DisplayName("Justification")]
        public string Justification { get;  set; }

        [DisplayName("Category")]
        public CategoryDTO Category { get; set; }

        [Required(ErrorMessage = "The Category Id is Required")]
        [DisplayName("Category Id")]
        public Guid CategoryId { get;  set; }

        [Required(ErrorMessage = "The Email Approval is Required")]
        [MinLength(2)]
        [MaxLength(250)]
        [DisplayName("Email Approval")]
        public string EmailApproval { get;  set; }

        [DisplayName("Date Create")]
        public DateTime DateCreate { get;  set; }

        [DisplayName("Date Approval")]
        public DateTime? DateApproval { get;  set; }

        [DisplayName("Date Read")]
        public DateTime? DateRead { get;  set; }
    }
}
