//using Common.Dto;
//using Repository.Entities;
//using Service.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service
//{
//    public class FilterToHungarain
//    {
//        //מקבל מערך משימות וצריך לעבור עליהם 
//        //גודל המטריצה הוא מס העובדים על מס המשימות
//        //במטריצה נשבץ עובד עובד למשימה רק שעונה על התנאי
//        //שיודע את השפה ופנוי בתאריך
//        private readonly IService<TaskDto> Tservice;
//        private readonly IService<EmployeeDto> Eservice;
//        public FilterToHungarain(IService<TaskDto> service,IService<EmployeeDto> service1)
//        {
//                this.Tservice = service;
//            this.Eservice = service1;
//        }
//        public double[,] FilterMat() {
//            List<EmployeeDto> employees = Eservice.GetAll();
//            List<TaskDto> tasks = new List<TaskDto>();
//            int countEmp = employees.Count;
//            int countTask= tasks.Count;
            
//            double[,] mat;
//            if (countEmp == countTask)
//            {
//                mat = new double[countTask, countEmp];

//            }
//            else
//            { 
//            if(countEmp>countTask) {
//                mat=new double[countEmp,countEmp];
//                }
//            else
//                    mat = new double[countTask, countTask];
//            }
//            int i=-1,j=-1;
//            bool flag=false;
//            foreach (var item in employees)
//            { 
//                i++;
//                foreach (var itemT in tasks)
//                { 
//                    j++;
//                    foreach (var itemV in item.Vacations)
//                    {
//                        if (itemT.DeadLine >= itemV.FromDate && itemT.DeadLine <= itemV.ToDate.AddDays(6))
//                        {
//                            mat[i, j] = double.MinValue;
//                           // j++;
//                            flag = true;
//                            break;
//                        }

                                
//                                }
//                    if (!flag)
//                    {
//                        flag = false;
//                        double sum = 0;
//                        foreach (var itemL in item.LanguageForEmployee)
//                        {
                           
//                            if (itemT.LanguageId == itemL.LanguageId)
//                            {
//                                sum = ((itemL.Level * 0.2 + item.Experience * 0.4) / itemT.Level) * 10;
//                                mat[i, j ]= sum;
                                
//                            }

//                    }
//                    }
//                }



//            }

//            return mat;
//        }

//    }
//}
