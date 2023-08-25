﻿namespace Mango.Services.CouponAPI.Models.Dtos
{
    /// <summary>
    /// Information of response dto
    /// CreatedBy: ThiepTT(24/08/2023)
    /// </summary>
    public class ReponseDto<T>
    {
        /// <summary>
        /// Result of response
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Is success
        /// </summary>
        public bool IsSuccess { get; set; } = false;

        /// <summary>
        /// Message of response
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}