using Summer.Intensive.DataBase.Models;
using Summer.Intensive.DataBase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Summer.Intensive.Core.PageService
{
    /// <summary>
    /// Сервис страницы
    /// </summary>
    public class PageService : IPageService
    {
        private readonly IPageRepository _repository;

        public PageService(IPageRepository repository)
        {
            _repository = repository;
        }

        public void ParsePage(Page page)
        {
            WebRequest webRequest = HttpWebRequest.Create(page.Url);
            webRequest.Method = "HEAD";
            try
            {
                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    var model = new Page()
                    {
                        Url = page.Url,
                        CheckParse = true
                    };
                    _repository.Add(model);
                    Console.WriteLine("Exists");
                }
            }
            catch (WebException ex)
            {
                var model = new Page()
                {
                    Url = page.Url,
                    CheckParse = false
                };
                _repository.Add(model);
                throw new ArgumentException("Not exists: " + ex.Message);
            }

            WebClient client = new WebClient();
            Stream data = client.OpenRead(page.Url);

            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();

            ParseUrl.ConvertHtml(s);
        }
    }
}
