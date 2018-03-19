
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
using System.Threading;
using System.IO;
using Microsoft.Win32;
using TagLib;
namespace CheckBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random random_index = new Random(); //index for random track
        public bool SongIsSelected = false; //song was choosed
        System.Windows.Threading.DispatcherTimer MusicTimer = new System.Windows.Threading.DispatcherTimer();// timer for slider
        private MediaPlayer player = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            Circle.Tag = false;
            Uri iconUri = new Uri(@"pack://application:,,,/bin/Debug/PlayerImages/ICO.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            player.Volume=0.5;
            MusicTimer.Tick += new EventHandler(Tack);
            MusicTimer.Tag = false;
            player.MediaOpened += Player_BufferingEnded;
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Poul\Music");
            foreach (FileInfo song in d.GetFiles())
            {
                if (System.IO.Path.GetExtension(song.FullName) == ".mp3")
                {
                    TagLib.File tagFile = TagLib.File.Create(song.FullName);   
                    string title = tagFile.Tag.Title;
                    ListViewItem temp = new ListViewItem();
                    temp.Content = title;
                    temp.Selected += Selecting;
                    temp.Tag = song.FullName;
                    list.Items.Add(temp);
                }
            }
        }
        private void Tack(object sender, EventArgs e)
        {
            if (Mysl.Value == (int)player.NaturalDuration.TimeSpan.TotalSeconds)
            {
                select("next");
                if (Songs.SelectedItem != null)
                    Selecting(Songs.SelectedItem, e);
                else
                    Selecting(list.SelectedItem, e);

                return;
            }
            int hours, minutes, seconds;                                                                                                     //setting the value of slider(slider = total player's position)
            hours = Convert.ToInt32((player.Position.TotalSeconds - player.Position.TotalSeconds % 3600) / 3600);
            minutes = Convert.ToInt32(((((player.Position.TotalSeconds) % 3600) - ((player.Position.TotalSeconds) % 3600) % 60) / 60));
            seconds = Convert.ToInt32(((int)(player.Position.TotalSeconds) % 3600) % 60);
            label1.Content = "";
            if (hours < 10)
                label1.Content += "0";
            label1.Content += Convert.ToString(hours) + ":";
            if (minutes < 10)
                label1.Content += "0";
            label1.Content += Convert.ToString(minutes) + ":";
            if (seconds < 10)
                label1.Content += "0";
            label1.Content += Convert.ToString(seconds);
            Mysl.Value = player.Position.TotalSeconds;
        }
        private void Player_BufferingEnded(object sender, EventArgs e)// when song is loaded
        {
            if(!SongIsSelected)
                SongIsSelected = true;
            Mysl.Minimum = 0;
            Mysl.Maximum = (int)player.NaturalDuration.TimeSpan.TotalSeconds;
            Mysl.Interval = 1;
            int H, M, S;
            H = Convert.ToInt32(Mysl.Maximum / 3600);
            M = Convert.ToInt32(Math.Truncate((Mysl.Maximum % 3600) / 60));
            S = Convert.ToInt32(Math.Truncate((Mysl.Maximum % 3600) % 60));
            label2.Content = "";
            if (H < 10)
                label2.Content += "0";
            label2.Content += Convert.ToString(H) + ":";
            if (M < 10)
                label2.Content += "0";
            label2.Content += Convert.ToString(M) + ":";
            if (S < 10)
                label2.Content += "0";
            label2.Content += Convert.ToString(S); // track's duration
            MusicTimer.Start();
            Play.Tag = false;
            MusicTimer.Interval = new TimeSpan(0, 0, 1);
            MusicTimer.Start();
            MusicTimer.Tag = true;
            Pause_Play_Clicked(null, null);
        }
        
        public void select(string mode)// choosing previon or next song(mode - "next","prew")
        {
            int new_songs_index=-1;
           if(list.SelectedItem==null)//song is in album "Best"
            {
                if (mode == "next")
                {
                    if ( Songs.SelectedIndex != (Songs.Items.Count - 1))
                    {
                        new_songs_index = Songs.SelectedIndex + 1;
                    }
                    else
                    {
                        if ((bool)Circle.Tag == true)
                            new_songs_index = 0;
                    }
                }
                else
                {
                    if (Songs.SelectedIndex != 0)
                    {
                        new_songs_index = list.SelectedIndex - 1;
                    }
                    else
                    {
                        if ((bool)Circle.Tag == true)
                            new_songs_index = Songs.Items.Count - 1;
                    }
                }
            }
            else  //song is in album "All Songs"
            {
                if (mode == "next")
                {
                    if (list.SelectedIndex != (list.Items.Count - 1))
                    {
                        new_songs_index = list.SelectedIndex + 1;
                    }
                    else
                    {
                        if ((bool)Circle.Tag == true)
                            new_songs_index = 0;
                    }
                }
                else
                {
                    if (list.SelectedIndex != 0)
                    {
                        new_songs_index = list.SelectedIndex - 1;
                    }
                    else
                    {
                        if ((bool)Circle.Tag == true)
                            new_songs_index = list.Items.Count - 1;
                        else
                            return;
                    }
                }
            }
          if(new_songs_index!=-1)
            list.SelectedItem = list.Items[new_songs_index];
        }
        void Selecting(object sender, EventArgs e)// operations after selecting of ListViewItem (song)
        {
            Play.Tag = true;
            pl.Source = new BitmapImage(new Uri(@"pack://application:,,,/bin/Debug/PlayerImages/Button1.png"));
            player.Position = TimeSpan.FromSeconds(0);
            player.Stop();
            MusicTimer.Stop();
            MusicTimer.Tag = false;
            Mysl.Value = 0;
            label1.Content = "00:00:00";
            label2.Content = "00:00:00";
            player.Close();

            if (sender.GetType()!=typeof(System.Windows.Threading.DispatcherTimer))//if event wasn't called by user (called from timer tick)
            {
                if (BestSongs.Visibility == Visibility.Hidden)
                    Songs.SelectedItem = null;
                else
                    list.SelectedItem = null;
            }
            ListViewItem selected_item = (ListViewItem)sender;
            player.Open(new Uri(selected_item.Tag.ToString(), UriKind.Relative));
            TagLib.File tagFile = TagLib.File.Create(selected_item.Tag.ToString());
            if (tagFile.Tag.Pictures.Length > 0)
            {
                var picture = tagFile.Tag.Pictures[0];
                ImageBox.Source = BitmapFrame.Create(new MemoryStream(picture.Data.Data));
            }
            else
            {
                ImageBox.Source = new BitmapImage(new Uri(@"pack://application:,,,/bin/Debug/PlayerImages\DefoltImage.png"));
            }
            SongAlbum.Visibility = Visibility.Visible;
            SongName.Visibility = Visibility.Visible;
            SongArtist.Visibility = Visibility.Visible;
            listalbum.Visibility = Visibility.Visible;
            listartist.Visibility = Visibility.Visible;

            SongName.Content = tagFile.Tag.Title;
            if (tagFile.Tag.FirstAlbumArtist != null)
                SongArtist.Content = tagFile.Tag.FirstAlbumArtist;
            else
                SongArtist.Content = "unknown";
           
            if (tagFile.Tag.Album!=null)
                SongAlbum.Content = tagFile.Tag.Album;
            else
                SongAlbum.Content = "unknown";
        }
        private void ClickWindow(object sender, MouseButtonEventArgs e) //hiding the ListView
        {
            if (list.Visibility == Visibility.Visible)
                list.Visibility = Visibility.Hidden;
            if (BestSongs.Visibility == Visibility.Visible)
                BestSongs.Visibility = Visibility.Hidden;
        }
        private void ClickList(object sender, EventArgs e)
        {
            if (list.Visibility == Visibility.Hidden)
                list.Visibility = Visibility.Visible;
            else
                list.Visibility = Visibility.Hidden;
        }
        private void AlbomClick(object sender, RoutedEventArgs e)
        {
            if (BestSongs.Visibility == Visibility.Hidden)
                BestSongs.Visibility = Visibility.Visible;
            else
                BestSongs.Visibility = Visibility.Hidden;
        }
        public List<ListViewItem> GetOpenedSongs()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "mp3";
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
            openFileDialog.Multiselect = true;
            openFileDialog.ShowDialog();
            List<ListViewItem> OpenedSongs = new List<ListViewItem>();

            foreach (string path_to_song in openFileDialog.FileNames)
            {
                ListViewItem opened_song = new ListViewItem();
                opened_song.Content = System.IO.Path.GetFileName(path_to_song);

                opened_song.Selected += Selecting;
                opened_song.Tag = path_to_song;
                OpenedSongs.Add(opened_song);
            }
            return OpenedSongs;
        }
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            foreach (ListViewItem temp in GetOpenedSongs())
            {
                ListViewItem opened_song = new ListViewItem();
                opened_song.Content = temp.Content;
                opened_song.Tag = temp.Tag;
                opened_song.Selected += Selecting;
                list.Items.Add(opened_song);
            }
        }
        private void AddSong(object sender, EventArgs e)
        {
            foreach (ListViewItem opened_song in GetOpenedSongs())
            {
                ListViewItem adding_song = new ListViewItem();
                adding_song.Content = opened_song.Content;
                adding_song.Tag = opened_song.Tag;
                adding_song.Selected += Selecting;
                Songs.Items.Add(adding_song);
            }
        }
        private void Remove(object sender, EventArgs e)
        {
            if (Songs.SelectedItem != null)
                Songs.Items.Remove(Songs.SelectedItem);
        }
        private void Add_To_Best(object sender, EventArgs e)
        {
            if (list.SelectedItem == null)
                return;
            ListViewItem selected = (ListViewItem)list.SelectedItem;
            if (Songs.Items.Count > 0)
            {
                foreach (ListViewItem item_of_BestAlbum in Songs.Items)
                {
                    if (selected.Content == item_of_BestAlbum.Content)
                        return;
                }
            }
            ListViewItem liked_song = new ListViewItem();
            liked_song.Content = selected.Content;
            liked_song.Tag = selected.Tag;
            liked_song.Selected += Selecting;
            Songs.Items.Add(liked_song);
        }
        void RandomSong(object sender, EventArgs e) //choosing random song
        {
            ListViewItem temp = (ListViewItem)list.Items[random_index.Next(list.Items.Count)];
            list.SelectedItem = temp;
            SongIsSelected = true;
            Selecting(temp, e);
        }
        private void ClBack(object sender, MouseButtonEventArgs e)
        {
            if (SongIsSelected)
            {
                if (Mysl.Value <= 5)
                    Mysl.Value = 0;
                else
                    Mysl.Value -= 5;

                player.Position = TimeSpan.FromSeconds(Mysl.Value);
            }
        }
        private void ClForward(object sender, RoutedEventArgs e)
        {
            if (SongIsSelected)
            {
                if (Mysl.Value + 5 >= Mysl.Maximum)
                    Mysl.Value = Mysl.Maximum;
                else
                    Mysl.Value += 5;

                player.Position = TimeSpan.FromSeconds(Mysl.Value);
            }
        }
        private void NextSong(object sender, MouseButtonEventArgs e)
        {
            if (SongIsSelected)
            {
                if (e.ClickCount > 1)
                    return;
                select("next");
                if (Songs.SelectedItem != null)
                    Selecting(Songs.SelectedItem, e);
                else
                    Selecting(list.SelectedItem, e);
            }
        }
        private void PrewSong(object sender, MouseButtonEventArgs e)
        {
            if (SongIsSelected)
            {
              
                select("prew");
                if (Songs.SelectedItem != null)
                    Selecting(Songs.SelectedItem, e);
                else
                    Selecting(list.SelectedItem, e);
            }
        }
        private void Pause_Play_Clicked(object sender, RoutedEventArgs e)
        {
            if (SongIsSelected)
            {
                if (!(bool)Play.Tag)
                {
                    if (!(bool)MusicTimer.Tag)
                    {
                        player.Close();
                        ListViewItem temp = (ListViewItem)list.SelectedItem;
                        player.Open(new Uri(temp.Tag.ToString(), UriKind.Relative));
                    }
                    player.Position = TimeSpan.FromSeconds(Mysl.Value);
                    player.Play();
                    pl.Source = new BitmapImage(new Uri(@"pack://application:,,,/bin\Debug\PlayerImages\Button2.png"));
                }
                else
                {
                    player.Pause();
                    pl.Source = new BitmapImage(new Uri(@"pack://application:,,,/bin\Debug\PlayerImages\Button1.png"));
                }
                Play.Tag = !(bool)Play.Tag;
            }
        }
        private void ValChan(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SongIsSelected)
            {
                if (sender.GetType() == typeof(Slider))
                {
                    player.Position = TimeSpan.FromSeconds(Mysl.Value);
                }
            }
        }
        private void  MD(object sender, RoutedEventArgs e)
        {
                if (SongIsSelected)
                    player.Pause();
        }
        private void CircleClick(object sender, EventArgs e)
        {
            if((bool)Circle.Tag!=true)
            {
               CircleImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/bin\Debug\PlayerImages\CircleArrow1.png"));
            }
            else
            {
                CircleImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/bin\Debug\PlayerImages\CircleArrow2.png"));
            }
            Circle.Tag = !(bool)Circle.Tag;
        }
        private void  MU(object sender, RoutedEventArgs e)
        {
            if (SongIsSelected)
                player.Play();
        }
        private void Bal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Balance = Bal.Value / 100;
        }
        private void  MuteClick(object sender,  EventArgs e)
        {
            if (volumeslider.Muted)
                volumeslider.ValueOfSlider = volumeslider.value_before_muted;
            else
            {
                volumeslider.value_before_muted = volumeslider.ValueOfSlider;
                volumeslider.ValueOfSlider = 0;
            }
          volumeslider.Muted = !volumeslider.Muted;
          player.Volume = volumeslider.ValueOfSlider/100;
    }
        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            if(!volumeslider.Muted)
            player.Volume = volumeslider.ValueOfSlider / 100;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow Info = new InfoWindow();
            Info.ShowDialog();
        }
    }
}
