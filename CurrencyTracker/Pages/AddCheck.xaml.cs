using CurrencyTracker.Models;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CurrencyTracker.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AddCheck : Page
	{
		public AddCheck()
		{
			this.InitializeComponent();
		}

		private void Submitbtn_Click(object sender, RoutedEventArgs e)
		{
			if (TitleBox.Text == string.Empty || DescBox.Text == string.Empty || AmountBox.Text == string.Empty || DatePicker.Date == null)
			{
				ErrorNotif.Show("You should fill all fields...");
				return;
			}

			decimal amount;

			if (!decimal.TryParse(AmountBox.Text, out amount))
			{
				ErrorNotif.Show("Amount is not valid...");
				return;
			}

			(Window.Current.Content as Frame).Navigate(typeof(MainPage), new Check { Amount = amount, DateTime = DatePicker.Date.Value.DateTime, Description = DescBox.Text, Title = TitleBox.Text, IsDeposit = (TypeCom.SelectedIndex == 1 ? true : false)});
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(MainPage));
		}
	}
}
