using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Persistence.Model
{
    public partial class CriticalValues
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string ValueName { get; set; }
    }
}
