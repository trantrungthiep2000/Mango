using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models
{
    /// <summary>
    /// Information of product
    /// CreatedBy: ThiepTT(06/09/2023)
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id of product
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Name of product
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Price of product
        /// </summary>
        [Range(1, 1000)]
        public double Price { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Name of catergory
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Url of image
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
