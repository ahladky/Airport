using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

class Program
{
  

    static void Main(string[] args)
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
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 20, 0, 0), "MA01043", "UKR_KYIV", "AirBaltic", "D", FlightStatus.check_in, "A4", new Dictionary<string, ushort>() { { "Business Class", 220 } }));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 3, 21, 0, 0), "MA01044", "UA_KYIV", "BritishAir", "C", FlightStatus.delayed, "A1", new Dictionary<string, ushort>() { { "Business Class", 800 } }));

        FlightsPanel[0].PassengerList.Add(new Passenger(1,"Fname","Sname","ukr","DO09876", new DateOnly(1995, 5, 3),Sex.male,FlightClass.economy));
        FlightsPanel[0].PassengerList.Add(new Passenger(2,"Fname1", "Sname1", "ukr", "DO09888", new DateOnly(2000, 5, 3), Sex.female, FlightClass.business));


        long a;
        string flight_number;
        string editValue;
        int flightIndex;
        int varToOut = 0;
        List<Flight> FlightsPanelOne = new List<Flight>();
        List<Passenger> passes = new List<Passenger>();
        do
        {

            Console.Clear();
            Console.SetWindowSize(100, 20);
            Console.WriteLine(@"Сhoose role:
            1. Passenger
            2. Employee
            ");

           a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:   //Passenger
                    {
                        do
                        {
                            Console.Clear();
                            Console.SetWindowSize(100, 20);
                            Console.WriteLine(@"Navigation:
            1. Airport panel
            2. Edit flight
            3. Search flight 
            ");

                            a = long.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:  //Airport panel
                                    {
                                        Console.WriteLine(@"Airport panel:
                    1. All flight
                    2. Arrival flight
                    3. Departure flight
                    ");

                                        a = long.Parse(Console.ReadLine());
                                        switch (a)
                                        {
                                            case 1:
                                                {
                                                    HeadTable();
                                                    BodyTable(FlightsPanel);
                                                    Console.WriteLine("");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    HeadTable();
                                                    BodyTable(FlightsPanel, "arrival");
                                                    Console.WriteLine("");
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    HeadTable();
                                                    BodyTable(FlightsPanel, "departure");
                                                    Console.WriteLine("");
                                                    break;
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
                                            if (varToOut == 1)
                                            {
                                                break;
                                            }

                                            do
                                            {
                                                Console.WriteLine("Flight found");
                                                Console.Clear();
                                                HeadTable();
                                                FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                BodyTable(FlightsPanelOne);
                                                Console.WriteLine("");
                                                Console.WriteLine(@"Select a field to edit Flight - {0}:
                       1. Direction
                       2. DateTime Flight
                       3. Flight number
                       4. City arrival
                       5. Airline
                       6. Terminal
                       7. Flight status
                       8. Gates
                       9. Exit", flight_number);

                                                a = long.Parse(Console.ReadLine());
                                                switch (a)
                                                {
                                                    case 1:
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
                                                    case 2:
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
                                                    case 3:
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
                                                    case 4:
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
                                                    case 5:
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
                                                    case 6:
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
                                                    case 7:
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
                                                    case 8:
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
                                                    case 9:
                                                        {
                                                            Console.WriteLine("");
                                                            break;
                                                        }
                                                }

                                                Console.WriteLine("");

                                                //Console.WriteLine("Press Spacebar to exit; press any key to continue edit Flight - {0}", flight_number);
                                                //if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                                                FlightsPanelOne.Clear();
                                                Console.WriteLine("Press Spacebar to exit; press any key to continue edit Flight - {0}", flight_number);
                                            }

                                            while (Console.ReadKey().Key != ConsoleKey.Spacebar);

                                        }


                                        break;
                                    }
                                case 3: //Search flight 
                                    {

                                        do
                                        {
                                            Console.Clear();

                                            Console.WriteLine(@"Search flight:
                    1. by the flight number 
                    2. by date of arrival
                    3. by arrival(departure) port
                    4. by arrival(departure) port, nearest (1 hour) flight
                    ");

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
                                                            // flightIndex = FlightsPanel.FindIndex(c => c.City_arrival == flight_number);
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
                                            }

                                            Console.WriteLine("Press Spacebar to exit; press any key to another search");

                                        }
                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        Console.WriteLine("");
                                        break;
                                    }
                                default:
                                    Console.WriteLine("Exit");
                                    break;
                            }

                            Console.WriteLine("Press Spacebar to exit; press any key to go start Navigation");
                        }
                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                        {
                            Console.WriteLine("Exit");


                        }
                        break;
                    };
                case 2:   //Employee
                    {
                        do
                        {
                        startPoint:
                            Console.Clear();
                            Console.SetWindowSize(100, 20);
                            Console.WriteLine(@"Navigation (Employee):
            1. Airport panel
            2. Flights pricelist
            3. Passengers list
            4. Search 
            ");

                            a = long.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1: //Airport panel
                                    {
                                        do
                                        {
                                            //тут вибір типу рейсів
                                            Console.Clear();
                                            Console.SetWindowSize(100, 20);
                                            Console.WriteLine(@"Choose airport panel:
            1. Arrivals flights
            2. Departures flights
            3. Back
            ");

                                            a = long.Parse(Console.ReadLine());

                                            switch (a)
                                            {
                                                case 1:
                                                    {
                                                        HeadTable();
                                                        BodyTable(FlightsPanel, "arrival");
                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        HeadTable();
                                                        BodyTable(FlightsPanel, "departure");
                                                        Console.WriteLine("");
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        goto startPoint;
                                                        //break;
                                                    }
                                            }
             

                                            Console.WriteLine("Press Spacebar to exit; press any key to go choose airport panel");
                                        }
                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        { 
                                        }

                                        
                                        break;
                                    };
                                case 2: //Flights pricelist
                                    {
                                        Console.Clear();
                                        do
                                        {
                                            
                                            varToOut = 0;
                                            flightIndex = -1;
                                            Console.WriteLine("Enter flight number");
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
                                            Console.WriteLine("");
                                            Console.WriteLine("Flight pricelist: ");
                                            foreach (var flight in FlightsPanelOne)
                                            {
                                                foreach (var dic in flight.FlightsCost)
                                                {
                                                    Console.WriteLine("{0} - {1} $", dic.Key, dic.Value);
                                                }
                                                //break;
                                            }
                                            Console.WriteLine("");
                                            FlightsPanelOne.Clear();

                                        }

                                        break;
                                    };
                                case 3: //Passengers list
                                    {
                                        
                                        Console.Clear();
                                        do
                                        {

                                            varToOut = 0;
                                            flightIndex = -1;
                                            Console.WriteLine("Enter flight number");
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
                                            Console.WriteLine("");
                                            Console.WriteLine("Flight passengers list: ");
                                            
                                            foreach (var flight in FlightsPanelOne)
                                            {
                                                //foreach (var pl in flight.PassengerList)
                                                //{
                                                
                                                HeadTablePassengers(Console.GetCursorPosition().Top + 1);
                                                BodyTablePassengers(flight.PassengerList, Console.GetCursorPosition().Top + 1);
                                                //}
                                                passes = flight.PassengerList;

                                            }
                                            Console.WriteLine("");
                                            //FlightsPanelOne.Clear();
                                        }

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
                                                         FlightsPanel[flightIndex].PassengerList.Add(new Passenger(id, firstName, secondName, nationality, passport, dateOfBirthday, sex, flightClass));
                                                         Console.WriteLine("Add passenger");
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
                                                        a = long.Parse(Console.ReadLine());
                                                        foreach (var f in passes)
                                                        {
                                                            if (f.ID == a)
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
                                                                    Console.WriteLine("Enter FlightClass  (values - {0} / {1}) (old value {2}): ", FlightClass.economy, FlightClass.business, passenger.FlightClass);
                                                                    try
                                                                    {
                                                                        FlightClass flightClass;
                                                                        Enum.TryParse(Console.ReadLine(), out flightClass);
                                                                        passenger.EditFlightClass(flightClass);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Console.WriteLine(ex.Message);
                                                                    }
                                                                    
                                                                    
                                                                    break;
                                                                }
                                                            case 8: // Exit
                                                                {
                                                                    goto startPoint;
                                                                    break;
                                                                }
                                                        }


                                                        List<Passenger> newList = new List<Passenger>();
                                                        foreach (var f in passes)
                                                        {
                                                            if (f.ID == a)
                                                            {
                                                                newList.Add(passenger);                                                              
                                                            }
                                                            else
                                                            {
                                                                newList.Add(f);
                                                            }
                                                        }

                                                        FlightsPanel[flightIndex].EditPassengerList(newList);

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
                                                        FlightsPanel[flightIndex].EditPassengerList(newList);

                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        goto startPoint;
                                                        //break;
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
                                                            FlightsPanelOne.Clear();
                                                            FlightsPanelOne.Add(FlightsPanel[flightIndex]);
                                                            BodyTable(FlightsPanelOne);
                                                            Console.WriteLine("");
                                                            FlightsPanelOne.Clear();
                                                        }

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
                                                                if(passenger.FirstName == passenger_name || passenger.SecondName == passenger_name)
                                                                {
                                                                    passenger_list.Add(passenger);
                                                                    countFound += 1;
                                                                }
                                                            }
                                                            if (passenger_list.Count > 0)
                                                            {
                                                                Console.WriteLine("Flight number {0}", flight.Flight_number);
                                                                HeadTablePassengers(Console.GetCursorPosition().Top + 1);
                                                                BodyTablePassengers(passenger_list, Console.GetCursorPosition().Top + 1);
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
                                                                if (passenger.Passport == passport)
                                                                {
                                                                    passenger_list.Add(passenger);
                                                                    countFound += 1;
                                                                }
                                                            }
                                                            if (passenger_list.Count > 0)
                                                            {
                                                                Console.WriteLine("Flight number {0}", flight.Flight_number);
                                                                HeadTablePassengers(Console.GetCursorPosition().Top + 1);
                                                                BodyTablePassengers(passenger_list, Console.GetCursorPosition().Top + 1);
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
                                                        Console.WriteLine("Enter arrival(departure) port what you want search");
                                                        string port = Console.ReadLine();
                                                        int countFound = 0;
                                                        FlightsPanelOne.Clear();
                                                        foreach (var flight in FlightsPanel)
                                                        {
                                                            if(flight.City_arrival == port)
                                                            {
                                                               FlightsPanelOne.Add(flight);
                                                                countFound += 1;
                                                            }
                                                        }
                                                        if(FlightsPanelOne.Count > 0)
                                                        {
                                                            HeadTable();
                                                            BodyTable(FlightsPanelOne);
                                                        }
                                                        if (countFound == 0)
                                                        {
                                                            Console.WriteLine("Not found!");
                                                        }
                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        goto startPoint;
                                                        //break;
                                                    }
                                            }

                                             Console.WriteLine("Press Spacebar to exit; press any key to choose search again");
                                        }
                                        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                        {
                                        }
                                        break;
                                    };
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Press Spacebar to exit; press any key to go start Navigation");
                        }
                            
                    
                        while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
                        {
                            Console.WriteLine("Exit");


                        }
                    
                        break;
                    };
            }
            Console.WriteLine("");
            Console.WriteLine("Press Spacebar to exit; press any key to go choose role");

        }
        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
        {
            Console.WriteLine("Exit");
            
            
        }
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
        int i = 1;
        foreach (Flight f in flightsPanel)
        {  
            if(f.Direction == direction || direction == null)
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
                i += 1;
            }

        }
    }

    static void HeadTablePassengers(int i)
    {
        //Console.Clear();
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

    static void BodyTablePassengers(List<Passenger> flightsPassengers, int curLine)
    {
        int i = 0 + curLine;
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
                Console.Write("| " + f.FlightClass + " ");

                i += 1;
        }
    }
}