using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static string filePath = "";
        static ImageRequest imageRequest;
        static void Main(string[] args)
        {
            while (true)
            {
                imageRequest = new ImageRequest();
                Console.WriteLine("Enter number of Signatures in request :- ");
                var Sigcount = GetCountNumber();
                //Signatures in the execution request
                if (Sigcount > 0)
                {
                    imageRequest.Signatures = new List<Signature>();
                    for (int i = 1; i <= Sigcount; i++)
                    {
                        Console.WriteLine("Enter signature path for " + i);
                        filePath = Console.ReadLine();
                        filePath = filePath.Trim();

                        if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                        {
                            byte[] imageData = File.ReadAllBytes(filePath);
                            var baseString = Convert.ToBase64String(imageData);
                            Signature signature = new Signature();
                            signature.ImageId = string.Empty;
                            signature.ImageType = "Signature";
                            signature.ImageMimeType = "image/png";
                            signature.ImageData = baseString;
                            signature.EncryptedAtSource = "Yes";
                            signature.EncryptionType = "K1";
                            signature.EncryptionKeyID = "KAO";
                            imageRequest.Signatures.Add(signature);
                        }
                        else
                        {
                            Console.WriteLine("File path is not valid or file error");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not a number");
                }

                //Images in the execution request
                Console.WriteLine("Please enter the number of pictures in request");
                var ImgCount = GetCountNumber();
                if (ImgCount > 0)
                {
                    imageRequest.Pictures = new List<Picture>();
                    for (int i = 1; i <= ImgCount; i++)
                    {
                        Console.WriteLine("Enter Image path for " + i);
                        filePath = Console.ReadLine();
                        filePath = filePath.Trim();
                        if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                        {
                            byte[] imageData = File.ReadAllBytes(filePath);
                            var baseString = Convert.ToBase64String(imageData);
                            Picture picture = new Picture();
                            picture.ImageId = string.Empty;
                            picture.ImageType = "document";
                            picture.ImageMimeType = "image/jpeg";
                            picture.ImageData = baseString;
                            picture.EncryptedAtSource = "Yes";
                            picture.EncryptionType = "K1";
                            picture.EncryptionKeyID = "KAO";

                            imageRequest.Pictures.Add(picture);
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Not a number");
                }

                #region Image Attributes

                imageRequest.ImageIdAttributes = new ImageIdAttributes();
                imageRequest.ImageIdAttributes.OrderDetails = new List<OrderDetail>();

                OrderDetail orderDetail = new OrderDetail();
                orderDetail.MMSObjectID = string.Empty;
                orderDetail.OrderId = string.Empty;
                orderDetail.OrderNumber = string.Empty;
                imageRequest.ImageIdAttributes.OrderDetails.Add(orderDetail);

                #endregion

                #region Object to string conversion 
                var settings = new JsonSerializerSettings() { ContractResolver = new NullToEmptyStringResolver() };
                var outputString = JsonConvert.SerializeObject(imageRequest, settings);
                #endregion

                

                #region O/P
                Console.WriteLine("Please find the below output");
                Console.WriteLine();
                Console.WriteLine(outputString);
                #endregion
            }
        }


        static int GetCountNumber()
        {
            int totalCnt;
            try
            {
                var val = Console.ReadLine();
                totalCnt = Convert.ToInt32(val);
                return totalCnt;
            }
            catch(Exception e)
            {
                return -1;
            }
        }
    }
}
