using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TrilmDataAccess;

namespace TrilmDataAccessExample
{
    public partial class MainPage : ContentPage
    {
        private ClientServices clientServices;

        public MainPage()
        {
            InitializeComponent();

            TrilmDataAccess.WebServices.Address = @"http://192.168.247.2:8080/DataAccess.ashx";
            clientServices = new ClientServices();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var query = TrilmDataAccess.DataQuery.Create("Security", "ws_Session_List", new
            {
                FacID = 2
            });
             query += TrilmDataAccess.DataQuery.Create("Security", "ws_Session_List", new
            {
                FacID = 1
            });

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var result = await clientServices.ExecuteAsync(query);
           
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
                   
            if(clientServices.LastError=="")
            {
                lblStatus.Text = string.Format("Return rows {2}.Execution time of a method {0} s {1} ms: ",watch.Elapsed.Seconds,watch.Elapsed.Milliseconds,result.Tables[0].Rows.Count+ result.Tables[1].Rows.Count);
            }
            else
            {
                lblStatus.Text = clientServices.LastError;
            }
        }
    }
}
