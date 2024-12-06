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
        struct _eventObject
        {
            public string Name { get; set; }
            public string EventType { get; set; }
            public int Visitors { get; set; }
        }

        List<_eventObject> _events = new List<_eventObject>();
        List<string> _eventTypes = new List<string>() { "Festival", "Orkest", "Opera" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            eventTypeComboBox.Items.Clear();

            foreach(string et in _eventTypes)
            {
                //ComboBoxItem newItem = new ComboBoxItem();
                //newItem.Content = et;
                //eventTypeComboBox.Items.Add(newItem);
                eventTypeComboBox.Items.Add(et);
            }
        }

        private void OnCreateEventButtonClick(object sender, RoutedEventArgs e)
        {
            //TODO: validatie
            if (eventTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Slecht bezig!");
                return;
            }

            if(string.IsNullOrEmpty(eventNameTextBox.Text))
            {
                MessageBox.Show("Nog altijd slecht bezig");
                return;
            }

            if(!int.TryParse(eventVisitorsTextBox.Text, out _))
            {
                MessageBox.Show("Even slecht bezig");
                return;
            }


            _eventObject newEvent = new _eventObject();
            newEvent.Name = eventNameTextBox.Text;
            newEvent.EventType = eventTypeComboBox.SelectedValue.ToString();
            newEvent.Visitors = int.Parse(eventVisitorsTextBox.Text);

            _events.Add(newEvent);
            ShowEvents();
        }

        private void OnDeleteEventButtonClick(object sender, RoutedEventArgs e)
        {
            if (eventsListBox.SelectedIndex != -1)
            {
                _events.RemoveAt(eventsListBox.SelectedIndex);

                ShowEvents();
            }
        }

        private void OnDeleteAllEventsClick(object sender, RoutedEventArgs e)
        {
            _events.Clear();

            ShowEvents();
        }

        private void OnCreateDefaultEventClick(object sender, RoutedEventArgs e)
        {
    
            _eventObject newEvent = new _eventObject();
            newEvent.Name = "Jaarlijks optreden";
            newEvent.EventType = "Orkest";
            newEvent.Visitors = 100;

            _events.Add(newEvent);

            ShowEvents();
        }

        private void ShowEvents()
        {
            eventsListBox.Items.Clear();
            foreach (_eventObject e in _events)
            {
                string eventText = $"{e.EventType} - {e.Name}: {e.Visitors}";
                eventsListBox.Items.Add(eventText);
            }
        }

        private void OnCloseMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }


    public class EventObject
    {
        public string Name { get; set; }
        public string EventType { get; set; }

        public EventObject(string name, string eventType)
        {
            
        }

        public override string ToString()
        {
            return this.Name + " (" + EventType + ")";
        }
    }
}