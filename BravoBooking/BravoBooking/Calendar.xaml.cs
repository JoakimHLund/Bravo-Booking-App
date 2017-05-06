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
    public partial class Calendar : ContentPage
    {
        public Calendar()
        {
            InitializeComponent();

        }

        private void DatePicker_OnDateSelected(Object sender, DateChangedEventArgs e)
        {
            MainLabel.Text = e.NewDate.ToString();
        }

    }
}
