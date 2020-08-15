using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models.Enums
{
    public enum OrderSheetStatus
    {
        /// <summary>
        /// 기본값
        /// </summary>
        Default,
        /// <summary>
        /// 결제완료
        /// </summary>
        Accept,
        /// <summary>
        /// 상품준비중
        /// </summary>
        Instruct,
        /// <summary>
        /// 배송지시
        /// </summary>
        Departure,
        /// <summary>
        /// 배송중
        /// </summary>
        Delivering,
        /// <summary>
        /// 배송 완료
        /// </summary>
        FinalDelivery,
        /// <summary>
        /// 업체 직접 배송 (배송 연동 미적용), 추적불가
        /// </summary>
        NoneTracking,
    }
}
