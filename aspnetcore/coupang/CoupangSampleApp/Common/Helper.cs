using CoupangSampleApp.Models;
using CoupangSampleApp.Models.Enums;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Common
{
    public static class Helper
    {
        public static OrderSheetStatus ToOrderSheetStatus(string v)
        {
            var ret = OrderSheetStatus.Default;

            switch (v)
            {
                case "ACCEPT": ret = OrderSheetStatus.Accept; break;
                case "INSTRUCT": ret = OrderSheetStatus.Instruct; break;
                case "DEPARTURE": ret = OrderSheetStatus.Departure; break;
                case "DELIVERING": ret = OrderSheetStatus.Delivering; break;
                case "FINAL_DELIVERY": ret = OrderSheetStatus.FinalDelivery; break;
                case "NONE_TRACKING": ret = OrderSheetStatus.NoneTracking; break;
            }

            return ret;
        }

        public static string ToParameterName(OrderSheetStatus status)
        {
            string ret = string.Empty;

            switch (status)
            {
                case OrderSheetStatus.Accept: ret = "ACCEPT"; break;
                case OrderSheetStatus.Instruct: ret = "INSTRUCT"; break;
                case OrderSheetStatus.Departure: ret = "DEPARTURE"; break;
                case OrderSheetStatus.Delivering: ret = "DELIVERING"; break;
                case OrderSheetStatus.FinalDelivery: ret = "FINAL_DELIVERY"; break;
                case OrderSheetStatus.NoneTracking: ret = "NONE_TRACKING"; break;
            }

            return ret;
        }

        public static string ToString(OrderSheetStatus status)
        {
            string ret = string.Empty;

            switch (status)
            {
                case OrderSheetStatus.Accept: ret = "결제완료"; break;
                case OrderSheetStatus.Instruct: ret = "상품준비중"; break;
                case OrderSheetStatus.Departure: ret = "배송지시"; break;
                case OrderSheetStatus.Delivering: ret = "배송중"; break;
                case OrderSheetStatus.FinalDelivery: ret = "배송완료"; break;
                case OrderSheetStatus.NoneTracking: ret = "업체 직접 배송(배송 연동 미적용), 추적불가"; break;
            }

            return ret;
        }


        public static string DateToString(DateTime dateTime)
        {
            string ret = string.Empty;

            if (dateTime != default)
            {
                ret = dateTime.ToString("yyyy-MM-dd");
            }

            return ret;
        }


        public static Ordersheet GetDumpOrdersheet()
        {
            var random = new Random();


            return new Ordersheet()
            {
                Receiver = new Receiver()
                {
                    Name = "수취인 이름 테스트",
                },
                Orderer = new Orderer()
                {
                    Name = "주문자 이름 테스트"
                },
                OrderId = random.Next(10000),
                ShipmentBoxId = random.Next(10000),
                Status = ToParameterName((OrderSheetStatus)random.Next(5)),
            };
        }
       
    }
}
