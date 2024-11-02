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
    public class IndexModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public IndexModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public IList<JobPosting> JobPosting { get; set; } = default!;

        public void OnGetAsync()
        {
            JobPosting = _jobPostingService.GetJobPostings(); ;
        }
    }
}
