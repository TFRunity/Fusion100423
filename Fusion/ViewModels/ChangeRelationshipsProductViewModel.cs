using System;
using System.Collections.Generic;
using Fusion.Models;

namespace Fusion.ViewModels
{
    public class ChangeRelationshipsProductViewModel
    {
        public Guid ProductId { get; set; }
        public List<Category> RelationshipsToUpdate { get; set; } = new List<Category>();
        public IList<ProductCategory> CurrentRelationships { get; set; } = new List<ProductCategory>();
    }
}
