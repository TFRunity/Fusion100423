using System;

namespace Fusion.Models
{
    public class UsersPicture
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
