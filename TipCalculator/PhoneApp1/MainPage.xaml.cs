using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TipCalculator.Resources;

namespace TipCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        int splitAmong;
        int tipPercentage;
        double splitAmount;
        double total;
        double mealCost;
        double tipAmount;


        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            tipPercentage = 15; // Set initial tip percentage to 15%
            slider1.Value = tipPercentage; // Set the slider to start at 15%
            txtTipPercentage.Text = tipPercentage.ToString() + "%"; // Concat "%" to the tip percentage
            splitAmong = 1; // Set initial value of split among to 1
            txtSplitAmong.Text = splitAmong.ToString(); // Set the text box that will contain value for split among to 1
        }

        // Calculate all values, given the meal's cost
        private void initCalculations()
        {
            try
            {
                mealCost = double.Parse(txtMealCost.Text);

                tipAmount = (tipPercentage / 100.0) * mealCost; // The total tip for the bill
                txtTipAmount.Text = tipAmount.ToString("C2"); // String representation of the tip

                total = mealCost + tipAmount; // The total cost including tip is the meal's cost plus the tip amount
                txtTotal.Text = total.ToString("C2"); // String representation of the total cost

                splitAmount = total / splitAmong; // Calculate the amount each person has to pay, with the tip included
                txtSplitAmount.Text = splitAmount.ToString("C2"); // String representation of the split amount
            }
            catch { }
        }

        private void calculate(object sender, System.Windows.Input.GestureEventArgs e)
        {
            initCalculations();
        }

        // Update the tip percentage based on where the slider is
        private void tipChanges(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                tipPercentage = (Int16)slider1.Value; // Adjust the tip percentage according to where the slider is
                txtTipPercentage.Text = tipPercentage.ToString() + "%";
                initCalculations();

            }
            catch { }
        }

        // Decrement the split among value by one for every down tap
        private void downTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (splitAmong > 1)
                splitAmong--;
            txtSplitAmong.Text = splitAmong.ToString();
            initCalculations();
        }

        // Increment the split among value by one for every up tap
        private void upTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            splitAmong++;
            txtSplitAmong.Text = splitAmong.ToString();
            initCalculations();
        }

        private void initCalculations(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }



        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}