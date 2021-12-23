using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Areas.Admin.ViewModels
{
    public class CandidateViewModel
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cnic { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int GenderId { get; set; }
        public string Gender { get; set; }

        public int FeePayerId { get; set; }
        public string FeePayer { get; set; }
        
        public int ParentId { get; set; }
        public string Parent { get; set; }
    }
}
