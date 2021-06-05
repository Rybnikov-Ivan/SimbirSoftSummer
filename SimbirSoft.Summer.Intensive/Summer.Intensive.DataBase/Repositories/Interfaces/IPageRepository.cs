using Summer.Intensive.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Summer.Intensive.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс для страницы
    /// </summary>
    public interface IPageRepository
    {
        /// <summary>
        /// Получение содержания страницы
        /// </summary>
        /// <param name="id"></param>
        void Add(Page model);
    }
}
