using System.Collections.Generic;
using ASPNetCore1.Data;
using ASPNetCoreApp1.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASPNetCoreApp1.Pages.Heroes
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHeroData _heroData;
        private readonly ILogger<ListModel> logger;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }

        public string Title { get; set; }
        public IEnumerable<Hero> Heroes { get; set; }
        public ListModel(IConfiguration configuration,
                         IHeroData heroData, ILogger<ListModel> logger)
        {
            _configuration = configuration;
            _heroData = heroData;
            this.logger = logger;
        }
        public void OnGet()
        {
            logger.LogInformation("Fetching heroes");

            Title = _configuration["AppTitle"];
            Heroes = _heroData.GetHeroes(SearchTerm);
        }
    }
}