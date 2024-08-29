using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Rol İsmi Alanı Boş Bırakılamaz.")]
        [Display(Name = "Rol İsmi : ")]
        public string Name { get; set; }
    }
}
