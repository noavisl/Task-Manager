using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HungarianAlgoritem
    {
        public double[,] mat;
        int[] taskForEmployee;//השמת משימה לעובד
        int[] unAsigmentRow;//סימון השורות שללא שיבוץ
        int[] unAsigmentCol;// סימון עמודות שלהן אפסים בשורות מסומנות
        int[] asigmentRow;//סימון שורות עם שיבוץ בעמודות מסומנות
        bool[,] yellowMat;//העברת קווים על העמודות המסומנות והשורות הלא מסומנות
        double min = 0;//המינמלי בכל המטריצה
        int m = 0;//לא לדרוס!
        int k = 0;//לא לדרוס!!
        int r;
        int c;

        public HungarianAlgoritem(double[,] matrix)
        {

            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            taskForEmployee = new int[r];
            //הכפלת המטריצה במינוס אחד כדי לגרום לערך הגדול ביותר להיות הערך הנמוך ביותר 
            //וכך האלגוריתם יעבוד נכון
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    matrix[i, j] = matrix[i, j] * -1;

            //הרחבת המטריצה למרובעת 
            if (r > c)
            {
                mat = new double[r, c + (c - r)];
                for (int i = 0; i < r; i++)
                    for (int j = 0; j < c; j++)
                        mat[i, j] = matrix[i, j];

                for (int i = 0; i < r; i++)
                    for (int j = c; j < c + (c - r); j++)
                        mat[i, j] = double.MaxValue;
            }
            if (r < c)
            {
                mat = new double[r + (r - c), c];
                for (int i = 0; i < r; i++)
                    for (int j = 0; j < c; j++)
                        mat[i, j] = matrix[i, j];

                for (int i = r; i < r + (r - c); i++)
                    for (int j = 0; j < c; j++)
                        mat[i, j] = double.MaxValue;
            }
        }

        public void ReduceMinRow()
        {
            //הפחתת האלמנט המינימלי בכל שורה
            for (int i = 0; i < r; i++)
            {
                double min = double.MaxValue;
                //נמצא את  המינימום בכל שורה
                for (int j = 0; j < c; j++)
                {
                    min = Math.Min(min, mat[i, j]);
                }
                //נפחית את המינינום שמצאנו מכל תא בשורה
                for (int j = 0; j < c; j++)
                {
                    mat[i, j] -= min;
                }
                //שלחית לפונקצית בדיקת שיבוץ חד חד ערכי
            }
            if (IsOptimalPlacement() != c)//האם כל המשימות משובצות
                //return mat;//השיבוץ עבד, כעת יש לשבץ לעובד עצמו את המשימה
                ReduceMinCol();
        }

        public void ReduceMinCol()
        {
            //הפחתת האלמנט המינימלי בכל עמודה
            for (int i = 0; i < c; i++)
            {
                double min = double.MaxValue;
                //נמצא את  המינימום בכל עמודה
                for (int j = 0; j < r; j++)
                {
                    min = Math.Min(min, mat[i, j]);
                }
                //נפחית את המינינום שמצאנו מכל תא בעמודה
                for (int j = 0; j < r; j++)
                {
                    mat[i, j] -= min;
                }
                //שלחית לפונקצית בדיקת שיבוץ חד חד ערכי
            }
            if (IsOptimalPlacement() == c)
                //return mat ;
                UnAsigmentRow();
            
        }

        //סימון השורות שללא שיבוץ
        public void UnAsigmentRow()
        {
            unAsigmentRow = new int[taskForEmployee.Length];// מערך לשמירת השורות- העובדים שללא שיבוץ
            for (int i = 0; i < taskForEmployee.Length; i++)
            {
                if (taskForEmployee[i] == 0)
                    unAsigmentRow[m++] = i;//m-מספר השורות שללא שיבוץ
            }
            UnAsigmentCol();
        }
        // סימון עמודות שלהן אפסים בשורות מסומנות
        public void UnAsigmentCol()
        {      ///באיזה גודל צריך להגדיר את המערך יכול להיות שורה שלה יש שתי עמודות...????
            unAsigmentCol = new int[c];//מערך ששומר את העמודות שלהן יש 0 בשורות המסומנות
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (mat[unAsigmentRow[i], j] == 0)
                        unAsigmentCol[k++] = j;// סימון עמודות שלהן אפסים בשורות מסומנות
                }
            }
            AsigmentCol();
        }
        //סימון שורות עם שיבוץ בעמודות מסומנות
        public void AsigmentCol()
        {
            asigmentRow = new int[r];
            int f = 0;
            for (int i = 0; i < k; i++) {
                for (int j = 0; j < r; j++)
                {    //בדיקה האם השורה בעמודה המסומנת = 0  - יש לה שיבוץ
                     //והאם שורה זו לא מסומנת כבר במערך של השורות ללא שיבוץ
                    if (mat[j, unAsigmentCol[i]] == 0 && !unAsigmentRow.Contains(j))
                        asigmentRow[f++] = j;// סימון שורות עם שיבוץ בעמודות מסומנות
                }
            }
        }

        //העברת קווים על העמודות המסומנות והשורות הלא מסומנות
        public void UnasigmentRowAndCol()
        {
            for(int i=0; i<r; i++) { 
              for(int j=0; j<c; j++)
                {
                    if (!unAsigmentRow.Contains(i) && !asigmentRow.Contains(i) && !unAsigmentCol.Contains(j))
                        yellowMat[i, j] = true;   
                }    
            }
        }

        //מציאת האלמנט המינמלי בכל המטריצה
        public void FindMinMat()
        {
             min = double.MaxValue;
            for(int i=0; i<r;i++) { 
               for(int j= 0; j<c; j++)
                {
                    if (!yellowMat[i, j] && mat[i,j]<min)
                        min= mat[i,j];        
                } 
            }
        }

        public void End()
        {
            for(int i=0; i<r; i++)
            {
                for(int j=0; j<c; j++)
                {
                   if (!unAsigmentRow.Contains(i) && !asigmentRow.Contains(i) && unAsigmentCol.Contains(j))
                        mat[i,j]+=min;
                   else if (!yellowMat[i,j])
                        mat[i,j]-=min;  
                }
            }
        } 

        // פונקצית בדיקת שיבוץ חד חד ערכי
        public int IsOptimalPlacement()
        {
            bool[] flag = new bool[c];
            //bool again = true;
            int count = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 1; j < c+1; j++)
                {
                    if (mat[i, j-1] == 0)
                        if (!flag[i])
                        {
                            flag[i] = true;//לציין שהמשימה תפוסה
                            //again = false;
                            taskForEmployee[i] = j;//לכל עובד במערך מיושם משימה
                            count++;//כמות המשימות המיושמות לבדיקה בהמשך האם יש שיבוץ לכל המשימות
                            break;
                        }
                }
            }
            return count ;
        }

    } 
   }
