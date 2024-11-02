using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject;
using CandidateManagement_Service;

namespace CandidateManagement_NgoGiaHuy.Pages.JobPostingPage
{
    public class EditModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public EditModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        public IActionResult OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting =  _jobPostingService.GetJobPosting(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            JobPosting = jobposting;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _jobPostingService.UpdateJobPosting(JobPosting);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostingExists(JobPosting.PostingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobPostingExists(string id)
        {
          return _jobPostingService.GetJobPosting(id) != null;
        }
    }
}
