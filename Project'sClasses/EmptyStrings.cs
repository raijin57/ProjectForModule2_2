namespace Project_sClasses
{
    /// <summary>
    /// Статический класс, который работает с теми данными, в которых есть пропущенные значения
    /// </summary>
    public static class EmptyStrings
    {
        /// <summary>
        /// Статический метод, который "выбирает" какое значение по умолчанию поместить на то место, где в файле данных нет.
        /// </summary>
        /// <param name="col">Номер столбца.</param>
        /// <returns></returns>
        public static string FillTheBlank(int col)
        {
            // Здесь по возрастанию соответственно для полей Date_time, city, state/province, ...
            switch (col)
            {
                case 0:
                    return "1/1/2000 10:00";
                case 1:
                    return "неизвестный город";
                case 2:
                    return "штат неизвестен";
                case 3:
                    return "нет данных о стране";
                case 4:
                    return "нет информации о форме";
                case 5:
                    return "неизвестно";
                case 6:
                    return "неизвестно";
                case 7:
                    return "нет описания";
                case 8:
                    return "нет информации о дате";
                case 9:
                    return "нет данных";
                case 10:
                    return "нет данных";
                default:
                    return string.Empty;
            }
        }
    }
}
