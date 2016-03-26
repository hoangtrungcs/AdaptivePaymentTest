using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptivePaymentLib
{
	public class Const
	{
		public static String API_USERNAME = "sdk-three_api1.sdk.com";
		public static String API_PASSWORD = "QFZCWN5HZM8VBG7Q";
		public static String API_SIGNATURE = "A.d9eRKfd1yVkRrtmMfCFLTqa6M9AyodL0SJkhYztxUi8W9pCXF6.4NI";

		public static String API_ENDPOINT_PAY = "https://svcs.sandbox.paypal.com/AdaptivePayments/Pay";
		public static String API_ENDPOINT_PAYMENT_DETAIL = "https://svcs.sandbox.paypal.com/AdaptivePayments/PaymentDetails";
		public static String API_ENDPOINT_PREAPPROVAL = "https://svcs.sandbox.paypal.com/AdaptivePayments/Preapproval";
		public static String API_ENDPOINT_PREAPPROVAL_DETAIL = "https://svcs.sandbox.paypal.com/AdaptivePayments/PreapprovalDetails";
		public static String API_ENDPOINT_CANCEL_PREAPPROVAL = "https://svcs.sandbox.paypal.com/AdaptivePayments/CancelPreapproval";

		public static String VERSION = "1.1.0";
		public static String ERROR_LANGUAGE = "en_US";
		public static String DETAIL_LEVEL = "ReturnAll";
		public static String REQUEST_DATA_BINDING = "NV";
		public static String RESPONSE_DATA_BINDING = "NV";
		public static String APP_ID = "APP-80W284485P519543T";

		public static String IP_ADDRESS = "255.255.255.255";
		public static String PARTNER_NAME = "MobiPay";
		public static String DEVICE_ID = "255.255.255.255";

		public static String CURRENCY_CODE = "USD";

		public static String RETURN_URL = "http://google.com.vn";
		public static String CANCEL_URL = "http://docbao.vn";

		public static String FEES_PAYER = "EACHRECEIVER";

		public static String PAY_CMD = "https://www.sandbox.paypal.com/webscr?cmd=_ap-payment&paykey=";
		public static String PREAPPROVED_CMD = "https://www.sandbox.paypal.com/webscr?cmd=_ap-preapproval&preapprovalkey=";
	}
}
