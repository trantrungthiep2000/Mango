﻿using Mango.Services.EmailAPI.Data;
using Mango.Services.EmailAPI.Models;
using Mango.Services.EmailAPI.Models.Dtos;
using Mango.Services.EmailAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Mango.Services.EmailAPI.Services
{
    /// <summary>
    /// Information of email service
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public class EmailService : IEmailService
    {
        private DbContextOptions<AppDbContext> _dbOptions;

        public EmailService(DbContextOptions<AppDbContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        /// <summary>
        /// Email cart and log
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns></returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public async Task EmailCartAndLog(CartDto cartDto)
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("<br/>Cart Email Requested ");
            message.AppendLine("<br/>Total " + cartDto.CartHeader!.CartTotal);
            message.Append("<br/>");
            message.Append("<ul>");

            foreach (var item in cartDto.CartDetails!)
            {
                message.Append("<li>");
                message.Append(item.Product!.Name + " x " + item.Count);
                message.Append("</li>");
            }

            message.Append("</ul>");

            await LogAndEmail(message.ToString(), cartDto.CartHeader.Email);
        }

        private async Task<bool> LogAndEmail(string message, string email)
        {
            try
            {
                var emailLogger = new EmailLogger()
                {
                    Email = email,
                    EmailSent = DateTime.Now,
                    Message = message,
                };

                await using var _db = new AppDbContext(_dbOptions); 
                _db.EmailLoggers.Add(emailLogger);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
