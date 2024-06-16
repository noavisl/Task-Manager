// See https://aka.ms/new-console-template for more information
using DataContext;
using HungaryProject;

Console.WriteLine("Hello, World!");
Db myDb = new Db();
FilterToHungarain fh = new FilterToHungarain(myDb);

double[,] mat = fh.FilterMat();
for (int i = 0; i < mat.Length; i++)
{
    for (int j = 0; j < mat.Length; j++)
        Console.WriteLine(mat[i, j]);
}
Console.WriteLine();