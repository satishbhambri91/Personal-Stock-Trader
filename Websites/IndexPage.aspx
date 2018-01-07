<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexPage.aspx.cs" Inherits="IndexPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>HTML Table Header</title>
    <style type="text/css">
        .auto-style1 {
            width: 599px;
        }
        .auto-style2 {
            height: 223px;
        }
        .auto-style3 {
            width: 599px;
            height: 223px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Welcome to Personal Stock Trading Application
        <br />
        <br />
        This application consists of following four parts :<br />
        Public Page (IndexPage.aspx) : This page lists the functionality of the application. This application is a personal stock trading application. You can see the live stock prices, get historical data for the stocks, Buy/Sell stocks and manage account.
        <br />
        <br />
        This application consists of two parts :
        <br />
        1. Staff <br />
        2. Normal Users.
        <br />
        <br />
        Staff account is again of two types :
        <br />
        1. Sysadmin (Admin2) : View the information for the Normal Users and Set their account status as verified or not verified and send any notification to the user. <br />
        2. Normadmin (Admin1) : View the information but cannot modify.
        <br />
        <br />
        End users can sign up for this application using the Normal users button, which takes them to the login/signup page, where they can sign up.
        <br />
        <br />
        Staff can also use this application to trade using their accounts.
        <br />
        Kindly click on the corresponding button to access the application :
        <br />
        <br />
        <asp:Button ID="NormalUsersButton" runat="server" OnClick="NormalUsersButton_Click" Text="Normal Users" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="StaffButton" runat="server" OnClick="StaffButton_Click" Text="Staff" Width="174px" />
    
        <br />
        <br />
        User Pages :
        <br />
        View Stocks Page<br />
        Banking Page<br />
        Transact Page<br />
        <br />
        Staff Pages :<br />
        View User Info<br />
        Verify User Info<br />
        <br />
        For testing, following are the admin credentials and the user credentials :<br />
        <br />
        Admin credentials :<br />
        <br />
        Username: Admin1<br />
        Password: Admin1<br />
        Admin1 account can just see the user information and update the account verification status, but cannot send the notification to any other user.
        <br />
        <br />
        Username: Admin2<br />
        Password: Admin2<br />
        Admin2 account can also send the notifications to the users alongside updating the verification status and viewing the information.
        <br />
        <br />
        User Credentials :<br />
        <br />
        Username : abc&nbsp;&nbsp; <br />
        Password : abc<br />
        <br />
        Username : Rubaina<br />
        Password : singh<br />
        <br />
        Username: satish&nbsp;&nbsp;&nbsp;
        <br />
        Password: satish<br />
        <br />
        State Management :<br />
        XML files for users and admins<br />
        Cookies
        <br />
&nbsp;<br />
        These have been implemented using forms based authentication.
        <br />
        <br />
        Local component layer : Encryption Class Library (DLL)<br />
        <br />
        Admin can access the application from users perspective and transact stocks as users but to access the users pages, he needs to click on the normal users button.
        <br />
        <br />
        Services used in this application are :<br />
        (Remote Service Layer)<br />
        <br />
        Google Finance Api (Public Service) :<br />
        <a href="https://www.google.com/finance/historical?q=NYSE%3aIBM">https://www.google.com/finance/historical?q=NYSE%3aIBM</a><br />
        (Say, user enters IBM)<br />
        <br />
        ASU Stock Service (Public Service) :<br />
        <a href="http://neptune.fulton.ad.asu.edu/WSRepository/Services/Stockquote/Service.svc?wsdl">http://neptune.fulton.ad.asu.edu/WSRepository/Services/Stockquote/Service.svc?wsdl</a><br />
        <br />
        Image Verifier Service :
        <br />
        <a href="http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifierSvc/Service.svc?wsdl">http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifierSvc/Service.svc?wsdl</a><br />
        <br />
        Login Service :<br />
        <a href="http://webstrar6.fulton.asu.edu/Page8/Service1.svc?wsdl">http://webstrar6.fulton.asu.edu/Page8/Service1.svc?wsdl</a><br />
        <br />
        Stock Service :<br />
        <a href="http://webstrar6.fulton.asu.edu/page7/Service1.svc?wsdl">http://webstrar6.fulton.asu.edu/page7/Service1.svc?wsdl</a><br />
        <br />
        Banking Service :<br />
        <a href="http://webstrar6.fulton.asu.edu/page6/Service1.svc/">http://webstrar6.fulton.asu.edu/page6/Service1.svc/</a><br />
        <br />
        Transact Service :<br />
        <a href="http://webstrar6.fulton.asu.edu/page4/Service1.svc?wsdl">http://webstrar6.fulton.asu.edu/page4/Service1.svc?wsdl</a><br />
        <br />
        <html>
        <body>
            <br />
            <br />
            <br />
<table border="1">
<tr><th bgcolor = "#c1ff32" colspan = "10">This is deployed at:<a href="http://webstrar6.fulton.asu.edu/page5/IndexPage.aspx">http://webstrar6.fulton.asu.edu/page5/IndexPage.aspx</a>  </th></tr>
<tr><th bgcolor = "#c1ff32" colspan = "10">This project is developed by: Satish Bhambri</th></tr>

<tr>
<th>Provider name</th>
<th>Service name with input and output types</th>
<th>TryIt link</th>
<th class="auto-style1">Service description</th>
<th>Actual resources used to implement the service
</th>
</tr>

<div>
<tr>
<td>Satish Bhambri</td>
<td>View stocks service input:string Output:List of Data, Live stock values</td>
<td><a href="http://webstrar6.fulton.asu.edu/page5/Login.aspx?ReturnUrl=%2fpage5%2fUsers%2fView+Stocks+Page.aspx">View Stocks TryIt</a></td>
<td class="auto-style1">It displays the live prices of the stocks, their symbols and companies. Enter the symbol of any particular stock to view the historical data and live prices of that stock. </td>
<td>Implemented using the ASU finance Api to fetch the live prices and google finance api to fetch a csv of the historical data of the stocks.</td>
</tr>
</br>
<div background-color="#c1ff32">
<tr>
<td>Satish Bhambri</td>
</br>
<td>Transact Stock Service input:int Output:int</td>
<td><a href="http://webstrar6.fulton.asu.edu/page5/Users/Transact Service Page.aspx">Transact Stock TryIt</a></td>
<td class="auto-style1">Buy or Sell stocks, based on the balance in your account</td>
<td>This service has been implemented from scratch, though it uses the banking service for the account details and valid amount</td>
</tr>
</div>

<div>
</br>
<tr>
<td>Satish Bhambri</td>
<td>Banking Service for Stock Account input:string Output:string</td>
<td><a href="http://webstrar6.fulton.asu.edu/page5/Users/Bank Account Page.aspx">Banking Account TryIt Page</a></td>
<td class="auto-style1">Deposits, Withdraw and checks Account.</td>
<td>This service has been implemented from scratch</td>
</tr>
</div>
</br>
<div background-color="#c1ff32" >
<tr>
<td class="auto-style2">Satish Bhambri</td>
</br>
<td class="auto-style2">Login Service input:User Credentials Output:User Data</td>
<td class="auto-style2"><a href="http://webstrar6.fulton.asu.edu/page5/Admin1/UsersInfo.aspx">Admin 1</a>
    <a href="http://webstrar6.fulton.asu.edu/page5/Admin1/Admin2/VerifyUserInfo.aspx">Admin 2</a></td>
<td class="auto-style3">This Service signs up a new user, logs in existing user and displays the user data on the staff page.</td>
<td class="auto-style2">This service has been implemented from the scratch. Used XML for data management. </td>
</tr>
</div>
</br>
<div>

</div>


</table>
</body>
</html>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
