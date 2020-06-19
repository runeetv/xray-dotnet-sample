using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;

namespace blog_app.Data
{
    public class AWSHelper
    {

        private AWSCredentials _credentials = new Amazon.Runtime.StoredProfileAWSCredentials("Anuja");
        private AmazonS3Client _s3Client;        

        public AWSHelper()
        {
            _s3Client = new AmazonS3Client(_credentials, Amazon.RegionEndpoint.USEast1);           
        }


        public async Task<byte[]> GetImageFromS3Bucket(string bucketName, string imageName)
        {
            var req = new GetObjectRequest { BucketName = bucketName, Key = imageName };
            GetObjectResponse response = await _s3Client.GetObjectAsync(req);
            await response.WriteResponseStreamToFileAsync(Environment.CurrentDirectory + "/wwwroot/images/ad/Downloaded.png",false,CancellationToken.None);
            string image = Environment.CurrentDirectory + "/wwwroot/images/ad/Downloaded.png";
            byte[] imageBinary = System.IO.File.ReadAllBytes(image);
            return imageBinary;
        }

        public void AddMessageToSQS( string serviceUrl,string clientIP)
        {

            var userLog = "{'User ip':'" + clientIP + "','TimeStamp':'"+ DateTime.Now.ToString()+"' }";
            AmazonSQSClient amazonSQSClient = new AmazonSQSClient(_credentials, Amazon.RegionEndpoint.USEast1);
            SendMessageRequest sendRequest = new SendMessageRequest(serviceUrl, userLog);

            var result = amazonSQSClient.SendMessageAsync(sendRequest).Result;

        }

        
    }
}
