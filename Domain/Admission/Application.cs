using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Application
    {
        public int ApplicationId { get; set; }
        
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        
        public int ClassId { get; set; }
        public virtual Class Class{ get; set; }
        
        public int? OptionOneId { get; set; }
        public virtual Option OptionOne { get; set; }

        public int? OptionTwoId { get; set; }
        public virtual Option OptionTwo { get; set; }

        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }

        public int FeePayerId { get; set; }
        public virtual Parent FeePayer { get; set; }

    }
}
