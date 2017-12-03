using NineYi.Mall.BE;

namespace NineYi.Mall.BL.Interface
{
    /// <summary>
    /// IShipper
    /// </summary>
    public interface IShipper
    {
        /// <summary>
        /// 計算運費
        /// </summary>
        /// <param name="deliveryItem">產品資料</param>
        /// <returns>運費</returns>
        double CalculateFee(DeliveryEntity deliveryItem);
    }
}