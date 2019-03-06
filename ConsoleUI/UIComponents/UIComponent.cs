using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.UIComponents
{
    public class UIComponent
    {
        public string Name { get; set; }
        public Action Action { get; set; }
    }
}

