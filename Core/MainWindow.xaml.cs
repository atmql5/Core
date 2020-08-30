using System;
using System.Collections.Generic;
using System.Deployment.Internal;
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

namespace Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItem parentItem = null;
            GetChildren(parentItem);
        }
        private void GetChildren(TreeViewItem parentItem)
        {
            int id = 0;
            if(parentItem != null)
            {
                Solution s = (Solution)parentItem.Tag;
                id = s.Id;
            }
            List<Solution> solutionList = new List<Solution>();
            using (var db = new RoboContext())
            {
                solutionList = db.Solutions.Where(s => s.Pid == id).ToList();
            }
            foreach (Solution row in solutionList)
            {
                TreeViewItem newItem = new TreeViewItem()
                {
                    Header = row.Header,
                    Tag = row
                };
                
                if (parentItem == null)
                {
                    CTreeWiew.Items.Add(newItem);
                }
                else
                {
                   parentItem.Items.Add(newItem)
                }
                Solution k = (Solution)newItem.Tag;
                if ((k.Rgt - k.lft) > 1)
                {
                    GetChildren(newItem);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            RoboContext db = new RoboContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            MessageBox.Show("Ok");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RoboContext db = new RoboContext();
            db.Add(new Solution { Header = "ELECTRONICS", Type = 1, Pid = 0, Lft = 1, Rgt = 20 });
            db.Add(new Solution { Header = "TELEVISIONS", Type = 1, Pid = 1, Lft = 2, Rgt = 9 });
            db.Add(new Solution { Header = "TUBE", Type = 2, Pid = 2, Lft = 3, Rgt = 4 });
            db.Add(new Solution { Header = "LCD", Type = 2, Pid = 2, Lft = 5, Rgt = 6 });
            db.Add(new Solution { Header = "PLASMA", Type = 3, Pid = 2, Lft = 7, Rgt = 8 });
            db.Add(new Solution { Header = "PORTABLE ELECTRONICS", Type = 1, Pid = 1, Lft = 10, Rgt = 19 });
            db.Add(new Solution { Header = "MP3 PLAYERS", Type = 1, Pid = 6, Lft = 11, Rgt = 14 });
            db.Add(new Solution { Header = "FLASH", Type = 3, Pid = 7, Lft = 12, Rgt = 13 });
            db.Add(new Solution { Header = "CD PLAYERS", Type = 2, Pid = 6, Lft = 15, Rgt = 16 });
            db.Add(new Solution { Header = "2 WAY RADIOS", Type = 2, Pid = 6, Lft = 17, Rgt = 18 });
            db.Add(new Solution { Header = "KOMPUTERS", Type = 1, Pid = 0, Lft = 21, Rgt = 28 });
            db.Add(new Solution { Header = "PORTABLE", Type = 2, Pid = 11, Lft = 22, Rgt = 23 });
            db.Add(new Solution { Header = "DESKTOP", Type = 3, Pid = 11, Lft = 24, Rgt = 25 });
            db.Add(new Solution { Header = "SERVERS", Type = 2, Pid = 11, Lft = 26, Rgt = 27 });
            db.Add(new Solution { Header = "CARS", Type = 1, Pid = 0, Lft = 29, Rgt = 30 });
            db.SaveChanges();
            MessageBox.Show("Ok");
        }
    }
}
