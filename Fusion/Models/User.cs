using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Fusion.Models
{
    public class User : IdentityUser<Guid>
    {
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public string Year { get; set; }
        public string MainPicture { get; set; } //URL
        public string Gradient { get; set; } //Chooseable
        public string BackgroundPicture { get; set; } //Moderable
        public string Description { get; set; } 
        public string FutureJob { get; set; } //Selectable
        //Relationships
        public virtual List<UsersPicture> UsersPictures { get; set; } = new List<UsersPicture>();
        public virtual List<Order> Orders { get; set; } = new List<Order>();
        public Guid CurrentOrderId { get; set; }
    }
}
