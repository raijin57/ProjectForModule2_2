namespace Project_sClasses
{
    /// <summary>
    /// Класс, описывающий НЛО.
    /// </summary>
    public class UfoData
    {
        // Поля с информацией об НЛО.
        private readonly static string[] _headers = ["Date_time", "city", "state / province", "country", "UFO_shape", "length_of_encounter_seconds", "described_duration_of_encounter", "description", "date_documented", "latitude", "longitude"];
        public readonly DateTime Date_time;
        public readonly string city;
        public readonly string state;
        public readonly string country;
        public readonly string UFO_shape;
        public readonly double length_of_encounter_seconds;
        public readonly string described_duration_of_encounter;
        public readonly string description;
        public readonly string date_documented;
        public readonly double latitude;
        public readonly double longitude;
        // Формат даты, получаемой из файла.
        internal string format = "M/d/yyyy HH:mm";
        /// <summary>
        /// Конструктор, формирующий объект класса.
        /// </summary>
        /// <param name="row">Массив строк, содержащий информацию об элементе класса.</param>
        public UfoData(string[] row)
        {
            try
            {
                // Обрабатываем все данные.
                DateTime.TryParseExact(row[0], format, null, System.Globalization.DateTimeStyles.None, out Date_time);
                this.city = row[1];
                this.state = row[2];
                this.country = row[3];
                this.UFO_shape = row[4];
                try
                {
                    if (row[5].IndexOf('.') != -1)
                    {
                        this.length_of_encounter_seconds = 60.0 * double.Parse(row[5].Replace('.', ','));
                    }
                    else
                    {
                        this.length_of_encounter_seconds = double.Parse(row[5]);
                    }
                }
                // Как обрабатывать значения по типу "2`" (строка 27824 в файле) - вопрос открытый. Моё решение - игнорировать.
                catch { }
                this.described_duration_of_encounter = row[6];
                this.description = row[7];
                this.date_documented = row[8];
                // Тот же вопрос и с "33q.200088" (с. 43784)
                try
                {
                    this.latitude = double.Parse(row[9].Replace('.', ','));
                }
                catch { }
                try
                {
                    this.longitude = double.Parse(row[10].Replace('.', ','));
                }
                catch { }
            }
            // В случае некорректности данных - выводим предупреждение.
            catch (Exception e)
            {
                Console.WriteLine("Данные в файле некорректны. Смените файл, используя соответствующий пункт меню.");
            }
        }
        /// <summary>
        /// Переписанная реализация метода ToString(), выводящая информацию об НЛО, подготовленную к добавлению в файл CSV.
        /// </summary>
        /// <returns>Строку с информацией об объекте класса.</returns>
        public override string ToString()
        {
            return $"{Date_time};{city};{state};{country};{UFO_shape};{length_of_encounter_seconds};{described_duration_of_encounter};{description};{date_documented};{latitude};{longitude}";
        }
    }
}
