using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace blog_app.Data
{
    public class DDBHelper
    {
        private AWSCredentials _credentials = new Amazon.Runtime.StoredProfileAWSCredentials("Anuja");
        private AmazonDynamoDBClient _ddbClient;
        private Table _ddbTable;


        public DDBHelper(string ddbTableName)
        {
            _ddbClient = new AmazonDynamoDBClient(_credentials, RegionEndpoint.USEast1);
            _ddbTable = Table.LoadTable(_ddbClient, ddbTableName);            
        }
      
        public Document GetItems(int id)
        {                        
            var item = _ddbTable.GetItemAsync(id).Result;            
            return item;
        }


        
    }
}
