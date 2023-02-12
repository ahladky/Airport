using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

class Program
{
    static List<Passenger> GetPassenger()
    {
        List<Passenger> PassengerList = new List<Passenger>();
        PassengerList.Add(new Passenger(1, "Andriy", "Sname", "ukr", "DO09876", new DateOnly(1995, 5, 3), Sex.male));
        PassengerList.Add(new Passenger(2, "Oleg", "Sname1", "ukr", "DO09888", new DateOnly(2000, 5, 3), Sex.male));
        PassengerList.Add(new Passenger(3, "Anton", "Sname2", "ukr", "DO09668", new DateOnly(2001, 6, 7), Sex.male));
        PassengerList.Add(new Passenger(4, "Roman", "Sname3", "ukr", "DO09866", new DateOnly(1998, 7, 13), Sex.male));
        PassengerList.Add(new Passenger(5, "Vitaliy", "Sname4", "ukr", "DO09778", new DateOnly(1999, 5, 4), Sex.male));
        PassengerList.Add(new Passenger(6, "Oliya", "Sname5", "ukr", "DO09987", new DateOnly(1997, 9, 9), Sex.female));
        PassengerList.Add(new Passenger(7, "Oksana", "Sname6", "ukr", "DO09123", new DateOnly(1990, 3, 16), Sex.female));
        PassengerList.Add(new Passenger(8, "Sofiya", "Sname7", "ukr", "DO09111", new DateOnly(1989, 1, 20), Sex.female));
        return PassengerList;
    }
    static List<Flight> GetFlightsPanel()  
    {
        List<Flight> FlightsPanel = new List<Flight>();
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 10, 0, 0), "MA01033", "FR_ORY", "LOT", "A", FlightStatus.arrived, "A1", new Dictionary<string, ushort>() { { "Economy Class", 200 }, { "Business Class", 500 } }));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 2, 11, 0, 0), "MA01055", "UA_KYIV", "TurkishAir", "F", FlightStatus.check_in, "A2", new Dictionary<string, ushort>() { { "Economy Class", 50 }, { "Business Class", 300 } }));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 12, 0, 0), "MA01051", "PL_WRC", "AirBaltic", "B", FlightStatus.in_flight, "A3", new Dictionary<string, ushort>() { { "Economy Class", 100 }, { "Business Class", 400 } }));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 1, 12, 30, 0), "MA01036", "PL_WRC", "LOT", "E", FlightStatus.gate_closed, "A4", new Dictionary<string, ushort>() { { "Economy Class", 80 }, { "Business Class", 200 } }));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 2, 14, 0, 0), "MA01037", "GB_LHR", "Lufthansa", "C", FlightStatus.departed_at, "A1", new Dictionary<string, ushort>() { { "Economy Class", 70 }, { "Business Class", 150 } }));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 3, 15, 0, 0), "MA01038", "FR_ORY", "LowCostAir", "D", FlightStatus.check_in, "A2", new Dictionary<string, ushort>() { { "Economy Class", 90 }, { "Business Class", 220 } }));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 16, 0, 0), "MA01039", "GB_LHR", "AirBaltic", "B", FlightStatus.departed_at, "A3", new Dictionary<string, ushort>() { { "Economy Class", 60 }, { "Business Class", 250 } }));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 2, 17, 0, 0), "MA01040", "PL_WRC", "LowCostAir", "A", FlightStatus.canceled, "A4", new Dictionary<string, ushort>() { { "Economy Class", 100 } }));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 18, 0, 0), "MA01041", "FR_ORY", "BritishAir", "E", FlightStatus.expected_at, "A5", new Dictionary<string, ushort>() { { "Economy Class", 120 } }));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 2, 19, 0, 0), "MA01042", "GB_LHR", "LOT", "E", FlightStatus.delayed, "A6", new Dictionary<string, ushort>() { { "Economy Class", 80 }, { "Business Class", 220 } }));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 20, 0, 0), "MA01043", "UA_KYIV", "AirBaltic", "D", FlightStatus.check_in, "A4", new Dictionary<string, ushort>() { { "Business Class", 220 } }));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 3, 21, 0, 0), "MA01044", "UA_KYIV", "BritishAir", "C", FlightStatus.delayed, "A1", new Dictionary<string, ushort>() { { "Business Class", 800 } }));

        FlightsPanel[0].PassengerListId = new Dictionary<FlightClass, ushort[]>() { { FlightClass.economy, new ushort[] { 1, 2, 3 } }, { FlightClass.business, new ushort[] { 4, 5, 6 } } };
        FlightsPanel[1].PassengerListId = new Dictionary<FlightClass, ushort[]>() { { FlightClass.economy, new ushort[] { 3 } }, { FlightClass.business, new ushort[] { 6 } } };
        FlightsPanel[2].PassengerListId = new Dictionary<FlightClass, ushort[]>() { { FlightClass.economy, new ushort[] { 4, 5, 6 } }, { FlightClass.business, new ushort[] { 1, 7, 3 } } };
        FlightsPanel[3].PassengerListId = new Dictionary<FlightClass, ushort[]>() { { FlightClass.economy, new ushort[] { 1, 3 } }, { FlightClass.business, new ushort[] { 7, 2 } } };
        return FlightsPanel;
    }
    static List<Menu> GetMenusList()
    {
        List<Menu> menu = new List<Menu>();
        string menuText = "";
        menuText = @"Сhoose role:
            1. Passenger
            2. Employee
            3. Exit";
        menu.Add(new Menu(menuText, 0,"Start"));    // Start lvl 0

        #region PassengerMenu

        menuText = @"Navigation:
            1. Airport panel
            2. Edit flight
            3. Search flight
            4. Back";
        menu.Add(new Menu(menuText, 1, "Passenger")); //Passenger lvl 1
        menuText = @"Airport panel:
            1. All flight
            2. Arrival flight
            3. Departure flight   
            4. Back";
        menu.Add(new Menu(menuText, 2, "Passenger")); //Passenger lvl 2
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
        menu.Add(new Menu(menuText, 3, "PassengerEdit")); //PassengerEdit lvl 3
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
            2. Flights pricelist
            3. Passengers list
            4. Search
            5. Back";
        menu.Add(new Menu(menuText, 1, "Employee")); //Employee lvl 1
        menuText = @"Choose airport panel:
            1. Arrivals flights
            2. Departures flights
            3. Back";
        menu.Add(new Menu(menuText, 2, "Employee")); //Employee lvl 2
        #endregion


        return menu;
    }

    static Menu GetMenu(int level = 0, string line = "Start")
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
            }
         }
        return menu;
    }


    static void Main(string[] args)
    {

        List<Passenger> PassengerList = GetPassenger();
        List<Flight> FlightsPanel = GetFlightsPanel();
        List<Menu> menu = GetMenusList();
        Menu cur_menu = new Menu();

        long a;
        string flight_number;
        string editValue;
        int flightIndex;
        int varToOut = 0;
        int menuLevel = 0;
        string menuLine = "Start";
        List<Flight> FlightsPanelOne = new List<Flight>();
        List<Passenger> passes = new List<Passenger>();

       while(menuLevel >= 0)
        {
           menuLevel = 0;
           menuLine = "Start";
           cur_menu = GetMenu(menuLevel, menuLine);
           cur_menu.ShowMenu();

           a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:   //Passenger
                    {
                        menuLevel = 1;
                        menuLine = "Passenger";
                        while (menuLevel > 0)
                        {
                            menuLevel = 1;
                            menuLine = "Passenger";
                            cur_menu = GetMenu(menuLevel, menuLine);
                            cur_menu.ShowMenu();

                            a = long.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:  //Airport panel
                                    {
                                        menuLevel = 2;
                                        menuLine = "Passenger";

                                        while (menuLevel == 2)
                                        {                                           
                                            cur_menu = GetMenu(menuLevel, menuLine);
                                            cur_menu.ShowMenu();

                                            a = long.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1: // All flight
                                                    {
                                                        HeadTable();
                                                        BodyTable(FlightsPanel);
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Press any key, to go back");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                case 2: // Arrival flight
                                                    {
                                                        HeadTable();
                                                        BodyTable(FlightsPanel, "arrival");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Press any key, to go back");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                case 3: // Departure flight
                                                    {
                                                        HeadTable();
                                                        BodyTable(FlightsPanel, "departure");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Press any key, to go back");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                case 4: //Back
                                                    {
                                                        menuLevel -= 1;
                                                        cur_menu = GetMenu(menuLevel, "Passenger");
                                                        cur_menu.ShowMenu();
                                                        break;
                                                    }

                                            }
                                        }

                                        Console.WriteLine("");
                                        break;
                                    }
                                case 2: //Edit flight
                                    {
                                        HeadTable();
                                        BodyTable(FlightsPanel);
                                        Console.WriteLine("");

                                        do
                                        {
                                            flightIndex = -1;
                                            Console.WriteLine("Enter flight number you want to edit");
                                            flight_number = Console.ReadLine();
                                            flightIndex = FlightsPanel.FindIndex(c => c.Flight_number == flight_number);
                                            if (flightIndex < 0)
                                            {
                                                Console.WriteLine("Flight not found");
                                                Console.WriteLine("Press Spacebar to exit; press any key to continue");

                                                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                                                {
                                                    varToOut = 1;
                                                    break;
                                                }
                                            }
                                        }
                                        while (flightIndex < 0);
                                        {
                                            if (varToOut == 1)  break;
                                            menuLevel = 3;
                                            menuLine = "PassengerEdit";

                                            //do
                                            while(menuLevel == 3)
                                            {
                                                Console.WriteLine("Flight found");
                                                Console.Clear();
                                                HeadTable();
                                                FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                BodyTable(FlightsPanelOne);
                                                Console.WriteLine("");
                                                Console.WriteLine(@"Select a field to edit Flight - {0}: ", flight_number);
                                                
                                                cur_menu = GetMenu(menuLevel, menuLine);
                                                cur_menu.ShowMenu(false);

                                                a = long.Parse(Console.ReadLine());
                                                switch (a)
                                                {
                                                    case 1:  // Edit Direction
                                                        {
                                                            Console.WriteLine("Enter Direction new value (old value - {0}) (departure/arrival)", FlightsPanel[flightIndex].Direction);
                                                            editValue = Console.ReadLine();
                                                            try
                                                            {
                                                                FlightsPanel[flightIndex].EditDirection(editValue);
                                                                Console.WriteLine("Direction changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 2:  // Edit DateTime Flight
                                                        {
                                                            Console.WriteLine("Enter DateTime Flight new value (old value - {0})", FlightsPanel[flightIndex].DateTimeF);
                                                            editValue = Console.ReadLine();
                                                            try
                                                            {
                                                                FlightsPanel[flightIndex].EditDateTimeF(DateTime.Parse(editValue));
                                                                Console.WriteLine("DateTime Flight changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 3:  // Edit Flight number
                                                        {
                                                            Console.WriteLine("Enter Flight number new value (old value - {0})", FlightsPanel[flightIndex].Flight_number);
                                                            editValue = Console.ReadLine();
                                                            try
                                                            {
                                                                FlightsPanel[flightIndex].EditFlight_number(editValue);
                                                                Console.WriteLine("Flight number changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 4:  // Edit City
                                                        {
                                                            Console.WriteLine("Enter City arrival new value (old value - {0})", FlightsPanel[flightIndex].City_arrival);
                                                            editValue = Console.ReadLine();
                                                            try
                                                            {
                                                                FlightsPanel[flightIndex].EditCity_arrival(editValue);
                                                                Console.WriteLine("City arrival changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 5:  // Edit Airline
                                                        {
                                                            Console.WriteLine("Enter Airline new value (old value - {0})", FlightsPanel[flightIndex].Airline);
                                                            editValue = Console.ReadLine();
                                                            try
                                                            {
                                                                FlightsPanel[flightIndex].EditAirline(editValue);
                                                                Console.WriteLine("Airline changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 6:  // Edit Terminal
                                                        {
                                                            Console.WriteLine("Enter Terminal new value (old value - {0})", FlightsPanel[flightIndex].Terminal);
                                                            editValue = Console.ReadLine();
                                                            try
                                                            {
                                                                FlightsPanel[flightIndex].EditTerminal(editValue);
                                                                Console.WriteLine("Terminal changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 7: // Edit Flight status
                                                        {
                                                            Console.WriteLine("Enter Flight status new value (old value - {0})", FlightsPanel[flightIndex].Flight_status);
                                                            Console.WriteLine("check_in , gate_closed , arrived , departed_at , unknown , canceled , expected_at , delayed , in_flight");
                                                            try
                                                            {
                                                                FlightStatus flightStatus;
                                                                Enum.TryParse(Console.ReadLine(), out flightStatus);
                                                                FlightsPanel[flightIndex].EditFlightStatus(flightStatus);
                                                                Console.WriteLine("Flight status changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.ToString());
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 8:  // Edit Gates
                                                        {
                                                            Console.WriteLine("Enter Gates new value (old value - {0})", FlightsPanel[flightIndex].Gates);
                                                            editValue = Console.ReadLine();
                                                            try
                                                            {
                                                                FlightsPanel[flightIndex].EditGates(editValue);
                                                                Console.WriteLine("Gates changed!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                    case 9:  // Back
                                                        {
                                                            menuLevel -= 1;
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                }

                                                Console.WriteLine("");
                                                FlightsPanelOne.Clear();
                                               // Console.WriteLine("Press Spacebar to exit; press any key to continue edit Flight - {0}", flight_number);
                                            }
                                           // while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        }
                                        break;
                                    }
                                case 3: //Search flight 
                                    {
                                        menuLevel = 3;
                                        menuLine = "PassengerSearch";
                                        
                                        while (menuLevel == 3)
                                        {
                                            menuLevel = 3;
                                            menuLine = "PassengerSearch";
                                            cur_menu = GetMenu(menuLevel, menuLine);
                                            cur_menu.ShowMenu();                                            

                                            a = long.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1: //by the flight number
                                                    {
                                                        Console.Clear();
                                                        do
                                                        {
                                                            varToOut = 0;
                                                            flightIndex = -1;
                                                            Console.WriteLine("Enter flight number you want search");
                                                            flight_number = Console.ReadLine();
                                                            flightIndex = FlightsPanel.FindIndex(c => c.Flight_number == flight_number);
                                                            if (flightIndex < 0)
                                                            {
                                                                Console.WriteLine("Flight not found");
                                                                Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                                                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                                                                {
                                                                    varToOut = 1;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        while (flightIndex < 0);
                                                        {
                                                            if (varToOut == 1)
                                                            {
                                                                break;
                                                            }
                                                            HeadTable();
                                                            FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                            BodyTable(FlightsPanelOne);
                                                            Console.WriteLine("");
                                                            FlightsPanelOne.Clear();

                                                        }

                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 2: //by date of arrival
                                                    {
                                                        Console.Clear();
                                                        do
                                                        {
                                                            flightIndex = 0;
                                                            Console.WriteLine("Enter flight date of arrival you want search");
                                                            string search_text;
                                                            search_text = Console.ReadLine();
                                                            try
                                                            {
                                                                DateTime search_date = DateTime.Parse(search_text);
                                                                foreach (Flight flight in FlightsPanel)
                                                                {
                                                                    if (flight.DateTimeF.Year == search_date.Year
                                                                        && flight.DateTimeF.Month == search_date.Month
                                                                        && flight.DateTimeF.Day == search_date.Day
                                                                        && flight.Direction == "arrival")
                                                                    {
                                                                        FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                                    }
                                                                    flightIndex += 1;
                                                                }
                                                                HeadTable();
                                                                BodyTable(FlightsPanelOne);
                                                                Console.WriteLine("");
                                                                FlightsPanelOne.Clear();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                                        }
                                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 3: //by arrival(departure) port
                                                    {
                                                        do
                                                        {
                                                            Console.Clear();
                                                            flightIndex = 0;
                                                            Console.WriteLine("Enter arrival(departure) port you want search");
                                                            flight_number = Console.ReadLine();
                                                            foreach (Flight flight in FlightsPanel)
                                                            {
                                                                if (flight.City_arrival == flight_number)
                                                                {
                                                                    FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                                }
                                                                flightIndex += 1;
                                                            }
                                                            if (FlightsPanelOne.Count > 0)
                                                            {
                                                                HeadTable();
                                                                BodyTable(FlightsPanelOne);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Flights not found");
                                                            }
                                                            Console.WriteLine("");
                                                            FlightsPanelOne.Clear();

                                                            Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                                        }
                                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 4: //by arrival(departure) port, nearest (1 hour) flight
                                                    {
                                                        do
                                                        {
                                                            Console.Clear();
                                                            flightIndex = 0;
                                                            Console.WriteLine("Enter arrival(departure) port you want search");
                                                            string search_text;
                                                            search_text = Console.ReadLine();
                                                            try
                                                            {
                                                                DateTime search_date = new DateTime(2023, 03, 01, 12, 00, 00);//DateTime.Now;
                                                                foreach (Flight flight in FlightsPanel)
                                                                {
                                                                    if (flight.DateTimeF.Year == search_date.Year
                                                                        && flight.DateTimeF.Month == search_date.Month
                                                                        && flight.DateTimeF.Day == search_date.Day
                                                                        && flight.DateTimeF.Hour >= search_date.Hour  // DateTime.Now.Hour
                                                                        && flight.DateTimeF.Hour <= search_date.Hour + 1  // DateTime.Now.Hour+2
                                                                        && flight.City_arrival == search_text)
                                                                    {
                                                                        FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                                    }
                                                                    flightIndex += 1;
                                                                }
                                                                if (FlightsPanelOne.Count > 0)
                                                                {
                                                                    HeadTable();
                                                                    BodyTable(FlightsPanelOne);
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Flights not found");
                                                                }
                                                                Console.WriteLine("");
                                                                FlightsPanelOne.Clear();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                            Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                                        }
                                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 5: //Back
                                                    {
                                                        menuLevel -= 1;
                                                        cur_menu = GetMenu(menuLevel, "Passenger");
                                                        cur_menu.ShowMenu();
                                                        break;
                                                    }
                                            }
                                        }

                                        break;
                                    }
                                case 4: //Back
                                    {
                                        menuLevel -= 1;
                                        cur_menu = GetMenu(menuLevel, "Passenger");
                                        cur_menu.ShowMenu();
                                        break;
                                    }
                            }
                        }
                        break;
                    };
                case 2:   //Employee
                    {
                        menuLevel = 1;
                        menuLine = "Employee";
                        while (menuLevel > 0)                            
                        {
                            menuLevel = 1;
                            cur_menu = GetMenu(menuLevel, menuLine);
                            cur_menu.ShowMenu();
                            a = long.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1: //Airport panel
                                    {
                                        menuLevel = 2;
                                        menuLine = "Employee";

                                        while(menuLevel == 2)
                                        {
                                            menuLevel = 2;
                                            menuLine = "Employee";
                                            cur_menu = GetMenu(menuLevel, menuLine);
                                            cur_menu.ShowMenu();

                                            a = long.Parse(Console.ReadLine());
                                            HeadTable();
                                            switch (a)
                                            {
                                                case 1:  //FlightsPanel - arrival
                                                    {
                                                        HeadTable();
                                                        BodyTable(FlightsPanel, "arrival");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Press any key, to go back");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                case 2: //FlightsPanel - departure
                                                    {
                                                        HeadTable();
                                                        BodyTable(FlightsPanel, "departure");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Press any key, to go back");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                case 3: // Back
                                                    {
                                                        menuLevel -= 1;
                                                        cur_menu = GetMenu(menuLevel, menuLine);
                                                        cur_menu.ShowMenu();
                                                        break;
                                                    }
                                            }
             
                                        }
                                        

                                        
                                        break;
                                    };
                                case 2: //Flights pricelist
                                    {
                                        #region old code find
                                        //Console.Clear();
                                        //do
                                        //{
                                            
                                        //    varToOut = 0;
                                        //    flightIndex = -1;
                                        //    Console.WriteLine("Enter flight number");
                                        //    flight_number = Console.ReadLine();
                                        //    flightIndex = FlightsPanel.FindIndex(c => c.Flight_number == flight_number);
                                        //    if (flightIndex < 0)
                                        //    {
                                        //        Console.WriteLine("Flight not found");
                                        //        Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                        //        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                                        //        {
                                        //            varToOut = 1;
                                        //            break;
                                        //        }
                                        //    }
                                        //}
                                        //while (flightIndex < 0);
                                        //{
                                        //    if (varToOut == 1)
                                        //    {
                                        //        break;
                                        //    }
                                        //    HeadTable();
                                        //    FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                        //    BodyTable(FlightsPanelOne);
                                        //    Console.WriteLine("");
                                        //    Console.WriteLine("");
                                        //    Console.WriteLine("Flight pricelist: ");
                                        //    foreach (var flight in FlightsPanelOne)
                                        //    {
                                        //        foreach (var dic in flight.FlightsCost)
                                        //        {
                                        //            Console.WriteLine("{0} - {1} $", dic.Key, dic.Value);
                                        //        }
                                        //        //break;
                                        //    }
                                        //    Console.WriteLine("");
                                        //    FlightsPanelOne.Clear();

                                        //}
                                        #endregion
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter flight number you want search");
                                            Flight findFlight = ViewFlightByNumber(Console.ReadLine(), FlightsPanel);
                                            if (findFlight.Flight_number != "")
                                            {
                                                ViewFlightPrices(findFlight);
                                            }
                                            else 
                                            { 
                                                Console.WriteLine("Flight not found");
                                            }
                                            Console.WriteLine("");
                                            Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                        }
                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        Console.WriteLine("");
                                        break;
                                    };
                                case 3: //Passengers list
                                    {
                                        Console.Clear();
                                        #region old code find   
                                        //do
                                        //{

                                        //    varToOut = 0;
                                        //    flightIndex = -1;
                                        //    Console.WriteLine("Enter flight number");
                                        //    flight_number = Console.ReadLine();
                                        //    flightIndex = FlightsPanel.FindIndex(c => c.Flight_number == flight_number);
                                        //    if (flightIndex < 0)
                                        //    {
                                        //        Console.WriteLine("Flight not found");
                                        //        Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                        //        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                                        //        {
                                        //            varToOut = 1;
                                        //            break;
                                        //        }
                                        //    }
                                        //}
                                        //while (flightIndex < 0);
                                        //{
                                        //    if (varToOut == 1)
                                        //    {
                                        //        break;
                                        //    }
                                        //    HeadTable();
                                        //    FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                        //    BodyTable(FlightsPanelOne);
                                        //    Console.WriteLine("");
                                        //    Console.WriteLine("");
                                        //    Console.WriteLine("Flight passengers list: ");

                                        //    foreach (var flight in FlightsPanelOne)
                                        //    {
                                        //        //foreach (var pl in flight.PassengerList)
                                        //        //{

                                        //        HeadTablePassengers(Console.GetCursorPosition().Top + 1);
                                        //        BodyTablePassengers(flight.PassengerList, Console.GetCursorPosition().Top + 1);
                                        //        //}
                                        //        passes = flight.PassengerList;

                                        //    }
                                        //    Console.WriteLine("");
                                        //    //FlightsPanelOne.Clear();
                                        //}
                                        #endregion
                                        Flight findFlight = new Flight();
                                        do
                                        {
                                            Console.WriteLine("Enter flight number you want search");
                                            findFlight = ViewFlightByNumber(Console.ReadLine(), FlightsPanel);
                                            if (findFlight.Flight_number != "")
                                            {
                                                ViewFlightPrices(findFlight);
                                                Console.WriteLine("");
                                                Console.WriteLine("Flight passengers list: ");
                                                HeadTablePassengers();
                                                BodyTablePassengers(findFlight.PassengerList);
                                                passes = findFlight.PassengerList;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Flight not found");
                                                Console.WriteLine("");
                                                Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                            }                                            
                                            
                                        }
                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        Console.WriteLine("");

                                        do
                                        {
                                            Console.WriteLine(@"Do with flight passengers list:
            1. Add passenger
            2. Edit passenger
            3. Delete passenger
            4. Back
            ");
                                            a = long.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1: //Add passenger
                                                    {
                                                        
                                                        Console.WriteLine("Enter ID: ");
                                                        ushort id = ushort.Parse(Console.ReadLine());
                                                        Console.WriteLine("Enter First Name: ");
                                                        string firstName = Console.ReadLine();
                                                        Console.WriteLine("Enter Second Name: ");
                                                        string secondName = Console.ReadLine();
                                                        Console.WriteLine("Enter Nationality: ");
                                                        string nationality = Console.ReadLine();
                                                        Console.WriteLine("Enter Passport: ");
                                                        string passport = Console.ReadLine();
                                                        Console.WriteLine("Enter DateOfBirthday (format dd.mm.yyyy): ");
                                                        DateOnly dateOfBirthday = DateOnly.FromDateTime(DateTime.Now);
                                                        try
                                                        {
                                                            dateOfBirthday = DateOnly.Parse(Console.ReadLine());
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }                                                        
                                                        Console.WriteLine("Enter Sex (values - {0} / {1}): ",Sex.male,Sex.female);
                                                        Sex sex;
                                                        Enum.TryParse(Console.ReadLine(), out sex);
                                                        Console.WriteLine("Enter FlightClass  (values - {0} / {1}): ", FlightClass.economy, FlightClass.business);
                                                        FlightClass flightClass;
                                                        Enum.TryParse(Console.ReadLine(), out flightClass);

                                                        try 
                                                        {
                                                         //FlightsPanel[flightIndex].PassengerList.Add(new Passenger(id, firstName, secondName, nationality, passport, dateOfBirthday, sex, flightClass));
                                                         foreach (Flight flight in FlightsPanel)
                                                            {
                                                                if (flight.CompareToByFlight(findFlight) == 0)
                                                                {
                                                                   // flight.PassengerList.Add(new Passenger(id, firstName, secondName, nationality, passport, dateOfBirthday, sex, flightClass));
                                                                    Console.WriteLine("Add passenger");
                                                                }
                                                            }                                                         
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }                                                        
                                                        break;
                                                    }
                                                case 2: //Edit passenger
                                                    {
                                                        Passenger passenger = new Passenger();

                                                        Console.WriteLine("");
                                                        Console.WriteLine("Enter id passengers to start edit: ");
                                                        long passenger_id = long.Parse(Console.ReadLine());
                                                        foreach (var f in passes)
                                                        {
                                                            if (f.ID == passenger_id)
                                                            {
                                                                passenger = f;
                                                                break;
                                                            }
                                                        }

                                                        Console.WriteLine(@"Edit passengers:
            1. First Name
            2. Second Name
            3. Nationality
            4. Passport
            5. Date Of Birthday
            6. Sex
            7. FlightClass
            8. Exit
            ");
                                                        a = long.Parse(Console.ReadLine());
                                                        switch (a)
                                                        {
                                                            case 1:  // Edit First Name
                                                                {
                                                                    Console.WriteLine("Enter First Name: ");
                                                                    string enterValue = Console.ReadLine();
                                                                    passenger.EditFirstName(enterValue);
                                                                    break;
                                                                }
                                                            case 2: // Edit Second Name
                                                                {
                                                                    Console.WriteLine("Enter Second Name: ");
                                                                    string enterValue = Console.ReadLine();
                                                                    passenger.EditSecondName(enterValue);
                                                                    break;
                                                                }
                                                            case 3: // Edit Nationality
                                                                {
                                                                    Console.WriteLine("Enter Nationality: ");
                                                                    string enterValue = Console.ReadLine();
                                                                    passenger.EditNationality(enterValue);
                                                                    break;
                                                                }
                                                            case 4: // Edit Passport
                                                                {
                                                                    Console.WriteLine("Enter Passport: ");
                                                                    string enterValue = Console.ReadLine();
                                                                    passenger.EditPassport(enterValue);
                                                                    break;
                                                                }
                                                            case 5: // Edit Date Of Birthday
                                                                {
                                                                    Console.WriteLine("Enter DateOfBirthday (format dd.mm.yyyy): ");
                                                                    DateOnly dateOfBirthday = DateOnly.FromDateTime(DateTime.Now);
                                                                    try
                                                                    {
                                                                        dateOfBirthday = DateOnly.Parse(Console.ReadLine());
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Console.WriteLine(ex.Message);
                                                                    }
                                                                    Console.WriteLine("Enter Date Of Birthday (format dd.mm.yyyy): ");
                                                                    DateOnly dateOfBD = DateOnly.FromDateTime(DateTime.Now);
                                                                    try
                                                                    {
                                                                        dateOfBD = DateOnly.Parse(Console.ReadLine());
                                                                        passenger.EditDateOfBirthday(dateOfBD);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Console.WriteLine(ex.Message);
                                                                    }
                                                                    
                                                                    break;
                                                                }
                                                            case 6: // Edit Sex
                                                                {
                                                                    Console.WriteLine("Enter Sex (values - {0} / {1}) (old value {2}): ", Sex.male, Sex.female,passenger.Sex);
                                                                    try
                                                                    {
                                                                        Sex sex;
                                                                        Enum.TryParse(Console.ReadLine(), out sex);
                                                                        passenger.EditSex(sex);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Console.WriteLine(ex.Message);
                                                                    }
                                                                    break;
                                                                }
                                                            case 7: // Edit FlightClass
                                                                {
                                                                    //Console.WriteLine("Enter FlightClass  (values - {0} / {1}) (old value {2}): ", FlightClass.economy, FlightClass.business, passenger.FlightClass);
                                                                    try
                                                                    {
                                                                        FlightClass flightClass;
                                                                        Enum.TryParse(Console.ReadLine(), out flightClass);
                                                                        //passenger.EditFlightClass(flightClass);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Console.WriteLine(ex.Message);
                                                                    }
                                                                    
                                                                    
                                                                    break;
                                                                }
                                                            case 8: // Exit
                                                                {
                                                                   // goto startPoint;
                                                                    break;
                                                                }
                                                        }

                                                        try
                                                        {
                                                            foreach (Flight flight in FlightsPanel)
                                                            {
                                                                if (flight.CompareToByFlight(findFlight) == 0)
                                                                {
                                                                    foreach (Passenger p in flight.PassengerList)
                                                                    {
                                                                        if (p.ID == passenger.ID)
                                                                        {
                                                                            p.FirstName = passenger.FirstName;
                                                                            p.SecondName = passenger.SecondName;
                                                                            p.Nationality = passenger.Nationality;
                                                                            p.Passport = passenger.Passport;
                                                                            p.DateOfBirthday = passenger.DateOfBirthday;
                                                                            p.Sex = passenger.Sex;
                                                                            //p.FlightClass = passenger.FlightClass;  
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        //List<Passenger> newList = new List<Passenger>();
                                                        //foreach (var f in passes)
                                                        //{
                                                        //    if (f.ID == a)
                                                        //    {
                                                        //        newList.Add(passenger);                                                              
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        newList.Add(f);
                                                        //    }
                                                        //}

                                                        //FlightsPanel[flightIndex].EditPassengerList(newList);

                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 3: //Delete passenger
                                                    {

                                                        Passenger passenger = new Passenger();

                                                        Console.WriteLine("");
                                                        Console.WriteLine("Enter id passengers to delete: ");
                                                        a = long.Parse(Console.ReadLine());
   
                                                        List<Passenger> newList = new List<Passenger>();
                                                        foreach (var f in passes)
                                                        {
                                                            if (f.ID != a)
                                                            {
                                                                newList.Add(f);
                                                            }                                                            
                                                        }
                                                        //FlightsPanel[flightIndex].EditPassengerList(newList);

                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        // goto startPoint;
                                                        break;
                                                    }
                                            }

                                            FlightsPanelOne.Clear();
                                            Console.WriteLine("Press Spacebar to exit; press any key to continue do with passengers list");
                                        }
                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        {

                                        }

                                        FlightsPanelOne.Clear();
                                        break;
                                    };
                                case 4: //Search flight 
                                    {
                                        Console.Clear();

                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine(@"Search by:
            1. Flight number
            2. First or second name
            3. Passport
            4. Arrival(departure) port
            5. Back
            ");
                                            a = long.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1: // Flight number
                                                    {
                                                        #region old code find
                                                        //    do
                                                        //    {
                                                        //        varToOut = 0;
                                                        //        flightIndex = -1;
                                                        //        Console.WriteLine("Enter flight number you want search");
                                                        //        flight_number = Console.ReadLine();
                                                        //        flightIndex = FlightsPanel.FindIndex(c => c.Flight_number == flight_number);
                                                        //        if (flightIndex < 0)
                                                        //        {
                                                        //            Console.WriteLine("Flight not found");
                                                        //            Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                                        //            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                                                        //            {
                                                        //                varToOut = 1;
                                                        //                break;
                                                        //            }
                                                        //        }
                                                        //    }
                                                        //    while (flightIndex < 0);
                                                        //    {
                                                        //        if (varToOut == 1)
                                                        //        {
                                                        //            break;
                                                        //        }
                                                        //        HeadTable();
                                                        //        FlightsPanelOne.Clear();
                                                        //        FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                        //        BodyTable(FlightsPanelOne);
                                                        //        Console.WriteLine("");
                                                        //        FlightsPanelOne.Clear();
                                                        //    }
                                                        #endregion
                                                        do
                                                        {
                                                            Console.WriteLine("Enter flight number you want search");
                                                            if (ViewFlightByNumber(Console.ReadLine(), FlightsPanel).Flight_number == "")
                                                            {
                                                               Console.WriteLine("Flight not found");
                                                            }
                                                            Console.WriteLine("");
                                                            Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                                        }
                                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 2: // First or second name
                                                    {
                                                        Console.WriteLine("Enter first or second name what you want search");
                                                        string passenger_name = Console.ReadLine();                                                       
                                                        int countFound = 0;
                                                        List<Passenger> passenger_list = new List<Passenger>();


                                                        foreach (var flight in FlightsPanel)
                                                        {

                                                            foreach (var passenger in flight.PassengerList)
                                                            {
                                                                //if(passenger.FirstName == passenger_name || passenger.SecondName == passenger_name)
                                                                if (passenger.CompareToByName(passenger_name) == 0)
                                                                {
                                                                    passenger_list.Add(passenger);
                                                                    countFound += 1;
                                                                }
                                                            }
                                                            if (passenger_list.Count > 0)
                                                            {
                                                                Console.WriteLine("Flight number {0}", flight.Flight_number);
                                                                //HeadTablePassengers(Console.GetCursorPosition().Top + 1);
                                                                //BodyTablePassengers(passenger_list, Console.GetCursorPosition().Top + 1);
                                                                Console.WriteLine("");
                                                            }
                                                           
                                                            passenger_list.Clear();
                                                        }
                                                         if(countFound == 0)
                                                        {
                                                            Console.WriteLine("Not found!");
                                                        }
                                                          
                                                        
                                                        break;
                                                    }
                                                case 3: // Passport
                                                    {
                                                        Console.WriteLine("Enter passport what you want search");
                                                        string passport = Console.ReadLine();
                                                        int countFound = 0;
                                                        List<Passenger> passenger_list = new List<Passenger>();
                                                        foreach (var flight in FlightsPanel)
                                                        {
                                                            foreach (var passenger in flight.PassengerList)
                                                            {
                                                                //if (passenger.Passport == passport)
                                                                if(passenger.CompareToByPassport(passport) == 0)
                                                                {
                                                                    passenger_list.Add(passenger);
                                                                    countFound += 1;
                                                                }
                                                            }
                                                            if (passenger_list.Count > 0)
                                                            {
                                                                Console.WriteLine("Flight number {0}", flight.Flight_number);
                                                                //HeadTablePassengers(Console.GetCursorPosition().Top + 1);
                                                                //BodyTablePassengers(passenger_list, Console.GetCursorPosition().Top + 1);
                                                                Console.WriteLine("");
                                                            }
                                                   
                                                            passenger_list.Clear();
                                                        }

                                                        if (countFound == 0)
                                                        {
                                                            Console.WriteLine("Not found!");
                                                        }
                                                        break;
                                                    }
                                                case 4: // Arrival(departure) port
                                                    {
                                                        #region old code find
                                                        //Console.WriteLine("Enter arrival(departure) port what you want search");
                                                        //string port = Console.ReadLine();
                                                        //int countFound = 0;
                                                        //FlightsPanelOne.Clear();
                                                        //foreach (var flight in FlightsPanel)
                                                        //{
                                                        //    if(flight.City_arrival == port)
                                                        //    {
                                                        //       FlightsPanelOne.Add(flight);
                                                        //        countFound += 1;
                                                        //    }
                                                        //}
                                                        //if(FlightsPanelOne.Count > 0)
                                                        //{
                                                        //    HeadTable();
                                                        //    BodyTable(FlightsPanelOne);
                                                        //}
                                                        //if (countFound == 0)
                                                        //{
                                                        //    Console.WriteLine("Not found!");
                                                        //}
                                                        #endregion

                                                        do
                                                        {   
                                                            Console.WriteLine("Enter arrival(departure) port what you want search");
                                                            if (ViewFlightByPort(Console.ReadLine(), FlightsPanel) != 1)
                                                            {
                                                                Console.WriteLine("Flight not found");
                                                            }
                                                            Console.WriteLine("");
                                                            Console.WriteLine("Press Spacebar to exit; press any key to try againe");
                                                        }
                                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        //goto startPoint;
                                                        break;
                                                    }
                                            }

                                             Console.WriteLine("Press Spacebar to exit; press any key to choose search again");
                                        }
                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        {
                                        }
                                        break;
                                    };
                                case 5: //Back
                                    {
                                        menuLevel -= 1;
                                        cur_menu = GetMenu(menuLevel, "Employee");
                                        cur_menu.ShowMenu();
                                        break;
                                    }
                            }
                            Console.WriteLine("");                           
                        }                        
                    
                        break;
                    };
                case 3:   //Exit
                    {
                        menuLevel = -1;
                        Console.Clear();
                        Console.WriteLine("Good bay!");
                        break;
                    }
            }
            Console.WriteLine("");
        }

        Console.ReadLine();
        Environment.Exit(0);

    }



    static void HeadTable()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write("| Direction ");
        Console.SetCursorPosition(12, 0);
        Console.Write("| Date/time ");
        Console.SetCursorPosition(36, 0);
        Console.Write("| Number ");
        Console.SetCursorPosition(46, 0);
        Console.Write("| City ");
        Console.SetCursorPosition(56, 0);
        Console.Write("| Airline ");
        Console.SetCursorPosition(66, 0);
        Console.Write("| Terminal ");
        Console.SetCursorPosition(76, 0);
        Console.Write("| FlightStatus ");
        Console.SetCursorPosition(86, 0);
        Console.Write("| Gates ");
    }


    static void BodyTable(List<Flight> flightsPanel, string direction = null)
    {
        int i;
        foreach (Flight f in flightsPanel)
        {
            i = Console.GetCursorPosition().Top + 1;
            if (f.Direction == direction || direction == null)
            {               
                Console.SetCursorPosition(0, i);
                Console.Write("| " + f.Direction + " ");
                Console.SetCursorPosition(12, i);
                Console.Write("| " + f.DateTimeF + " ");
                Console.SetCursorPosition(36, i);
                Console.Write("| " + f.Flight_number + " ");
                Console.SetCursorPosition(46, i);
                Console.Write("| " + f.City_arrival + " ");
                Console.SetCursorPosition(56, i);
                Console.Write("| " + f.Airline + " ");
                Console.SetCursorPosition(66, i);
                Console.Write("| " + f.Terminal + " ");
                Console.SetCursorPosition(76, i);
                Console.Write("| " + f.Flight_status + " ");
                Console.SetCursorPosition(86, i);
                Console.Write("| " + f.Gates);       
                i +=1;
            }

        }
    }
    static void BodyTable(Flight f)
    {
        int i = Console.GetCursorPosition().Top + 1;
        
                Console.SetCursorPosition(0, i);
                Console.Write("| " + f.Direction + " ");
                Console.SetCursorPosition(12, i);
                Console.Write("| " + f.DateTimeF + " ");
                Console.SetCursorPosition(36, i);
                Console.Write("| " + f.Flight_number + " ");
                Console.SetCursorPosition(46, i);
                Console.Write("| " + f.City_arrival + " ");
                Console.SetCursorPosition(56, i);
                Console.Write("| " + f.Airline + " ");
                Console.SetCursorPosition(66, i);
                Console.Write("| " + f.Terminal + " ");
                Console.SetCursorPosition(76, i);
                Console.Write("| " + f.Flight_status + " ");
                Console.SetCursorPosition(86, i);
                Console.Write("| " + f.Gates);
                 
    }

    static void HeadTablePassengers()
    {
        //Console.Clear();
        int i = Console.GetCursorPosition().Top + 1;
        Console.SetCursorPosition(0, i);
        Console.Write("| id ");
        Console.SetCursorPosition(4, i);
        Console.Write("| FirstName ");
        Console.SetCursorPosition(20, i);
        Console.Write("| SecondName ");
        Console.SetCursorPosition(40, i);
        Console.Write("| Nationality ");
        Console.SetCursorPosition(50, i);
        Console.Write("| Passport ");
        Console.SetCursorPosition(60, i);
        Console.Write("| DateOfBirthday ");
        Console.SetCursorPosition(75, i);
        Console.Write("| Sex ");
        Console.SetCursorPosition(85, i);
        Console.Write("| FlightClass ");

    }

    static void BodyTablePassengers(List<Passenger> flightsPassengers)
    {
        int i = Console.GetCursorPosition().Top + 1;
        foreach (Passenger f in flightsPassengers)
        {
                Console.SetCursorPosition(0, i);
                Console.Write("| " + f.ID + " ");
                Console.SetCursorPosition(4, i);
                Console.Write("| " + f.FirstName + " ");
                Console.SetCursorPosition(20, i);
                Console.Write("| " + f.SecondName + " ");
                Console.SetCursorPosition(40, i);
                Console.Write("| " + f.Nationality + " ");
                Console.SetCursorPosition(50, i);
                Console.Write("| " + f.Passport + " ");
                Console.SetCursorPosition(60, i);
                Console.Write("| " + f.DateOfBirthday + " ");
                Console.SetCursorPosition(75, i);
                Console.Write("| " + f.Sex + " ");
                Console.SetCursorPosition(85, i);
               // Console.Write("| " + f.FlightClass + " ");

                i += 1;
        }
    }

    public static Flight ViewFlightByNumber (string fl_num, List<Flight> flights)
    {
        // int isFound = 0;
        Flight findFlight = new Flight();
        foreach (Flight f in flights)
        {
            if (f.CompareToByFlightNum(fl_num) == 0)
            {
                Console.Clear();
                HeadTable();
                BodyTable(f);
                findFlight = f;
             //   isFound = 1;
            }
        }
        Console.WriteLine("");
        return findFlight;
    }
    public static void ViewFlightPrices(Flight flight)
    {
        foreach (var c in flight.FlightsCost)
        {
            Console.WriteLine("{0} - {1} $", c.Key, c.Value);
        }
    }
    public static int ViewFlightByPort(string fl_port, List<Flight> flights)
    {
        int isFound = 0;
        foreach (Flight f in flights)
        {
            if (f.CompareToByFlightPort(fl_port) == 0)
            {
                if (isFound == 0) 
                {
                    HeadTable();
                }               
                BodyTable(f);
                isFound = 1;
            }
        }
        Console.WriteLine("");
        return isFound;
    }

}