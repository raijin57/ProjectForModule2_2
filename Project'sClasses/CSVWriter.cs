using System.Text;
namespace Project_sClasses
{
    /// <summary>
    /// Статический класс, записывающий данные в файл CSV.
    /// </summary>
    public static class CSVWriter
    {
        /// <summary>
        /// Статический метод, выполняющий запись в файл.
        /// </summary>
        /// <param name="data">Массив с объектами, записываемыми в файл.</param>
        /// <param name="path">Путь к файл, в который требуется записать данные.</param>
        public static void Write(object[] data, string path)
        {
            // Формируем массив строк, для дальнейшего записывания.
            string[] toFile = new string[data.Length];
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    toFile[i] = data[i].ToString();
                }
                // Сперва записываем в файл заголовок.
                File.WriteAllLines(path, ["Date_time;city;state/province;country;UFO_shape;length_of_encounter_seconds;described_duration_of_encounter;description;date_documented;latitude;longitude"], Encoding.UTF8);
                // Затем добавляем сами данные.
                File.AppendAllLines(path, toFile);
            }
            // Обрабатываем исключения при записи.
            catch (IOException)
            {
                Console.Clear();
                Console.WriteLine("Файл используется, закройте его перед изменением.");
            }
        }
    }
}
