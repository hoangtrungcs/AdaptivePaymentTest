using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AdaptivePaymentLib
{
	public class Preapproval
	{
		public static String request(String startingDate, String endingDate,
			String senderEmail, String maxTotal)
		{
			StringBuilder sRequest = Utils.getBaseStringRequest();

			sRequest.Append("&startingDate=");
			sRequest.Append(HttpUtility.UrlEncode(startingDate));
			
			sRequest.Append("&endingDate=");
			sRequest.Append(HttpUtility.UrlEncode(endingDate));
			
			sRequest.Append("&maxTotalAmountOfAllPayments=");
			sRequest.Append(HttpUtility.UrlEncode(maxTotal));

			sRequest.Append("&senderEmail=");
			sRequest.Append(HttpUtility.UrlEncode(senderEmail));

			return Utils.doWebRequest(Const.API_ENDPOINT_PREAPPROVAL, sRequest.ToString());
		}
	}
}
