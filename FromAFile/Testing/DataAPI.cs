using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class DataAPI
    {
        public List<DataInfo> Info { get; set; }

    }

    public class DataInfo
    {
      public string id { get; set; } 
      public string institution_ID            {get; set;}
      public string institution_Name          {get; set;}
      public string institution_Address       {get; set;}
      public string institution_City          {get; set;}
      public string institution_State         {get; set;}
      public string institution_Zip           {get; set;}
      public string institution_Phone         {get; set;}
      public string institution_OPEID         {get; set;}
      public string institution_IPEDS_UnitID  {get; set;}
      public string institution_Web_Address   {get; set;}
      public string campus_ID                 {get; set;}
      public string campus_Name               {get; set;}
      public string campus_Address            {get; set;}
      public string campus_City               {get; set;}
      public string campus_State              {get; set;}
      public string campus_Zip                {get; set;}
      public string campus_IPEDS_UnitID       {get; set;}
      public string accreditation_Type        {get; set;}
      public string agency_Name               {get; set;}
      public string agency_Status             {get; set;}
      public string program_Name              {get; set;}
      public string accreditation_Status      {get; set;}
      public string accreditation_Date_Type   {get; set;}
      public string periods                   {get; set;}
      public string last_Action               {get; set;}
      public string action_Date               {get; set;}
      public string justification             {get; set;}
      public string other_Justification       {get; set;}
      public string justification_Url         {get; set;}

        public override string ToString()
        {
            return $"{id} {campus_Name} {campus_Zip}";
        }
    }
}
