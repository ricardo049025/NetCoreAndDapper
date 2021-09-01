using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Domain.Domain.Enums;
namespace Application.Main.Helpers
{
    public static class SqlGenericHelper<TEntity> where TEntity : class
    {

        public static string getObjectPropertiesToStrig(TEntity entity)
        {
            string columns = string.Empty;

            foreach (var item in entity.GetType().GetProperties())
            {
                var attribute = ((item.GetCustomAttributes(typeof(DescriptionAttribute), true)).Length == 0 ? null : (DescriptionAttribute)(item.GetCustomAttributes(typeof(DescriptionAttribute), true)[0])) ;                
                if (attribute != null) 
                    if(attribute.Description == "Ignore") continue;
                
                columns += $"[{item.Name}],";
            }
            
            columns = columns.Remove(columns.Length-1,1);
            
            return columns;
        }

        public static string getObjectPropertiesToStrigWithValues(TEntity entity)
        {
            string columns = string.Empty;

            foreach (var item in entity.GetType().GetProperties())
            {
                var attribute = ((item.GetCustomAttributes(typeof(DescriptionAttribute), true)).Length == 0 ? null : (DescriptionAttribute)(item.GetCustomAttributes(typeof(DescriptionAttribute), true)[0])) ;                
                if (attribute != null) 
                    if(attribute.Description == "Ignore") continue;

                switch (item.PropertyType.Name)
                {
                    case "String": case "Date": case "DateTime":
                            columns += $"'{item.GetValue(entity)}' [{item.Name}],";
                    break;

                    case "Double": case "Int": case "Float": case "Long":
                            columns += $"{item.GetValue(entity)} [{item.Name}],";
                    break;

                    case "Boolean":
                            columns += $"{((bool) item.GetValue(entity) ? "1" : "0")} [{item.Name}],";
                    break;
                }
                
            }           

            columns = columns.Remove(columns.Length-1,1);
            
            return columns;
        }

         public static string getObjectPropertiesToStrigWithUpdateValues(TEntity entity)
        {
            string columns = string.Empty;

            foreach (var item in entity.GetType().GetProperties())
            {
                var attribute = ((item.GetCustomAttributes(typeof(DescriptionAttribute), true)).Length == 0 ? null : (DescriptionAttribute)(item.GetCustomAttributes(typeof(DescriptionAttribute), true)[0])) ;                
                if (attribute != null) 
                    if(attribute.Description == "Ignore") continue;

                switch (item.PropertyType.Name)
                {
                    case "String": case "Date": case "DateTime":
                            columns += $" {item.Name} = '{item.GetValue(entity)}',";
                    break;

                    case "Double": case "Int": case "Float": case "Long":
                            columns += $"{item.Name} = {item.GetValue(entity)},";
                    break;

                    case "Boolean":
                            columns += $"{item.Name} = {((bool) item.GetValue(entity) ? "1" : "0")},";
                    break;
                }
                
            }           

            columns = columns.Remove(columns.Length-1,1);
            
            return columns;
        }
    }
}