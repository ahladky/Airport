using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

public class StartData
{
    public List<Flight> FlightsPanel;

    public StartData()
    {
        List<Flight> FlightsPanel = new List<Flight>();
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 10, 0, 0), "MA01033", "PL_WRC", "LOT", "A", FlightStatus.arrived, "A1"));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 2, 11, 0, 0), "MA01055", "UA_KYIV", "Turkish Airlines", "F", FlightStatus.check_in, "A2"));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 12, 0, 0), "MA01051", "PL_WRC", "AirBaltic", "B", FlightStatus.in_flight, "A3"));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 3, 13, 0, 0), "MA01036", "FR_ORY", "LOT", "E", FlightStatus.gate_closed, "A4"));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 2, 14, 0, 0), "MA01037", "GB_LHR", "Lufthansa", "C", FlightStatus.departed_at, "A1"));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 3, 15, 0, 0), "MA01038", "FR_ORY", "LowCostAir", "D", FlightStatus.check_in, "A2"));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 16, 0, 0), "MA01039", "GB_LHR", "AirBaltic", "B", FlightStatus.departed_at, "A3"));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 2, 17, 0, 0), "MA01040", "PL_WRC", "LowCostAir", "A", FlightStatus.canceled, "A4"));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 18, 0, 0), "MA01041", "FR_ORY", "British Airways", "E", FlightStatus.expected_at, "A5"));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 2, 19, 0, 0), "MA01042", "GB_LHR", "LOT", "E", FlightStatus.delayed, "A6"));
        FlightsPanel.Add(new Flight("arrival", new DateTime(2023, 3, 1, 20, 0, 0), "MA01043", "UKR_KYIV", "AirBaltic", "D", FlightStatus.check_in, "A4"));
        FlightsPanel.Add(new Flight("departure", new DateTime(2023, 3, 3, 21, 0, 0), "MA01044", "UA_KYIV", "British Airways", "C", FlightStatus.delayed, "A1"));
    }
}
