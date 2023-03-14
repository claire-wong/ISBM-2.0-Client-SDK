/* Purpose: This is a simple application that acts as an ISBM publication Consumer.
 *          It demonstrates the idea of using an ISBM Client Adapter to read publication 
 *          from an ISBM Server Adapter. It should be interoperable with any ISBM compatible
 *          adapters regardless of the actual service bus that delivers the messages.  
 *          
 * Author: Claire Wong
 * Date Created:  2022/08/15
 * 
 * (c) 2022
 * This code is licensed under MIT license
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ISBM20ClientAdapter;
using ISBM20ClientAdapter.ResponseType;

namespace ISBM20ConsumerRequestTestCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bodFilePath = AppDomain.CurrentDomain.BaseDirectory + "BODs\\GetMeasurements.json";
            textBoxBODRequest.Text = File.ReadAllText(bodFilePath);
        }

        private void buttonOpenSession_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ConsumerRequestService myConsumerRequestService = new ConsumerRequestService();
            OpenConsumerRequestSessionResponse myOpenSubscriptionSessionResponse = myConsumerRequestService.OpenConsumerRequestSession(textBoxHostName.Text, textBoxChannelId.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myOpenSubscriptionSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myOpenSubscriptionSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myOpenSubscriptionSessionResponse.ISBMHTTPResponse;

            textBoxSessionId.Text = myOpenSubscriptionSessionResponse.SessionID;
        }

        private void buttonPostRequest_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adapter method
            ConsumerRequestService myConsumerRequestService = new ConsumerRequestService();
            PostRequestResponse myPostRequestResponse = myConsumerRequestService.PostRequest(textBoxHostName.Text, textBoxSessionId.Text, textBoxTopic.Text, textBoxBODRequest.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myPostRequestResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myPostRequestResponse.ReasonPhrase;
            textBoxResponse.Text = myPostRequestResponse.ISBMHTTPResponse;

            textBoxMessageId.Text = myPostRequestResponse.MessageID;
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ConsumerRequestService myConsumerRequestService = new ConsumerRequestService();
            CloseConsumerRequestSessionResponse myCloseConsumerRequestSessionResponse = myConsumerRequestService.CloseConsumerRequestSession(textBoxHostName.Text, textBoxSessionId.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myCloseConsumerRequestSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myCloseConsumerRequestSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myCloseConsumerRequestSessionResponse.ISBMHTTPResponse;
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ConsumerRequestService myConsumerRequestService = new ConsumerRequestService();
            ReadResponseResponse myReadResponseResponse = myConsumerRequestService.ReadResponse(textBoxHostName.Text, textBoxSessionId.Text, textBoxMessageId.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myReadResponseResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myReadResponseResponse.ReasonPhrase;
            textBoxResponse.Text = myReadResponseResponse.ISBMHTTPResponse;

            if (myReadResponseResponse.StatusCode == 200)
            {
                textBoxMessageId.Text = myReadResponseResponse.MessageID;
                textBoxBODResponse.Text = myReadResponseResponse.MessageContent;
            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ConsumerRequestService myConsumerRequestService = new ConsumerRequestService();
            RemoveResponseResponse myRemoveResponseResponse = myConsumerRequestService.RemoveResponse(textBoxHostName.Text, textBoxSessionId.Text, textBoxMessageId.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myRemoveResponseResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myRemoveResponseResponse.ReasonPhrase;
            textBoxResponse.Text = myRemoveResponseResponse.ISBMHTTPResponse;

            textBoxBODResponse.Text = "";
            textBoxMessageId.Text = "";
        }
               
    }
}
