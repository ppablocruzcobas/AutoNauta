
namespace AutoNauta.Model
{
    public class DisconnectURLParams : BaseURLParams
    {
        public string username { get; set; }
        public string loggerId { get; set; }
        public string ssid { get; set; }
        public string domain { get; set; }
        public string wlanacname { get; set; }
        public string wlanmac { get; set; }
        public string wlanuserip { get; set; }
        public string ATTRIBUTE_UUID { get; set; }
        public string CSRFHW { get; set; }
    }
}
