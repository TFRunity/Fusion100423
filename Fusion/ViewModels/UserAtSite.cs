using System;
using System.Collections.Generic;
using Fusion.Models;

namespace Fusion.ViewModels
{
    public class UserAtSite
    {
        public UserAtSite(User user)
        {
            Name = user.UserName;
            Description = user.Description;
            UserPictures = user.UsersPictures;
            Year = user.Year;
            MainPicture = user.MainPicture;
            Gradient = user.Gradient;
            BackgroundPicture = user.BackgroundPicture;
            FutureJob = user.FutureJob;
            OrderId = user.CurrentOrderId;
            Orders = user.Orders;
            Email = user.Email;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UsersPicture> UserPictures { get; set; }
        public string Year { get; set; }
        public string MainPicture { get; set; }
        public string Gradient { get; set; }
        public string BackgroundPicture { get; set; }
        public string FutureJob { get; set; }
        public string Email { get; set; }
        public Guid OrderId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
