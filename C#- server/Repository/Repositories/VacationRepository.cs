using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class VacationRepository:IRepository<Vacation>
    {
        private readonly IContext context;
        public VacationRepository(IContext context)
        {
            this.context = context;
        }
        public Vacation Add(Vacation entity)
        {
            this.context.Vacations.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(int id)
        {
            var e = this.context.Vacations.FirstOrDefault(x => x.Id == id);
            this.context.Vacations.Remove(e);
            this.context.save();
        }

        public Vacation Get(int id)
        {
            return this.context.Vacations.FirstOrDefault(x => x.Id == id);
        }

        public List<Vacation> GetAll()
        {
            return this.context.Vacations.ToList();
        }

        public Vacation Update(int id, Vacation entity)
        {
            var v = context.Vacations.FirstOrDefault(x => x.Id == id);
            v.EmployeeId = entity.EmployeeId;
            v.FromDate = entity.FromDate;
            v.ToDate = entity.ToDate;

            this.context.save();
            return v;
        }
    }
}
