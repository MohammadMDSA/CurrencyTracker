﻿using CurrencyTracker.Models;
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
		private static decimal Total = 0m;

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
			var checklistItems = new List<CheckListItem>();
			var total = Total;

			foreach (var item in Checks)
			{
				int coe = 1 * (item.IsDeposit ? 1 : -1);
				total += coe * item.Amount;
				checklistItems.Add(new CheckListItem { Total = total, Check = item });
			}

			checklistItems.Reverse();

			ChecksList.ItemsSource = checklistItems;
		}

	}

	public class ColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var deposit = (bool)value;

			return new SolidColorBrush(deposit ? Colors.Green : Colors.Red);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class ArrowConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var deposit = (bool)value;

			return deposit ? "\uE74A" : "\uE74B";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
