# TrilmDataAccessExample

Step 1: Please download webservice:http://www.mediafire.com/file/9dswmw1bf8s28rt/WebServices.rar

IIS Install Note:
- Remember check IIS-> WWW-> ASP.NET
- Convert your webservices website to .NET 4.0
- Enable Dicrectory Browsing
- Run run %windir%\Microsoft.NET\Framework\v4.0.21006\aspnet_regiis.exe -i if ASP.NET 4.0 is installed incorrect

Step 2: Publish Webservices to IIS

Step 3: Change Connection Strings with your SQL server account

Step 4: Create your sql stored procedure( must have prefix ws_ and a parameter :  @SessionID VARCHAR(MAX) (we use SessionID to credentials,disconnect application,get userID...)

Step 5: Install TrilmDataAccess Package from nuget( PCL Profile 111)

Step 6: using TrilmDataAccess

Step 7: Set your webservices address and inital servers
TrilmDataAccess.WebServices.Address = @"http://192.168.247.2:8080/DataAccess.ashx";
clientServices = new ClientServices();

Step 8: Call stored procedure and get result
var query = TrilmDataAccess.DataQuery.Create("Security", "ws_Session_List", new
{
                FacID = 2
});
query += TrilmDataAccess.DataQuery.Create("Security", "ws_Session_List", new
{
                FacID = 1
});

var watch = System.Diagnostics.Stopwatch.StartNew();
var result = await clientServices.ExecuteAsync(query);//return dataset

Note: if you want List<> please your FastMember to connect datatable to List<>

Support  async-await, compress data,cache ,call many stored procedure at a time,  transaction rollback.disconnect client from database,write once, use webservices forever 
