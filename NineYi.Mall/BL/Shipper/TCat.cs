using NineYi.Mall.BE;
using NineYi.Mall.BL.Interface;

namespace NineYi.Mall.BL.Shipper
{
    /// <summary>
    /// 黑貓貨運商
    /// </summary>
    /// <seealso cref="NineYi.Mall.BL.Interface.IShipper" />
    public class TCat : IShipper
    {
        /// <summary>
        /// 計算運費
        /// </summary>
        /// <param name="deliveryItem">產品資料</param>
        /// <returns>運費</returns>
        public double CalculateFee(DeliveryEntity deliveryItem)
        {
            var fee = 0d;
            var weight = deliveryItem.ProductWeight;
            if (weight > 20)
            {
                fee = 400d;
            }
            else
            {
                fee = 100 + weight * 10;
            }

            return fee;
        }
    }
}
