using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class CounterViewModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int PreviousCount { get; set; }
        public int CurrentCount { get; set; }
    }
}
