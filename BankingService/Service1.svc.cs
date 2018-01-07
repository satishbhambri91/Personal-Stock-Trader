using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BankingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static double netBalance;
        //Deposits the amount
        public string DepositAmount(double value)
        {
            netBalance = netBalance + value;
            return ("Deposited Successfully" + "New Balance is : " + netBalance);
        }
        //to withdraw the amount
       public string WithdrawAmount(double value) 
        {
            if (netBalance < value || netBalance == 0)
            {
                return "Not Enough Balance, Kindly Update your Account";
            }
            else
            {
                netBalance = netBalance - value;
            }
            return ("Transaction Successfull" + "New Balance is : " + netBalance);
        }
        //checks for the sufficient balance in account for withdrawing or buying stocks
       public Boolean AmountCheck(double value) 
       {
           if (value <= netBalance)
           {
               return true;
           }
           else 
           {
               return false;
           }
       }
        public string ViewAmount() 
        {
            return ("Your account currently has : " + netBalance);
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
