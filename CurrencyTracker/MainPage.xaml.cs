using CurrencyTracker.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CurrencyTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		private List<Check> Checks;

        public MainPage()
        {
            this.InitializeComponent();

			Checks = new List<Check>();

        }

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var list = new List<Check>();
			var c = new Check { Amount = 1000.717273M, Title = "Title", DateTime = DateTime.Now, Description = "Foofds;kdsjfds;klkfjds;gljdsg;lkajf;adslkfjasd;lkfjasd;flkjadsf'kasdljf'asdklfjasdfkl'jed'l\nfdsjf;sdkjfsd;lfkjsd;fgkjsdf;dslkjfsad;klfsdd;lfsdf\nsdf;sdjf;dsfjsd;lkfjsd;fklkjsd;fkdsjf;dsllkjf bar" };
			list.Add(c);
			ChecksList.ItemsSource = list;
		}

		private void ChecksList_ItemClick(object sender, ItemClickEventArgs e)
		{
			
		}

		private void AddCheckBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
