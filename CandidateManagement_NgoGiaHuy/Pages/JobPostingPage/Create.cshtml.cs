using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BusinessObject;
using CandidateManagement_Service;

namespace CandidateManagement_NgoGiaHuy.Pages.JobPostingPage
{
    public class CreateModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;
        public CreateModel(IJobPostingService jobPostingService)
        { 
            _jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
          if (!ModelState.IsValid || JobPosting == null)
            {
                return Page();
            }

            _jobPostingService.AddJobPosting(JobPosting);

            return RedirectToPage("./Index");
        }
    }
}
