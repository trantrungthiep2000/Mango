using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    /// <summary>
    /// Information of product
    /// CreatedBy: ThiepTT(07/09/2023)
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id of product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Name of product
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Price of product
        /// </summary>
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

        /// <summary>
        /// Count
        /// </summary>
        [Range(1, 100)]
        public int Count { get; set; } = 1;
    }
}
