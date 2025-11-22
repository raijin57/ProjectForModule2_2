namespace Project_sClasses
{
    /// <summary>
    /// Статический класс, отвечающий за получение и обработку полученного пути к файлу.
    /// </summary>
    public static class PathGetter
    {
        // Приватное поле с путем к файлу.
        private static string? path = null;
        /// <summary>
        /// Статический метод, проверяющий введённый путь на корректность и на наличие по нему CSV файла.
        /// </summary>
        /// <param name="inputPath">Строка с путём к файлу.</param>
        public static void Path(string? inputPath)
        {
            // Очищаем консоль (для поддержания чистоты в консоли).
            Console.Clear();
            // Проверяем что введённый "путь" не является пустой строкой, был введён и что по нему существует файл типа CSV.
            if (inputPath == null || inputPath == Environment.NewLine || inputPath == string.Empty || File.Exists(inputPath) == false || !inputPath.EndsWith(".csv"))
            {
                // Если что-то не выполнено, то вводим путь заново.
                Console.WriteLine("Введите путь к файлу:");
                Path(Console.ReadLine());
            }
            else
            {
                // Если путь корректен - передаём его в поле.
                path = inputPath;
            }
        }
        /// <summary>
        /// Статический метод для замены пути к файлу (в случае если вводится новый путь для работы с новым файлом).
        /// </summary>
        /// <param name="inputPath">Строка с путём к файлу.</param>
        public static void ChangePath(string? inputPath)
        {
            // Очищаем консоль (для поддержания чистоты в консоли).
            Console.Clear();
            path = inputPath;
            // Отправляем полученный путь на проверку в метод Path().
            Path(path);
            Console.WriteLine("Файл был заменен");
            // Обрабатываем данные полученные по новому пути.
            UfoDataProcess.MakeArray();
        }
        /// <summary>
        /// Статический метод проверяющий существование файла по введённому пути.
        /// </summary>
        /// <returns>true, если файл по указанному пути существует и false иначе.</returns>
        public static bool PathExists() => path == null ? false : true;
        /// <summary>
        /// Статический метод, возвращающий путь к файлу.
        /// </summary>
        /// <returns>Строку с путём, где есть файл или пустую строку, если файла на пути нет.</returns>
        public static string ReturnFilePath()
        {
            if (PathExists())
            {
                return path;
            }
            else
            {
                Console.WriteLine("Сперва введите корректный путь.");
                return string.Empty;
            }
        }
    }
}
