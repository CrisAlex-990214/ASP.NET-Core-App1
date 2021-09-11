using System.Collections.Generic;
using ASPNetCore1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ASPNetCoreApp1.Pages.Heroes
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHeroData _heroData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }

        public string Title { get; set; }
        public IEnumerable<Hero> Heroes { get; set; }
        public ListModel(IConfiguration configuration,
                         IHeroData heroData)
        {
            _configuration = configuration;
            _heroData = heroData;
        }
        public void OnGet()
        {
            Title = _configuration["AppTitle"];
            Heroes = _heroData.GetHeroes(SearchTerm);
        }
    }
}