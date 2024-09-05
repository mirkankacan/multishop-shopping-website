using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _CategoryHomeComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryHomeComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAllCategoriesAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
    }
}