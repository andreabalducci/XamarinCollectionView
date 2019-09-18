using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamlist.ViewModels;

namespace xamlist.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsCollectionPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsCollectionPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}