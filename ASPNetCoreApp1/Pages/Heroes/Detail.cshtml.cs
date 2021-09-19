using ASPNetCore1.Data;
using ASPNetCoreApp1.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreApp1.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IHeroData _heroData;
        public Hero Hero { get; set; }
        [BindProperty(SupportsGet = true)]
        public int heroId { get; set; }
        public DetailModel(IHeroData heroData)
        {
            _heroData = heroData;
        }
        public IActionResult OnGet(int heroId)
        {
            Hero = _heroData.GetById(heroId);

            if (Hero == null) 
                return RedirectToPage("./NotFound");
            else 
                return Page(); 
        }

        public IActionResult OnPost()
        {
            var hero = _heroData.Delete(heroId);

            if(hero != null)    
            {
                _heroData.Commit();
                TempData["Message"] = $"{ hero.Name } deleted!";
                return RedirectToPage("./List");
            }

            return RedirectToPage("./NotFound");
        }
    }
}