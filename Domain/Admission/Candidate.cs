using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Candidate
    {
        public Candidate()
        {
        }

        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cnic { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int GenderId { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
