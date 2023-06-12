using Microsoft.ML.Data;

namespace eAutobus.ML
{
    public class Productprediction
    {
        public float Score { get; set; }
    }
    public class UserItemEntry
    {
        public uint UserID { get; set; }
        public uint ItemID { get; set; }
        public float Label { get; set; }
    }

    public class UserItemPrediction
    {
        public float Label { get; set; }
        public float Score { get; set; }

    }

}
