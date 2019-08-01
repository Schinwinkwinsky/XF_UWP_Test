using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UWPTest.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MasterPage, MasterItem>(this, "SelectedItem", OnSelectedItem);
        }

        public MainPage(Type master, Type detail)
        {
            InitializeComponent();

            Master = (Page) Activator.CreateInstance(master);

            Detail = new NavigationPage((Page) Activator.CreateInstance(detail));

            MessagingCenter.Subscribe<MasterPage, MasterItem>(this, "SelectedItem", OnSelectedItem);
        }

        private async void OnSelectedItem(MasterPage sender, MasterItem masterItem)
        {
            if (masterItem.Title.Equals("Account"))
            {
                if (App.isLogged)
                    Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(AccountPage)));
                else
                    await Navigation.PushModalAsync(new NavigationPage(new SignInPage()));
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(masterItem.TargetType));
            }

            IsPresented = false;
        }
    }
}