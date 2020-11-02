using System;
using System.Collections.Generic;

namespace CC_Grid
{
  public class Measure
  {
    public int Id { get; set; }
    public float VoltagePhaseA { get; set; }  //Tensões em relação ao neutro, considero defasagem 120° e pego apenas o valor RMS
    public float CurrentPhaseA { get; set; }  //Corrente de fase
    public float VoltagePhaseB { get; set; } 
    public float CurrentPhaseB { get; set; }
    public float VoltagePhaseC { get; set; }
    public float CurrentPhaseC { get; set; }
    public float PowerFactor_A { get; set; }
    public float PowerFactor_B { get; set; }
    public float PowerFactor_C { get; set; }
    public float ActivePower  { get; set; }
    public float ReactivePower  { get; set; } 
    public DateTime Datetime { get; set; }   
    public virtual Circuit Circuit { get; set; }
  }

  public class HistoryCircuit
  {
    public int Id { get; set; }
    public string Action { get; set; }
    public DateTime Datetime { get; set; }   
    public virtual Circuit Circuit { get; set; }
  }

  public class Circuit
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Measure> Measures { get; set; }
    public virtual ICollection<HistoryCircuit> HistoryCircuits { get; set; }
  }

  public class Configuration
  {
    public float MinTimeAutonomy { get; set; }
    
    public float StartComutationOn_Off { get; set; }

    public float StartComutationOFF_On { get; set; }

    public int Level_1_Shutdown { get; set; }

    public int Level_2_Shutdown { get; set; }

    public int Level_3_Shutdown { get; set; }

    public int Level_4_Shutdown { get; set; }

    public string Circuit1Name { get; set; }

    public string Circuit2Name { get; set; }

    public string Circuit3Name { get; set; }

    public string Circuit4Name { get; set; }

    public float StartPeakHour { get; set; }

    public float EndPeakHour { get; set; }

    public float ActivePricePeakHour { get; set; }

    public float ReactivePricePeakHour { get; set; }

    public float ActivePriceNonPeakHour { get; set; }

    public float ReactivePriceNonPeakHour { get; set; }

    public int RevenueDay { get; set; }

    public string OperationType { get; set; }  //Manual or Automatic

    public float PriceHiredPowerHP { get; set; }

    public float PriceHiredPowerHFP { get; set; }

    public float PriceExceededPowerHFP { get; set; }

    public float PriceExceededPowerHP { get; set; }

    public int HiredPower { get; set; }// em kW

    public string SwitchingControlType { get; set; }// 'Peak-shaving' ou 'Chaveamento Horário'

    public int PercentagePeakShavingHiredPower { get; set; } //0 a 100;
  }

  public class Battery
  {
    public float ChargePower { get; set; }
    public float DischargePower { get; set; }
    public string Technology { get; set; }
    public float ChargeCurrent { get; set; }
    public float DischargeCurrent { get; set; }
    public int DepthOfCharge { get; set; }
    public float TotalEnergy { get; set; } // energia em KVAh  
  }

   public class HistoryBattery
  {
    public int Id { get; set; }
    public DateTime Datetime { get; set; }
    
    public float StateOfCharge { get; set; } // energia em KVAh

    public string State { get; set; }  //Charging, Discharding, stand-by

    public float StateCurrent { get; set; }

    public float StatePower { get; set; }
    
  }

  public class Operation
  {
    public int Id { get; set; }
    public DateTime Datetime { get; set; }   
    
    public string Status { get; set; } //On, Off-Grid, Manual

    public int PriorityLevel { get; set; } 

    public string GeneralInfo {get; set;}
    
  }



}