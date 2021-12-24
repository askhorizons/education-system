using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

    }
}
