using System;
using NineYi.Mall.BE;
using NineYi.Mall.BL.Factory;
using NineYi.Mall.BL.Interface;

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

            var shipperFactory = new ShipperFactory();
            IShipper shipper = shipperFactory.GetShipper(deliveryItem);
            var fee = shipper.CalculateFee(deliveryItem); ;
            return fee;
        }
    }
}
