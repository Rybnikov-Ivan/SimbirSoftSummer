namespace Summer.Intensive.DataBase.Models
{
    /// <summary>
    /// Модель страницы
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Идентификатор страницы
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Url страницы
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Проверка страницы на содержание, парсинг
        /// </summary>
        public bool CheckParse { get; set; }
    }
}
