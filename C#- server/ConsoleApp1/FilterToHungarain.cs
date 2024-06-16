using Common.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungaryProject
{


    public class FilterToHungarain
    {
        //מקבל מערך משימות וצריך לעבור עליהם 
        //גודל המטריצה הוא מס העובדים על מס המשימות
        //במטריצה נשבץ עובד עובד למשימה רק שעונה על התנאי
        //שיודע את השפה ופנוי בתאריך
        //  private readonly IService<TaskDto> Tservice;
        // private readonly IService<EmployeeDto> Eservice;
        private readonly IContext _context;
        public FilterToHungarain(IContext db)
        {
            this._context = db;
            //    //   this.Tservice = service;
            //  this.Eservice = service1;
        }
        public double[,] FilterMat()
        {
            List<Employee> employees = _context.Employees.Include(e => e.LanguageForEmployees).Include(e => e.Vacations) .ToList();
            List<Repository.Entities.Task> tasks = _context.Tasks.ToList();
            int countEmp = employees.Count;
            int countTask = tasks.Count;

            double[,] mat;
            if (countEmp == countTask)
            {
                mat = new double[countTask, countEmp];

            }
            else
            {
                if (countEmp > countTask)
                {
                    mat = new double[countEmp, countEmp];
                }
                else
                    mat = new double[countTask, countTask];
            }

            int i, j,size=Math.Max(countTask, countTask);
            //אתחול המטריצה בערכים מינימלים (בהשמך זה יוכפל במינוס אחד וכך נקבל את שהוא מקסימלי

            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                    mat[i, j] = double.MinValue;

            i = -1;
            j = -1;
            bool flag = false;
            foreach (var item in employees)
            {
                 i++;
                tasks = _context.Tasks.ToList();
                foreach (var itemT in tasks)
                {
                    if (itemT.EmployeeId != 0)
                        break;
                    j++;
                    foreach (var itemV in item.Vacations)
                    {
                        if (itemT.DeadLine >= itemV.FromDate && itemT.DeadLine <= itemV.ToDate.AddDays(6))
                        {
                            mat[i, j] = double.MinValue;
                            // j++;
                            flag = true;
                            break;
                        }


                    }
                    if (!flag)
                    {
                        flag = false;
                        double sum =double.MinValue ;
                        foreach (var itemL in item.LanguageForEmployees)
                        {

                            if (itemT.LanguageId == itemL.LanguageId)
                            {
                                sum = ((itemL.Level * 0.2 + item.Experience * 0.4) / itemT.Level) * 10;
                                //mat[i, j] = sum;
                                break;

                            }

                        }
                          mat[i, j] = sum;//ניקוד השפה שנבחרה
                          j = 0;
                    }
                }



            }

            return mat;
        }

    }
}