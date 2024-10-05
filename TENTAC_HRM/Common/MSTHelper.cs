using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TENTAC_HRM
{
    class MSTHelper
    {
        DataProvider provider = new DataProvider();
        private readonly string URL = "https://masothue.com";
        public class ResponseData
        {
            public int success { get; set; }
            public string message { get; set; }
            public string url { get; set; }
        }

        public class TaxInfomation
        {
            public bool susscess { get; set; }
            public string message { get; set; }
            public string mst { get; set; }
            public string name { get; set; }
            public string deputy { get; set; }
            public string address { get; set; }
            public string date_actived { get; set; }
            public string status { get; set; }
            public string by_manager { get; set; }
            public string note { get; set; }
        }


        public Task<TaxInfomation> GetTaxInfomation(string taxCode, string name)
        {
            var task = Task.Run(async () =>
            {
                HttpClient httpClient;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var handler = new HttpClientHandler();
                handler.AllowAutoRedirect = true;
                httpClient = new HttpClient(handler);
                httpClient.Timeout = TimeSpan.FromSeconds(5);
                var form_data = new Dictionary<string, string>();
                form_data.Add("type", "auto");
                form_data.Add("force-search", "1");
                form_data.Add("q", taxCode);
                var req = new HttpRequestMessage(HttpMethod.Post, $"{URL}/Ajax/Search") { Content = new FormUrlEncodedContent(form_data) };

                req.Headers.Add("scheme", "https");
                req.Headers.Add("X-Requested-With", "XMLHttpRequest");
                req.Headers.Add("origin", $"{URL}");
                req.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36");
                httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = false };

                var res = await httpClient.SendAsync(req);


                var html = await res.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<ResponseData>(html);
                if (responseData.success == 0)
                {
                    return new TaxInfomation { susscess = false, message = responseData.message };
                }
                else
                {
                    var urlInfo = $"{URL}{responseData.url}" + taxCode + "-" + provider.RemoveVietnameseTone(name.Replace(" ", "-").ToString());
                    var wrequest = (HttpWebRequest)WebRequest.Create(urlInfo);
                    wrequest.KeepAlive = false;
                    wrequest.ProtocolVersion = HttpVersion.Version10;
                    wrequest.Timeout = System.Threading.Timeout.Infinite;
                    wrequest.Method = @"GET";
                    wrequest.ContentType = @"application/x-www-form-urlencoded";
                    wrequest.UserAgent = @"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)";
                    wrequest.Accept = "*/*";
                    wrequest.UseDefaultCredentials = true;
                    wrequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    var wresponse = wrequest.GetResponse();
                    var responseStream = wresponse.GetResponseStream();
                    var readStream = new StreamReader(responseStream, Encoding.UTF8);
                    var response = readStream.ReadToEnd();
                    var page = new HtmlAgilityPack.HtmlDocument();
                    page.LoadHtml(response);
                    var table_info = page.DocumentNode.SelectSingleNode("//table[@class='table-taxinfo']").InnerHtml;
                    page.LoadHtml(table_info);
                    var Name = page.DocumentNode.SelectSingleNode("//thead/tr").InnerText.Replace("\n", "");
                    HtmlNodeCollection AllNodes = page.DocumentNode.SelectNodes("//td");
                    List<string> listData = new List<string>();
                    var taxInfo = new TaxInfomation();
                    taxInfo.susscess = true;
                    taxInfo.name = Name;
                    foreach (var node in AllNodes)
                    {
                        var body = node.InnerText;
                        listData.Add(body);
                    }
                    taxInfo.mst = listData[1];
                    taxInfo.address = listData.Count == 12 ? "" : listData[3];
                    taxInfo.deputy = listData.Count == 12 ? listData[3] : listData[5];
                    taxInfo.date_actived = listData.Count == 12 ? listData[5] : listData[7];
                    taxInfo.by_manager = listData.Count == 12 ? listData[7] : listData[9];
                    taxInfo.status = listData.Count == 12 ? listData[9] : listData[11];

                    taxInfo.note = listData[listData.Count - 2].Split('.')[0].Replace("\n", "");

                    return taxInfo;
                }
            });
            return task;
        }
    }
}
