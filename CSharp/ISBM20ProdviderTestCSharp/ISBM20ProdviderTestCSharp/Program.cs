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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Provider_Test
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
