using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Data.Entities
{
    public class Permissions
    {
        [Key]
        public long PermissionId { get; set; }
        public string LoginId { get; set; }
        public int? RoleId { get; set; }
        public bool? IsAdminRestricted { get; set; }
        public bool? IsUserRestricted { get; set; }
        public int Demo { get; set; }
        public DateTime? Updated { get; set; }
    }
}
