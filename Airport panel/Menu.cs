using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

public class Menu
{
    public string Text { get; set; }
    public int Level { get; set; }
    public string Line { get; set; }

    public Menu()
    {

    }
    public Menu(string text, int level, string line)
    {
        Text = text;
        Level = level;
        Line = line;
    }

    public void ShowMenu(bool clearConsole = true)
    {
        if(clearConsole) Console.Clear();
        Console.SetWindowSize(100, 20);
        Console.WriteLine(Text);
    }

}
