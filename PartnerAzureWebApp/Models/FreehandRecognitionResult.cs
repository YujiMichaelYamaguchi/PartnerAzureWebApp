using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MichaelAzureWebApp.Models
{
    [DataContract]
    public class word
    {
        [DataMember]
        public string boundingbox { get; set; }
        [DataMember]
        public string text { get; set; }
    }


    [DataContract]
    public class line
    {
        [DataMember]
        public string boundingbox { get; set; }
        [DataMember]
        public List<word> words { get; set; }
        [DataMember]
        public string sentence { get; set; }
    }

    [DataContract]
    public class region
    {
        [DataMember]
        public string boundingbox { get; set; }
        [DataMember]
        public List<line> lines { get; set; }
    }

    [DataContract]
    public class FreehandRecognitionResult
    {
        [DataMember]
        public string language { get; set; }
        [DataMember]
        public double textAngle { get; set; }
        [DataMember]
        public string orientation { get; set; }
        [DataMember]
        public List<region> regions { get; set; }
    }
}
