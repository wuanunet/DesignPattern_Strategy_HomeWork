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
            else if (deliveryItem.DeliveryType == DeliveryTypeEnum.Kerrytj)
            {
                shipper = new Kerrytj();
                fee = shipper.CalculateFee(deliveryItem);
                return fee;
            }
            else if (deliveryItem.DeliveryType == DeliveryTypeEnum.PostOffice)
            {
                shipper = new PostOffice();
                fee = shipper.CalculateFee(deliveryItem);
                return fee;
            }
            else
            {
                throw new ArgumentException("請檢查 deliveryItem.DeliveryType 參數");
            }
        }
    }
}
