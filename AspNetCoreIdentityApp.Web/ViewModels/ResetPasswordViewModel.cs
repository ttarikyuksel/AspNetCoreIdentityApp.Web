using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılmaz.")]
        [Display(Name = "Yeni Şifre :")]
        public string Password { get; set; } = null!;



        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre Aynı Değildir.")]
        [Required(ErrorMessage = "Şifre Tekrar Alanı Boş Bırakılmaz.")]
        [Display(Name = "Yeni Şifre Tekrar :")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
