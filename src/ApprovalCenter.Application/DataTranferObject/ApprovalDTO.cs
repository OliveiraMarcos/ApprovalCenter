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
        public string Subject { get; protected set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(500)]
        [DisplayName("Description")]
        public string Description { get; protected set; }

        [DisplayName("Is Approval")]
        public bool? IsApproval { get; protected set; }

        [DisplayName("Justification")]
        public string Justification { get; protected set; }

        //[DisplayName("Description")]
        //public CategoryDTO Category { get; protected set; }

        [Required(ErrorMessage = "The Category Id is Required")]
        [DisplayName("Category Id")]
        public Guid CategoryId { get; protected set; }

        [Required(ErrorMessage = "The Email Approval is Required")]
        [MinLength(2)]
        [MaxLength(250)]
        [DisplayName("Email Approval")]
        public string EmailApproval { get; protected set; }

        [DisplayName("Date Create")]
        public DateTime DateCreate { get; protected set; }

        [DisplayName("Date Approval")]
        public DateTime? DateApproval { get; protected set; }

        [DisplayName("Date Read")]
        public DateTime? DateRead { get; protected set; }
    }
}
