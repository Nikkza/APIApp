using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApplication
{
    public static class ImportantVariables
    {
        private const string APIKey = "66731d7ad0854bb397b0e02504eaa785";
        public const string APIAdress = "http://api.trafikinfo.trafikverket.se/v1.3/data.json";

        public static string RequestTrainMessageQuery(int TrainNumber)
        {
            return "<REQUEST>" +
                        "<LOGIN authenticationkey='" + APIKey + "'/>" +
                        "<QUERY objecttype='TrainAnnouncement' >" +
                            "<FILTER>" +
                                "<EQ name='AdvertisedTrainIdent' value='" + TrainNumber + "'/>" +
                            "</FILTER>" +
                        "</QUERY>" +
                    "</REQUEST>";

        }

        public static string RequestAllStationsQuery()
        {
            return "<REQUEST>" +
                        "<LOGIN authenticationkey ='" + APIKey + "'/>" +
                        "<QUERY objecttype='TrainStation' >" +
                        "<FILTER>" +
                            "<EQ name='Prognosticated' value='TRUE'/>" + 
                        "</FILTER>" +
                        "<EXCLUDE> ModifiedTime </EXCLUDE>" + // Klagar på detta (datetime) annars
                        "<EXCLUDE> Deleted </EXCLUDE>" +
                        "</QUERY>" +
                    "</REQUEST>";
        }
        public static string RequestStationTrainTimesQuery(string StationShortName)
        {
            return "<REQUEST>" +
                        "<LOGIN authenticationkey = '" + APIKey + "'/>" +
                        "<QUERY objecttype='TrainAnnouncement' orderby = 'AdvertisedTimeAtLocation'>" +
                        "<FILTER>" +
                            "<AND>" +
                                "<EQ name ='ActivityType' value = 'Avgang'/>" +
                                "<EQ name = 'LocationSignature' value = '" + StationShortName + "'/>" +
                                "<OR>" +
                                    "<AND>" +
                                        "<GT name = 'AdvertisedTimeAtLocation' value = '$dateadd(-00:15:00)'/>" +
                                        "<LT name = 'AdvertisedTimeAtLocation' value = '$dateadd(14:00:00)'/>" +
                                    "</AND>" +
                                    "<AND>" +
                                        "<LT name = 'AdvertisedTimeAtLocation' value = '$dateadd(00:30:00)'/>" +
                                        "<GT name = 'EstimatedTimeAtLocation' value = '$dateadd(-00:15:00)'/>" +
                                    "</AND>" +
                                "</OR>" +
                            "</AND>" +
                        "</FILTER>" +
                        "<INCLUDE> AdvertisedTrainIdent </INCLUDE>" +
                        "<INCLUDE> AdvertisedTimeAtLocation </INCLUDE>" +
                        "<INCLUDE> TrackAtLocation </INCLUDE>" +
                        "<INCLUDE> ToLocation </INCLUDE>" +
                        "</QUERY>" +
                    "</REQUEST>";
        }
    }
}
