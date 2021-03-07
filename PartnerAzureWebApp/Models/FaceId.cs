using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MichaelAzureWebApp.Models
{
    [DataContract]
    public class Accessory
    {
        [DataMember]
        public string type { get; set; } = "Default";
        [DataMember]
        public double confidence { get; set; } = 999.9;
    }

    [DataContract]
    public class Blur
    {
        [DataMember]
        public string blurLevel { get; set; }

        [DataMember]
        public double value { get; set; }
    }

    [DataContract]
    public class Emotion
    {
        [DataMember]
        public double anger { get; set; }

        [DataMember]
        public double contempt { get; set; }

        [DataMember]
        public double disgust { get; set; }

        [DataMember]
        public double fear { get; set; }

        [DataMember]
        public double happiness { get; set; }

        [DataMember]
        public double neutral { get; set; }

        [DataMember]
        public double sadness { get; set; }

        [DataMember]
        public double surprise { get; set; }
    }

    [DataContract]
    public class Exposure
    {
        [DataMember]
        public string exposureLevel { get; set; }

        [DataMember]
        public double value { get; set; }
    }

    [DataContract]
    public class HairColor
    {
        [DataMember]
        public string color { get; set; }

        [DataMember]
        public double confidence { get; set; }
    }

    [DataContract]
    public class HeadPose
    {
        [DataMember]
        public double pitch { get; set; }

        [DataMember]
        public double roll { get; set; }

        [DataMember]
        public double yaw { get; set; }
    }

    [DataContract]
    public class MakeUp
    {
        [DataMember]
        public bool eyeMakeup { get; set; }

        [DataMember]
        public bool lipMakeup { get; set; }
    }

    [DataContract]
    public class Noise
    {
        [DataMember]
        public string noiseLevel { get; set; }

        [DataMember]
        public double value { get; set; }
    }

    [DataContract]
    public class Occlusion
    {
        [DataMember]
        public bool foreheadOccluded { get; set; }

        [DataMember]
        public bool eyeOccluded { get; set; }

        [DataMember]
        public bool mouthOccluded { get; set; }
    }

    [DataContract]
    public class FacialHair
    {
        [DataMember]
        public double moustache { get; set; }

        [DataMember]
        public double beard { get; set; }

        [DataMember]
        public double sideburns { get; set; }
    }

    [DataContract]
    public class FaceRectangle
    {
        [DataMember]
        public int top { get; set; }

        [DataMember]
        public int left { get; set; }

        [DataMember]
        public int width { get; set; }

        [DataMember]
        public int height { get; set; }

    }

    [DataContract]
    public class FacePart
    {
        [DataMember]
        public double x { get; set; }

        [DataMember]
        public double y { get; set; }
    }

    [DataContract]
    public class FaceLandMarks
    {
        [DataMember]
        public FacePart pupilLeft { get; set; }

        [DataMember]
        public FacePart pupilRight { get; set; }

        [DataMember]
        public FacePart noseTip { get; set; }

        [DataMember]
        public FacePart mouthLeft { get; set; }

        [DataMember]
        public FacePart mouthRight { get; set; }

        [DataMember]
        public FacePart eyebrowLeftOuter { get; set; }

        [DataMember]
        public FacePart eyebrowLeftInner { get; set; }

        [DataMember]
        public FacePart eyeLeftOuter { get; set; }

        [DataMember]
        public FacePart eyeLeftTop { get; set; }

        [DataMember]
        public FacePart eyeLeftBottom { get; set; }

        [DataMember]
        public FacePart eyeLeftInner { get; set; }

        [DataMember]
        public FacePart eyebrowRightInner { get; set; }

        [DataMember]
        public FacePart eyebrowRightOuter { get; set; }

        [DataMember]
        public FacePart eyeRightInner { get; set; }

        [DataMember]
        public FacePart eyeRightTop { get; set; }

        [DataMember]
        public FacePart eyeRightBottom { get; set; }

        [DataMember]
        public FacePart eyeRightOuter { get; set; }

        [DataMember]
        public FacePart noseRootLeft { get; set; }

        [DataMember]
        public FacePart noseRootRight { get; set; }

        [DataMember]
        public FacePart noseLeftAlarTop { get; set; }

        [DataMember]
        public FacePart noseRightAlarTop { get; set; }

        [DataMember]
        public FacePart noseLeftAlarOutTip { get; set; }

        [DataMember]
        public FacePart noseRightAlarOutTip { get; set; }

        [DataMember]
        public FacePart upperLipTop { get; set; }

        [DataMember]
        public FacePart upperLipBottom { get; set; }

        [DataMember]
        public FacePart underLipTop { get; set; }

        [DataMember]
        public FacePart underLipBottom { get; set; }

    }

    [DataContract]
    public class Hair
    {
        [DataMember]
        public double bold { get; set; }

        [DataMember]
        public bool invisible { get; set; }

        [DataMember]
        public List<HairColor> hairColor { get; set; }

    }

    [DataContract]
    public class FaceAttributes
    {
        [DataMember]
        public double smile { get; set; }

        [DataMember]
        public HeadPose headPose { get; set; }

        [DataMember]
        public string gender { get; set; }

        [DataMember]
        public double age { get; set; }

        [DataMember]
        public FacialHair facialHair { get; set; }

        [DataMember]
        public string glasses { get; set; }

        [DataMember]
        public Emotion emotion { get; set; }

        [DataMember]
        public Blur blur { get; set; }

        [DataMember]
        public Exposure exposure { get; set; }

        [DataMember]
        public Noise noise { get; set; }

        [DataMember]
        public MakeUp makeUp { get; set; }

        [DataMember]
        public List<Accessory> accessories { get; set; }

        [DataMember]
        public Occlusion occlusion { get; set; }

        [DataMember]
        public Hair hair { get; set; }

    }

    [DataContract]
    public class FaceId
    {
        [DataMember]
        public string faceId { get; set; } = string.Empty;

        [DataMember]
        public string faceRectangleBase64String { get; set; } = string.Empty;

        [DataMember]
        public string mainEmotion { get; set; } = string.Empty;

        [DataMember]
        public FaceRectangle faceRectangle { get; set; }

        [DataMember]
        public FaceLandMarks faceLandmarks { get; set; }

        [DataMember]
        public FaceAttributes faceAttributes { get; set; }
    }
}
