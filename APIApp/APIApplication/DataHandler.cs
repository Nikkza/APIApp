using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace APIApplication
{
    class DataHandler
    {

        List<TrainStationsAPIHandler.TrainStation> StationList = new List<TrainStationsAPIHandler.TrainStation>();
        List<StationArrivalDepatureAPIHandler.TrainAnnouncement> ArrivalDepartureList = new List<StationArrivalDepatureAPIHandler.TrainAnnouncement>();

        public static Uri Adress = new Uri(ImportantVariables.APIAdress);
        
        public string GetStationFullName(string LocationSignature)
        {
            foreach (var item in StationList)
            {
                if (item.LocationSignature == LocationSignature)
                {
                    return item.AdvertisedLocationName;
                }
            }
            return null;
        }

        public string GetStationShortName(int StationIndex)
        {
            return StationList[StationIndex].LocationSignature;
        }

        public int GetTrainNr(int Index)
        {
            return Int32.Parse(ArrivalDepartureList[Index].AdvertisedTrainIdent);
        }

        public string GetTrainTime(int Index)
        {
            return ArrivalDepartureList[Index].AdvertisedTimeAtLocation;
        }

        #region Stations
        public void FetchStations(ComboBox s)
        {
            WebClient webclient = new WebClient();
            webclient.UploadStringCompleted += (obj, arguments) =>
            {
                StationList = FormatStationJSON(arguments.Result);

                foreach (var item in StationList)
                {
                    s.Items.Add(item.AdvertisedLocationName);
                }
            };

            string requestBody = ImportantVariables.RequestAllStationsQuery();

            webclient.Encoding = Encoding.UTF8;
            webclient.UploadStringAsync(Adress, "POST", requestBody);
        }

        private static List<TrainStationsAPIHandler.TrainStation> FormatStationJSON(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(TrainStationsAPIHandler.RootObject));

            var ms = new MemoryStream(Encoding.GetEncoding("UTF-8").GetBytes(json));
            var data = (TrainStationsAPIHandler.RootObject)serializer.ReadObject(ms);
            return data.RESPONSE.RESULT[0].TrainStation.ToList();
        }
        #endregion


        #region TrainMessages
        public void FetchTrainMessages(Label TrainInfoLabel, int TrainNumber, string StationShortName, string ArrivalTime)
        {
            WebClient webclient = new WebClient();
            webclient.UploadStringCompleted += (obj, arguments) =>
            {
                var ListOfResult = FormatTrainMessagesJSON(arguments.Result);

                        TrainInfoLabel.Text = "Info: ";
                foreach (var Tmessage in ListOfResult)
                {
                    if (Tmessage.LocationSignature == StationShortName && Tmessage.AdvertisedTimeAtLocation == ArrivalTime)
                    {
                        if (Tmessage.Canceled == true)
                        {
                            foreach (var explanation in Tmessage.Deviation)
                            {
                                TrainInfoLabel.Text += explanation + " ";
                            }
                            TrainInfoLabel.Text += Tmessage.WebLink;
                        }
                        else
                        {
                            if (Tmessage.ToLocation != null)
                            {
                                if (Tmessage.ActivityType == "Avgang")
                                {
                                    if (Tmessage.EstimatedTimeAtLocation != null)
                                    {
                                        var newTime = Tmessage.EstimatedTimeAtLocation.Split('T');
                                        TrainInfoLabel.Text += "Estimerad tid: " + newTime[1].Substring(0, 5) + " ";
                                    }
                                    else
                                    {
                                        var Time = Tmessage.AdvertisedTimeAtLocation.Split('T');
                                        TrainInfoLabel.Text += "Ankomsttid: " + Time[1].Substring(0, 5) + " ";
                                    }

                                    
                                    var ToLocationName = GetStationFullName(Tmessage.ToLocation[0].LocationName);
                                    if (Tmessage.ToLocation[0].LocationName == "No.nk")
                                    {
                                        ToLocationName = "Narvik";
                                    }
                                    
                                    TrainInfoLabel.Text +=
                                        " TrainNr: " + Tmessage.AdvertisedTrainIdent +
                                        "  mot " + ToLocationName;
                                                                                
                                }
                               
                            }
                        }
                    }
                }
            };

            Uri address = new Uri(ImportantVariables.APIAdress);
            string requestBody = ImportantVariables.RequestTrainMessageQuery(TrainNumber);

            webclient.Encoding = Encoding.UTF8;
            webclient.UploadStringAsync(address, "POST", requestBody);
        }

        private static List<TrainMessageAPIHandler.TrainAnnouncement> FormatTrainMessagesJSON(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(TrainMessageAPIHandler.RootObject));
            var ms = new MemoryStream(Encoding.GetEncoding("UTF-8").GetBytes(json));

            var data = (TrainMessageAPIHandler.RootObject)serializer.ReadObject(ms);
            return data.RESPONSE.RESULT[0].TrainAnnouncement.ToList();
        }
        #endregion


        #region ArrivalDeparture
        public void FetchArrivalDeparture(ListBox s, string StationShortName)
        {
            WebClient webclient = new WebClient();
            webclient.UploadStringCompleted += (obj, arguments) =>
            {
                var ResultList = FormatArrivalDepartureJSON(arguments.Result);
                ArrivalDepartureList.Clear();

                foreach (var result in ResultList)
                {
                    if (result.TrainAnnouncement != null)
                    {
                        foreach (var train in result.TrainAnnouncement)
                        {
                            if (train.ToLocation != null)
                            {
                                ArrivalDepartureList.Add(train);
                                var time = train.AdvertisedTimeAtLocation.Split('T');
                                var LocationName = train.ToLocation[0].LocationName;
                                s.Items.Add(time[1].Substring(0, 5) +
                                     "  TrainNr: " + train.AdvertisedTrainIdent +
                                     "  To: " + GetStationFullName(LocationName) +
                                     "   Date: " +
                                    time[0].Substring(8, 2) + "/" + time[0].Substring(5, 2)
                                    );
                            }
                        }
                    }
                }
            };

            Uri address = new Uri(ImportantVariables.APIAdress);
            string requestBody = ImportantVariables.RequestStationTrainTimesQuery(StationShortName);

            webclient.Encoding = Encoding.UTF8;
            webclient.UploadStringAsync(address, "POST", requestBody);
        }

        private static List<StationArrivalDepatureAPIHandler.RESULT> FormatArrivalDepartureJSON(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(StationArrivalDepatureAPIHandler.RootObject));
            var ms = new MemoryStream(Encoding.GetEncoding("UTF-8").GetBytes(json));

            var data = (StationArrivalDepatureAPIHandler.RootObject)serializer.ReadObject(ms);
            return data.RESPONSE.RESULT.ToList();
        }
        #endregion  
    }
}
