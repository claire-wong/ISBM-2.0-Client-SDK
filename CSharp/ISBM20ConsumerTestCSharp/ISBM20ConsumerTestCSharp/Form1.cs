/* Purpose: This is a simple application that acts as an ISBM publication provider.
 *          It demonstrates the idea of using open standards to publish messages
 *          using an ISBM adapter. This .net core UWP app interacts with an ISBM adapter that's
 *          compatible with ISBM 2.0. It should be interoperable with other ISBM adapters
 *          regardless of the actual service bus that delivers the messages.  
 *          
 * Author: Claire Wong
 * Date Created:  2020/05/02
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
using ISBM20ClientAdapter;
using ISBM20ClientAdapter.ResponseType;

namespace ISBM20ConsumerTestCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenSession_Click(object sender, EventArgs e)
        {
            ConsumerPublicationServices myConsumerPublicationService = new ConsumerPublicationServices();
            OpenSubscriptionSessionResponse myOpenSubscriptionSessionResponse = myConsumerPublicationService.OpenSubscriptionSession(textBoxHostName.Text, textBoxChannelId.Text, textBoxTopic.Text);

            textBoxStatusCode.Text = myOpenSubscriptionSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myOpenSubscriptionSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myOpenSubscriptionSessionResponse.ISBMHTTPResponse;

            textBoxSessionId.Text = myOpenSubscriptionSessionResponse.SessionID;
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {
            ConsumerPublicationServices myConsumerPublicationServices = new ConsumerPublicationServices();
            CloseSubscriptionSessionResponse myCloseSubscriptionSessionResponse = myConsumerPublicationServices.CloseSubscriptionSession(textBoxHostName.Text, textBoxSessionId.Text);

            textBoxStatusCode.Text = myCloseSubscriptionSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myCloseSubscriptionSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myCloseSubscriptionSessionResponse.ISBMHTTPResponse;
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            ConsumerPublicationServices myConsumerPublicationServices = new ConsumerPublicationServices();
            ReadPublicationResponse myReadPublicationResponse = myConsumerPublicationServices.ReadPublication(textBoxHostName.Text, textBoxSessionId.Text);

            textBoxStatusCode.Text = myReadPublicationResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myReadPublicationResponse.ReasonPhrase;
            textBoxResponse.Text = myReadPublicationResponse.ISBMHTTPResponse;

            textBoxMessageID.Text = myReadPublicationResponse.MessageID;
            textBoxTopic.Text = myReadPublicationResponse.Topic;
            textBoxBOD.Text = myReadPublicationResponse.MessageContent;
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            ConsumerPublicationServices myConsumerPublicationServices = new ConsumerPublicationServices();
            RemovePublicationResponse myRemovePublicationResponse = myConsumerPublicationServices.RemovePublication(textBoxHostName.Text, textBoxSessionId.Text);

            textBoxStatusCode.Text = myRemovePublicationResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myRemovePublicationResponse.ReasonPhrase;
            textBoxResponse.Text = myRemovePublicationResponse.ISBMHTTPResponse;

            textBoxBOD.Text = "";
            textBoxMessageID.Text = "";
            textBoxTopic.Text= "";
        }
    }
}
