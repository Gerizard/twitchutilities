using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using AutoUpdaterDotNET;
using twitch_utils;
using twitch_utils.Properties;

namespace test_webview
{
    //Next improvement global variables to reduce code of urls of webview2s
    public partial class Utils : Form
    {
        public Utils()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            AutoUpdater.Start("https://raw.githubusercontent.com/Gerizard/twitchutilities/main/version.xml");

            string widget = File.ReadAllText("widgets.txt", Encoding.UTF8);
            string usernamewrite = File.ReadAllText("username.txt", Encoding.UTF8);


            if (widget == "Twitch Widgets")
            {
                comboBox1.Text = "Twitch Widgets";
                var url = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/quick-actions";
                var url2 = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/chat?uuid=b6b7f1f27da01485c2dece51233f97dd";

                Uri uri1 = new Uri(url);
                Uri uri2 = new Uri(url2);

                webView21.Source = uri1;
                webView22.Source = uri2;


                var url5 = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/stream-preview?uuid=e8afd8fbea227e8c6fc78f2ec522fc6a";
                var url6 = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/activity-feed?uuid=ae07cb61624ff41a45f594785a966194";

                Uri uri5 = new Uri(url5);
                Uri uri6 = new Uri(url6);

                webView25.Source = uri5;
                webView26.Source = uri6;

                textBox1.Text = usernamewrite;

                webView23.Visible = false;
                webView24.Visible = false;
                webView25.Visible = true;
                webView26.Visible = true;



            }
            else if (widget == "Twitch + StreamElements")
            {
                comboBox1.Text = "Twitch + Streamelements";
                var url = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/quick-actions";
                var url2 = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/chat?uuid=b6b7f1f27da01485c2dece51233f97dd";

                Uri uri1 = new Uri(url);
                Uri uri2 = new Uri(url2);

                webView21.Source = uri1;
                webView22.Source = uri2;

                var url3 = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/stream-preview?uuid=e8afd8fbea227e8c6fc78f2ec522fc6a";
                var url4 = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/activity-feed?uuid=ae07cb61624ff41a45f594785a966194";

                Uri uri3 = new Uri(url3);
                Uri uri4 = new Uri(url4);

                webView25.Source = uri3;
                webView26.Source = uri4;
                textBox1.Text = usernamewrite;

                webView23.Visible = true;
                webView24.Visible = true;
                webView25.Visible = false;
                webView26.Visible = false;

            }
            else
            {
                var url = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/quick-actions";
                var url2 = "https://dashboard.twitch.tv/popout/u/" + usernamewrite + "/stream-manager/chat?uuid=b6b7f1f27da01485c2dece51233f97dd";

                Uri uri1 = new Uri(url);
                Uri uri2 = new Uri(url2);

                webView21.Source = uri1;
                webView22.Source = uri2;
                textBox1.Text = usernamewrite;
            }

            string changelogshown = File.ReadAllText("changelogshown.txt", Encoding.UTF8);
            if (changelogshown == "false")
            {
                Changelog form = new Changelog();
                form.ShowDialog();
                File.WriteAllText("changelogshown.txt", "true");
            }
            else if (changelogshown == "true") { 
            //do nothing already shown
            }

        }










        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                string message = "Put Username";
                MessageBox.Show(message);
            }
            else
            {

                if (webView25.Visible == false && webView26.Visible == false)
                {

                    webView21.Reload();
                    webView22.Reload();
                    webView23.Reload();
                    webView24.Reload();

                }
                else if (webView23.Visible == false && webView24.Visible == false)
                {

                    webView21.Reload();
                    webView22.Reload();
                    webView25.Reload();
                    webView26.Reload();

                }
                else
                {
                    webView21.Reload();
                    webView22.Reload();
                    webView23.Reload();
                    webView24.Reload();
                    webView25.Reload();
                    webView26.Reload();
                }



            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                string message = "Put Username";
                MessageBox.Show(message);
            }
            else
            {
                //Actions and Chat change name
                var name = textBox1.Text;
                File.WriteAllText("username.txt", name);
                var url = "https://dashboard.twitch.tv/popout/u/" + name + "/stream-manager/quick-actions";
                var url2 = "https://dashboard.twitch.tv/popout/u/" + name + "/stream-manager/chat?uuid=b6b7f1f27da01485c2dece51233f97dd";

                Uri uri1 = new Uri(url);
                Uri uri2 = new Uri(url2);

                webView21.Source = uri1;
                webView22.Source = uri2;


                string widget = File.ReadAllText("widgets.txt", Encoding.UTF8);
                if (widget == "Twitch Widgets")
                {

                    var url3 = "https://dashboard.twitch.tv/popout/u/" + name + "/stream-manager/stream-preview?uuid=e8afd8fbea227e8c6fc78f2ec522fc6a";
                    var url4 = "https://dashboard.twitch.tv/popout/u/" + name + "/stream-manager/activity-feed?uuid=ae07cb61624ff41a45f594785a966194";

                    Uri uri3 = new Uri(url3);
                    Uri uri4 = new Uri(url4);

                    webView25.Source = uri3;
                    webView26.Source = uri4;



                }


            }

        }














        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var username2 = textBox1.Text;
            if (comboBox1.SelectedItem.Equals("Twitch Widgets"))
            {
                var widgets = comboBox1.SelectedItem.ToString();
                File.WriteAllText("widgets.txt", widgets);

                var url = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/quick-actions";
                var url2 = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/chat?uuid=b6b7f1f27da01485c2dece51233f97dd";

                Uri uri1 = new Uri(url);
                Uri uri2 = new Uri(url2);

                webView21.Source = uri1;
                webView22.Source = uri2;


                var url5 = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/stream-preview?uuid=e8afd8fbea227e8c6fc78f2ec522fc6a";
                var url6 = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/activity-feed?uuid=ae07cb61624ff41a45f594785a966194";

                Uri uri5 = new Uri(url5);
                Uri uri6 = new Uri(url6);

                webView25.Source = uri5;
                webView26.Source = uri6;



                webView23.Visible = false;
                webView24.Visible = false;
                webView25.Visible = true;
                webView26.Visible = true;

            }
            else if (comboBox1.SelectedItem.Equals("Twitch + StreamElements"))
            {
                var widgets2 = comboBox1.SelectedItem.ToString();
                File.WriteAllText("widgets.txt", widgets2);
                var url = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/quick-actions";
                var url2 = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/chat?uuid=b6b7f1f27da01485c2dece51233f97dd";

                Uri uri1 = new Uri(url);
                Uri uri2 = new Uri(url2);

                webView21.Source = uri1;
                webView22.Source = uri2;

                var url3 = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/stream-preview?uuid=e8afd8fbea227e8c6fc78f2ec522fc6a";
                var url4 = "https://dashboard.twitch.tv/popout/u/" + username2 + "/stream-manager/activity-feed?uuid=ae07cb61624ff41a45f594785a966194";

                Uri uri3 = new Uri(url3);
                Uri uri4 = new Uri(url4);

                webView25.Source = uri3;
                webView26.Source = uri4;


                webView23.Visible = true;
                webView24.Visible = true;
                webView25.Visible = false;
                webView26.Visible = false;
            }
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    System.Diagnostics.Process.Start("https://www.paypal.com/donate/?hosted_button_id=ZGDPQSZDGWWEY&sdkMeta=eyJ1cmwiOiJodHRwczovL3d3dy5wYXlwYWxvYmplY3RzLmNvbS9kb25hdGUvc2RrL2RvbmF0ZS1zZGsuanMiLCJhdHRycyI6eyJkYXRhLXVpZCI6IjljN2ZiM2VmNTFfbWplNm16cTZudGsifX0&targetMeta=eyJ6b2lkVmVyc2lvbiI6IjlfMF81OCIsInRhcmdldCI6IkRPTkFURSIsInNka1ZlcnNpb24iOiIwLjguMCJ9");
             
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AutoUpdater.Start("https://raw.githubusercontent.com/Gerizard/twitchutilities/main/version.xml");

        }

     

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changelog form = new Changelog();
            form.Show();
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Gerizard/twitchutilities/issues");
        }

        private void suggestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Gerizard/twitchutilities/issues");
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Twitch Username");
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(comboBox1, "Choose widgets");
        }
    }
}
