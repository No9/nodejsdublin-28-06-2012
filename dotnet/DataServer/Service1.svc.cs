using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace DataServer
{

    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
      [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        List<TestData> retVal;


        public List<TestData> GetDataUsingDataContract()
        {

            retVal = HttpContext.Current.Cache["CacheItem"] as List<TestData>;

            if (retVal == null)
            {
                retVal = new List<TestData>();
                for (int i = 0; i < 10000; i++)
                {
                    TestData data = new TestData();
                    data.name = i.ToString();
                    data.table = "table1";
                    data.date = DateTime.Now;
                    retVal.Add(data);
                }
                HttpContext.Current.Cache.Insert("CacheItem", retVal);
            }


            //List<TestData> retVal = new List<TestData>();

            /*
            SqlConnection myConnection = new SqlConnection("server=.;" +
                                       "Trusted_Connection=yes;" +
                                       "database=nodejstest; " +
                                       "connection timeout=30");

            myConnection.Open();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select top 10000 * from  testtable1",
                                                         myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    TestData data = new TestData();
                    data.name = myReader.GetString(0);
                    data.table = myReader.GetString(1);
                    data.date = myReader.GetDateTime(2);
                    retVal.Add(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }*/
            return retVal;
        }
    }
}
