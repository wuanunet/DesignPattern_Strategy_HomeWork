using NineYi.Mall.BE;
using NineYi.Mall.BL.Interface;

namespace NineYi.Mall.BL.Shipper
{
    /// <summary>
    /// 大榮貨運貨運商
    /// </summary>
    /// <seealso cref="NineYi.Mall.BL.Interface.IShipper" />
    public class Kerrytj : IShipper
    {
        /// <summary>
        /// 計算運費
        /// </summary>
        /// <param name="deliveryItem">產品資料</param>
        /// <returns>運費</returns>
        public double CalculateFee(DeliveryEntity deliveryItem)
        {
            var fee = 0d;
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
    }
}
