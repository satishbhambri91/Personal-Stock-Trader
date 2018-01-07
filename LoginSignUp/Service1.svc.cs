using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using EncryptionClassLibrary;

namespace LoginSignUp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Class1 EncryptionDecryptionObject = new Class1();
        public void SignUp(string username, string password, string email, string acno, string bankaddr)
        {
            
            
            //Taking the username and password as input from the user and store it in an xml file

            //Finding the path of the xml file and store it in a variable.
            var fullpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Users.xml");
           // var fullpath2 = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Staff.xml");
            XmlDocument xdoc = new XmlDocument();
            //We load the xml document
            xdoc.Load(fullpath);
            XmlNodeList nodel = xdoc.GetElementsByTagName("Username");
            string acverification = "Not Verified";
            var doc = XDocument.Load(fullpath);
            var newElement = new XElement("user",
                      new XElement("Username", username),
                      new XElement("Password", password),
                      new XElement("Email", email),
                      new XElement("AccountNumber",acno),
                      new XElement("BankAddr",bankaddr),
                      new XElement("AccountStatus",acverification));
            doc.Element("users").Add(newElement);
            //We save the document after the xml file is updated.
            doc.Save(fullpath);


        }

        //We take input from the user to check if he already signed up 
        public bool Login(string username, string password)
        {
            XmlDocument xdoc = new System.Xml.XmlDocument();
            // xdoc.Load(@"C:\Users\Pramod Kalidindi\Documents\Visual Studio 2013\Projects\Login\Login\obj\Debug\test.xml");
            //We find the path of the xml file and load it
            xdoc.Load(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Users.xml"));


            //We go through every child node in user parent node to check if the user already signed up
            foreach (XmlNode node2 in xdoc.SelectNodes("//user"))
            {
                string uname = node2.SelectSingleNode("Username").InnerText;
                string pwd = node2.SelectSingleNode("Password").InnerText;
                
                //  string uname = node2[0].InnerText;
                // string pwd = node3[0].InnerText;
               // string mpwd = EncryptionDecryptionObject.Decrypt(pwd);
                //If we find the username and and password we return a confirmation string
                if ((username == uname) && (password == pwd))
                {
                    // string confirmation = "You are already signed up!";
                    return true;
                }
                else
                {
                    XmlDocument xdoc2 = new System.Xml.XmlDocument();
                    xdoc2.Load(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Staff.xml"));
                    foreach (XmlNode admin_node in xdoc2.SelectNodes("//admin"))
                    {
                        
                        string admnuname = admin_node.SelectSingleNode("Username").InnerText;
                        string admnpwd = admin_node.SelectSingleNode("Password").InnerText;

                        string mpwd2 = EncryptionDecryptionObject.Decrypt(password);
                        if ((username == admnuname) && (mpwd2 == admnpwd))
                        {
                            // string confirmation = "You are already signed up!";
                            return true;
                        }
                    }

                }

                

            }

            // string confirmation1 = "The details you have entered are wrong. Type the correct details ";
            return false;

        }

        public string DisplayXmlData() 
        {
            try
            {
                XmlDocument xdoc = new System.Xml.XmlDocument();
                xdoc.Load(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Users.xml"));
                XmlNodeList xnlist = xdoc.SelectNodes("//user");
                string data = null;
                foreach (XmlNode node in xnlist)
                {
                    string UserName = node.SelectSingleNode("Username").InnerText;
                    string Password = node.SelectSingleNode("Password").InnerText;
                    string email = node.SelectSingleNode("Email").InnerText;
                    string bankac = node.SelectSingleNode("AccountNumber").InnerText;
                    string bankaddr = node.SelectSingleNode("BankAddr").InnerText;
                    string status = node.SelectSingleNode("AccountStatus").InnerText;
                    data = data + ("UserName :" + UserName + " Password :" + Password + " EmailId :" + email + "Bank Account number :"+ bankac+" Bank Address :"+ bankaddr+ "Account Status :" + status +";");
                }
                return data;

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public void setverificationstatus(string uname) 
        {
            try
            {
                XmlDocument xdoc = new System.Xml.XmlDocument();
                xdoc.Load(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Users.xml"));
                XmlNodeList xnlist = xdoc.SelectNodes("//user");
                foreach (XmlNode node in xnlist)
                {
                    if(node.FirstChild.InnerText == uname)
                    {
                        node.LastChild.InnerText = "Verified";
                        xdoc.Save(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Users.xml"));
                        break;
                    }
                    
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
