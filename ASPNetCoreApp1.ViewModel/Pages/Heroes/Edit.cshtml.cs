using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCore1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Type = ASPNetCore1.Data.Type;

namespace ASPNetCoreApp1.Pages.Heroes
{
    public class EditModel : PageModel
    {
        private readonly IHeroData _heroData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Hero Hero{ get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }

        public EditModel(IHeroData heroData, IHtmlHelper htmlHelper)
        {
            _heroData = heroData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? heroId)
        {
            Types = _htmlHelper.GetEnumSelectList<Type>();
            
            if(heroId.HasValue)
            {
                Hero = _heroData.GetById(heroId.Value);
            }
            else
            {
                Hero = new Hero();
            }

            if (Hero == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Types = _htmlHelper.GetEnumSelectList<Type>();
                return Page();
            }

            if (Hero.Id == 0)
            {
                _heroData.Add(Hero);
            }
            else
            {
                _heroData.Update(Hero);
            }

            _heroData.Commit();
            TempData["Message"] = "Hero saved!";

            return RedirectToPage("./List", new { heroId = Hero.Id });
        }
    }
}
