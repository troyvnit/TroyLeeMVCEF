using System;

namespace TroyLeeMVCEF.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using Core.Functions;

    public class User
    {
        public User()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool Activated { get; set; }     
        public string Password
        {
            set { PasswordHash = CommonFunctions.MD5EncryptPassword(value); }
        }  
        public string DisplayName
        {
            get { return FirstName; }
        }
    }
}
