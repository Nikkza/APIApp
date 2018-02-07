using System;
using System.Drawing;
using System.Windows.Forms;

namespace APIApplication
{

    public partial class Form1 : Form
    {
        DataHandler dataH;
        DataBaseRepository DbRep;
        Timer fadeTimer;

        public Form1()
        {
            InitializeComponent();
            DbRep = new DataBaseRepository();
            dataH = new DataHandler();
            dataH.FetchStations(Stationbox);
            DbRep.LoadDeparture(SavedDeparture);
            fadeTimer = new Timer() { Interval = 8000 };
            fadeTimer.Tick += new EventHandler(TimerEventProcessor);

        }


        private void Stationbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbRep.AddTrainStations((string)Stationbox.SelectedItem, SavedDeparture);
            SavedDeparture.Items.Clear();
            DbRep.LoadDeparture(SavedDeparture);
           
            ListboxName.Items.Clear();
            string shortstationname = dataH.GetStationShortName(Stationbox.SelectedIndex);
            dataH.FetchArrivalDeparture(ListboxName, shortstationname);

        }

        private void ListboxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            fadeTimer.Stop();
            label_TrainMsg.Text = "";
            int TrainNr = dataH.GetTrainNr(ListboxName.SelectedIndex);
            string StationShortName = dataH.GetStationShortName(Stationbox.SelectedIndex);
            string ArrivalTime = dataH.GetTrainTime(ListboxName.SelectedIndex);

            label_TrainMsg.BackColor = System.Drawing.Color.Thistle;
            dataH.FetchTrainMessages(label_TrainMsg, TrainNr, StationShortName, ArrivalTime);
            fadeTimer.Start();
            
        }

        private void Stationbox_KeyDown(object sender, KeyEventArgs e)
        {
            Stationbox.DroppedDown = true;
          
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            fadeTimer.Stop();
            label_TrainMsg.Text = "";
            label_TrainMsg.BackColor = System.Drawing.Color.Transparent;
        }

        private void SavedDeparture_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in Stationbox.Items)
            {
                if (SavedDeparture.SelectedItem.ToString() == item.ToString())
                {
                    Stationbox.SelectedValue = item;
                    Stationbox.SelectedItem = item;
                    Stationbox.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }
    }
}

