using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string Cnic { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application> ApplicationParents { get; set; }
        public virtual ICollection<Application> ApplicationFeePayers { get; set; }

    }
}
