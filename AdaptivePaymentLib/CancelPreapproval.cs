using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AdaptivePaymentLib
{
	public class CancelPreapproval
	{
		public static String request(String preapprovalKey)
		{
			StringBuilder sRequest = Utils.getBaseStringRequest();

			sRequest.Append("&preapprovalKey=");
			sRequest.Append(HttpUtility.UrlEncode(preapprovalKey));

			return Utils.doWebRequest(Const.API_ENDPOINT_CANCEL_PREAPPROVAL, sRequest.ToString());
		}
	}
}
