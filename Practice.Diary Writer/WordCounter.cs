using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Diary_Writer
{
    public class WordCounter
    {

        public int AllTextCounter {  get; set; }
        public int NoSpaceCounter { get; set; }

        //New object that count Word with/without white space

        public WordCounter (int AllTextCounter,int NoSpaceCounter) 
        {
            this.AllTextCounter = AllTextCounter;
            this.NoSpaceCounter = NoSpaceCounter;
        }
    }
}
