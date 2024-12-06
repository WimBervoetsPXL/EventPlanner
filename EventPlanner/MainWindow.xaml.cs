using System.CodeDom;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        struct EventObject
        {
            public string Name;
            public string EventType;
            public int Visitors;
        }

        List<string> _eventTypes = new List<string>() { "Festival", "Orkest", "Opera" };
        List<EventObject> _allEvents = new List<EventObject>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            eventTypeComboBox.Items.Clear();

            foreach(string type in _eventTypes)
            {
                //ComboBoxItem item = new ComboBoxItem();
                //item.Content = type;
                //eventTypeComboBox.Items.Add(item);
                eventTypeComboBox.Items.Add(type);
            }
        }

        private void OnCloseMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnCreateEventButtonClick(object sender, RoutedEventArgs e)
        {
            //TODO: Validatie

            EventObject newEvent = new EventObject();
            newEvent.Name = eventNameTextBox.Text;
            newEvent.EventType = eventTypeComboBox.SelectedValue.ToString();
            newEvent.Visitors = int.Parse(eventVisitorsTextBox.Text);

            _allEvents.Add(newEvent);

            ShowAllEvents();
        }

        private void OnDeleteEventButtonClick(object sender, RoutedEventArgs e)
        {
            if (eventsListBox.SelectedIndex != -1)
            {
                _allEvents.RemoveAt(eventsListBox.SelectedIndex);

                ShowAllEvents();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een event.");
            }
        }

        private void OnDeleteAllEventsClick(object sender, RoutedEventArgs e)
        {
            _allEvents.Clear();

            ShowAllEvents();
        }

        private void OnCreateDefaultEventClick(object sender, RoutedEventArgs e)
        {
            EventObject newEvent = new EventObject();
            newEvent.Name = "Jaarlijks optreden";
            newEvent.EventType = "Orkest";
            newEvent.Visitors = 100;

            _allEvents.Add(newEvent);

            ShowAllEvents();
        }

        private void ShowAllEvents()
        {
            eventsListBox.Items.Clear();

            foreach (EventObject e in _allEvents)
            {
                string eventDisplay = $"{e.EventType} - {e.Name}: {e.Visitors}";
                eventsListBox.Items.Add(eventDisplay);
            }
        }
    }


    //public class EventObject
    //{
    //    public string Name { get; set; }
    //    public string EventType { get; set; }

    //    public EventObject(string name, string eventType)
    //    {
            
    //    }

    //    public override string ToString()
    //    {
    //        return this.Name + " (" + EventType + ")";
    //    }
    //}
}