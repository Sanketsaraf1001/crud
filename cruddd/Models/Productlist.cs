using System.ComponentModel.DataAnnotations;
using System;

namespace cruddd.Models
{
    public class Productlist
    {
        [Key]
        [Required (ErrorMessage ="Required*")]
        
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "Required*")]
        public string? CategoryName { get; set; }
    }
}
