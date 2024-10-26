using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactFormRazor.Pages
{
    public class ContactFormModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            // Page load logic if any
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the page to show validation messages.
            }

            Message = "Form submitted successfully!";
            return RedirectToPage(); // Redirect to clear form after successful submission.
        }

        public class InputModel
        {
            [Required(ErrorMessage = "First name is required and must be between 3 and 10 characters.")]
            [StringLength(10, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 10 characters.")]
            [RegularExpression(@"^[^@#\$\""%]*$", ErrorMessage = "First name cannot contain @, #, $, \", or %.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required and must be between 2 and 15 characters.")]
            [StringLength(15, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 15 characters.")]
            [RegularExpression(@"^[^@#\$\""%]*$", ErrorMessage = "Last name cannot contain @, #, $, \", or %.")]
            public string LastName { get; set; }

            [StringLength(25, MinimumLength = 8, ErrorMessage = "Address, if provided, must be between 8 and 25 characters.")]
            public string? AddressLine1 { get; set; } // Optional field

            [RegularExpression(@"^\d{10}$|^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be exactly 10 digits or in 123-456-7890 format.")]
            [Required(ErrorMessage = "Phone number is required.")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Inquiry information is required.")]
            public string Inquiry { get; set; }
        }
    }
}
