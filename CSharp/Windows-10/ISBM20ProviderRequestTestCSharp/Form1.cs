/* Purpose: This is a simple application that acts as an ISBM publication Provider.
 *          It demonstrates the idea of using an ISBM Client Adapter to post publication 
 *          to an ISBM Server Adapter. It should be interoperable with any ISBM compatible
 *          adapters regardless of the actual service bus that delivers the messages.  
 *          
 * Author: Claire Wong
 * Date Created:  2022/08/13
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
using RapidRedPanda.ISBM.ClientAdapter;
using RapidRedPanda.ISBM.ClientAdapter.ResponseType;
using RapidRedPanda.ISBM.ClientAdapter.EndpointOptions;


namespace ISBM20ProviderRequestTestCSharp
{
    public partial class Form1 : Form
    {
        ProviderRequestService myProviderRequestService = new ProviderRequestService(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bodFilePath = AppDomain.CurrentDomain.BaseDirectory + "BODs\\ShowMeasurements.json";
            textBoxBODResponse.Text = File.ReadAllText(bodFilePath);
        }

        private void buttonOpenSession_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adapter method
            myProviderRequestService.Credentials.Username = textBoxUserName.Text;
            myProviderRequestService.Credentials.Password = textBoxPassword.Text;
              
            OpenProviderRequestSessionResponse mProviderRequestServiceResponse = myProviderRequestService.OpenProviderRequestSession(textBoxHostName.Text, textBoxChannelId.Text, textBoxTopic.Text);
            
            //ISBM Adapter Response
            textBoxStatusCode.Text = mProviderRequestServiceResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = mProviderRequestServiceResponse.ReasonPhrase;
            textBoxResponse.Text = mProviderRequestServiceResponse.ISBMHTTPResponse;

            textBoxSessionId.Text = mProviderRequestServiceResponse.SessionID;
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adapter method
            CloseProviderRequestSessionResponse myCloseProviderRequestSessionResponse = myProviderRequestService.CloseProviderRequestSession(textBoxHostName.Text, textBoxSessionId.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myCloseProviderRequestSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myCloseProviderRequestSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myCloseProviderRequestSessionResponse.ISBMHTTPResponse;
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            ReadRequestResponse myReadRequestResponse = myProviderRequestService.ReadRequest(textBoxHostName.Text, textBoxSessionId.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myReadRequestResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myReadRequestResponse.ReasonPhrase;
            textBoxResponse.Text = myReadRequestResponse.ISBMHTTPResponse;

            if (myReadRequestResponse.StatusCode == 200)
            {
                textBoxMessageId.Text = myReadRequestResponse.MessageID;
                textBoxRequestMessageId.Text = myReadRequestResponse.MessageID;
                textBoxBODRequest.Text = myReadRequestResponse.MessageContent;
            }
        }

        private void buttonResponse_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adapter method
            PostResponseResponse myPostResponseResponse = myProviderRequestService.PostResponse(textBoxHostName.Text, textBoxSessionId.Text, textBoxRequestMessageId.Text, textBoxBODResponse.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myPostResponseResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myPostResponseResponse.ReasonPhrase;
            textBoxResponse.Text = myPostResponseResponse.ISBMHTTPResponse;

            textBoxMessageId.Text = myPostResponseResponse.MessageID;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Calling ISBM Adaper method
            RemoveRequestResponse myRemoveRequestResponse = myProviderRequestService.RemoveRequest(textBoxHostName.Text, textBoxSessionId.Text);

            //ISBM Adapter Response
            textBoxStatusCode.Text = myRemoveRequestResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myRemoveRequestResponse.ReasonPhrase;
            textBoxResponse.Text = myRemoveRequestResponse.ISBMHTTPResponse;

            textBoxBODRequest.Text = "";
            textBoxMessageId.Text = "";
        }
    }
}
