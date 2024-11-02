using CandidateManagement_BusinessObject;
using CandidateManagement_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CandidateManagement_NgoGiaHuy.Pages
{
    public class LoginModel : PageModel
    {
        private IHRAccountService _hraccountService;
        public LoginModel(IHRAccountService hRAccountService)
        {
            _hraccountService = hRAccountService;
        }
        public void OnGet()
        { 
        
        }
        public void OnPost() {
            string email = Request.Form["txtEmail"].ToString() ?? "";
            string password = Request.Form["txtPassword"].ToString() ?? "";
            Hraccount? account = _hraccountService.GetAccountByEmail(email);
            if (account != null && account.Password == password) 
            {
                HttpContext.Session.SetString("RoleID", account.MemberRole.ToString() ?? "");
                Response.Redirect("/CandidateProfilePage");
            } else
            {
                Response.Redirect("/Error");
           }
        }
    }
}
