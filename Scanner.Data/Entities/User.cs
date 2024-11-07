using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Data.Entities
{
    public class User
    {
        [Key]
        public long LoginId { get; set; }
        public string FullName { get; set; }
        public int? RoleId { get; set; }
        public string Role { get; set; }
        public int? AdminId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
