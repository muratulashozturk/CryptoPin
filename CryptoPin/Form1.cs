using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gecko;


namespace CryptoPin
{
    public partial class Form1 : Form
    {
        string widgetHtml = "<html style='color:#4545F2;background-color:transparent;'> <!-- TradingView Widget BEGIN --> <style> .tv-ticker-item-last__title{ color:#4545F2; } span { border:none;color:#4545F2; } body { color:#4545F2;border:none; background-color: transparent; overflow: hidden; pointer-events: none;user-select: none; -webkit-user-select: none; -khtml-user-select: none; -moz-user-select: none; -ms-user-select: none } div { color:#4545F2;border:none; background-color : transparent; overflow: hidden; pointer-events: none;user-select: none; -webkit-user-select: none; -khtml-user-select: none; -moz-user-select: none; -ms-user-select: none } </style> <div class=\"tradingview-widget-container\"> <div class=\"tradingview-widget-container__widget\"></div> <script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-single-quote.js\" async> { \"symbol\": \"BITSTAMP:BTCUSD\", \"width\": 505, \"colorTheme\": \"light\", \"isTransparent\": true, \"locale\": \"en\" } </script> </div> </html>";
              

        public Form1()
        {
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var width = screen.Width;
            var height = screen.Height;
            var ustTaraf = height - (height - 200);
            var altTaraf = height - 200;
            Win32Api.SetWindowPosition(this.Handle,5, ustTaraf, 600, 100);
            Win32Api.SetWindowTopmost(this.Handle, true);
            Xpcom.Initialize(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Firefox64"));
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = false;
            this.Enabled = false;
            Cursor.Hide();
            Win32Api.ShowCursor(false);
            geckoWebBrowser1.LoadHtml(widgetHtml);
        }
    }
}
