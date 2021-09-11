using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ASPNetCore1.Data
{
    public interface IHeroData
    {
        IEnumerable<Hero> GetHeroes(string name);
        Hero GetById(int id);
        Hero Add(Hero hero);
        void Update(Hero hero);
        int Commit();
    }
    public class Hero
    {
        public int Id { get; set; }
        
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required]
        public Type Type { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
    public enum Type
    {
        DC, Marvel, StarWars
    }

    public class HeroRepository : IHeroData
    {
        private readonly List<Hero> Heroes;
        public HeroRepository()
        {
            Heroes = new List<Hero>
            {
                new Hero { Id = 1, Name = "Iron Man", Type = Type.Marvel, CreationDate = new DateTime(1986,02,24) },
                new Hero { Id = 3, Name = "Hulk", Type = Type.Marvel, CreationDate = new DateTime(1958,11,23) },
                new Hero { Id = 2, Name = "Wonder Woman", Type = Type.DC, CreationDate = new DateTime(1989,06,03) },
                new Hero { Id = 4, Name = "Darth Vader", Type = Type.StarWars, CreationDate = new DateTime(1954,10,11) }
            }
            .OrderBy(x => x.Id)
            .ToList();
        }

        public IEnumerable<Hero> GetHeroes(string name = null)
        {
            return string.IsNullOrEmpty(name) ? 
                Heroes : Heroes.Where(x => string.IsNullOrEmpty(x.Name) || x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Hero GetById(int id)
        {
            return Heroes.SingleOrDefault(x => x.Id == id);
        }

        public Hero Add(Hero hero)
        {
            Heroes.Add(hero);
            hero.Id = Heroes.Max(x => x.Id) + 1;

            return hero;
        }

        public void Update(Hero hero)
        {
            var heroData = Heroes.SingleOrDefault(x => x.Id == hero.Id);

            if(heroData != null)
            {
                heroData.Name = hero.Name;
                heroData.Type = hero.Type;
                heroData.CreationDate = hero.CreationDate;
            }
        }

        public int Commit()
        {
            return 0;
        }
    }


}
