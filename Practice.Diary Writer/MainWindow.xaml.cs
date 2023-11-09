using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Practice.Diary_Writer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window ,INotifyPropertyChanged
    {

        private string wordCounterVisual;

        public List<int> FontSizelist { get; set; } 

        public string WordCounterVisual
        {
            get { return wordCounterVisual; }
            set
            {
                wordCounterVisual = value;
                OnPropertyChanged("WordCounterVisual");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            WordCounterVisual = "0(0)";
            FontSizelist = new List<int>() { 6, 10, 15 , 20, 25, 30, 35, 40, 45, 50 };
        }

        //Create INotifyPrpertyChanged to update WordCounter(Complicated,ask the boy later
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) 
        {
            if(PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void TypeTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            DiaryPageBlck.Text = TypeTxtb.Text;
            string TrimmedText = DiaryPageBlck.Text.Trim(' ');
            //make a string of the textblock without space to count it.
            WordCounter Counter1 = new WordCounter { Counter = DiaryPageBlck.Text.Length, NoSpaceCounter = TrimmedText.Length };
            WordCounterVisual = Counter1.ToString();
            //Store the updated value for binding
            if (TypeTxtb.Text.Length >= 6000)
            {
                TypeTxtb.Text = TypeTxtb.Text.Substring(0,6000);//Limit Text Length to 6000 words counting White Space
            }
        }
        // a button that change style of text
        private void Italicbtn_Click(object sender, RoutedEventArgs e)
        {
            if (DiaryPageBlck.FontStyle != FontStyles.Italic)
            {
                DiaryPageBlck.FontStyle = FontStyles.Italic;
            }
            else
            {
                DiaryPageBlck.FontStyle = FontStyles.Normal;
            }    
        }

        private void Underlinebtn_Click(object sender, RoutedEventArgs e)
        {
            if (DiaryPageBlck.TextDecorations != TextDecorations.Underline)
            {
                DiaryPageBlck.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                DiaryPageBlck.TextDecorations = null;
            }
        }

        private void Boldbtn_Click(object sender, RoutedEventArgs e)
        {
            if (DiaryPageBlck.FontWeight != FontWeights.Bold)
            {
                DiaryPageBlck.FontWeight = FontWeights.Bold;
            }
            else
            {
                DiaryPageBlck.FontWeight = FontWeights.Regular;
            }
        }

        private void FontSizeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                double NewFontSize = (int)cb.SelectedValue;
                DiaryPageBlck.FontSize = NewFontSize;
            }
        }

            private void FontSizeList_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                if (!char.IsNumber(e.Text, e.Text.Length - 1))
                {
                    e.Handled = true;
                //Check FontSize to make sure it's a number 
                }
            }

        private void FontSizeList_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FontSizeList.Text != "")
            {
                DiaryPageBlck.FontSize = Convert.ToInt32(FontSizeList.Text);
                //Allow user to enter custom Font Size
            }
        }

        private void TxtAllignLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            DiaryPageBlck.TextAlignment = TextAlignment.Left;
        }

        private void TxtAllignMidBtn_Click(object sender, RoutedEventArgs e)
        {
            DiaryPageBlck.TextAlignment = TextAlignment.Center;
        }

        private void TxtAllignRightBtn_Click(Object sender, RoutedEventArgs e)
        {
            DiaryPageBlck.TextAlignment = TextAlignment.Right;
        }
    }
}

       
