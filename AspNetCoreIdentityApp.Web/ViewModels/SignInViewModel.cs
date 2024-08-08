﻿using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {
            
        }
        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [EmailAddress(ErrorMessage = "Email Formatı Yanlış.")]
        [Required(ErrorMessage = "Email  Alanı Boş Bırakılmaz.")]
        [Display(Name = "Email :")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}