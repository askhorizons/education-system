using AutoMapper;
using Client.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Areas.Admin.ViewComponents
{
    public class CandidateListViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CandidateListViewComponent(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(string cnic, string name)
        {
            var items = await GetItemsAsync(cnic, name);
            return View(items);
        }
        private async Task<IEnumerable<CandidateViewModel>> GetItemsAsync(string cnic, string name)
        {
            var temp = await _context.Candidates
                .ToListAsync();

            if (!string.IsNullOrEmpty(cnic) && !string.IsNullOrWhiteSpace(cnic))
            {
                temp = temp.Where(p => p.Cnic.Contains(cnic)).ToList();
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                temp = temp.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            return _mapper.Map<IEnumerable<CandidateViewModel>>(temp);
        }
    }
}
