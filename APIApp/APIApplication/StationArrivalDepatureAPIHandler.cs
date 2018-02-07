using System;
using System.Collections.Generic;

namespace APIApplication
{
    public class StationArrivalDepatureAPIHandler
    {
        public class ToLocation
        {
            public string LocationName { get; set; }
            public int Priority { get; set; }
            public int Order { get; set; }
        }

        public class TrainAnnouncement
        {
            public string AdvertisedTimeAtLocation { get; set; }
            public string AdvertisedTrainIdent { get; set; }
            public List<ToLocation> ToLocation { get; set; }
            public string TrackAtLocation { get; set; }
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
