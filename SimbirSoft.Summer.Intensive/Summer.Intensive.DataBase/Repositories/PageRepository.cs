using Summer.Intensive.DataBase.Models;
using Summer.Intensive.DataBase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Summer.Intensive.DataBase.Repositories
{
    /// <summary>
    /// Репозиторий веб строки
    /// </summary>
    public class PageRepository : IPageRepository
    {
        private readonly DataContext _dataContext;

        public PageRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Page model)
        {
            _dataContext.Pages.Add(model);
        }
    }
}
