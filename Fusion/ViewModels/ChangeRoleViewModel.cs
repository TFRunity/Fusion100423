﻿using Fusion.Models;
using System;
using System.Collections.Generic;

namespace Fusion.ViewModels
{
    public class ChangeRoleViewModel
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public List<UserRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<UserRole>();
            UserRoles = new List<string>();
        }
    }
}
