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

        /// <summary>
        /// Auth API base
        /// </summary>
        public static string AuthAPIBase { get; set; } = string.Empty;

        /// <summary>
        /// Product API base
        /// </summary>
        public static string ProductAPIBase { get; set; } = string.Empty;

        /// <summary>
        /// Role admin
        /// </summary>
        public const string RoleAdmin = "ADMIN";

        /// <summary>
        /// Role customer
        /// </summary>
        public const string RoleCustomer = "CUSTOMER";

        /// <summary>
        /// Token cookie
        /// </summary>
        public const string TokenCookie = "JWTToken";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
