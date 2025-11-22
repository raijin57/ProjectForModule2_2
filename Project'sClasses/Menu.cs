namespace Project_sClasses
{
    /// <summary>
    /// Статический класс контролирующий текстовое меню. 
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Статический метод который выводит на консоль текстовое меню.
        /// </summary>
        public static void Print()
        {
            // Очищаем консоль (для поддержания чистоты в консоли)
            Console.Clear();
            // Если уже был выбран файл - выводим меню (дабы не начать работу с файлом до его загрузки).
            if (!PathGetter.PathExists())
            {
                // Если файл загружают впервые.
                Console.WriteLine($"1. Выбрать файл{Environment.NewLine}2. Данные об НЛО треугольной формы (более 1000 секунд){Environment.NewLine}3. Сводная статистика об НЛО{Environment.NewLine}4. Завершить работу программы{Environment.NewLine}5. [доп] Упорядочить по строке{Environment.NewLine}6. [доп] НЛО в период 20:00-6:30");
            }
            else
            {
                // Если некий файл уже был загружен и пользователь хочет поменять файл с которым работает.
                Console.WriteLine($"1. Заменить файл{Environment.NewLine}2. Данные об НЛО треугольной формы (более 1000 секунд){Environment.NewLine}3. Сводная статистика об НЛО{Environment.NewLine}4. Завершить работу программы{Environment.NewLine}5. [доп] Упорядочить по строке{Environment.NewLine}6. [доп] НЛО в период 20:00-6:30");
            }
        }
        /// <summary>
        /// Статический метод, выводящий на консоль подпункты меню.
        /// </summary>
        /// <param name="subPoint">Строка с указанием подпункт какого пункта меню нужно вывести.</param>
        public static void Select(string subPoint)
        {
            // Получаем информацию о том, подпункт какого пункта нужно вывести.
            switch (subPoint)
            {
                case "2":
                    Console.WriteLine($"\n2.1 Вывести информацию на экран{Environment.NewLine} 2.2 Сохранить выборку в `UFO-Shape-Time.csv`");
                    break;
                case "3":
                    Console.WriteLine($"\n3.1 Общее количество записей об НЛО{Environment.NewLine} 3.2 Город, в котором наиболее активны ловцы НЛО{Environment.NewLine}  3.3 Статистика по формам НЛО (в процентном соотношении){Environment.NewLine}   3.4 Средняя продолжительность времени наблюдения{Environment.NewLine}    3.5 Медиана широт");
                    break;
                case "5":
                    Console.WriteLine($"\n5.1 Вывести информацию на экран{Environment.NewLine} 5.2 Сохранить в файл `Grouped-UFOs.csv` результат группировки с сохранением порядка.");
                    break;
                case "6":
                    Console.WriteLine($"\n6.1 Вывести информацию на экран{Environment.NewLine} 6.2 Сохранить выборку в CSV-файл с именем, полученным от пользователя.");
                    break;
            }
        }

    }
}
