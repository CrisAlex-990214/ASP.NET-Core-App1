using ASPNetCore1.Data;
using ASPNetCoreApp1.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreApp1.Data
{
    public class SqlHeroRepository : IHeroData
    {
        private readonly HeroDbContext db;

        public SqlHeroRepository(HeroDbContext db)
        {
            this.db = db;
        }

        public Hero Add(Hero hero)
        {
            db.Add(hero);

            return hero;
        }

        public int Commit()
        {
           return db.SaveChanges();
        }

        public Hero Delete(int id)
        {
            var hero = GetById(id);

            if(hero != null)
            {
                db.Remove(hero);
            }

            return hero;
        }

        public Hero GetById(int id)
        {
            return db.Heroes.Find(id);
        }

        public IEnumerable<Hero> GetHeroes(string name = null)
        {
            return name == null ? db.Heroes : 
                db.Heroes.Where(x => string.IsNullOrEmpty(x.Name) || 
                x.Name.Contains(name));
        }

        public void Update(Hero hero)
        {
            var entity = db.Heroes.Attach(hero);
            entity.State = EntityState.Modified;
        }

        public int GetCountOfHeroes()
        {
            return db.Heroes.Count();
        }
    }
}
