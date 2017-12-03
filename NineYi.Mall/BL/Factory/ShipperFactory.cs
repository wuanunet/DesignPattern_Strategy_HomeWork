using System;
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
        /// 取得貨運商
        /// </summary>
        /// <param name="deliveryItem">宅配物件</param>
        /// <returns>貨運商</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IShipper GetShipper(DeliveryEntity deliveryItem)
        {
            IShipper shipper = null;
            switch (deliveryItem.DeliveryType)
            {
                case DeliveryTypeEnum.TCat:
                    shipper = new TCat();
                    break;
                case DeliveryTypeEnum.Kerrytj:
                    shipper = new Kerrytj();
                    break;
                case DeliveryTypeEnum.PostOffice:
                    shipper = new PostOffice();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return shipper;
        }
    }
}
