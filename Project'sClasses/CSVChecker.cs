namespace Project_sClasses
{
    /// <summary>
    /// Статический класс, занимающийся проверкой корректности CSV файлов.
    /// </summary>
    public static class CSVChecker
    {
        /// <summary>
        /// Поле, хранящее необходимую для работы с программой структуру заголовка.
        /// </summary>
        private readonly static string[] _headers = ["Date_time", "city", "state/province", "country", "UFO_shape", "length_of_encounter_seconds", "described_duration_of_encounter", "description", "date_documented", "latitude", "longitude"];
        /// <summary>
        /// Статический метод который сравнивает заголовок из входящего файла с требуемым для работы.
        /// </summary>
        /// <param name="headers">Массив строк, содержащий первую строку полученного файла (заголовок).</param>
        /// <returns>true, если структура заголовка полученного файла корректна и false иначе.</returns>
        public static bool Headers(string[] headers)
        {
            // Проверяем совпадение по длине.
            if (headers.Length == _headers.Length)
            {
                // Если длина корректна, проверяем поэлементно совпадение каждого заголовка.
                for (int i = 0; i < _headers.Length; i++)
                {
                    if (headers[i] != _headers[i])
                    {
                        Console.WriteLine("Структура файлов не идентична. Замените файл на новый, используя соответствующий пункт меню.");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("Структура файлов не идентична. Замените файл на новый, используя соответствующий пункт меню.");
                return false;
            }
        }
        /// <summary>
        /// Статический метод который проверяет имя для CSV файла на корректность.
        /// </summary>
        /// <param name="fileName">Строка с именем для файла.</param>
        /// <returns>true, если имя корректно и false иначе.</returns>
        public static bool IsValidFileName(string fileName)
        {
            // Проверяем чтобы имя не было пустым либо слишком длинным.
            if (string.IsNullOrWhiteSpace(fileName) || fileName.Length > 255)
            {
                return false;
            }
            // Получаем массив с символами, запрещенными в качестве имени файла.
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in fileName)
            {
                foreach (char invalidChar in invalidChars)
                {
                    if (c == invalidChar)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}
