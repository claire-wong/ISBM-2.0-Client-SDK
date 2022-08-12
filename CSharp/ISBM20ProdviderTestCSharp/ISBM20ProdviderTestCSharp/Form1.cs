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
using System.IO;
using ISBM20ClientAdapter;
using ISBM20ClientAdapter.ResponseType;


namespace Provider_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bodFilePath = AppDomain.CurrentDomain.BaseDirectory + "BODs\\SyncMeasurements.json";
            textBoxBOD.Text = File.ReadAllText(bodFilePath);
        }

        private void buttonOpenSession_Click(object sender, EventArgs e)
        {
            ProviderPublicationService myProviderPublicationService = new ProviderPublicationService();
            OpenPublicationSessionResponse myOpenPublicationSessionResponse = myProviderPublicationService.OpenPublicationSession(textBoxHostName.Text, textBoxChannelId.Text);

            textBoxStatusCode.Text = myOpenPublicationSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myOpenPublicationSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myOpenPublicationSessionResponse.ISBMHTTPResponse;

            textBoxSessionId.Text = myOpenPublicationSessionResponse.SessionID;
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {
            ProviderPublicationService myProviderPublicationService = new ProviderPublicationService();
            ClosePublicationSessionResponse myClosePublicationSessionResponse = myProviderPublicationService.ClosePublicationSession(textBoxHostName.Text, textBoxSessionId.Text);

            textBoxStatusCode.Text = myClosePublicationSessionResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myClosePublicationSessionResponse.ReasonPhrase;
            textBoxResponse.Text = myClosePublicationSessionResponse.ISBMHTTPResponse;

        }

            private void buttonPushlish_Click(object sender, EventArgs e)
        {
            ProviderPublicationService myProviderPublicationService = new ProviderPublicationService();
            PostPublicationResponse myPostPublicationResponse = myProviderPublicationService.PostPublication(textBoxHostName.Text, textBoxSessionId.Text, textBoxTopic.Text, textBoxBOD.Text);
            
            textBoxStatusCode.Text = myPostPublicationResponse.StatusCode.ToString();
            textBoxReasonPhrase.Text = myPostPublicationResponse.ReasonPhrase;
            textBoxResponse.Text = myPostPublicationResponse.ISBMHTTPResponse;
            
            textBoxMessageID.Text = myPostPublicationResponse.MessageID;

        }
    }
}
