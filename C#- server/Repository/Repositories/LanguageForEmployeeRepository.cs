using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class LanguageForEmployeeRepository:IRepository<LanguageForEmployee>
    {
        private readonly IContext context;
        public LanguageForEmployeeRepository(IContext context)
        {
            this.context = context;
        }
        public LanguageForEmployee Add(LanguageForEmployee entity)
        {
            this.context.LanguageForEmployees.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(int id)
        {
            var e = this.context.LanguageForEmployees.FirstOrDefault(x => x.Id == id);
            this.context.LanguageForEmployees.Remove(e);
            this.context.save();
        }

        public LanguageForEmployee Get(int id)
        {
            return this.context.LanguageForEmployees.FirstOrDefault(x => x.Id == id);
        }

        public List<LanguageForEmployee> GetAll()
        {
            return this.context.LanguageForEmployees.ToList();
        }

        public LanguageForEmployee Update(int id, LanguageForEmployee entity)
        {
            var e = context.LanguageForEmployees.FirstOrDefault(x => x.Id == id);
            e.Level = entity.Level;
            e.IdEmployee = entity.IdEmployee;
            e.LanguageId= entity.LanguageId;

            this.context.save();
            return e;
        }
    }
}
