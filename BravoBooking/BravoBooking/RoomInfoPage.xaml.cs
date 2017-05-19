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
        public RoomInfoPage(string s)
        {
            InitializeComponent();
            //RomInfo2.Text=RoomInfoPage.TitleProperty.ToString();
            string rom = s;
            if (s[0].ToString() == "L")
            {
               string romnavn= s.Substring(8, 2);
            }
            RomInfo2.Text = rom;
            
            //string roomName = ;
            //RomInfo.Text = "Du har valgt rom:";
        }

        //metode for kalender
    }
}
