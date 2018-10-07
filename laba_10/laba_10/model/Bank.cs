using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace laba_10.Models
{
    class Bank
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int Count { get; set; }

        public Bank(string title, string name, int count, string date)
        {
            this.Title = title;
            this.Name = name;
            this.Count = count;
            this.Date = date;
        }
    }

}
