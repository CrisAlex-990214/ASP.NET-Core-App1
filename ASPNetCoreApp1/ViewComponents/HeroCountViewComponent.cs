using ASPNetCore1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreApp1.ViewComponents
{
    public class HeroCountViewComponent : ViewComponent
    {
        private readonly IHeroData heroData;

        public HeroCountViewComponent(IHeroData heroData)
        {
            this.heroData = heroData;
        }

        public IViewComponentResult Invoke()
        {
            var count = heroData.GetCountOfHeroes();
            return View(count);
        }
    }
}
