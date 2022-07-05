int GetPositiveNumber(string msg)
{
    while (true)
    {
        Console.WriteLine(msg);
        string ValueFromConsole = Console.ReadLine();
        if (int.TryParse(ValueFromConsole, out int number) && number > 0)
            return number;
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Это не число или число меньше 1");
            Console.ResetColor();
        }
    }
}
void PrintArray(string[] array)
{
    Console.WriteLine();
    Console.Write("Исходный массив: ");
    foreach (var item in array)
        Console.Write($"{item}  ");
}
void NewArray(string[] array)
{
    string[] arrayNew = array.Clone() as string[];
    Console.WriteLine();
    Console.Write("Новый массив: ");
    foreach (var item in arrayNew)
    {
        if (item.Length < 4)
        {
            arrayNew = arrayNew.Where(e => e != item).ToArray();
            Console.Write($"{item}  ");
        }
    }
}
string[] GetArray(string[] arrayGiven, ref string[] arrayConsole)
{
    while (true)
    {
        Console.WriteLine("Ввести данные с клавиатуры (1) или из программы (2)?");
        string ValueFromConsole = Console.ReadLine();
        if (ValueFromConsole == "1")
        {
            int q= 0;
            int N = GetPositiveNumber("Сколько строк будете вводить?");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите {i+1}-ю строку");
                string StringFromConsole = Console.ReadLine();
                Array.Resize(ref arrayConsole, arrayConsole.Length + 1);
                arrayConsole[arrayConsole.Length - 1] = StringFromConsole;               
            }
            return arrayConsole;
        }
        if (ValueFromConsole == "2")
        {
            return arrayGiven;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Требуется ответ '1' или '2'");
            Console.ResetColor();
        }
    } 
}
void ChooseArray(string[] arrayGiven, string[] arrayConsole)
{
    if (arrayConsole.Length == 0)
    {
        if (arrayGiven.Length == 0)
        {
            Console.WriteLine("Массив данных из программы пуст");
        }
        else
        {
            PrintArray(arrayGiven);
            NewArray(arrayGiven);
        }
    }
    else
    {
        PrintArray(arrayConsole);
        NewArray(arrayConsole);
    }
    
}
string[] myArrayConsole = new string[0];
string[] myArrayGiven = new string[] { "Asas", "Fssa", "5)f", "qq54", "af" };
GetArray(myArrayGiven, ref myArrayConsole);
ChooseArray(myArrayGiven, myArrayConsole);

