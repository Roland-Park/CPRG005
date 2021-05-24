using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CPRG005.Final.Roland.Pages
{
    public class SignupModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private IHashingHelper hashingHelper;

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must confirm your password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string City { get; set; }
        public SignupModel(IHttpClientFactory clientFactory, IHashingHelper hashingHelper)
        {
            this.clientFactory = clientFactory;
            this.hashingHelper = hashingHelper;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            UserName = Request.Form[nameof(UserName)];
            Password = Request.Form[nameof(Password)];
            PasswordConfirm = Request.Form[nameof(PasswordConfirm)];
            FirstName = Request.Form[nameof(FirstName)];
            LastName = Request.Form[nameof(LastName)];
            Phone = Request.Form[nameof(Phone)];
            City = Request.Form[nameof(City)];

            if (!string.Equals(Password, PasswordConfirm))
            {
                return BadRequest("Passwords do not match");
            }

            var customer = new CustomerCreationViewModel
            {
                FirstName = FirstName,
                LastName = LastName,
                City = City,
                Phone = Phone
            };

            var authorization = new AuthorizeCreationViewModel
            {
                UserName = UserName,
                Password = hashingHelper.Hash(Password),
                Customer = customer
            };

            try
            {
                var client = clientFactory.CreateClient("MarinaApi");
                var response = await client.PostAsJsonAsync("authorization", authorization);
                return Page();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class CustomerCreationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }

    public class AuthorizeCreationViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CustomerCreationViewModel Customer { get; set; }
    }
}
