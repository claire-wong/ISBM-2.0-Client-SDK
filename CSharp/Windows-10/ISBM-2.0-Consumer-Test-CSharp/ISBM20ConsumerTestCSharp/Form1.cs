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
            //Calling ISBM Adaper method
            ConsumerPublicationService myConsumerPublicationService = new ConsumerPublicationService();
            OpenSubscriptionSessionResponse myOpenSubscriptionSessionResponse = myConsumerPublicationService.OpenSubscriptionSession(textBoxHostName.Text, textBoxChannelId.Text, textBoxTopic.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myOpenSubscriptionSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myOpenSubscriptionSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myOpenSubscriptionSessionResponse.ISBMHTTPResponse;

            textBoxSessionId.Text = myOpenSubscriptionSessionResponse.SessionID;
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ConsumerPublicationService myConsumerPublicationService = new ConsumerPublicationService();
            CloseSubscriptionSessionResponse myCloseSubscriptionSessionResponse = myConsumerPublicationService.CloseSubscriptionSession(textBoxHostName.Text, textBoxSessionId.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myCloseSubscriptionSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myCloseSubscriptionSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myCloseSubscriptionSessionResponse.ISBMHTTPResponse;
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ConsumerPublicationService myConsumerPublicationService = new ConsumerPublicationService();
            ReadPublicationResponse myReadPublicationResponse = myConsumerPublicationService.ReadPublication(textBoxHostName.Text, textBoxSessionId.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myReadPublicationResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myReadPublicationResponse.ReasonPhrase;
            textBoxResponse.Text = myReadPublicationResponse.ISBMHTTPResponse;

            if (myReadPublicationResponse.StatusCode == 200)
            {
                textBoxMessageID.Text = myReadPublicationResponse.MessageID;
                textBoxTopic.Text = myReadPublicationResponse.Topic;
                textBoxBOD.Text = myReadPublicationResponse.MessageContent;
            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ConsumerPublicationService myConsumerPublicationService = new ConsumerPublicationService();
            RemovePublicationResponse myRemovePublicationResponse = myConsumerPublicationService.RemovePublication(textBoxHostName.Text, textBoxSessionId.Text, textBoxUserName.Text, textBoxPassword.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myRemovePublicationResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myRemovePublicationResponse.ReasonPhrase;
            textBoxResponse.Text = myRemovePublicationResponse.ISBMHTTPResponse;

            textBoxBOD.Text = "";
            textBoxMessageID.Text = "";
        }
    }
}
