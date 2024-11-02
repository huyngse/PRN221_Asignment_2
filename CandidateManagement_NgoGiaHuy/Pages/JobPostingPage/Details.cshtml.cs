using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject;
using CandidateManagement_Service;

namespace CandidateManagement_NgoGiaHuy.Pages.JobPostingPage
{
    public class DetailsModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public DetailsModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

      public JobPosting JobPosting { get; set; } = default!; 

        public IActionResult OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting = _jobPostingService.GetJobPosting(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            else 
            {
                JobPosting = jobposting;
            }
            return Page();
        }
    }
}
