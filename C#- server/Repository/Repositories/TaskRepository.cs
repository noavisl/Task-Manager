using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TaskRepository : IRepository<Entities.Task>
    {

        private readonly IContext context;
        public TaskRepository(IContext context)
        {
            this.context = context;
        }

        public Entities.Task Add(Entities.Task entity)
        {
            this.context.Tasks.Add(entity);
            this.context.save();
            //החזרת האובייקט שהתווסף ל DB
            return entity;
        }

        public void Delete(int id)
        {
            var t = this.context.Tasks.FirstOrDefault(x => x.Id == id);
            this.context.Tasks.Remove(t);
            this.context.save();
        }

        public Entities.Task Get(int id)
        {
            return this.context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public List<Entities.Task> GetAll()
        {
            return this.context.Tasks.ToList();
        }

        public Entities.Task Update(int id, Entities.Task entity) { 
            var t=context.Tasks.FirstOrDefault(x => x.Id == id);
            t.Title= entity.Title;  
            t.Description= entity.Description;
            t.LanguageId = entity.LanguageId;    
            t.DeadLine= entity.DeadLine;    
            t.Status = entity.Status;
            t.Level= entity.Level;  
            t.EmployeeId= entity.EmployeeId;    
            this.context.save();
            return t;
        }

    }
}
