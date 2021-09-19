using ASPNetCoreApp1.Core;
using System.Collections.Generic;

namespace ASPNetCore1.Data
{
    public interface IHeroData
    {
        IEnumerable<Hero> GetHeroes(string name);
        Hero GetById(int id);
        Hero Add(Hero hero);
        void Update(Hero hero);
        Hero Delete(int id);
        int Commit();
        int GetCountOfHeroes();
    }


}
