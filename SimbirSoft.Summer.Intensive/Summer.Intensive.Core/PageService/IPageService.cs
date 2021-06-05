using Summer.Intensive.DataBase.Models;

namespace Summer.Intensive.Core.PageService
{
    /// <summary>
    /// Интерфейс для сервиса страницы
    /// </summary>
    public interface IPageService
    {
        /// <summary>
        /// Парсинг страницы
        /// </summary>
        /// <param name="page"></param>
        void ParsePage(Page page);
    }
}
