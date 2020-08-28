using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AgendaApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            EventService = RestService.For<IEventsService>("https://azureupwardapi2020.azurewebsites.net/");

            this.BindingContext = this;
        }

        public IEventsService EventService { get; private set; }

        public ObservableCollection<Session> MyAgenda { get ; } =  new ObservableCollection<Session>();

        protected override async void OnAppearing()
        {
            var sesiones = await EventService.GetSessions();

            foreach (var session in sesiones)
            {
                session.color = Colors[new Random().Next(0, Colors.Length)];
            }

            MyAgenda.Clear();
            sesiones.ForEach(a => MyAgenda.Add(a));
        }

        public string[] Colors = new[] { "#B96CBD" , "#49A24D" , "#FDA838", "#F75355", "#00C6AE", "#00C6AE" };
    }
}
