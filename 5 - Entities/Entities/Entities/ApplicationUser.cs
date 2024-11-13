using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USR_BIRTHDATE")]
        public int BirthDate {get;set;}
        
        [Column("USR_PHONENUMBER")]
        public new string? PhoneNumber {get;set;}
        
        [Column("USR_TYPE")]
        public UserType? Type {get;set;}
    }
}