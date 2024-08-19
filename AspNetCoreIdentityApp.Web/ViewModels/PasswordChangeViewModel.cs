using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Eski Şifre Alanı Boş Bırakılmaz.")]
        [Display(Name = "Eski Şifre :")]
        [MinLength(6,ErrorMessage ="Şifreniz en az 6 karakter olabilir.")]
        public string PasswordOld { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni Şifre Alanı Boş Bırakılmaz.")]
        [Display(Name = "Yeni Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
        public string PasswordNew { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNew), ErrorMessage = "Şifre Aynı Değildir.")]
        [Required(ErrorMessage = "Yeni Şifre Tekrar Alanı Boş Bırakılmaz.")]
        [Display(Name = "Yeni Şifre Tekrar :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
        public string PasswordNewConfirm { get; set; }
    }
}
