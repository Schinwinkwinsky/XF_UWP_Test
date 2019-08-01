using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UWPTest.Views
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = listView.SelectedItem as MasterItem;

            if (item != null)
            {
                MessagingCenter.Send(this, "SelectedItem", item);

                listView.SelectedItem = null;
            }
        }
    }

    public class MasterItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}