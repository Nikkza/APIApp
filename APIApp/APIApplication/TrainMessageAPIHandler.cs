using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApplication
{
    public class TrainMessageAPIHandler
    {
        public class FromLocation
        {
            public string LocationName { get; set; }
            public int Priority { get; set; }
            public int Order { get; set; }
        }

        public class ToLocation
        {
            public string LocationName { get; set; }
            public int Priority { get; set; }
            public int Order { get; set; }
        }

        public class ViaToLocation
        {
            public string LocationName { get; set; }
            public int Priority { get; set; }
            public int Order { get; set; }
        }

        public class ViaFromLocation
        {
            public string LocationName { get; set; }
            public int Priority { get; set; }
            public int Order { get; set; }
        }

        public class TrainAnnouncement
        {
            public string ActivityId { get; set; }
            public string ActivityType { get; set; }
            public bool Advertised { get; set; }
            public string AdvertisedTimeAtLocation { get; set; }
            public string AdvertisedTrainIdent { get; set; }
            public bool Canceled { get; set; }
            public bool EstimatedTimeIsPreliminary { get; set; }
            public List<FromLocation> FromLocation { get; set; }
            public string InformationOwner { get; set; }
            public string LocationSignature { get; set; }
            public string MobileWebLink { get; set; }
            public string ModifiedTime { get; set; }
            public int NewEquipment { get; set; }
            public List<string> OtherInformation { get; set; }
            public bool PlannedEstimatedTimeAtLocationIsValid { get; set; }
            public List<string> ProductInformation { get; set; }
            public string ScheduledDepartureDateTime { get; set; }
            public List<string> Service { get; set; }
            public string TechnicalTrainIdent { get; set; }
            public string TimeAtLocation { get; set; }
            public List<ToLocation> ToLocation { get; set; }
            public string TrackAtLocation { get; set; }
            public List<string> TrainComposition { get; set; }
            public string TypeOfTraffic { get; set; }
            public List<ViaToLocation> ViaToLocation { get; set; }
            public string WebLink { get; set; }
            public string WebLinkName { get; set; }
            public List<string> Deviation { get; set; }
            public string EstimatedTimeAtLocation { get; set; }
            public List<ViaFromLocation> ViaFromLocation { get; set; }
        }

        public class RESULT
        {
            public List<TrainAnnouncement> TrainAnnouncement { get; set; }
        }

        public class RESPONSE
        {
            public List<RESULT> RESULT { get; set; }
        }

        public class RootObject
        {
            public RESPONSE RESPONSE { get; set; }
        }
    }
}
