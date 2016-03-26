using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AdaptivePaymentLib;

namespace TestApp
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{

		}

		private void buttonGetPayDetail_Click(object sender, EventArgs e)
		{
			groupBoxPayDetail.Visible = false;
			String payKey = textBoxPayDetail_PayKey.Text;
			if (payKey == "")
			{
				fuck();
				return;
			}
			String res = PaymentDetail.request(textBoxPayDetail_PayKey.Text);
			groupBoxPayDetail.Visible = true;
			richTextBoxPayDetail.Text = res;

			NVPCodec decoder = new NVPCodec();
			decoder.Decode(res);

			textBoxPayDetail_Amount.Text = decoder["paymentInfoList.paymentInfo(0).receiver.amount"];
			textBoxPayDetail_Status.Text = decoder["status"];
			textBoxPayDetail_Sender.Text = decoder["senderEmail"];
			textBoxPayDetail_Receiver.Text = decoder["paymentInfoList.paymentInfo(0).receiver.email"];
		}

		private void buttonPay_Click(object sender, EventArgs e)
		{
			groupBoxPay.Visible = false;

			String res = "";
			bool isExplicit = true;
			if (radioButtonPay_Explicit.Checked)
			{

				res = Pay.doExplicit(
					textBoxPay_Sender.Text,
					textBoxPay_Receiver.Text,
					textBoxPay_Amount.Text,
					textBoxPay_Memo.Text);
			}
			else
			{
				isExplicit = false;
				res = Pay.doImplicit(
					textBoxPay_Sender.Text,
					textBoxPay_Receiver.Text,
					textBoxPay_Amount.Text,
					textBoxPay_Memo.Text,
					textBoxPay_PreappKey.Text);
			}

			groupBoxPay.Visible = true;

			richTextBoxPay.Text = res;
			
			NVPCodec decoder = new NVPCodec();
			decoder.Decode(res);

			textBoxPay_PayKey.Text = decoder["payKey"];
			textBoxPay_ACK.Text = decoder["responseEnvelope.ack"];
			textBoxPay_Status.Text = decoder["paymentExecStatus"];

			labelPay_CMDLink.Visible = false;
			textBoxPay_CMDLink.Visible = false;

			if (isExplicit)
			{
				if (decoder["responseEnvelope.ack"] == "Success")
				{
					labelPay_CMDLink.Text = "This is explicit payment";
					labelPay_CMDLink.Visible = true;
					textBoxPay_CMDLink.Text = Const.PAY_CMD + decoder["payKey"];
					textBoxPay_CMDLink.Visible = true;					
				}
			}
			else
			{
				if (decoder["responseEnvelope.ack"] == "Success")
				{
					labelPay_CMDLink.Text = "This is implicit payment, the payment is COMPLETED";
					labelPay_CMDLink.Visible = true;

					textBoxPay_CMDLink.Visible = false;
				}
			}
		}

		private void fuck()
		{
			MessageBox.Show("FUCK", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		private void buttonPreappOK_Click(object sender, EventArgs e)
		{
			groupBoxPreapp.Visible = false;

			String res = Preapproval.request(
				textBoxPreapp_SDate.Text, textBoxPreapp_EDate.Text,
				textBoxPreapp_SenderEmail.Text, textBoxPreapp_MaxTotal.Text);

			groupBoxPreapp.Visible = true;
			
			richTextBoxPreapp.Text = res;

			NVPCodec decoder = new NVPCodec();
			decoder.Decode(res);

			textBoxPreapp_ACK.Text = decoder["responseEnvelope.ack"];
			textBoxPreapp_PreappKey.Text = decoder["preapprovalKey"];

			if (decoder["responseEnvelope.ack"] == "Success")
			{
				labelPreapp_CMDLink.Visible = true;
				textBoxPreapp_CMDLink.Visible = true;
				textBoxPreapp_CMDLink.Text = Const.PREAPPROVED_CMD + decoder["preapprovalKey"];
			}
			else
			{
				labelPreapp_CMDLink.Visible = false;
				textBoxPreapp_CMDLink.Visible = false;
			}

		}

		private void radioButtonImplicitPay_CheckedChanged(object sender, EventArgs e)
		{
			labelPay_PreappKey.Enabled = radioButtonPay_Implicit.Checked;
			textBoxPay_PreappKey.Enabled = radioButtonPay_Implicit.Checked;
		}

		private void buttonPreappDetail_GetDetail_Click(object sender, EventArgs e)
		{
			groupBoxPreappDetail.Visible = false;
			if (textBoxPreappDetail_PreappKey.Text == "")
			{
				fuck();
				return;
			}
			richTextBoxPreappDetail.Text = PreapprovalDetail.request(textBoxPreappDetail_PreappKey.Text);
			groupBoxPreappDetail.Visible = true;
		}

		private void buttonPreappCancel_DoCancel_Click(object sender, EventArgs e)
		{
			groupBoxPreappCancel.Visible = false;
			if (textBoxPreappCancel_PreappKey.Text == "")
			{
				fuck();
				return;
			}
			richTextBoxPreappCancel.Text = CancelPreapproval.request(textBoxPreappCancel_PreappKey.Text);
			groupBoxPreappCancel.Visible = true;

		}

		
	}
}
