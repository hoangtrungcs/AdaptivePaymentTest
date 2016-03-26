using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AdaptivePaymentLib
{
	public class PaymentDetail
	{
		public static String request(String payKey)
		{
			StringBuilder sRequest = Utils.getBaseStringRequest();

			sRequest.Append("&payKey=");
			sRequest.Append(HttpUtility.UrlEncode(payKey));

			return Utils.doWebRequest(Const.API_ENDPOINT_PAYMENT_DETAIL, sRequest.ToString());
		}
	}
}
