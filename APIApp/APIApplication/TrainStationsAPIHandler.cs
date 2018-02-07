using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace APIApplication
{
    public class TrainStationsAPIHandler
    {
        [DataContract]
        public class Geometry
        {
            [DataMember]
            public string SWEREF99TM { get; set; }
            [DataMember]
            public string WGS84 { get; set; }
        }

        [DataContract]
        public class TrainStation
        {
            [DataMember]
            public bool Advertised { get; set; }
            [DataMember]
            public string AdvertisedLocationName { get; set; }
            [DataMember]
            public string AdvertisedShortLocationName { get; set; }
            [DataMember]
            public string CountryCode { get; set; }
            [DataMember]
            public List<int> CountyNo { get; set; }
            [DataMember]
            public Geometry Geometry { get; set; }
            [DataMember]
            public string LocationInformationText { get; set; }
            [DataMember]
            public string LocationSignature { get; set; }
            [DataMember]
            public DateTime ModifiedTime { get; set; }
            [DataMember]
            public List<string> PlatformLine { get; set; }
            [DataMember]
            public bool Prognosticated { get; set; }
        }

        [DataContract]
        public class RESULT
        {
            [DataMember]
            public List<TrainStation> TrainStation { get; set; }
        }

        [DataContract]
        public class RESPONSE
        {
            [DataMember]
            public List<RESULT> RESULT { get; set; }
        }

        [DataContract]
        public class RootObject
        {
            [DataMember]
            public RESPONSE RESPONSE { get; set; }
        }
    }
}
