using System;
using NineYi.Mall.BE;
using NineYi.Mall.BL.Interface;
using NineYi.Mall.BL.Shipper;

namespace NineYi.Mall.BL
{
    /// <summary>
    /// 宅配Service
    /// </summary>
    public class DeliveryService
    {
        /// <summary>
        /// 計算運費
        /// </summary>
        /// <param name="deliveryItem">宅配資料</param>
        /// <returns>運費</returns>
        public double Calculate(DeliveryEntity deliveryItem)
        {
            if (deliveryItem == null)
            {
                throw new ArgumentException("請檢查 deliveryItem 參數");
            }

            IShipper shipper = null;
            var fee = default(double);
            if (deliveryItem.DeliveryType == DeliveryTypeEnum.TCat)
            {
                shipper = new TCat();
                fee = shipper.CalculateFee(deliveryItem);
                return fee;
            }
            else if (deliveryItem.DeliveryType == DeliveryTypeEnum.KTJ)
            {
                var length = deliveryItem.ProductLength;
                var width = deliveryItem.ProductWidth;
                var height = deliveryItem.ProductHeight;

                var size = length * width * height;

                if (length > 50 || width > 50 || height > 50)
                {
                    fee = size * 0.00001 * 110 + 50;
                }
                else
                {
                    fee = size * 0.00001 * 120;
                }

                return fee;
            }
            else if (deliveryItem.DeliveryType == DeliveryTypeEnum.PostOffice)
            {
                var weight = deliveryItem.ProductWeight;
                var feeByWeight = weight * 10 + 80;

                var length = deliveryItem.ProductLength;
                var width = deliveryItem.ProductWidth;
                var height = deliveryItem.ProductHeight;
                var feeByVolumetric = length * width * height * 0.00001 * 110;

                return feeByWeight > feeByVolumetric ? feeByWeight : feeByVolumetric;
            }
            else
            {
                throw new ArgumentException("請檢查 deliveryItem.DeliveryType 參數");
            }
        }
    }
}
