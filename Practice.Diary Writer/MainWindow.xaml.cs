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
            this.DataContext = this;
            WordCounterVisual = "0(0)";
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
            CounterMethod();
            if (TypeTxtb.Text.Length >= 600)
            {
                TypeTxtb.Text = TypeTxtb.Text.Substring(0,600);
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


        private void CounterMethod()
        {
            string TrimmedText = DiaryPageBlck.Text.Trim(' ');
            WordCounter WordCounterValue = new WordCounter(DiaryPageBlck.Text.Length, TrimmedText.Length);
            //make a string of the textblock without space to count it.
            WordCounterVisual = $"{WordCounterValue.AllTextCounter}({WordCounterValue.NoSpaceCounter})";
            //Create a string value to store the updated value
        }

   
    }
}

       
