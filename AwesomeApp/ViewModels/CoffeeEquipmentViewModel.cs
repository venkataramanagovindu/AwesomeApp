namespace AwesomeApp.ViewModels
{
    using AwesomeApp.Models;
    using MvvmHelpers;
    using command = MvvmHelpers.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using System.Windows.Input;

    class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> CoffeeList { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }

        string image = "https://media.istockphoto.com/id/1443305526/photo/young-smiling-man-in-headphones-typing-on-laptop-keyboard.jpg?s=2048x2048&w=is&k=20&c=YbyIE-QkVeacJODEhS5_LQzJahwiTmZTnism-xUwCLA=";
        public command.AsyncCommand RefreshCommand { get; }
        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";

            CoffeeList = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            CoffeeList.Add(new Coffee { Name = "Blue Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Orange Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Ice Coffee", Image = "Some3.png", Roaster = "Wait" });
            CoffeeList.Add(new Coffee { Name = "Blue Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Orange Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Ice Coffee", Image = "Some3.png", Roaster = "Wait" });
            CoffeeList.Add(new Coffee { Name = "Blue Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Orange Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Ice Coffee", Image = "Some3.png", Roaster = "Wait" });
            CoffeeList.Add(new Coffee { Name = "Blue Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Orange Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Ice Coffee", Image = "Some3.png", Roaster = "Wait" });
            CoffeeList.Add(new Coffee { Name = "Blue Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Orange Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Ice Coffee", Image = "Some3.png", Roaster = "Wait" });
            CoffeeList.Add(new Coffee { Name = "Blue Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Orange Coffee", Image = image, Roaster = "Yes please" });
            CoffeeList.Add(new Coffee { Name = "Ice Coffee", Image = "Some3.png", Roaster = "Wait" });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Wait", CoffeeList.Take(1)));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes", CoffeeList.Take(2)));



            IncreaseCount = new command.Command(OnClick);
            RefreshCommand = new command.AsyncCommand(HideRefreshButton);
        }
        int count = 0;
        string countDisplay = "Click Me! ";
        public ICommand IncreaseCount { get; }


        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }
        //set
        //{
        //    if (value == countDisplay)
        //        return;
        //    countDisplay = value;
        //    OnPropertyChanged();
        //}

        async Task HideRefreshButton()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }

        void OnClick()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }

        //private void ButtonClick_Clicked(object sender, EventArgs e)
        //{

        //}

        private void ListView_ItemSelected(Object sender, SelectedItemChangedEventArgs args)
        {

        }
        private void ListView_ItemTapped(Object sender, ItemTappedEventArgs itemTappedEvent)
        {

        }
        private void MenuItem_Clicked(Object sender, EventArgs e)
        {

        }

        Coffee selectedCoffee;
        Coffee prevSelected;
        public Coffee SelectedCOffee
        {
            get => selectedCoffee;
            set
            {
                if(value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "OK");
                    prevSelected = value;
                    value = null;
                }
                selectedCoffee = value;
                OnPropertyChanged();
            }
        }

    }
}
'