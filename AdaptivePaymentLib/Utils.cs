using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Net;
using System.IO;

namespace AdaptivePaymentLib
{
	class Utils
	{
		public static StringBuilder getBaseStringRequest()
		{
			StringBuilder sRequest = new StringBuilder();

			// requestEnvelope fields
			sRequest.Append("requestEnvelope.errorLanguage=");
			sRequest.Append(HttpUtility.UrlEncode(Const.ERROR_LANGUAGE));
			
			sRequest.Append("&requestEnvelope.detailLevel=");
			sRequest.Append(HttpUtility.UrlEncode(Const.DETAIL_LEVEL));
			
			// clientDetails fields
			sRequest.Append("&clientDetails.applicationId=");
			sRequest.Append(HttpUtility.UrlEncode(Const.APP_ID));

			sRequest.Append("&clientDetails.deviceId=");
			sRequest.Append(HttpUtility.UrlEncode(Const.DEVICE_ID));

			sRequest.Append("&clientDetails.ipAddress=");
			sRequest.Append(HttpUtility.UrlEncode(Const.IP_ADDRESS));

			sRequest.Append("&clientDetails.partnerName=");
			sRequest.Append(HttpUtility.UrlEncode(Const.PARTNER_NAME));
			
			// request specific data fields
			
			sRequest.Append("&cancelUrl=");
			sRequest.Append(HttpUtility.UrlEncode(Const.CANCEL_URL));

			sRequest.Append("&returnUrl=");
			sRequest.Append(HttpUtility.UrlEncode(Const.RETURN_URL));

			sRequest.Append("&currencyCode=");
			sRequest.Append(HttpUtility.UrlEncode(Const.CURRENCY_CODE));

			sRequest.Append("&feesPayer=");
			sRequest.Append(HttpUtility.UrlEncode(Const.FEES_PAYER));

			sRequest.Append("&trackingId=");
			sRequest.Append(HttpUtility.UrlEncode(System.Guid.NewGuid().ToString()));

			return sRequest;
		}

		public static String doWebRequest(String endpointURL, String requestString)
		{
			HttpWebRequest oPayRequest = (HttpWebRequest)WebRequest.Create(endpointURL);
			oPayRequest.Method = "POST";
			oPayRequest.ContentLength = requestString.Length;
			oPayRequest.ContentType = "application/x-www-form-urlencoded";
			
			// Set the HTTP Headers
			oPayRequest.Headers.Add("X-PAYPAL-SECURITY-USERID", Const.API_USERNAME);
			oPayRequest.Headers.Add("X-PAYPAL-SECURITY-PASSWORD", Const.API_PASSWORD);
			oPayRequest.Headers.Add("X-PAYPAL-SECURITY-SIGNATURE", Const.API_SIGNATURE);
			oPayRequest.Headers.Add("X-PAYPAL-SERVICE-VERSION", Const.VERSION);
			oPayRequest.Headers.Add("X-PAYPAL-APPLICATION-ID", Const.APP_ID);
			oPayRequest.Headers.Add("X-PAYPAL-REQUEST-DATA-FORMAT", Const.REQUEST_DATA_BINDING);
			oPayRequest.Headers.Add("X-PAYPAL-RESPONSE-DATA-FORMAT", Const.RESPONSE_DATA_BINDING);
			
			// Send the request
			StreamWriter oStreamWriter = new StreamWriter(oPayRequest.GetRequestStream());
			oStreamWriter.Write(requestString);
			oStreamWriter.Close();

			// Get the response
			HttpWebResponse oPayResponse = (HttpWebResponse) oPayRequest.GetResponse();
			StreamReader oStreamReader = new StreamReader(oPayResponse.GetResponseStream());
			string sResponse = oStreamReader.ReadToEnd();
			oStreamReader.Close();

			return HttpUtility.UrlDecode(sResponse);
		}
	}
}
