using CoffeeCatPlatform.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Repositories;
using Repositories.Impl;

namespace CoffeeCatPlatform.Pages.CatManagement
{
    public class EditCatModel : ManagerAuthModel
    {
        private readonly IRepositoryBase<Cat> _catRepository;

        public EditCatModel(CatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        [BindProperty]
        public Cat Cat { get; set; }

        public IActionResult OnGet(int? id)
        {
            var temp = _catRepository.GetAll().FirstOrDefault(c => c.CatId == id);

            if (temp == null)
            {
                TempData["ErrorMessage"] = "Cat not found.";
                return RedirectToPage("/ManagerPages/CatManagement");
            }
            Cat = temp;

            return Page();
        }

        public IActionResult OnPostEdit(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Cat.Birthday > DateTime.Today)
            {
                TempData["CatEditErrorMessage"] = "Cat Birthday cannot further than current day.";
                return Page();
            }
            if (id != Cat.CatId)
            {
                TempData["CatEditErrorMessage"] = "Changing CatId is not allowed.";
                return Page();
            }
            _catRepository.Update(Cat);

            TempData["SuccessMessage"] = "Cat updated successfully.";
            return RedirectToPage("/ManagerPages/CatManagement");
        }

        public IActionResult OnPostDelete(int id)
        {
            var catToDelete = _catRepository.GetAll().FirstOrDefault(c => c.CatId == Cat.CatId);

            if (catToDelete == null)
            {
                TempData["ErrorMessage"] = "Cat not found.";
                return RedirectToPage("/ManagerPages/CatManagement");
            }

            catToDelete.HealthStatus = 0;

            _catRepository.Update(catToDelete);

            TempData["SuccessMessage"] = "Cat deleted successfully.";
            return RedirectToPage("/ManagerPages/CatManagement");
        }
    }
}
