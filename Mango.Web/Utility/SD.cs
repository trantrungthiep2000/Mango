namespace Mango.Web.Utility
{
    /// <summary>
    /// Information of SD
    /// CreatedBy: ThiepTT(25/08/2023)
    /// </summary>
    public class SD
    {
        /// <summary>
        /// Coupon API base
        /// </summary>
        public static string CouponAPIBase { get; set; } = string.Empty;

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
