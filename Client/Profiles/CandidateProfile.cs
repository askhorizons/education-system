using AutoMapper;
using Client.Areas.Admin.ViewModels;
using Client.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Profiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateViewModel>()
                .ForMember(p => p.DateOfBirth, src => src.MapFrom(x => x.DateOfBirth.Value.ToString("dd MMM yyyy")))
                .ForMember(p => p.Gender, src => src.MapFrom(x => x.GenderId == 1 ? "Male" : "Female"));
        }
    }
}
