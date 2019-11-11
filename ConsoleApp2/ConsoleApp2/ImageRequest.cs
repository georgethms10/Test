using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ImageRequest
    {
        private string RequestId { get; set; }
        public string ApiVersion { get; set; }
        public string sourceApplicationName { get; set; }
        public List<Signature> Signatures { get; set; }
        public List<Picture> Pictures { get; set; }
        public ImageIdAttributes ImageIdAttributes { get; set; }

    }

    public class Signature
    {
        #region properties / attributes
        public string ImageId { get; set; }
        public DateTime ImageTime { get; set; }
        public string ImageType { get; set; }
        public string ImageMimeType { get; set; }
        public string ImageData { get; set; }
        public string EncryptedAtSource { get; set; }
        public string EncryptionType { get; set; }
        public string EncryptionKeyID { get; set; }
        #endregion
    }

    public class Picture
    {
        #region properties / attributes
        public string ImageId { get; set; }
        public DateTime ImageTime { get; set; }
        public string ImageType { get; set; }
        public string ImageMimeType { get; set; }
        public string ImageData { get; set; }
        public string EncryptedAtSource { get; set; }
        public string EncryptionType { get; set; }
        public string EncryptionKeyID { get; set; }
        #endregion
    }


    public class ImageIdAttributes
    {
        #region properties / attributes
        public string LEMPId { get; set; }
        public string StopId { get; set; }
        public string RoundId { get; set; }
        public string OrderType { get; set; }
        public string BranchNumber { get; set; }
        public string UserID { get; set; }
        public string StatusMessageId { get; set; }
        public string StatusDataComplete { get; set; }
        public string OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        #endregion
    }

    public class OrderDetail
    {
        #region properties / attributes
        public string OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string MMSObjectID { get; set; }
        #endregion
    }

}
