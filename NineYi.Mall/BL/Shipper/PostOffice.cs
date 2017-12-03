using NineYi.Mall.BE;
using NineYi.Mall.BL.Interface;

namespace NineYi.Mall.BL.Shipper
{
    /// <summary>
    /// 郵局貨運商
    /// </summary>
    /// <seealso cref="NineYi.Mall.BL.Interface.IShipper" />
    public class PostOffice : IShipper
    {
        /// <summary>
        /// 計算運費
        /// </summary>
        /// <param name="deliveryItem">產品資料</param>
        /// <returns>運費</returns>
        public double CalculateFee(DeliveryEntity deliveryItem)
        {
            var weight = deliveryItem.ProductWeight;
            var feeByWeight = weight * 10 + 80;

            var length = deliveryItem.ProductLength;
            var width = deliveryItem.ProductWidth;
            var height = deliveryItem.ProductHeight;
            var feeByVolumetric = length * width * height * 0.00001 * 110;

            return feeByWeight > feeByVolumetric ? feeByWeight : feeByVolumetric;
        }
    }
}
