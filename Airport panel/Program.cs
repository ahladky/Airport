using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_panel.Model;
using Microsoft.EntityFrameworkCore;

namespace Airport_panel;

class Program
{
    static void Main(string[] args)
    {      
        var dbContext = new MyDbContext();
        Menu curMenu = new Menu();

        long a;
        string editValue;
        curMenu.Level = 0;
        curMenu.Line = "Start";

       while(curMenu.Level >= 0)
       {            
           curMenu.Level = 0;
           curMenu.Line = "Start";
           curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
           curMenu.ShowMenu();

           a = long.Parse(Console.ReadLine());
            
            switch (a)
            {             
                case 1:   //Passenger
                    {
                        curMenu.Level = 1;
                        curMenu.Line = "Passenger";
                        while (curMenu.Level > 0)
                        {
                            curMenu.Level = 1;
                            curMenu.Line = "Passenger";
                            curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                            curMenu.ShowMenu();

                            a = long.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:  //Airport panel
                                    {
                                        curMenu.Level = 2;
                                        curMenu.Line = "Passenger";

                                        while (curMenu.Level == 2)
                                        {                                           
                                            curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                            curMenu.ShowMenu();

                                            a = long.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1: // All flight
                                                    {
                                                        dbContext.FlightTable();
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 2: // Arrival flight
                                                    {
                                                        dbContext.FlightTable("arrival");
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 3: // Departure flight
                                                    {                                                        
                                                        dbContext.FlightTable("departure");
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 4: //Back
                                                    {
                                                        curMenu.Level -= 1;
                                                        curMenu.GetMenu(curMenu.Level, "Passenger");
                                                        curMenu.ShowMenu();
                                                        break;
                                                    }
                                            }                                        
                                        }
                                        Console.WriteLine("");
                                        break;
                                    }
                                case 2: //Search flight 
                                    {
                                        curMenu.Level = 3;
                                        
                                        while (curMenu.Level == 3)
                                        {
                                            curMenu.Level = 3;
                                            curMenu.Line = "PassengerSearch";
                                            curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                            curMenu.ShowMenu();                                            

                                            a = long.Parse(Console.ReadLine());
                                            Console.Clear();
                                            switch (a)
                                            {
                                                case 1: //by the flight number
                                                    {
                                                        Console.WriteLine("Enter flight number you want search");
                                                        dbContext.SearchFlightTable(dbContext.SearchByFlightNumber(Console.ReadLine()));
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 2: //by date of arrival
                                                    {   
                                                        Console.WriteLine("Enter flight date of arrival you want search");
                                                        try 
                                                        {                                                          
                                                            dbContext.SearchFlightTable(dbContext.SearchByDateArrival(DateTime.Parse(Console.ReadLine())));
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 3: //by arrival(departure) port
                                                    {
                                                        Console.WriteLine("Enter arrival(departure) port you want search");                                                        
                                                        dbContext.SearchFlightTable(dbContext.SearchByPort(Console.ReadLine()));
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 4: //by arrival(departure) port, nearest (1 hour) flight
                                                    {
                                                        Console.WriteLine("Enter arrival(departure) port you want search neaster flight");
                                                        dbContext.SearchFlightTable(dbContext.SearchByNearestFlight(DateTime.Now, Console.ReadLine(), 1));
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 5: //Back
                                                    {
                                                        curMenu.Level -= 1;
                                                        curMenu.GetMenu(curMenu.Level, "Passenger");
                                                        curMenu.ShowMenu();
                                                        break;
                                                    }                                                   
                                            }
                                        
                                        }

                                        break;
                                    }
                                case 3: //Back
                                    {
                                        curMenu.Level -= 1;
                                        curMenu.GetMenu(curMenu.Level, "Passenger");
                                        curMenu.ShowMenu();
                                        break;
                                    }
                            }
                        }
                        break;
                    };
                case 2:   //Employee
                    {
                        curMenu.Level = 1;
                        curMenu.Line = "Employee";
                        while (curMenu.Level > 0)                            
                        {
                            curMenu.Level = 1;
                            curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                            curMenu.ShowMenu();
                            a = long.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1: //Airport panel
                                    {
                                        curMenu.Level = 2;
                                        while(curMenu.Level == 2)
                                        {
                                            curMenu.Level = 2;
                                            curMenu.Line = "Employee";
                                            curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                            curMenu.ShowMenu();

                                            a = long.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1:  //FlightsPanel - arrival
                                                    {                                                      
                                                        dbContext.FlightTable("arrival");
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 2: //FlightsPanel - departure
                                                    {
                                                        dbContext.FlightTable("departure");
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 3: // Back
                                                    {
                                                        curMenu.Level -= 1;
                                                        curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                                        curMenu.ShowMenu();
                                                        break;
                                                    }
                                            }
                                        }
                                        

                                        
                                        break;
                                    };
                                case 2: //Edit flight
                                    {
                                        dbContext.FlightTable();
                                        Console.WriteLine("");
                                        Console.WriteLine("Enter FULL flight number you want to edit");
                                        string fnumber = Console.ReadLine();
                                        
                                        curMenu.Level = 3;
                                        curMenu.Line = "Employee";

                                        while (curMenu.Level == 3)
                                        {
                                            Console.Clear();
                                            int idCurFlight = dbContext.OneFlightTable(fnumber);
                                            Console.WriteLine("");
                                            Console.WriteLine(@"Select a field to edit Flight - {0}: ", dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).Flight_number);

                                            curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                            curMenu.ShowMenu(false);

                                            a = long.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1:  // Edit Direction
                                                    {
                                                        Console.WriteLine("Enter Direction new value (departure/arrival)");
                                                        editValue = Console.ReadLine();
                                                        try
                                                        {
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).Direction = editValue;
                                                            Console.WriteLine("Direction changed!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }                                                       
                                                        break;
                                                    }
                                                case 2:  // Edit DateTime Flight
                                                    {
                                                        Console.WriteLine("Enter DateTime Flight new value");
                                                        editValue = Console.ReadLine();
                                                        try
                                                        {
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).DateTimeF = DateTime.Parse(editValue);
                                                            Console.WriteLine("DateTime Flight changed!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        break;
                                                    }
                                                case 3:  // Edit Flight number
                                                    {
                                                        Console.WriteLine("Enter Flight number new value");
                                                        editValue = Console.ReadLine();
                                                        try
                                                        {
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).Flight_number = editValue;
                                                            Console.WriteLine("Flight number changed!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        break;
                                                    }
                                                case 4:  // Edit City
                                                    {
                                                        Console.WriteLine("Enter City arrival new value");
                                                        editValue = Console.ReadLine();
                                                        try
                                                        {
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).City_arrival = editValue;
                                                            Console.WriteLine("City arrival changed!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        break;
                                                    }
                                                case 5:  // Edit Airline
                                                    {
                                                        Console.WriteLine("Enter Airline new value");
                                                        editValue = Console.ReadLine();
                                                        try
                                                        {
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).Airline = editValue;
                                                            Console.WriteLine("Airline changed!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        break;
                                                    }
                                                case 6:  // Edit Terminal
                                                    {
                                                        Console.WriteLine("Enter Terminal new value");
                                                        editValue = Console.ReadLine();
                                                        try
                                                        {
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).Terminal = editValue;
                                                            Console.WriteLine("Terminal changed!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        break;
                                                    }
                                                case 7: // Edit Flight status
                                                    {
                                                        Console.WriteLine("Enter Flight status new value");
                                                        Console.WriteLine("check_in , gate_closed , arrived , departed_at , unknown , canceled , expected_at , delayed , in_flight");
                                                        try
                                                        {
                                                            editValue = Console.ReadLine();
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).Flight_status = editValue;
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
                                                        Console.WriteLine("Enter Gates new value");
                                                        editValue = Console.ReadLine();
                                                        try
                                                        {
                                                            dbContext.FlightDB.SingleOrDefault(i => i.Id == idCurFlight).Gates = editValue;
                                                            Console.WriteLine("Gates changed!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        break;
                                                    }
                                                case 9:  // Back
                                                    {
                                                        curMenu.Level -= 1;
                                                        break;
                                                    }
                                            }
                                            Console.WriteLine("");
                                            Console.WriteLine("");
                                        }
                                        break;
                                    }
                                case 3: //Flights pricelist
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter flight number you want search");
                                        List<FlightDB> findFlight = dbContext.SearchByFlightNumber(Console.ReadLine());

                                        if (findFlight != null)
                                        {
                                            foreach (FlightDB flight in findFlight)
                                            {
                                                dbContext.OneFlightTable(flight.Flight_number);
                                                dbContext.ViewFlightPrices(flight.Id);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Flight not found!");
                                        }
                                        GoBackText();
                                        break;
                                    };
                                case 4: //Passengers list
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter flight number you want search");
                                        List<FlightDB> findFlight = dbContext.SearchByFlightNumber(Console.ReadLine());

                                        if (findFlight != null)
                                        {
                                            foreach (FlightDB flight in findFlight)
                                            {
                                                dbContext.OneFlightTable(flight.Flight_number);
                                                dbContext.ViewFlightPassegers(flight.Id);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Flight not found!");
                                        }
                                        GoBackText();
                                        break;
                                    };
                                case 5: //Search flight 
                                    {
                                        curMenu.Level = 3;                                     
                                        while (curMenu.Level == 3)
                                        {
                                            curMenu.Level = 3;
                                            curMenu.Line = "Employee";
                                            curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                            curMenu.ShowMenu();

                                            a = long.Parse(Console.ReadLine());
                                            Console.Clear();
                                            switch (a)
                                            {
                                                case 1: // Flight number
                                                    {                                                        
                                                        Console.WriteLine("Enter flight number you want search");
                                                        dbContext.SearchFlightTable(dbContext.SearchByFlightNumber(Console.ReadLine()));
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 2: // First or second name
                                                    {
                                                        Console.WriteLine("Enter first or second name what you want search");
                                                        List<PassengerDB> passengerList = dbContext.SearchByPassengerName(Console.ReadLine());                                                           
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Find passenger: ");
                                                        foreach (PassengerDB passenger in passengerList)
                                                        {
                                                            dbContext.OnePassуgerTable(passenger.Id);
                                                            Console.WriteLine("Find flight: ");
                                                            List<FlightDB> flights = dbContext.SearchByPassengerId(passenger.Id);
                                                            foreach (FlightDB flight in flights)
                                                            {
                                                                dbContext.OneFlightTable(flight.Flight_number);
                                                            }                                                          
                                                        }
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 3: // Passport
                                                    {
                                                        Console.WriteLine("Enter pasport data to search");
                                                        List<PassengerDB> passengerList = dbContext.SearchByPassport(Console.ReadLine());
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Find passenger: ");
                                                        foreach (PassengerDB passenger in passengerList)
                                                        {
                                                            dbContext.OnePassуgerTable(passenger.Id);
                                                            Console.WriteLine("Find flight: ");
                                                            List<FlightDB> flights = dbContext.SearchByPassengerId(passenger.Id);
                                                            foreach (FlightDB flight in flights)
                                                            {
                                                                dbContext.OneFlightTable(flight.Flight_number);
                                                            }
                                                        }
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 4: // Arrival(departure) port
                                                    {
                                                        Console.WriteLine("Enter arrival(departure) port you want search");
                                                        dbContext.SearchFlightTable(dbContext.SearchByPort(Console.ReadLine()));
                                                        GoBackText();
                                                        break;
                                                    }
                                                case 5: // Back
                                                    {
                                                        curMenu.Level -= 1;
                                                        curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                                        curMenu.ShowMenu();
                                                        break;
                                                    }
                                            }
                                        }
                                        break;
                                    };
                                case 6: //Passengers (add,edit,delete)
                                    {
                                        //curMenu.Level = 3;
                                        //curMenu.Line = "Passenger";

                                        //while (curMenu.Level == 3)
                                        //{
                                        //    Console.Clear();
                                        //    curMenu.Level = 3;
                                        //    curMenu.Line = "Passenger";
                                        //    curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                        //    curMenu.ShowMenu();


                                        //    a = long.Parse(Console.ReadLine());
                                        //    switch (a)
                                        //    {
                                        //        case 1:  //add Passenger
                                        //            {

                                        //                Console.WriteLine("");
                                        //                Console.WriteLine("Press any key, to go back");
                                        //                Console.ReadKey();
                                        //                break;
                                        //            }
                                        //        case 2: //edit Passenger
                                        //            {
                                        //                BodyTablePassengers(PassengerList);                                                        
                                        //                Console.WriteLine("Enter id passenger to edit");
                                        //                ushort id_pass;
                                        //                try
                                        //                {
                                        //                  id_pass = ushort.Parse(Console.ReadLine());
                                        //                  Passenger passenger = SearchByPassengerId(PassengerList, id_pass);
                                        //                  curMenu.Level = 4;
                                        //                  curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                        //                  curMenu.ShowMenu();
                                        //                    a = long.Parse(Console.ReadLine());
                                        //                    switch (a)
                                        //                    {
                                        //                        case 1:  // Edit First Name
                                        //                            {
                                        //                                Console.WriteLine("Enter First Name: ");
                                        //                                string enterValue = Console.ReadLine();
                                        //                                passenger.EditFirstName(enterValue);
                                        //                                break;
                                        //                            }
                                        //                        case 2: // Edit Second Name
                                        //                            {
                                        //                                Console.WriteLine("Enter Second Name: ");
                                        //                                string enterValue = Console.ReadLine();
                                        //                                passenger.EditSecondName(enterValue);
                                        //                                break;
                                        //                            }
                                        //                        case 3: // Edit Nationality
                                        //                            {
                                        //                                Console.WriteLine("Enter Nationality: ");
                                        //                                string enterValue = Console.ReadLine();
                                        //                                passenger.EditNationality(enterValue);
                                        //                                break;
                                        //                            }
                                        //                        case 4: // Edit Passport
                                        //                            {
                                        //                                Console.WriteLine("Enter Passport: ");
                                        //                                string enterValue = Console.ReadLine();
                                        //                                passenger.EditPassport(enterValue);
                                        //                                break;
                                        //                            }
                                        //                        case 5: // Edit Date Of Birthday
                                        //                            {
                                        //                                Console.WriteLine("Enter DateOfBirthday (format dd.mm.yyyy): ");
                                        //                                DateOnly dateOfBirthday = DateOnly.FromDateTime(DateTime.Now);
                                        //                                try
                                        //                                {
                                        //                                    dateOfBirthday = DateOnly.Parse(Console.ReadLine());
                                        //                                }
                                        //                                catch (Exception ex)
                                        //                                {
                                        //                                    Console.WriteLine(ex.Message);
                                        //                                }
                                        //                                Console.WriteLine("Enter Date Of Birthday (format dd.mm.yyyy): ");
                                        //                                DateOnly dateOfBD = DateOnly.FromDateTime(DateTime.Now);
                                        //                                try
                                        //                                {
                                        //                                    dateOfBD = DateOnly.Parse(Console.ReadLine());
                                        //                                    passenger.EditDateOfBirthday(dateOfBD);
                                        //                                }
                                        //                                catch (Exception ex)
                                        //                                {
                                        //                                    Console.WriteLine(ex.Message);
                                        //                                }

                                        //                                break;
                                        //                            }
                                        //                        case 6: // Edit Sex
                                        //                            {
                                        //                                Console.WriteLine("Enter Sex (values - {0} / {1}) (old value {2}): ", Sex.male, Sex.female, passenger.Sex);
                                        //                                try
                                        //                                {
                                        //                                    Sex sex;
                                        //                                    Enum.TryParse(Console.ReadLine(), out sex);
                                        //                                    passenger.EditSex(sex);
                                        //                                }
                                        //                                catch (Exception ex)
                                        //                                {
                                        //                                    Console.WriteLine(ex.Message);
                                        //                                }
                                        //                                break;
                                        //                            }
                                        //                        case 7:
                                        //                            {
                                        //                                curMenu.Level -= 1;
                                        //                                curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                        //                                curMenu.ShowMenu();
                                        //                                break;
                                        //                            }
                                        //                    }

                                        //                }
                                        //                catch (Exception ex)
                                        //                {
                                        //                    Console.WriteLine(ex.Message);
                                        //                }   
                                        //                Console.WriteLine("");
                                        //                Console.WriteLine("Press any key, to go back");
                                        //                Console.ReadKey();
                                        //                break;
                                        //            }
                                        //        case 3: //delete Passenger
                                        //            {
                                        //                BodyTablePassengers(PassengerList);
                                        //                Console.WriteLine("");
                                        //                Console.WriteLine("Press any key, to go back");
                                        //                Console.ReadKey();
                                        //                break;
                                        //            }
                                        //        case 4: // Back
                                        //            {
                                        //                curMenu.Level -= 1;
                                        //                curMenu.Line = "Employee";
                                        //                curMenu = curMenu.GetMenu(curMenu.Level, curMenu.Line);
                                        //                curMenu.ShowMenu();
                                        //                break;
                                        //            }
                                        //    }


                                        //}
                                        break;
                                    }
                                case 7: //Back
                                    {
                                        curMenu.Level -= 1;
                                        curMenu.GetMenu(curMenu.Level, "Employee");
                                        curMenu.ShowMenu();
                                        break;
                                    }
                            }
                            Console.WriteLine("");                           
                        } 
                        break;
                    };
                case 3:   //Exit
                    {
                        curMenu.Level = -1;
                        Console.Clear();
                        Console.WriteLine("Good bay!");
                        break;
                    }
            }
            Console.WriteLine("");
       }
        Console.ReadLine();
        Environment.Exit(0);

        void GoBackText()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key, to go back");
            Console.ReadKey();
        }
    }
}