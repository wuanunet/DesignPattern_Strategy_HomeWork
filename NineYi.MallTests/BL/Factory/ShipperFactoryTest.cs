using System;
using FluentAssertions;
using NineYi.Mall.BE;
using NineYi.Mall.BL.Factory;
using NineYi.Mall.BL.Shipper;
using Xunit;

namespace NineYi.MallTests.BL.Factory
{
    /// <summary>
    /// ShipperFactoryTest
    /// </summary>
    public class ShipperFactoryTest
    {
        /// <summary>
        /// ShipperFactory
        /// </summary>
        private ShipperFactory _target;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipperFactoryTest"/> class.
        /// </summary>
        public ShipperFactoryTest()
        {
            this._target = new ShipperFactory();
        }

        /// <summary>
        /// 傳入的貨運商對象是 TCat 時，應接收到 TCat 的實體物件
        /// </summary>
        [Fact]
        [Trait(nameof(ShipperFactory), "GetShipper")]
        public void GetShipperTest_Input_DeliveryType_Is_TCat_Should_Get_TCat_Type()
        {
            //// Arrange
            var deliveryType = DeliveryTypeEnum.TCat;

            //// Act
            var actual = this._target.GetShipper(deliveryType);

            //// Assert
            actual.Should().BeOfType<TCat>();
        }

        /// <summary>
        /// 傳入的貨運商對象是 Kerrytj 時，應接收到 Kerrytj 的實體物件
        /// </summary>
        [Fact]
        [Trait(nameof(ShipperFactory), "GetShipper")]
        public void GetShipperTest_Input_DeliveryType_Is_Kerrytj_Should_Get_Kerrytj_Type()
        {
            //// Arrange
            var deliveryType = DeliveryTypeEnum.Kerrytj;

            //// Act
            var actual = this._target.GetShipper(deliveryType);

            //// Assert
            actual.Should().BeOfType<Kerrytj>();
        }

        /// <summary>
        /// 傳入的貨運商對象是 PostOffice 時，應接收到 PostOffice 的實體物件
        /// </summary>
        [Fact]
        [Trait(nameof(ShipperFactory), "GetShipper")]
        public void GetShipperTest_Input_DeliveryType_Is_PostOffice_Should_Get_PostOffice_Type()
        {
            //// Arrange
            var deliveryType = DeliveryTypeEnum.PostOffice;

            //// Act
            var actual = this._target.GetShipper(deliveryType);

            //// Assert
            actual.Should().BeOfType<PostOffice>();
        }

        [Fact]
        [Trait(nameof(ShipperFactory), "GetShipper")]
        public void GetShipperTest_Input_DeliveryType_Is_NotExist_Should_Get_ArgumentException()
        {
            //// Arrange
            var deliveryType = (DeliveryTypeEnum)99;
            var errorMessage = $"請確認貨運商對象 {nameof(deliveryType)}";

            //// Act
            Action action = () => this._target.GetShipper(deliveryType);

            //// Assert
            action.ShouldThrow<ArgumentNullException>()
                  .And
                  .Message
                  .Should()
                  .Contain(errorMessage);
        }
    }
}
