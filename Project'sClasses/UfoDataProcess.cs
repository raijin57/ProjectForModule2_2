namespace Project_sClasses
{
    /// <summary>
    /// Статический класс, занимающийся обработкой и "фасовкой" данных. 
    /// </summary>
    public static class UfoDataProcess
    {
        // Поле для данных, разбитых по разделителю CSV файла.
        public static string[] rowData = null;
        // Поле, хранящее путь к файлу.
        static string path;
        // Поле для подсчета общего количества элементов.
        public static int quantity = 0;
        // Массив с объектами типа UfoData - с данными об НЛО.
        public static UfoData[] UFOArray = null;
        /// <summary>
        /// Статический метод, обрабатывающий данные из файла и переводящий их в массив UfoData.
        /// </summary>
        /// <returns>Массив с данными типа UfoData.</returns>
        internal static UfoData[] MakeArray()
        {
            // Получаем путь к файлу.
            path = PathGetter.ReturnFilePath();
            Console.WriteLine("Это может занять какое-то время..");
            try
            {
                // Если файл существует - начинаем работу.
                if (File.Exists(path))
                {
                    rowData = File.ReadAllLines(path);
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Путь не может быть пустым. Введите путь к файлу");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не был найден. Введите путь к файлу");
                Environment.Exit(0);
            }
            // Разбиваем исходные данные на массив массивов.
            string[][] splittedData = new string[rowData.Length][];
            if (splittedData.Length < 2)
            {
                Console.WriteLine("Файл пуст или содержит только заголовок.");
                Environment.Exit(0);
            }
            // Добавляем в массив массивов данные из файла.
            for (int i = 0; i < rowData.Length; i++)
            {
                splittedData[i] = rowData[i].Split(',');
            }
            // Проверяем на то, корректен ли заголовок файла.
            if (CSVChecker.Headers(splittedData[0]))
            {
                // "Фильтруем" данные - пропускаем пустые данные. (ИСПРАВИТЬ!)
                int size = 0;
                for (int i = 0; i < splittedData.Length; i++)
                {
                    for (int j = 0; j < splittedData[i].Length; j++)
                    {
                        if (splittedData[i][j] == string.Empty)
                        {
                            splittedData[i][j] = EmptyStrings.FillTheBlank(j);
                        }
                    }
                }
                // На основе "отчищенных" данных формируем итоговый массив с объектами НЛО.
                UfoData[] UFOArray = new UfoData[splittedData[1..].Length];
                for (int i = 0; i < splittedData[1..].Length; i++)
                {
                    // Заполняем массив объектами класса UfoData.
                    UFOArray[i] = new UfoData(splittedData[1..][i]);
                }
                // Очищаем консоль (для поддержания чистоты консоли).
                Console.Clear();
                // Сохраняем количество итоговых данных.
                quantity = UFOArray.Length;
                Console.WriteLine("Данные из файла прочитаны! Нажмите любую кнопку для продолжения.");
                return UFOArray;
            }
            // "Заглушка", если заголовок некорректен.
            else
            {
                return Array.Empty<UfoData>();
            }
        }
        // Закрытое поле с получившимся массивом объектов класса UfoData.
        private static readonly UfoData[] array = MakeArray();
        /// <summary>
        /// Статический метод, для доступа к массиву типа UfoData.
        /// </summary>
        /// <returns>Массив с полученными данными об НЛО (тип - UfoData).</returns>
        public static UfoData[] GetArray()
        {
            return array;
        }
    }
}
