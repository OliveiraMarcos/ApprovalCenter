using System;
using System.ComponentModel.DataAnnotations;

namespace Thundera.Application.DataTranferObject
{
    public class BaseDTO
    {
        [Key]
        public Guid Id { get; set; }
    }
}
