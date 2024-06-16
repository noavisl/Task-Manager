using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace HungaryProject
{
    public class HungarianAlgoritem
    {

        //FilterToHungarain filterToHungarain;
        bool[] e;
        public HungarianAlgoritem(bool[] bools)
        {
            int s = bools.Length;
            e = new bool[s];
            e = bools;
        }
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
        int size;
        int count;
        double[,] temp;

        public int[] RunHungarianAlgorithm(double[,] matrix)
        {

            size = matrix.GetLength(0);
            mat = new double[size, size];
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            taskForEmployee = new int[size];
            //הכפלת המטריצה במינוס אחד כדי לגרום לערך הגדול ביותר להיות הערך הנמוך ביותר 
            //וכך האלגוריתם יעבוד נכון
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    mat[i, j] = matrix[i, j] * -1;

            //return mat;
            return ReduceMinRow();
        }

        public int[] ReduceMinRow()
        {
            //הפחתת האלמנט המינימלי בכל שורה
            for (int i = 0; i < size; i++)
            {
                double min = double.MaxValue;
                //נמצא את  המינימום בכל שורה
                for (int j = 0; j < size; j++)
                {
                    min = Math.Min(min, mat[i, j]);
                }
                //נפחית את המינינום שמצאנו מכל תא בשורה
                for (int j = 0; j < size; j++)
                {
                    mat[i, j] -= min;
                }
                //שלחית לפונקצית בדיקת שיבוץ חד חד ערכי
            }
            IsOptimalPlacement();
            if (count != size)//האם כל המשימות משובצות
                              //return mat;//השיבוץ עבד, כעת יש לשבץ לעובד עצמו את המשימה
                return ReduceMinCol();

            return taskForEmployee;
        }

        public int[] ReduceMinCol()
        {
            temp = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    temp[i, j] = mat[i, j];
            }
            //הפחתת האלמנט המינימלי בכל עמודה
            for (int i = 0; i < size; i++)
            {
                double min = double.MaxValue;
                //נמצא את  המינימום בכל עמודה
                for (int j = 0; j < size; j++)
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
            IsOptimalPlacement();
            if (count == size)
                //return mat ;
                return UnAsigmentRow();

            return taskForEmployee;

        }

        //סימון השורות שללא שיבוץ
        public int[] UnAsigmentRow()
        {
            unAsigmentRow = new int[taskForEmployee.Length];// מערך לשמירת השורות- העובדים שללא שיבוץ
            for (int i = 0; i < taskForEmployee.Length; i++)
            {
                if (taskForEmployee[i] == -1)
                    unAsigmentRow[m++] = i;//m-מספר השורות שללא שיבוץ
            }
            return UnAsigmentCol();
        }
        // סימון עמודות שלהן אפסים בשורות מסומנות
        public int[] UnAsigmentCol()
        {      ///באיזה גודל צריך להגדיר את המערך יכול להיות שורה שלה יש שתי עמודות...????
            unAsigmentCol = new int[size];//מערך ששומר את העמודות שלהן יש 0 בשורות המסומנות
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (mat[unAsigmentRow[i], j] == 0)
                        unAsigmentCol[k++] = j;// סימון עמודות שלהן אפסים בשורות מסומנות
                }
            }
            return AsigmentCol();
        }
        //סימון שורות עם שיבוץ בעמודות מסומנות
        public int[] AsigmentCol()
        {
            asigmentRow = new int[size];
            int f = 0;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < size; j++)
                {    //בדיקה האם השורה בעמודה המסומנת = 0  - יש לה שיבוץ
                     //והאם שורה זו לא מסומנת כבר במערך של השורות ללא שיבוץ
                    if (mat[j, unAsigmentCol[i]] == 0 && !unAsigmentRow.Contains(j))
                        asigmentRow[f++] = j;// סימון שורות עם שיבוץ בעמודות מסומנות
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    if (temp[i, j] != mat[i, j])
                        ReduceMinCol();
            }
            return UnasigmentRowAndCol();
        }

        //העברת קווים על העמודות המסומנות והשורות הלא מסומנות
        public int[] UnasigmentRowAndCol()
        {
            yellowMat = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!unAsigmentRow.Contains(i) && !asigmentRow.Contains(i) && !unAsigmentCol.Contains(j))
                        yellowMat[i, j] = true;
                }
            }
            return FindMinMat();
        }

        //מציאת האלמנט המינמלי בכל המטריצה
        public int[] FindMinMat()
        {
            min = double.MaxValue;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (!yellowMat[i, j] && mat[i, j] < min)
                        min = mat[i, j];
                }
            }
            return End();
        }

        public int[] End()
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (!unAsigmentRow.Contains(i) && !asigmentRow.Contains(i) && unAsigmentCol.Contains(j))
                        mat[i, j] += min;
                    else if (!yellowMat[i, j])
                        mat[i, j] -= min;
                }
            }
            return IsOptimalPlacement();
        }

        // פונקצית בדיקת שיבוץ חד חד ערכי
        public int[] IsOptimalPlacement()
        {
            bool[] flag = new bool[size];
            taskForEmployee = new int[size];
            Array.Fill(taskForEmployee, -1);
            //bool again = true;
            count = 0;
            for (int i = 0; i < size; i++)//עובד
            {
                for (int j = 0; j < size; j++)//משימה
                {
                    Console.WriteLine(mat[i, j]);
                    if (mat[i, j] == 0)
                        if (!flag[j] && e[i])//אם המשימה עדיין לא שובצה
                        {
                            flag[j] = true;//לציין שהמשימה תפוסה
                            //again = false;
                            taskForEmployee[i] = j;//לכל עובד במערך מיושם משימה
                            count++;//כמות המשימות המיושמות לבדיקה בהמשך האם יש שיבוץ לכל המשימות
                            break;
                        }
                }
            }
            return taskForEmployee;


        }


    }
}
