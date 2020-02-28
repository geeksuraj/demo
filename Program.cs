using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        
        protected static async Task<String> GetApiResult()
        {
            using var client = new HttpClient();
            
            var result = await client.GetAsync("http://127.0.0.1:5000/session/71");
            var v = await result.Content.ReadAsStringAsync();
            return v;

        }
        protected string dataTableToString(DataTable data)
        {

            string reply = "";
            foreach(DataColumn column in data.Columns)
            {
                reply = reply + " " + column;
            }

            Console.WriteLine(reply);
            foreach (DataRow row in data.Rows)
            {
                Console.WriteLine("--- Row ---");
                foreach (var item in row.ItemArray)
                {
                    Console.Write("Item: "); // Print label.
                    Console.WriteLine(item);
                }
            }

            return reply;
        }
                public static DataTable jsonStringToTable(string jsonContent)
        {
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonContent);
            return dt;
        }

        private static async Task Main(string[] args)
        {

            var a = await GetApiResult();
            //Console.WriteLine(a);
            Program ps= new Program();
            DataTable dt = jsonStringToTable(a);
            dt.DataTableToExcel(@"D:\abc.csv");
            //string reply = 


            //ps.dataTableToExcel(dt, @"D:\excel.csv");

            /* foreach (DataColumn column in dt.Columns)
             {
                 reply = reply + "\t" + column;
             }

             reply = reply + "\n";

             foreach (DataRow row in dt.Rows)
             {

                 foreach (var item in row.ItemArray)
                 {
                     reply = reply + "\t" + item;
                 }
                 reply = reply + "\n";
             }
             Console.WriteLine(reply);
             */
            Console.WriteLine("Your file is stored in D drive");
            Console.ReadKey();
        }
    }

    
}




