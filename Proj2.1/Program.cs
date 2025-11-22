/*
 * 
 * Дулаев Арсен Аланович
 *       БПИ 246-1
 *       Вариант 19.
 * Все созданные в программе файлы сохраняются в папку Files, находящуюся в папке на одном уровне с решением.
 * 
 */

// Используем созданную библиотеку классов. (Project'sClasses)
using Project_sClasses;

namespace Proj2._1
{
    /// <summary>
    /// Основной класс программы.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        static void Main()
        {
            // Основной цикл программы.
            do
            {
                // Выводим на экран меню.
                Menu.Print();
                // Ждём выбор пункта меню.
                string? point = Console.ReadLine().Trim();
                switch (point)
                {
                    case "1":
                        Menu.Print();
                        Console.WriteLine("Введите путь к файлу:");
                        // Если путь вводится впервые.
                        if (!PathGetter.PathExists())
                        {
                            PathGetter.Path(Console.ReadLine());
                            UfoDataProcess.GetArray();
                        }
                        // Если хотим заменить путь.
                        else
                        {
                            PathGetter.ChangePath(Console.ReadLine());
                            UfoDataProcess.GetArray();
                        }
                        break;
                    case "2":
                        Menu.Print();
                        if (PathGetter.PathExists()) { }
                        // Проверяем чтобы сперва ввели путь к файлу, перед тем как совершать с ним операции.
                        else
                        {
                            Console.WriteLine("Сперва выберите файл! Нажмите любую кнопку для продолжения.");
                            continue;
                        }
                        // Массив для НЛО, удовлетворяющих условию.
                        UfoData[] rightUFOs = [];
                        int index = 0;
                        foreach (UfoData UFO in UfoDataProcess.GetArray())
                        {
                            if (UFO.UFO_shape == "triangle" && UFO.length_of_encounter_seconds > 1000)
                            {
                                Array.Resize(ref rightUFOs, rightUFOs.Length + 1);
                                rightUFOs[index] = UFO;
                                index++;
                            }
                        }
                        // Выводим доступные подпункты.
                        Menu.Select(point);
                        string subpoint = Console.ReadLine().Trim();
                        // Выполняем вызванный подпункт.
                        switch (subpoint)
                        {
                            case "1" or "2.1":
                                Console.Clear();
                                int counter = 0;
                                foreach (UfoData UFO in rightUFOs)
                                {
                                    Console.WriteLine($"{++counter}: {UFO}");
                                }
                                break;
                            case "2" or "2.2":
                                Console.Clear();
                                if (rightUFOs.Length > 0)
                                {
                                    // Записываем в файл.
                                    CSVWriter.Write(rightUFOs, @$"..\..\..\..\Files\UFO-Shape-Time.csv");
                                }
                                break;
                            default:
                                Console.WriteLine("Такой команды в меню нет. Нажмите любую кнопку для повторного вызова меню");
                                break;
                        }
                        // В случае если подходящих данных нет, то выводим об этом сообщение. Иначе просим продолжить.
                        Console.WriteLine(rightUFOs.Length > 0 ? "Для продолжения нажмите любую клавишу." : "Подходящих данных в файле не нашлось. Для продолжения нажмите любую клавишу");
                        break;
                    case "3":
                        Menu.Print();
                        if (PathGetter.PathExists()) { }
                        else
                        {
                            Console.WriteLine("Сперва выберите файл! Нажмите любую кнопку для продолжения.");
                            continue;
                        }
                        Menu.Select(point);
                        subpoint = Console.ReadLine().Trim();
                        switch (subpoint)
                        {
                            case "1" or "3.1":
                                Console.Clear();
                                Console.WriteLine($"Общее количество записей об НЛО - {UfoDataProcess.quantity}");
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            case "2" or "3.2":
                                Console.Clear();
                                // Создаём словарь для поиска самого активного города.
                                var catchersCity = new Dictionary<string, int>();
                                for (int i = 0; i < UfoDataProcess.GetArray().Length; i++)
                                {
                                    // Если ключ (город) уже есть, то увеличиваем количество раз, сколько там видели НЛО.
                                    if (catchersCity.ContainsKey(UfoDataProcess.GetArray()[i].city))
                                    {
                                        catchersCity[UfoDataProcess.GetArray()[i].city]++;
                                    }
                                    // Если ключа нет, то добавляем и присваеваем ему значение 1.
                                    else
                                    {
                                        catchersCity.Add(UfoDataProcess.GetArray()[i].city, 1);
                                    }
                                }
                                int maxRepeat = 0;
                                // Считаем сколько максимум раз видели в неком городе.
                                foreach (var catcherCity in catchersCity)
                                {
                                    maxRepeat = Math.Max(maxRepeat, catcherCity.Value);
                                }
                                // Ищем город, зная сколько раз в нём видели НЛО.
                                foreach (var catcherCity in catchersCity)
                                {
                                    if (catcherCity.Value == maxRepeat)
                                    {
                                        Console.WriteLine($"{catcherCity.Key} {catcherCity.Value}");
                                    }
                                }
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            case "3" or "3.3":
                                Console.Clear();
                                // Словарь для подсчета раз сколько какие формы встречались.
                                var shapesDict = new Dictionary<string, int>();
                                int quantityOfShapes = 0;
                                for (int i = 0; i < UfoDataProcess.GetArray().Length; i++)
                                {
                                    if (UfoDataProcess.GetArray()[i].UFO_shape != string.Empty)
                                    {
                                        // Аналогично логике из п. 3.2
                                        if (shapesDict.ContainsKey(UfoDataProcess.GetArray()[i].UFO_shape))
                                        {
                                            shapesDict[UfoDataProcess.GetArray()[i].UFO_shape]++;
                                            quantityOfShapes++;
                                        }
                                        else
                                        {
                                            shapesDict.Add(UfoDataProcess.GetArray()[i].UFO_shape, 1);
                                            quantityOfShapes++;
                                        }
                                    }
                                }
                                // Выводим только те значения, где процентное количество (после округления до целых) не равно нулю.
                                foreach (var shape in shapesDict)
                                {
                                    Console.Write(Math.Round((double)shape.Value / quantityOfShapes * 100) == 0 ? "" : $"{shape.Key} {Math.Round((double)shape.Value / quantityOfShapes * 100)}%\n");
                                }
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            case "4" or "3.4":
                                Console.Clear();
                                // Словарь для подсчёта среднего среди формы.
                                var shapesDictForMiddle = new Dictionary<string, double>();
                                // Словарь для подсчёта того, сколько раз форму видели.
                                var shapesDictForTimesSeen = new Dictionary<string, int>();
                                int quantityOfMiddle = 0;
                                for (int i = 0; i < UfoDataProcess.GetArray().Length; i++)
                                {
                                    if (shapesDictForTimesSeen.ContainsKey(UfoDataProcess.GetArray()[i].UFO_shape))
                                    {
                                        shapesDictForTimesSeen[UfoDataProcess.GetArray()[i].UFO_shape]++;
                                        shapesDictForMiddle[UfoDataProcess.GetArray()[i].UFO_shape] += UfoDataProcess.GetArray()[i].length_of_encounter_seconds;
                                        quantityOfMiddle++;
                                    }
                                    else
                                    {
                                        shapesDictForTimesSeen.Add(UfoDataProcess.GetArray()[i].UFO_shape, 1);
                                        shapesDictForMiddle.Add(UfoDataProcess.GetArray()[i].UFO_shape, UfoDataProcess.GetArray()[i].length_of_encounter_seconds);
                                        quantityOfMiddle++;
                                    }
                                }
                                // Выводим среднее значение секунд.
                                foreach (var UFO in shapesDictForTimesSeen)
                                {
                                    Console.WriteLine($"{UFO.Key} - {Math.Round(shapesDictForMiddle[UFO.Key] / UFO.Value)} секунд");
                                }
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            case "5" or "3.5":
                                Console.Clear();
                                // Сортируем используя делегаты по столбцу latitude.
                                Array.Sort(UfoDataProcess.GetArray(), delegate (UfoData x, UfoData y) { return x.latitude.CompareTo(y.latitude); });
                                // Если нечётное количество элементов, то медиана это элемент посередине. (после упорядочивания)
                                if (UfoDataProcess.GetArray().Length % 2 == 1)
                                {
                                    Console.WriteLine($"Медиана широт - {UfoDataProcess.GetArray()[UfoDataProcess.GetArray().Length / 2].latitude}");
                                }
                                // Если количество чётное, то медиана - среднее от двух наиболее близких к середине. (после упорядочивания)
                                else
                                {
                                    double median = (UfoDataProcess.GetArray()[UfoDataProcess.GetArray().Length / 2 - 1].latitude + UfoDataProcess.GetArray()[UfoDataProcess.GetArray().Length / 2].latitude) / 2;
                                    Console.WriteLine($"Медиана широт - {median}");
                                }
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            default:
                                Console.WriteLine("Такой команды в меню нет. Нажмите любую кнопку для повторного вызова меню");
                                break;
                        }
                        break;
                    case "4":
                        Menu.Print();
                        Environment.Exit(0);
                        break;
                    case "5":
                        Menu.Print();
                        if (PathGetter.PathExists()) { }
                        else
                        {
                            Console.WriteLine("Сперва выберите файл! Нажмите любую кнопку для продолжения.");
                            continue;
                        }
                        Menu.Select(point);
                        subpoint = Console.ReadLine().Trim();
                        switch (subpoint)
                        {
                            case "1" or "5.1":
                                Console.Clear();
                                Array.Sort(UfoDataProcess.GetArray(), delegate (UfoData x, UfoData y)
                                {
                                    // Сравнение по стране (country).
                                    int countryComparison = string.Compare(x.country, y.country);
                                    // Если сравнение не ноль (не одинаковые значения), то сортируем по строке.
                                    if (countryComparison != 0)
                                    {
                                        return countryComparison;
                                    }
                                    // Если страны равны, то сортируем по штату.
                                    else
                                    {
                                        return string.Compare(x.state, y.state);
                                    }
                                });
                                foreach (var strings in UfoDataProcess.GetArray())
                                {
                                    Console.WriteLine(strings);
                                }
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            case "2" or "5.2":
                                Console.Clear();
                                // Записываем в файл.
                                CSVWriter.Write(UfoDataProcess.GetArray(), @$"..\..\..\..\Files\Grouped-UFOs.csv");
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            default:
                                Console.WriteLine("Такой команды в меню нет. Нажмите любую кнопку для повторного вызова меню");
                                break;
                        }
                        break;
                    case "6":
                        Menu.Print();
                        if (PathGetter.PathExists()) { }
                        else
                        {
                            Console.WriteLine("Сперва выберите файл! Нажмите любую кнопку для продолжения.");
                            continue;
                        }
                        Menu.Select(point);
                        UfoData[] inTimeUFOs = new UfoData[0];
                        UfoData[] temp = UfoDataProcess.GetArray();
                        // Прописываем начало и конец диапазона по условию.
                        TimeSpan startTime = new TimeSpan(20, 0, 0);
                        TimeSpan endTime = new TimeSpan(6, 30, 0);
                        int size = 0;
                        for (int i = 0; i < temp.Length; i++)
                        {
                            TimeSpan timeOfDay = temp[i].Date_time.TimeOfDay;
                            // Если форма та (по условию).
                            if (temp[i].UFO_shape == "triangle" || temp[i].UFO_shape == "circle" || temp[i].UFO_shape == "cylinder")
                            {
                                // Если время между двумя днями (есть переход через полночь).
                                if (startTime > endTime)
                                {
                                    if (timeOfDay >= startTime || timeOfDay <= endTime)
                                    {
                                        size++;
                                        Array.Resize(ref inTimeUFOs, size);
                                        inTimeUFOs[size - 1] = temp[i];
                                    };
                                }
                                // Если промежуток в пределах одного дня.
                                else
                                {
                                    if (timeOfDay >= startTime && timeOfDay <= endTime)
                                    {
                                        size++;
                                        Array.Resize(ref inTimeUFOs, size);
                                        inTimeUFOs[size - 1] = temp[i];
                                    };
                                }
                            }
                        }
                        // Выполняем выбранный подпункт
                        subpoint = Console.ReadLine().Trim();
                        switch (subpoint)
                        {
                            case "1" or "6.1":
                                Console.Clear();
                                foreach (var j in inTimeUFOs)
                                {
                                    Console.WriteLine(j);
                                }
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            case "2" or "6.2":
                                Console.Clear();
                                Console.Write("Введите имя файла (без '.csv'): ");
                                string name = Console.ReadLine();
                                // Проверяем введённое имя для файла на корректность. (пока не будет введено корректное)
                                while (!CSVChecker.IsValidFileName(name))
                                {
                                    Console.Write("Имя для файла некорректно. Попробуйте еще раз: ");
                                    name = Console.ReadLine();
                                }
                                // Создаём файл с указанным именем.
                                CSVWriter.Write(inTimeUFOs, @$"..\..\..\..\Files\{name}.csv");
                                Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                                break;
                            default:
                                Console.WriteLine("Такой команды в меню нет. Нажмите любую кнопку для повторного вызова меню");
                                break;
                        }
                        break;
                    default:
                        Menu.Print();
                        Console.WriteLine("Такой команды в меню нет. Нажмите любую кнопку для повторного вызова меню");
                        break;
                }
            } while (Console.ReadKey().Key != ConsoleKey.D4);
        }
    }
}