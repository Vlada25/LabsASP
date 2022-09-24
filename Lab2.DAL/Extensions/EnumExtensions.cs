using Lab2.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(EquipmentType equipmentType)
        {
            Type type = equipmentType.GetType();
            var enumItem = type.GetField(equipmentType.ToString());
            var attribute = enumItem?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name;
        }

        public static EquipmentType SetEquipmentType(string typeStr)
        {
            switch (typeStr)
            {
                case "Refrigerator":
                    return EquipmentType.Refrigerator;
                case "Coffee Machine":
                    return EquipmentType.CoffeeMachine;
                case "Television":
                    return EquipmentType.Television;
                case "Computer":
                    return EquipmentType.Computer;
                case "Telephone":
                    return EquipmentType.Telephone;
                case "Headphones":
                    return EquipmentType.Headphones;
                case "Iron":
                    return EquipmentType.Iron;
                case "Electric Kettle":
                    return EquipmentType.ElectricKettle;
                default:
                    throw new Exception("Such type of equipment not found");
            }
        }

        public static EquipmentType SetEquipmentType(int typeInt)
        {
            switch (typeInt)
            {
                case 0:
                    return EquipmentType.Refrigerator;
                case 1:
                    return EquipmentType.CoffeeMachine;
                case 2:
                    return EquipmentType.Television;
                case 3:
                    return EquipmentType.Computer;
                case 4:
                    return EquipmentType.Telephone;
                case 5:
                    return EquipmentType.Headphones;
                case 6:
                    return EquipmentType.Iron;
                case 7:
                    return EquipmentType.ElectricKettle;
                default:
                    throw new Exception("Such type of equipment not found");
            }
        }
    }
}
