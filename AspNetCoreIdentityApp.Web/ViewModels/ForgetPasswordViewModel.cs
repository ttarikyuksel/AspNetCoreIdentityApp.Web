using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Email Formatı Yanlış.")]
        [Required(ErrorMessage = "Email  Alanı Boş Bırakılmaz.")]
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;
    }
}
