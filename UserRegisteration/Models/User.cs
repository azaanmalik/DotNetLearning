using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegisteration.Models
{
    public class User
    {
        public int UserId { get; set; }


        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = " User Name")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string UserName { get; set; } =string.Empty;

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(maximumLength: 20, ErrorMessage = "Password must be within the given range", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;


        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        [StringLength(maximumLength:20,ErrorMessage ="Password must be within the given range",MinimumLength =8)]
        public string ConfirmPassword { get; set; }=string.Empty;

        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Validation.DateNotInFuture(ErrorMessage = "Date cant be greater than today")]

        public DateTime? Date_of_Birth { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; } = string.Empty;

    }
}
