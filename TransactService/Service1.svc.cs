using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TransactService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Uri baseUri = new Uri("http://webstrar6.fulton.asu.edu/page6/Service1.svc/");
        public string BuyStock(string name, int value)
        {
            try
            {

                double stockprice = 10.0;
                double net = stockprice * value;
                //BankingServiceReference.Service1Client bankAc = new BankingServiceReference.Service1Client();

                //bool flag = bankAc.AmountCheck(net);

                UriTemplate myTemplate = new UriTemplate("AmountCheck?value={value}");

                Uri completeUri = myTemplate.BindByPosition(baseUri, net.ToString());

                WebClient proxy = new WebClient();

                byte[] abc = proxy.DownloadData(completeUri);
                Stream strm = new MemoryStream(abc);
                DataContractSerializer obj = new DataContractSerializer(typeof(Boolean));
                Boolean flag = Convert.ToBoolean(obj.ReadObject(strm));

                if (flag)
                {
                    UriTemplate myTemplate1 = new UriTemplate("WithdrawAmount?value={value}");

                    Uri completeUri1 = myTemplate1.BindByPosition(baseUri, net.ToString());

                    WebClient proxy1 = new WebClient();

                    byte[] abc1 = proxy.DownloadData(completeUri1);
                    Stream strm1 = new MemoryStream(abc1);
                    DataContractSerializer obj1 = new DataContractSerializer(typeof(string));
                    string returndval = obj1.ReadObject(strm1).ToString();
                    //return returndval;
                    return "Buy Successfull.." + "You have bought the stock " + name + "currently priced at $" + stockprice + "Transaction totalling to $" + net;
                }
                else
                {
                    return "Insufficient funds.. Please add sufficient funds in the Bank Account";
                }
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
        public string SellStock(string name, int value)
        {
            try
            {
                double stockprice = 10.0;
                double net = stockprice * value;
                // BankingServiceReference.Service1Client bankAc = new BankingServiceReference.Service1Client();
                //bankAc.DepositAmount(net);
                UriTemplate myTemplate = new UriTemplate("DepositAmount?value={value}");

                Uri completeUri = myTemplate.BindByPosition(baseUri, net.ToString());

                WebClient proxy = new WebClient();

                byte[] abc = proxy.DownloadData(completeUri);
                Stream strm = new MemoryStream(abc);
                DataContractSerializer obj = new DataContractSerializer(typeof(string));
                // Boolean flag = Convert.ToBoolean(obj.ReadObject(strm));
                return "Sold Successfully..";
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
}
