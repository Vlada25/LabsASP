using System.ComponentModel.DataAnnotations;

namespace Lab2.DAL.Models.Enums
{
    public enum EquipmentType
    {
        [Display(Name = "Refrigerator")]
        Refrigerator,

        [Display(Name = "Coffee Machine")]
        CoffeeMachine,

        [Display(Name = "Television")]
        Television,

        [Display(Name = "Computer")]
        Computer,

        [Display(Name = "Telephone")]
        Telephone,

        [Display(Name = "Headphones")]
        Headphones,

        [Display(Name = "Iron")]
        Iron,

        [Display(Name = "Electric Kettle")]
        ElectricKettle
    }
}
