using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Revolutionary.Areas.Identity.Data.Models;
using Revolutionary.Services;

namespace Revolutionary.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly UserExchangeManager.AuthenticationToApplication _exService;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            UserExchangeManager.AuthenticationToApplication exService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _exService = exService;
        }

        public string Username { get; set; }
        public string Role { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "ID")]
            public string Email { get; set; }

            
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            
            [StringLength(10)]
            [Display(Name = "Student code")]
            public string StudentCode { get; set; }

            
            [StringLength(30)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            
            [StringLength(20)]
            [Display(Name = "Class code")]
            public string Class { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Username = user.UserName;
            IList<string> Roles = await _userManager.GetRolesAsync(user);
            Role = Roles.First();

            Input = new InputModel
            {
                Name = user.Name,
                Email = user.Email,
                StudentCode = user.StudentCode,
                Class = user.Class,
                PhoneNumber = user.PhoneNumber
            };

            //IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user); 
            IsEmailConfirmed = true; // always be true

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            
            if (Input.StudentCode != null) user.StudentCode = Input.StudentCode;
            if (Input.Class != null) user.Class = Input.Class;
            if (Input.Name != null) user.Name = Input.Name;
            if (Input.PhoneNumber != null) user.PhoneNumber = Input.PhoneNumber;
            
            await _userManager.UpdateAsync(user);
            await _exService.Edit(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
