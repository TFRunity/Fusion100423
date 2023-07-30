﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class OrderNavbarViewModel
    {
        public Guid OrderId { get; set; }
        public bool Authentificated { get; set; }
        public bool Created { get; set; }
        public string Email { get; set; }
    }
}
