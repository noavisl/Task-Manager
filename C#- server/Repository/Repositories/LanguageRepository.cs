using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class LanguageRepository : IRepository<Language>
    {

        private readonly IContext context;
        public LanguageRepository(IContext context)
        {
            this.context = context;
        }
        public Language Add(Language entity)
        {
            this.context.Languages.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(int id)
        {
            var l = this.context.Languages.FirstOrDefault(x => x.Id == id);
            this.context.Languages.Remove(l);
            this.context.save();
        }

        public Language Get(int id)
        {
            return this.context.Languages.FirstOrDefault(x => x.Id == id);
        }

        public List<Language> GetAll()
        {
            return this.context.Languages.ToList();
        }

        public Language Update(int id ,Language entity)
        {
            var l = context.Languages.FirstOrDefault(x => x.Id == id);
            l.Name = entity.Name;
            this.context.save();
            return l;
        }
    }
}
