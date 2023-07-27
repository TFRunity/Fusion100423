using Microsoft.AspNetCore.Identity;
using System;

namespace Fusion.Models
{
    public class UserRole : IdentityRole<Guid>
    { 

        public override string Name { get => base.Name; set => base.Name = value; }
        public UserRole(string name)
        {
            Name = name;
        }
    }
}
