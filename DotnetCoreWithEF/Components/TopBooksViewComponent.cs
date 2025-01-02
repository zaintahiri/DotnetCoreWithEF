using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreWithEF.Components
{
    public class TopBooksViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
