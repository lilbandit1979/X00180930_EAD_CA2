using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace X00180930_EAD_CA2.Models
{
    public class Product
    {
        [Required]
        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2)]
        public string ProductName { get; set; } = "";
        [Required]
        public double ProductPrice { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public Category ProductCategory { get; set; }
        public Size ProductSize { get; set; }

     
    }
}
