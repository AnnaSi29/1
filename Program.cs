// Задача 1. Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

Console.WriteLine("Задача 1. Введите кол-во строк: ");
int n = int.Parse(Console.ReadLine());
Console.WriteLine("Введите кол-во столбцов: ");
int m = int.Parse(Console.ReadLine());
Console.WriteLine($"\nВывод массива: ");
int [,] array = GetArray (m, n, 0, 100); 
PrintArray(array);

Console.WriteLine($"\nОтсортированный массив по убыванию элементов в строках: ");
SotrArray(array);
PrintArray(array);

int [,] GetArray (int m, int n, int minValue, int maxValue) 
{
    int [,] result = new int [m,n];
    for (int i = 0; i< m; i++)
    {
        for (int j = 0; j< n; j++)
        {
            result [i,j] = new Random().Next(minValue, maxValue);
        }
    }
    return result;
}

void PrintArray(int [,] inArray) 
{
    for (int i = 0; i< inArray.GetLength(0); i++)
    {
        for (int j = 0; j< inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i,j]} ");
        }
        Console.WriteLine();
    }
}

 void SotrArray(int[,] array) 
 {
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      for (int k = 0; k < array.GetLength(1) - 1; k++)
      {
        if (array[i, k] < array[i, k + 1])
        {
          int result = array[i, k + 1];
          array[i, k + 1] = array[i, k];
          array[i, k] = result;
        }
      }
    }
  }
  return;
}


// Задача 2. Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

void Print(int[,] arr)
{
    int row_size = arr.GetLength(0);
    int column_size = arr.GetLength(1);

    for (int i = 0; i < row_size; i++)
    {
        for (int j = 0; j < column_size; j++)
            Console.Write($" {arr[i, j],3} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MassNums(int row, int column, int from, int to)
{
    int[,] arr = new int[row, column];

    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
            arr[i, j] = new Random().Next(from, to);
    return arr;
}

void RowSmallAmount(int[,] arr)
{
    int row_size = arr.GetLength(0);
    int column_size = arr.GetLength(1);
    int amount = 1000;
    int num;
    int smallest = 0;

    for (int i = 0; i < row_size; i++)
    {   
        num = 0;
        for (int j = 0; j < column_size; j++)
            num += arr[i, j];
            Console.Write($"{num, 4} ");            

        if (amount > num)
        {
            amount = num;
            smallest = i;
        }
    }
    Console.WriteLine();
    Console.Write($"Строка с наименьшей суммой - {smallest + 1}");
}

Console.Write("Задача 2. Введите кол-во строк: ");
int row = int.Parse(Console.ReadLine());
Console.Write("Введите кол-во столбцов: ");
int column = int.Parse(Console.ReadLine());

int[,] arr_1 = MassNums(row, column, 0, 10);
Print(arr_1);

RowSmallAmount(arr_1);

// Задача 3. Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

Console.WriteLine($"\nЗадача 3. Введите размеры матриц и диапазон случайных значений:");
int m = InputNumbers("Введите число строк 1-й матрицы: ");
int n = InputNumbers("Введите число столбцов 1-й матрицы (и строк 2-й): ");
int p = InputNumbers("Введите число столбцов 2-й матрицы: ");
int range = InputNumbers("Введите диапазон случайных чисел: от 1 до ");

int[,] firstMartrix = new int[m, n];
CreateArray(firstMartrix);
Console.WriteLine($"\nПервая матрица:");
WriteArray(firstMartrix);

int[,] secomdMartrix = new int[n, p];
CreateArray(secomdMartrix);
Console.WriteLine($"\nВторая матрица:");
WriteArray(secomdMartrix);

int[,] resultMatrix = new int[m,p];

MultiplyMatrix(firstMartrix, secomdMartrix, resultMatrix);
Console.WriteLine($"\nПроизведение первой и второй матриц:");
WriteArray(resultMatrix);

void MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix, int[,] resultMatrix)
{
  for (int i = 0; i < resultMatrix.GetLength(0); i++)
  {
    for (int j = 0; j < resultMatrix.GetLength(1); j++)
    {
      int sum = 0;
      for (int k = 0; k < firstMartrix.GetLength(1); k++)
      {
        sum += firstMartrix[i,k] * secomdMartrix[k,j];
      }
      resultMatrix[i,j] = sum;
    }
  }
}

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

void CreateArray(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      array[i, j] = new Random().Next(range);
    }
  }
}

void WriteArray (int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      Console.Write(array[i,j] + " ");
    }
    Console.WriteLine();
  }
}


// Задача 4. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

Console.Clear();
Console.WriteLine($"\nЗадача 4. Введите размер массива X x Y x Z:");
int x = InputNumbers("Введите X: ");
int y = InputNumbers("Введите Y: ");
int z = InputNumbers("Введите Z: ");
Console.WriteLine($"");

int[,,] array3D = new int[x, y, z];
CreateArray(array3D);
WriteArray(array3D);

int InputNumbers(string input)
{
    Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    return output;
}

void WriteArray(int[,,] array3D)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            Console.Write($"X({i}) Y({j}) ");
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"Z({k})={array3D[i, j, k]}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

void CreateArray(int[,,] array3D)
{
    int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10, 100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                    temp[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temp[i];
                }
                number = temp[i];
            }
        }
    }
    int count = 0;
    for (int x = 0; x < array3D.GetLength(0); x++)
    {
        for (int y = 0; y < array3D.GetLength(1); y++)
        {
            for (int z = 0; z < array3D.GetLength(2); z++)
            {
                array3D[x, y, z] = temp[count];
                count++;
            }
        }
    }
}    


// Задача 5. Напишите программу, которая заполнит спирально массив 4 на 4.

int arraySizeX = 4;
int arraySizeY = 4;
int[,] testArray = new int[arraySizeX, arraySizeY];

FillArrayInSpiral(testArray);
PrintDoubleArray(testArray);

void FillArrayInSpiral(int[,] array)
{

    int posI = 0;
    int posJ = 0;
    bool isItNewCircle = true;

    for (int i = 0; i < array.Length; i++)
    {
        array[posI, posJ] = i + 1;

        if (posJ + 1 < array.GetLength(1) && isItNewCircle && array[posI, posJ + 1] == 0)
        {
            posJ++;
            continue;
        }
        else
        {
            isItNewCircle = false;
        }

        if (posI + 1 < array.GetLength(0) && array[posI + 1, posJ] == 0)
        {
            posI++;
            continue;
        }

        if (posJ - 1 >= 0 && array[posI, posJ - 1] == 0)
        {
            posJ--;
            continue;
        }

        if (posI - 1 >= 0 && array[posI-1, posJ] == 0)
        {
            posI--;
            continue;
        }
        else
        {
            posJ++;
            isItNewCircle = true;
        }
    }
}

void PrintDoubleArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
