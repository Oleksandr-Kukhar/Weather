using System;
using System.Collections.Generic;

namespace Weather.Persistence.Model
{
    public partial class Wind
    {
        public Guid Id { get; set; }
        public double Speed { get; set; }
        public int Direction { get; set; }
        public DateTime RegisterTime { get; set; }
    }
}
