using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfStockService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service1 : IService1
    {
        public List<string[]> GetStockLiveData()
        {
            try
            {
               // List<string[]> LiveData = new List<string[]>();
                ASUStockServiceReference.ServiceClient client = new ASUStockServiceReference.ServiceClient();
                List<string[]> data = new List<string[]>();
               // var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                //var iconPath = "~/App_Data/companylist.csv";
                //var iconPath = System.Web.Hosting.HostingEnvironment.MapPath("~/companylist.csv");
              //  string fileurl = new Uri(iconPath).LocalPath;
                //string fileurl = "~/App_Data/companylist.csv";

                var readfile = File.OpenRead(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/CompanyData.csv"));
                var reader = new StreamReader(readfile);
                while (!reader.EndOfStream)
                {
                    var readitem = reader.ReadLine().Split(',');
                    data.Add(readitem);
                }
                //foreach (var item in data)
                //{
                //   // string quote = client.getStockquote(item[0]);
                //    LiveData.Add(item[0], "representing : " + item[1] + " of the sector :" + item[5] + "with Market cap of : " + item[3] + " is currently priced at :");
                //}

                return data;
            }
            catch(Exception ex)
            {
                List<string[]> exceptionList = new List<string[]>();
                string[] message = null;
                message[0] = ex.Message;
                exceptionList.Add(message);
                return exceptionList;
            }
        }

        public string getHistData(string symbol) 
        {
            try
            {
                DateTime tenDaysPast = DateTime.Now.Subtract(TimeSpan.FromDays(10));
                StringBuilder textString = new StringBuilder();
                WebClientForStockFinanceHistory wc1 = new WebClientForStockFinanceHistory();
                Dictionary<DateTime, StockDataItem> downloadedStockData;

                downloadedStockData = wc1.getStockDataFromYahoo(symbol, tenDaysPast, DateTime.Now);

                textString.AppendLine("Historical Data for the Stock");
                List<string> hdatalist = new List<string>();
                foreach (KeyValuePair<DateTime, StockDataItem> singleItem in downloadedStockData)
                {
                    textString.AppendLine(singleItem.Key.ToShortDateString() +
                        ";" +
                        singleItem.Value.open.ToString("0.0") + ";" +
                        singleItem.Value.close.ToString("0.0") + ";" +
                        singleItem.Value.high.ToString("0.0") + ";" +
                        singleItem.Value.low.ToString("0.0") + ";" +
                        singleItem.Value.volume +
                    "&"
                        );
                }
                string DataResult = textString.ToString();
                return DataResult;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
    public class WebClientForStockFinanceHistory
    {
        WebClient webConnector;
        //const string yahooAddress = "http://real-chart.finance.yahoo.com/table.csv?s=[-|ticker|-]&[-|sdate|-]&[-|edate|-]&g=d&ignore=.csv";
        //const string yahooAddress = "http://finance.yahoo.com/q/hp?s=[-|ticker|-]+Historical+Prices";
        const string yahooAddress = "https://www.google.com/finance/historical?q=NYSE%3A[-|ticker|-]&output=csv";
        public Dictionary<DateTime, StockDataItem> getStockDataFromYahoo(string ticker, DateTime startDate, DateTime endDate)
        {
            return fillDataDictionary(getData(constructYahooLink(ticker, startDate, endDate)));
        }

        string constructYahooLink(string ticker, DateTime startDate, DateTime endDate)
        {
            string constructedUri = yahooAddress;
            constructedUri = constructedUri.Replace("[-|ticker|-]", ticker);
            string constructedStartDate =
                "a=" + (startDate.Month - 1).ToString() +
                "&b=" + startDate.Day.ToString() +
                "&c=" + startDate.Year.ToString();


            string constructedendDate =
                "d=" + (startDate.Month - 1).ToString() +
                "&e=" + startDate.Day.ToString() +
                "&f=" + startDate.Year.ToString();
            constructedUri = constructedUri.Replace("[-|sdate|-]", constructedStartDate);
            constructedUri = constructedUri.Replace("[-|edate|-]", constructedendDate);
            // Console.WriteLine(constructedUri);
            return constructedUri;
        }
        string getData(string webpageUriString)
        {
            string tempStorageString = "";
            if (webpageUriString != "")
            {
                using (webConnector = new WebClient())
                {
                    using (Stream responseStream = webConnector.OpenRead(webpageUriString))
                    {
                        using (StreamReader responseStreamReader = new StreamReader(responseStream))
                        {
                            tempStorageString = responseStreamReader.ReadToEnd();
                            tempStorageString = tempStorageString.Replace("\n", Environment.NewLine);
                        }
                    }
                }

            }
            //Console.WriteLine(tempStorageString);
            return tempStorageString;
        }
        Dictionary<DateTime, StockDataItem> fillDataDictionary(string csvData)
        {
            Dictionary<DateTime, StockDataItem> parsedStockData = new Dictionary<DateTime, StockDataItem>();
            using (StringReader reader = new StringReader(csvData))
            {
                string csvLine;
                reader.ReadLine();
                //Console.WriteLine(reader.ReadLine().ToString());
                while ((csvLine = reader.ReadLine()) != null)
                {
                    string[] splitLine = csvLine.Split(',');
                    // Console.WriteLine("splitLine"+ splitLine[2]);
                    if (splitLine.Length >= 6)
                    {
                        StockDataItem newItem = new StockDataItem();
                        double tempOpen;
                        if (Double.TryParse(splitLine[1], out tempOpen))
                        {
                            newItem.open = tempOpen;
                            //Console.WriteLine("look here"+tempOpen);
                        }
                        double tempHigh;
                        if (Double.TryParse(splitLine[2], out tempHigh))
                        {
                            newItem.high = tempHigh;
                        }
                        double tempLow;
                        if (Double.TryParse(splitLine[3], out tempLow))
                        {
                            newItem.low = tempLow;
                        }
                        double tempClose;
                        if (Double.TryParse(splitLine[4], out tempClose))
                        {
                            newItem.close = tempClose;
                        }
                        double tempVolume;
                        if (Double.TryParse(splitLine[5], out tempVolume))
                        {
                            newItem.volume = tempVolume;
                        }
                        DateTime tempDate;
                        if (DateTime.TryParse(splitLine[0], out tempDate))
                        {
                            parsedStockData.Add(tempDate, newItem);
                        }
                    }
                }
            }
            //Console.WriteLine("parsedStockData:" + parsedStockData.Count);
            //foreach (KeyValuePair<DateTime, StockDataItem> kvp in parsedStockData)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value.high);
            //}
            return parsedStockData;
        }

        public void getStockData() { }
    }
    public class StockDataItem
    {
        public double open = 0;
        public double high = 0;
        public double low = 0;
        public double close = 0;
        public double volume = 0;
    }
    
}
