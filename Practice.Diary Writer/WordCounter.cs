using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Practice.Diary_Writer
{
    public class WordCounter
    {

        public int Counter { get; set; }
        public int NoSpaceCounter { get ; set; }

        //New object that count Word with/without white space
        public override string ToString()
        {
            return Counter + "(" + NoSpaceCounter +")";
        }
         
    }
}
