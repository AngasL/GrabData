using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrabDate
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            var downloadString = webClient.DownloadString("http://www.qiushibaike.com/");
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(downloadString);

            var contents = htmlDocument.DocumentNode
                    .Descendants("div")
                    .Where(d => d.Attributes.Contains("class")
                       && d.Attributes["class"].Value.Contains("content-text"));

            var items = htmlDocument.DocumentNode
                .SelectNodes("//div[@class='content-text']");


            //Console.OutputEncoding = Encoding.GetEncoding(936);
            var index = 1;
            foreach (var item in items)
            {
                Console.WriteLine(string.Format("{0}. {1}", index, item.InnerText.Trim()));
                index++;
            }
        }
    }
}
