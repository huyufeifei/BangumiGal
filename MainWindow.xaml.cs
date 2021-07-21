using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace BgmDesktop {

    public class Game {
        public int id, userCount;
        public string name, nameCN;
        public bool del;
        private Game() { }
        public Game(int Id, string Name, string NameCN) {
            id = Id;
            name = Name;
            nameCN = NameCN;
            del = false;
            userCount = 0;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Button headerLightButton;
        int userCnt;
        private string api = "https://bgm.tv/";

        public MainWindow() {
            InitializeComponent();
            Init();

        }

        private void Init() {
            headerLightButton = HomeButton;
            HomeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5c5c5c"));
            userCnt = 0;
            MakeUser(null, null);
            MakeUser(null, null);
        }
        
        private void GoHome(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            headerLightButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5c5c5c"));
            headerLightButton = button;
            ShowHome();
        }

        private void ShowHome() {
            //shower.Text = "点击了 首页";
            HomeGrid.Visibility = Visibility.Visible;
        }

        private void GoRating(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            headerLightButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5c5c5c"));
            headerLightButton = button;
            ShowRating();
        }

        private void ShowRating() {
            //shower.Text = "点击了 排行榜";
            HomeGrid.Visibility = Visibility.Hidden;
        }

        private void GoSelf(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            headerLightButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            headerLightButton = button;
            ShowSelf();
        }

        private void ShowSelf() {
            //shower.Text = "点击了 自我";
            HomeGrid.Visibility = Visibility.Hidden;
        }

        private void LableIn(object sender, MouseEventArgs e) {
            Label label = (Label)sender;
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fdfdfd"));
        }

        private void LableOut(object sender, MouseEventArgs e) {
            Label label = (Label)sender;
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c6c6c6"));
        }

        private void ButtonIn(object sender, MouseEventArgs e) {
            Button button = (Button)sender;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5c5c5c"));
        }

        private void ButtonOut(object sender, MouseEventArgs e) {
            Button button = (Button)sender;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3f3f3f"));
        }

        private void WindowClose(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void WindowSmall(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void WindowLarge(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            WindowLargeImage.Visibility = Visibility.Hidden;
            WindowNormalImage.Visibility = Visibility.Visible;
            WindowControlButton.Click -= WindowLarge;
            WindowControlButton.Click += WindowNormal;
            // WindowState = WindowState.Maximized;
            ChangeWindow(1);
        }

        private void WindowNormal(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            WindowNormalImage.Visibility = Visibility.Hidden;
            WindowLargeImage.Visibility = Visibility.Visible;
            WindowControlButton.Click -= WindowNormal;
            WindowControlButton.Click += WindowLarge;
            // WindowState = WindowState.Normal;
            ChangeWindow(0);
        }

        private bool IsWindowNormal() {
            return ActualWidth != SystemParameters.WorkArea.Width || ActualHeight != SystemParameters.WorkArea.Height;
        }

        private void TitleClick(object sender, MouseButtonEventArgs e) {
            if(e.ClickCount == 2) {
                if(IsWindowNormal()) {
                    WindowLarge(null, null);
                }
                else {
                    WindowNormal(null, null);
                }
            }
            if (IsWindowNormal()) {
                this.DragMove();
            }
        }

        Rect NormalWindow = Rect.Empty;//定义一个全局rect记录还原状态下窗口的位置和大小。
        /// <summary>
        /// 0 -> normal
        /// 1 -> max
        /// 2 -> left
        /// 3 -> right
        /// </summary>
        private void ChangeWindow(int state) {
            if(state == 0) {
                if(NormalWindow == Rect.Empty) {
                    NormalWindow = new Rect(this.Left, this.Top, this.Width, this.Height);
                }
                this.Left = NormalWindow.Left;
                this.Top = NormalWindow.Top;
                this.Width = NormalWindow.Width;
                this.Height = NormalWindow.Height;
                WindowNormalImage.Visibility = Visibility.Hidden;
                WindowLargeImage.Visibility = Visibility.Visible;
            }
            else if(state == 1) {
                NormalWindow = new Rect(this.Left, this.Top, this.Width, this.Height); //保存下当前位置与大小
                this.Left = 0; //设置位置
                this.Top = 0;
                this.Width = SystemParameters.WorkArea.Width; //设置大小
                this.Height = SystemParameters.WorkArea.Height;
            }
        }

        private void ChangeWindowState() {
            if (IsWindowNormal()) {
                ChangeWindow(1);
            }
            else {
                ChangeWindow(0);
            }
        }

        private void MakeUser(object sender, RoutedEventArgs e) {
            // make new textbox
            TextBox tb = new TextBox();
            tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#353738"));
            //tb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

            // make new checkbox
            CheckBox cb = new CheckBox() { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center, IsChecked = true};

            // make new button
            Button btn = new Button() { Height = 15, Width = 15 };
            btn.Click += DeleteUser;
            Image img = new Image() { Source = new BitmapImage(new Uri("Resourse/image/UI/delete.png", UriKind.Relative)) };
            btn.Content = img;

            // make new grid
            Grid target = new Grid() { Width = 120, Height = 20 };
            Thickness margin = target.Margin;
            margin.Top = 3;
            margin.Bottom = 3;
            target.Margin = margin;
            target.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            target.ColumnDefinitions.Add(new ColumnDefinition());
            target.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            target.Children.Add(cb);
            Grid.SetColumn(cb, 0);
            target.Children.Add(tb);
            Grid.SetColumn(tb, 1);
            target.Children.Add(btn);
            Grid.SetColumn(btn, 2);

            // make new rowDef
            RowDefinition rowDef = new RowDefinition();
            UserListGrid.RowDefinitions.Add(rowDef);

            // bind
            UserListGrid.Children.Add(target);
            Grid.SetRow(target, userCnt);
            userCnt = userCnt + 1;
        }

        private void DeleteUser(object sender, RoutedEventArgs e) {
            Grid thisUser = (Grid)((Control)sender).Parent;
            Grid father = (Grid)thisUser.Parent;
            father.Children.Remove(thisUser);
            for(int i = 0; i < father.Children.Count; i++) {
                Grid child = (Grid)VisualTreeHelper.GetChild(father, i);
                Grid.SetRow(child, i);
            }
            userCnt = userCnt - 1;
            father.RowDefinitions.RemoveAt(userCnt);
            //shower.Content = "remove row : " + Grid.GetRow(thisUser).ToString() + " tot count : " + father.RowDefinitions.Count.ToString();
        }

        private string GetUrl(string url) {
            string ans = null;
            WebRequest require = WebRequest.Create(url);
            require.Method = "GET";
            require.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:90.0) Gecko/20100101 Firefox/90.0");
            require.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            require.Headers.Add("Accept-Language", "en,zh-CN;q=0.8,zh;q=0.7,zh-TW;q=0.5,zh-HK;q=0.3,en-US;q=0.2");
            try {
                WebResponse response = require.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                ans = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch { }
            //Byte[] temp = Encoding.Default.GetBytes(ans);
            //ans = Encoding.UTF8.GetString(temp);
            return ans;
        }

        private int ToNumber(string s) {
            int ans = 0;
            foreach(char c in s) {
                ans = ans * 10 + (c - '0');
            }
            return ans;
        }

        private void Check(object sender, RoutedEventArgs e) {
            Dictionary<int, Game> dict = new Dictionary<int, Game>();
            int rightUserCount = 0, playUserCount = 0;
            for(int i = 0; i < UserListGrid.Children.Count; i++) {
                Grid child = (Grid)VisualTreeHelper.GetChild(UserListGrid, i);
                TextBox tb = (TextBox)VisualTreeHelper.GetChild(child, 1);
                string userName = tb.Text;
                string html = GetUrl(api + "game/list/" + userName + "/collect");
                if (html == null || html.Contains("<h2>呜咕，出错了</h2>")) {
                    tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ee5f5f"));
                }
                else {
                    tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#353738"));
                    ++rightUserCount;
                    CheckBox cb = (CheckBox)VisualTreeHelper.GetChild(child, 0);
                    bool isPlay = (bool)cb.IsChecked;
                    if(isPlay) {
                        playUserCount++;
                    }
                    // work on string
                    bool haveNextPage = true;
                    int nowPage = 1;
                    while (haveNextPage) {
                        haveNextPage = html.Contains("&rsaquo;&rsaquo;");
                        while (html.Contains("<h3>")) {
                            int pos = html.IndexOf("<h3>") + 23;
                            int pos2 = html.IndexOf("\"", pos);
                            int id = ToNumber(html.Substring(pos, pos2 - pos));
                            if(!dict.ContainsKey(id)) {
                                pos = html.IndexOf(">", pos2) + 1;
                                pos2 = html.IndexOf("<", pos);
                                string namecn = html.Substring(pos, pos2 - pos);
                                string name = "";
                                if (html.IndexOf("small", pos2) == pos2 + 6) {
                                    pos = pos2 + 25;
                                    pos2 = html.IndexOf("<", pos);
                                    name = html.Substring(pos, pos2 - pos);
                                }
                                else {
                                    name = namecn;
                                    namecn = "";
                                }
                                dict.Add(id, new Game(id, name, namecn));
                            }
                            if(isPlay) {
                                dict[id].userCount++;
                            }
                            else {
                                dict[id].del = true;
                            }
                            html = html.Substring(pos2);
                        }
                        if(haveNextPage) {
                            ++nowPage;
                            html = GetUrl(api + "game/list/" + userName + "/collect?page=" + nowPage.ToString());
                        }
                    }
                }
            }
            AnsArea.Children.Clear();
            int ansCount = 0;
            string ans = "";
            foreach(Game game in dict.Values) {
                if(game.del == false && game.userCount == playUserCount) {
                    ++ansCount;
                    ans += ansCount.ToString() + ":\n" + game.name + "\n";
                    if(game.nameCN != "") {
                        ans += game.nameCN + "\n";
                    }
                    ans += "\n";
                }
            }
            AnsArea.Children.Add(new Label() { Content = "总数：" + ansCount.ToString() + "\n\n" + ans });
        }
    }
}
