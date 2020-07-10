using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingDB {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QueriesPage : ContentPage {
		public QueriesPage() {
			InitializeComponent();
		}
		private void OnClicked(object sender, EventArgs e) {
			TimeSpan hour = new TimeSpan(1, 0, 0);
            lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                             where activity.Sport.Equals("Running") && activity.Duration >= hour
							 select activity;
		}

        private void HrRunDates_Clicked(object sender, EventArgs e)
        {
            TimeSpan hour = new TimeSpan(1, 0, 0);
            lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                             where activity.Sport.Equals("Running") && activity.Duration >= hour
                             select activity.DatePerformed;
        }

        private void HrRunDateDuration_Clicked(object sender, EventArgs e)
        {
            TimeSpan hour = new TimeSpan(1, 0, 0);
            lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                             where activity.Sport.Equals("Running") && activity.Duration >= hour
                             select (activity.DatePerformed, activity.Duration);
        }

        private void LRunAll_Clicked(object sender, EventArgs e)
        {
            // in LongActivityDefitions file long.txt is defines a long run to be one hour. This is the same as above queries. The wording makes it seem we only needed to check
            // what this length was and then use it as a timespan, leading to this identical code. I am not sure if I am supposed to be accessing another database instead. 
            // I think I could also simply query the long activites somehow 
            TimeSpan hour = new TimeSpan(1, 0, 0); 
            lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                             where activity.Sport.Equals("Running") && activity.Duration >= hour
                             select activity;
        }
        //var theTable = DB.conn.Table<Activity>();
        private void Calories_Clicked(object sender, EventArgs e)
        {
            var theTable = DB.conn.Table<Activity>();
            lv.ItemsSource = theTable.AsEnumerable().Where(s => s.Calories > 499).ToList();
        }
    }
}