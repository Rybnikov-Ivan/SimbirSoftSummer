using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Summer.Intensive.Core
{
    /// <summary>
    /// Класс для парсинга веб страницы и записи уникальных слов в консоль
    /// </summary>
    public class ParseUrl
    {
		/// <summary>
		/// Выборка уникальных слов и вывод их в консоль
		/// </summary>
		/// <param name="words"></param>
		public static void GetUniqueWords(string[] words)
		{
			var wordList = new List<String>(words);

			var grouped = wordList
				.GroupBy(i => i)
				.Select(i => new { Word = i.Key, Count = i.Count() }).OrderByDescending(i => i.Count).ToArray();

			for (int i = 0; i < grouped.Length; i++)
			{
				Console.WriteLine(grouped[i].Word.ToUpper() + " - " + grouped[i].Count);
			}
		}

		/// <summary>
		/// Конверт html файла и его разбиение
		/// </summary>
		/// <param name="html"></param>
		public static string ConvertHtml(string html)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			StringWriter sw = new StringWriter();
			ConvertTo(doc.DocumentNode, sw);
			sw.Flush();

			char[] delimiterChars = { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };

			var resStr = sw.ToString();
			resStr = Regex.Replace(resStr, @" "" ", "");
			var res = Regex.Replace(resStr, @"\s+", " ");

			string[] words = res.Split(delimiterChars);
			GetUniqueWords(words);
			return res;
		}

		private static void ConvertContentTo(HtmlNode node, TextWriter outText)
		{
			foreach (HtmlNode subnode in node.ChildNodes)
			{
				ConvertTo(subnode, outText);
			}
		}

		public static void ConvertTo(HtmlNode node, TextWriter outText)
		{
			string html;
			switch (node.NodeType)
			{
				case HtmlNodeType.Comment:
					break;

				case HtmlNodeType.Document:
					ConvertContentTo(node, outText);
					break;

				case HtmlNodeType.Text:
					string parentName = node.ParentNode.Name;
					if ((parentName == "script") || (parentName == "style"))
						break;

					html = ((HtmlTextNode)node).Text;

					if (HtmlNode.IsOverlappedClosingElement(html))
						break;

					if (html.Trim().Length > 0)
					{
						outText.Write(HtmlEntity.DeEntitize(html));
						outText.Write(" ");
					}
					break;

				case HtmlNodeType.Element:
					switch (node.Name)
					{
						case "p":
							outText.Write("\r\n");
							break;
					}

					if (node.HasChildNodes)
					{
						ConvertContentTo(node, outText);
					}
					break;
			}
		}
	}
}
