namespace Mango.Web.Models
{
    /// <summary>
    /// Information of product dto
    /// CreatedBy: ThiepTT(06/09/2023)
    /// </summary>
    public class ProductDto
    {
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
    }
}
