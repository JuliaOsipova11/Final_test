// Задача:
// Написать программу, которая из имеющегося массива строк формирует новый массив из строк,
// длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры,
// либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями,
// лучше обойтись исключительно массивами.

// Примеры:

// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

int SearchArraySize(string[] Array, int lengthElement)
{
    string[] validArray = new string[Array.Length];
    int count = 0;
    int validSizeArray = Array.Length;
    for (int i = 0; i < Array.Length; i++)
    {
        string currentElement = Array[i];
        if (currentElement.Length > lengthElement)
            count++;
    }
    validSizeArray -= count;
    if (validSizeArray == 0) validSizeArray++;
    return validSizeArray;
}
 
string[] GetLimitLengthElementArray(string[] Array, int lengthElement, int sizeArray)
{
    string[] resultArray = new string[sizeArray];
    string element = string.Empty;
    int count = 0;
    for (int i = 0; i < resultArray.Length; i++)
    {
        for (int j = count; j < Array.Length; j++)
        {
            string currentElement = Array[j];
            if (currentElement.Length <= lengthElement)
            {
                element = currentElement;
                count = j;
                break;
            }
            else count += j;
        }
        resultArray[i] = element;
        count++;
    }
    return resultArray;
}

void PrintArray(string[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length - 1; i++)
    {
        Console.Write($"{array[i]},");
    }
    Console.Write($"{array[array.Length - 1]}]");
}

string[] UserEntersArray()
{
    Console.Write("Input the number of strings ");
    int countString = Convert.ToInt32(Console.ReadLine());
    string[] newArray = new string[countString];
    if (countString <= 0) Console.WriteLine("Try again!");
    else
    {
        for (int i = 0; i < countString; i++)
        {
            Console.Write($"Input string №{i + 1}: ");
            newArray[i] += Console.ReadLine();
        }
    }
    return newArray;
}

int lengthString = 3; 
string[] userArray = UserEntersArray();
Console.WriteLine($"Ниже [введенные Вами строки] и [строки, длина которых меньше либо равна {lengthString} символам]:");
PrintArray(userArray);
Console.Write("->");
int validSizeArray = SearchArraySize(userArray, lengthString);
PrintArray(GetLimitLengthElementArray(userArray, lengthString, validSizeArray));