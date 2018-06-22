using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Battleship
{
    public class Globals
    {
        public int BoardWidth { get; }
        public int BoardHeight { get; }

        public Globals()
        {
            BoardWidth = Int32.Parse(ConfigurationManager.AppSettings["WidthSize"]);
            BoardHeight = Int32.Parse(ConfigurationManager.AppSettings["HeightSize"]);
        }
    }
}
