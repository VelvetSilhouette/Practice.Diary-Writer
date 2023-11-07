using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Diary_Writer
{
    public class WordCounter
    {

        public int Counter {  get; set; } = 0;
        public int NoSpaceCounter { get; set; } = 0;

        //New object that count Word with/without white space

        public override string ToString()
        {
            return Counter + "(" + NoSpaceCounter +")";
        }
         
    }
}
