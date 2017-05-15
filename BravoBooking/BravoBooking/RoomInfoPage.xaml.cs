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
    public partial class RoomInfoPage : ContentPage
    {
        public RoomInfoPage()
        {
            InitializeComponent();
            RomInfo2.Text=RoomInfoPage.TitleProperty.ToString();

            //string roomName = ;
            //RomInfo.Text = "Du har valgt rom:";
        }

        //metode for kalender
    }
}
