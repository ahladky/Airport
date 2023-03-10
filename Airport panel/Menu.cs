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
        if (clearConsole) Console.Clear();
        Console.SetWindowSize(110, 30);
        Console.WriteLine(Text);
    }


    public Menu GetMenu(int level, string line)
    {
        Menu menu = new Menu();

        if (level == 0)
        {
            line = "Start";
        }
  
        foreach (Menu m in GetMenusList())
        {
            if (m.Level == level && m.Line == line)
            {
                menu = m;
                break;
            }
        }
        return menu;
    }

    public List<Menu> GetMenusList()
    {
        List<Menu> menu = new List<Menu>();
        string menuText = "";
        menuText = @"Сhoose role:
                    1. Passenger
                    2. Employee
                    3. Exit";
        menu.Add(new Menu(menuText, 0, "Start"));    // Start lvl 0

        #region PassengerMenu

        menuText = @"Navigation:
                    1. Airport panel
                    2. Search flight
                    3. Back";
        menu.Add(new Menu(menuText, 1, "Passenger")); //Passenger lvl 1
        menuText = @"Airport panel:
                    1. All flight
                    2. Arrival flight
                    3. Departure flight   
                    4. Back";
        menu.Add(new Menu(menuText, 2, "Passenger")); //Passenger lvl 2

        menuText = @"Search flight:
                    1. by the flight number 
                    2. by date of arrival
                    3. by arrival(departure) port
                    4. by arrival(departure) port, nearest (1 hour) flight                    
                    5. Back";
        menu.Add(new Menu(menuText, 3, "PassengerSearch")); //PassengerSearch lvl 3
        #endregion

        #region EmployeeMenu
        menuText = @"Navigation (Employee):
                    1. Airport panel
                    2. Edit flight
                    3. Flights pricelist
                    4. Passengers list
                    5. Search
                    6. Passengers (add,edit,delete)
                    7. Back";
        menu.Add(new Menu(menuText, 1, "Employee")); //Employee lvl 1
        menuText = @"Choose airport panel:
                    1. Arrivals flights
                    2. Departures flights
                    3. Back";
        menu.Add(new Menu(menuText, 2, "Employee")); //Employee lvl 2
        menuText = @"
                    1.Direction
                    2.DateTime Flight
                    3.Flight number
                    4.City arrival
                    5.Airline
                    6.Terminal
                    7.Flight status
                    8.Gates
                    9.Back";
        menu.Add(new Menu(menuText, 3, "Employee")); //Employee lvl 3
        menuText = @"Choose search by:
                    1. Flight number
                    2. First or second name
                    3. Passport
                    4. Arrival(departure) port
                    5. Back";
        menu.Add(new Menu(menuText, 3, "Employee")); //Employee lvl 3
        menuText = @"Choose what do with passenger:
                    1. Add passenger
                    2. Edit passenger
                    3. Delete passenger
                    4. Back";
        menu.Add(new Menu(menuText, 3, "Passenger")); //Employee lvl 3

        menuText = @"Choose field to edit:
                    1. First Name
                    2. Second Name
                    3. Nationality
                    4. Passport
                    5. Date Of Birthday
                    6. Sex
                    7. FlightClass
                    8. Back";
        menu.Add(new Menu(menuText, 4, "Passenger")); //Employee lvl 4

        #endregion


        return menu;

    }
}
