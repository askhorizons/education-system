using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application> ApplicationsOptionOne { get; set; }
        public virtual ICollection<Application> ApplicationsOptionTwo { get; set; }

    }
}
