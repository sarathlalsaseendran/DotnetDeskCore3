using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetDeskCore3.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.thumbUrl = "/images/no-image-available.png";
            this.productCategory = Enum.ProductCategory.Other;
        }
        public Guid productId { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        [StringLength(100)]
        public string productName { get; set; }
        [StringLength(200)]
        [Display(Name = "Description")]
        public string description { get; set; }
        [StringLength(255)]
        [Display(Name = "Thumb URL")]
        public string thumbUrl { get; set; }
        [Display(Name = "Product Category")]
        public Enum.ProductCategory productCategory { get; set; }


        public Guid organizationId { get; set; }
        public Organization organization { get; set; }

    }
}
