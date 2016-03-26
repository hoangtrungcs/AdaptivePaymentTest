using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AdaptivePaymentLib
{
	public class Pay
	{
		public static String doExplicit(String senderEmail, String receiverEmail, String amount, String memo)
		{
			StringBuilder sRequest = Utils.getBaseStringRequest();

			sRequest.Append("&actionType=");
			sRequest.Append(HttpUtility.UrlEncode("PAY"));

			sRequest.Append("&memo=");
			sRequest.Append(HttpUtility.UrlEncode(memo));
			sRequest.Append("&receiverList.receiver(0).amount=");
			sRequest.Append(HttpUtility.UrlEncode(amount));
			sRequest.Append("&receiverList.receiver(0).email=");
			sRequest.Append(HttpUtility.UrlEncode(receiverEmail));
			sRequest.Append("&senderEmail=");
			sRequest.Append(HttpUtility.UrlEncode(senderEmail));

			return Utils.doWebRequest(Const.API_ENDPOINT_PAY, sRequest.ToString());
		}

		public static String doImplicit(String senderEmail, String receiverEmail,
			String amount, String memo, String preapprovalKey)
		{
			StringBuilder sRequest = Utils.getBaseStringRequest();

			sRequest.Append("&actionType=");
			sRequest.Append(HttpUtility.UrlEncode("PAY"));

			sRequest.Append("&memo=");
			sRequest.Append(HttpUtility.UrlEncode(memo));
			sRequest.Append("&receiverList.receiver(0).amount=");
			sRequest.Append(HttpUtility.UrlEncode(amount));
			sRequest.Append("&receiverList.receiver(0).email=");
			sRequest.Append(HttpUtility.UrlEncode(receiverEmail));
			sRequest.Append("&senderEmail=");
			sRequest.Append(HttpUtility.UrlEncode(senderEmail));

			sRequest.Append("&preapprovalKey=");
			sRequest.Append(HttpUtility.UrlEncode(preapprovalKey));


			return Utils.doWebRequest(Const.API_ENDPOINT_PAY, sRequest.ToString());
		}
	}
}
