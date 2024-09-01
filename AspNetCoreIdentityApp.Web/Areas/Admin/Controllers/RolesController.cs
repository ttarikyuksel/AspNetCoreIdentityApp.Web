using AspNetCoreIdentityApp.Web.Areas.Admin.Models;
using AspNetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityApp.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentityApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RolesController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private readonly RoleManager<AppRole> _roleManager;

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name!
            }).ToListAsync();



            return View(roles);
        }


        public IActionResult RoleCreate()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel request)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = request.Name });

            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }
            TempData["SuccessMessage"] = "Rol Oluşturulmuştur.";
            return RedirectToAction(nameof(RolesController.Index));
        }

        public async Task<IActionResult> RoleUpdate(string id)
        {
            var roleUpdate = await _roleManager.FindByIdAsync(id);

            if (roleUpdate == null)
            {
                throw new Exception("Güncellenecek rol bulunamamıştır");
            }

            return View(new RoleUpdateViewModel() { Id=roleUpdate.Id,Name = roleUpdate!.Name!});
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel request)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(request.Id);

            if (roleToUpdate == null)
            {
                throw new Exception("Güncellenecek rol bulunamamıştır");
            }

            roleToUpdate.Name = request.Name;
            await _roleManager.UpdateAsync(roleToUpdate);

            ViewData["SuccessMessage"] = "Rol Bilgisi Güncellenmiştir.";
                
            return View();
        }

        public async Task<IActionResult> RoleDelete(string id)
        {
            var roleDelete = await _roleManager.FindByIdAsync(id);

            if(roleDelete == null)
            {
                throw new Exception("Silinecek rol bulunamamıştır");
            }

            var result = await _roleManager.DeleteAsync(roleDelete);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(x => x.Description).First());
            }
            TempData["SuccessMessage"] = "Rol Silinmiştir.";
            return RedirectToAction(nameof(RolesController.Index));
        }
    }
}
