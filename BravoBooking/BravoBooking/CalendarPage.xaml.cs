using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BravoBooking
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();


        }

        private void DatePicker_OnDateSelected(Object sender, DateChangedEventArgs e)
        {
            MainLabel.Text = e.NewDate.ToString();
        }

        /*private void BookCalendar_OnClicked(Object sender, EventArgs e)
        {
            string text = MainEntry.Text;

            MainLabel.Text = "Rommet er booket" + text;
        }*/

        /*DateTime startTime = DateTime.Now;
        public DateTime StartTime
        {
            get { return startTime; }
            //set { SetProperty(ref startTime, value); }
        }

        DateTime endTime = DateTime.Now;
        public DateTime EndTime
        {
            get { return endTime; }
            //set { SetProperty(ref endTime, value); }
        }*/

    }
}
