using System;
using System.Collections.Generic;
using NineYi.Mall.BE;
using NineYi.Mall.BL.Interface;
using NineYi.Mall.BL.Shipper;

namespace NineYi.Mall.BL.Factory
{
    /// <summary>
    /// 貨運商工廠
    /// </summary>
    public class ShipperFactory
    {
        /// <summary>
        /// 貨運商清單
        /// </summary>
        private readonly Dictionary<DeliveryTypeEnum, IShipper> _shippers = new Dictionary<DeliveryTypeEnum, IShipper>
        {
            { DeliveryTypeEnum.TCat, new TCat() },
            { DeliveryTypeEnum.Kerrytj, new Kerrytj() },
            { DeliveryTypeEnum.PostOffice, new PostOffice() }
        };

        /// <summary>
        /// 取得貨運商
        /// </summary>
        /// <param name="deliveryItem">宅配物件</param>
        /// <returns>貨運商</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IShipper GetShipper(DeliveryEntity deliveryItem)
        {
            if (this._shippers.TryGetValue(deliveryItem.DeliveryType, out var shipper) == false)
            {
                throw new ArgumentNullException($"請確認貨運商資料 {nameof(deliveryItem)}");
            }

            return shipper;
        }
    }
}
