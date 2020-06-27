using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using blog_app.Data;
using Amazon.XRay.Recorder.Handlers.System.Net;
using System.Net;
using Amazon.XRay.Recorder.Core;


namespace blog_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IBlogRepository _blogRepository;
        private IHttpContextAccessor _accessor;
        private DDBHelper _ddbHelper;
        private IConfiguration _configuration;
        private AWSHelper _AWSHelper;
        public List<BlogCategory> Categories { get; set; }
        public List<BlogPost> Posts { get; set; }
        public string ClientIP { get; set; }

        public List<News> News { get; set; }

        public byte[] Image { get; set; }
        public IndexModel(ILogger<IndexModel> logger , IBlogRepository blogRepository , IHttpContextAccessor accessor , IConfiguration configuration)
        {
            _logger = logger;
            _blogRepository = blogRepository;
            _accessor = accessor;
            _configuration = configuration;


            Categories = _blogRepository.GetBlogCategories();
            Posts = _blogRepository.GetBlogPosts();
            Image = LoadAdRotaor().Result;
            ClientIP = AWSXRayRecorder.Instance.TraceMethod("Get Client IP", () => GetClientIP()); ;
            News = GetAWSNews();
            CaptureUserInfo(ClientIP);
        }


        private async Task<byte[]> LoadAdRotaor()
        {
            byte[] imageBinary = null;
            if (_configuration["Execute"] == "Local")
            {
                string image = Environment.CurrentDirectory + "/wwwroot/images/ad/AWS.png";
                imageBinary = System.IO.File.ReadAllBytes(image);
            }
            else
            {
                _AWSHelper = new AWSHelper(_configuration);
                _ddbHelper = new DDBHelper(_configuration);
                var doc = _ddbHelper.GetItems(1);
                var filename = doc["ad-s3-filename"];

                imageBinary = await _AWSHelper.GetImageFromS3Bucket(_configuration["S3BucketName"],filename);
            }
            return imageBinary;
        }
        public void OnGet()
        {

        }

        private string GetClientIP()
        {

            return _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        private List<News> GetAWSNews()
        {
            string rssFeedUrl = "http://feeds.feedburner.com/AmazonWebServicesBlog";
            List<News> feeds = new List<News>();

            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rssFeedUrl); // enter desired url            
            var response = request.GetResponseTraced();

            XDocument xDoc = XDocument.Load(response.GetResponseStream());

            //XDocument xDoc = XDocument.Load(rssFeedUrl);
            var items = (from x in xDoc.Descendants("item")
                         select new
                         {
                            Title = x.Element("title").Value,
                            Link = x.Element("link").Value,
                            Pubdate = x.Element("pubDate").Value,                           
                         });

            if (items != null)
            {
                feeds.AddRange(items.Select(i => new News
                {
                    Title = i.Title,
                    Link = i.Link,
                    PublishDate = i.Pubdate,                    
                }));
            }

            return feeds;
        }

      
        private void CaptureUserInfo(string ClientI)
        {
            if (_configuration["Execute"] == "Local")
                return;

            _AWSHelper = new AWSHelper(_configuration);
            _AWSHelper.AddMessageToSQS(_configuration["SQSServiceURL"], ClientIP);
        }

    }
}
