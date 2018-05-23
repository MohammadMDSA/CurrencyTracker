using CurrencyTracker.Models;
using CurrencyTracker.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CurrencyTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		private static List<Check> Checks = new List<Check>();

        public MainPage()
        {
            this.InitializeComponent();
        }

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			Check check;
			if (( check = e.Parameter as Check) != null){
				Checks.Add(check);
			}

			Checks.Add(new Check { Amount = 100, DateTime = DateTime.Now, Description = "Desc", IsDeposit = true, Title = "Title" });
			Checks.Add(new Check { Amount = 100, DateTime = DateTime.Now, Description = "Desc", IsDeposit = false, Title = "Title" });

			UpdateUI();
		}

		private void ChecksList_ItemClick(object sender, ItemClickEventArgs e)
		{
			
		}

		private void AddCheckBtn_Click(object sender, RoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(AddCheck));
		}

		private void UpdateUI()
		{
			Checks.Reverse();
			ChecksList.ItemsSource = Checks;
			Checks.Reverse();
		}

	}

	public class ColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var deposit = (bool)value;

			return new SolidColorBrush(deposit ? Color.FromArgb(40, 0, 255, 0) : Color.FromArgb(40, 255, 0, 0));
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
