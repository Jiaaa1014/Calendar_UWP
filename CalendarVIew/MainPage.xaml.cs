using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace CalendarVIew
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            OriginCollection = new ObservableCollection<DoctorInfo>
            {
                new DoctorInfo {Name = "Huang", AvatarUrl = "https://api.adorable.io/avatars/6", Date = DateTime.Now},
                new DoctorInfo {Name = "Liang", AvatarUrl = "https://api.adorable.io/avatars/66", Date = DateTime.Now.AddDays(2)},
                new DoctorInfo {Name = "Tsu", AvatarUrl = "https://api.adorable.io/avatars/677", Date = DateTime.Now.AddDays(2)},
                new DoctorInfo {Name = "Lin", AvatarUrl = "https://api.adorable.io/avatars/64", Date = DateTime.Now.AddDays(5)},
                new DoctorInfo {Name = "Wang", AvatarUrl = "https://api.adorable.io/avatars/34", Date = DateTime.Now.AddDays(5)}
            };
        }

        public ObservableCollection<DoctorInfo> OriginCollection;
        private void SmallCalendar_OnSelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            if(sender.SelectedDates.Count == 0)
            {
                return;

            }
            BigCalendar.SetDisplayDate(sender.SelectedDates.FirstOrDefault());
        }

        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            if (args.Item.Date.Date.Equals(DateTime.Now))
            {
                args.Item.SetDensityColors(new List<Color>{ Colors.Red, Colors.AliceBlue });
            }

            foreach (var a in OriginCollection)
            {
                if (args.Item.Date.Date.Equals(a.Date))
                {
                }   
            }
        }
    }
}
