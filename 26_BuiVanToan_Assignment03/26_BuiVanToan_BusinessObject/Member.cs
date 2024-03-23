using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _26_BuiVanToan_BusinessObject
{
    public class Member:IdentityUser
    {
        public string? MemberName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
