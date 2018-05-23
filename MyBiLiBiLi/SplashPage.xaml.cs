using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace MyBiLiBiLi
{
    /// <summary>
    /// 欢迎页
    /// </summary>
    public sealed partial class SplashPage : Page
    {

        private DispatcherTimer timer;//跳转计时器

        private int timeCount = 0;
        private int totalTime = 2;

        public SplashPage()
        {
            this.InitializeComponent();
            var bg = new Color() { R = 233, G = 233, B = 233};
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                StatusBar statusBar = StatusBar.GetForCurrentView();//创建状态栏
                statusBar.ForegroundColor = Colors.Black;
                statusBar.BackgroundColor = bg;//灰色
                statusBar.BackgroundOpacity = 100;//透明度
            }
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = bg;
            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonHoverBackgroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = bg;
            titleBar.ButtonForegroundColor = Color.FromArgb(255, 254, 254, 254);
            titleBar.InactiveBackgroundColor = bg;
            titleBar.ButtonInactiveBackgroundColor = bg;
        }

        //跳转到下个界面
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);//间隔时间1s
            timer.Tick += Splash_Timer_Tick;//委托事件
            timer.Start();
        }

        private void Splash_Timer_Tick(object sender, object e)
        {
            if (timeCount != totalTime)
            {
                timeCount++;
            }else
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        //初始化，上个界面跳转过来
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            timer.Stop();
            timer = null;
        }

    }
}
