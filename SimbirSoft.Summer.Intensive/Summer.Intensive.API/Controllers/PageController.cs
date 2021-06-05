using Microsoft.AspNetCore.Mvc;
using Summer.Intensive.Core.PageService;
using Summer.Intensive.DataBase;
using Summer.Intensive.DataBase.Models;
using System;

namespace Summer.Intensive.API.Controllers
{
    /// <summary>
    /// Контроллер для страниц
    /// </summary>
    [ApiController]
    [Route("/api/{controller}")]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;
        private readonly DataContext _dataContext;
        public PageController(IPageService pageService, DataContext dataContext)
        {
            _pageService = pageService;
            _dataContext = dataContext;
        }

        /// <summary>
        /// Метод, принимающий url строки в теле запроса
        /// </summary>
        /// <param name="page"></param>
        [HttpPost]
        public IActionResult GetString([FromBody] Page page)
        {
            Console.WriteLine($"Введенный Url: {page.Url}");

            _pageService.ParsePage(page);
            _dataContext.SaveChanges();

            return Ok();
        }
    }
}
