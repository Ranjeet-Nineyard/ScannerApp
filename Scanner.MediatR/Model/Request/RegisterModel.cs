using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.MediatR.Model.Request
{
    public class RegisterModel
    {
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? AdminId { get; set; }
    }
}
