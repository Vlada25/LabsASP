using Lab2.BLL.Services;
using Lab2.DAL;
using Lab2.DAL.Models;
using Lab2.DTO.RepairingModel;
using Lab2.DTO.UsedSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ConsoleApp
{
    public static class Helper
    {
        #region Necessary data

        private static string[] _equipmentTypes =
        {
            "Refrigerator", "Coffee Machine", "Television", "Computer", "Telephone",
            "Headphones", "Iron", "Electric Kettle"
        };


        public static Type GetTableType()
        {
            Console.WriteLine(
                "\nВыберите таблицу:\n" +
                "1) RepairingModels\n" +
                "2) Faults\n" +
                "3) SpareParts\n" +
                "4) UsedSpareParts\n"
                );

            if (!int.TryParse(Console.ReadLine(), out int item))
            {
                throw new Exception("Некорректный ввод!");
            }

            switch (item)
            {
                case 1:
                    return typeof(RepairingModel);
                case 2:
                    return typeof(Fault);
                case 3:
                    return typeof(SparePart);
                case 4:
                    return typeof(UsedSparePart);
                default:
                    return null;
            }
        }

        public static string GetManufacturer()
        {
            string message = "\nВыберите производителя:\n";
            for (int i = 0; i < DbInitializer.Manufacturers.Length; i++)
                message += $"{i + 1}) {DbInitializer.Manufacturers[i]}\n";

            Console.WriteLine(message);

            if (!int.TryParse(Console.ReadLine(), out int item))
            {
                throw new Exception("Некорректный ввод!");
            }

            return DbInitializer.Manufacturers[item - 1];
        }

        public static string GetEquipmentType()
        {
            string message = "\nВыберите тип оборудования:\n";
            for (int i  = 0; i < _equipmentTypes.Length; i++)
                message += $"{i + 1}) {_equipmentTypes[i]}\n";

            Console.WriteLine(message);

            if (!int.TryParse(Console.ReadLine(), out int item))
            {
                throw new Exception("Некорректный ввод!");
            }

            return _equipmentTypes[item - 1];
        }

        #endregion

        #region Getting data

        public static async Task GetAll(string modelType,
            RepairingModelsService repairingModelsService,
            FaultsService faultsService,
            SparePartsService sparePartsService,
            UsedSparePartsService usedSparePartsService)
        {
            switch (modelType)
            {
                case "RepairingModel":
                    var repairingModels = await repairingModelsService.GetAll();
                    foreach (var rm in repairingModels)
                        Console.WriteLine(rm.ToString());
                    break;
                case "Fault":
                    var faults = await faultsService.GetAll();
                    foreach (var f in faults)
                        Console.WriteLine(f.ToString());
                    break;
                case "SparePart":
                    var spareParts = await sparePartsService.GetAll();
                    foreach (var sp in spareParts)
                        Console.WriteLine(sp.ToString());
                    break;
                case "UsedSparePart":
                    var usedSpareParts = await usedSparePartsService.GetAll();
                    foreach (var usp in usedSpareParts)
                        Console.WriteLine(usp.ToString());
                    break;
                default:
                    throw new Exception("This type of model not supported!");
            }
        }

        public static async Task GetFaultsByPrice(decimal price, FaultsService faultsService)
        {
            var faults = await faultsService.GetAll();

            foreach (var fault in faults.Where(f => f.Price > price))
                Console.WriteLine(fault.ToString());
        }

        public static async Task GetRepairingModelsByTypeAndManufacturer(string type,
            string manufacturer,
            RepairingModelsService repairingModelsService)
        {
            var repairingModels = await repairingModelsService.GetAll();

            foreach (var repairingModel in repairingModels
                .Where(rm => rm.Type.Equals(type) && rm.Manufacturer.Equals(manufacturer, StringComparison.OrdinalIgnoreCase)))
                Console.WriteLine(repairingModel.ToString());
        }

        #endregion

        #region Creation entity

        public static async Task CreateEntity(string modelType,
            RepairingModelsService repairingModelsService,
            FaultsService faultsService,
            SparePartsService sparePartsService,
            UsedSparePartsService usedSparePartsService)
        {
            switch (modelType)
            {
                case "RepairingModel":
                    RepairingModelForCreationDto repairingModelForCreation = new RepairingModelForCreationDto();

                    Console.WriteLine("\n  Name:");
                    repairingModelForCreation.Name = Console.ReadLine();
                    Console.WriteLine("  Type:");
                    repairingModelForCreation.Type = GetEquipmentType();
                    Console.WriteLine("  Manufacturer:");
                    repairingModelForCreation.Manufacturer = Console.ReadLine();
                    Console.WriteLine("  Specifications:");
                    repairingModelForCreation.Specifications = Console.ReadLine();
                    Console.WriteLine("  ParticularQualities:");
                    repairingModelForCreation.ParticularQualities = Console.ReadLine();

                    await repairingModelsService.Create(repairingModelForCreation);
                    break;
                case "Fault":
                    break;
                case "SparePart":
                    break;
                case "UsedSparePart":
                    UsedSparePartForCreationDto usedSparePartForCreation = new UsedSparePartForCreationDto();

                    Console.WriteLine("\n  FaultId:");
                    usedSparePartForCreation.FaultId = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("  SparePartId:");
                    usedSparePartForCreation.SparePartId = Guid.Parse(Console.ReadLine());

                    await usedSparePartsService.Create(usedSparePartForCreation);
                    break;
                default:
                    throw new Exception("This type of model not supported!");
            }
        }

        #endregion

        #region Removing entity

        public static async Task DeleteEntity(string modelType,
            Guid entityId,
            RepairingModelsService repairingModelsService,
            FaultsService faultsService,
            SparePartsService sparePartsService,
            UsedSparePartsService usedSparePartsService)
        {
            switch (modelType)
            {
                case "RepairingModel":
                    await repairingModelsService.Delete(entityId);
                    break;
                case "Fault":
                    await faultsService.Delete(entityId);
                    break;
                case "SparePart":
                    await sparePartsService.Delete(entityId);
                    break;
                case "UsedSparePart":
                    await usedSparePartsService.Delete(entityId);
                    break;
                default:
                    throw new Exception("This type of model not supported!");
            }
        }

        #endregion

        #region Updating entity

        public static async Task UpdateEntity(string modelType,
            Guid entityId,
            RepairingModelsService repairingModelsService,
            FaultsService faultsService,
            SparePartsService sparePartsService,
            UsedSparePartsService usedSparePartsService)
        {
            switch (modelType)
            {
                case "RepairingModel":
                    RepairingModelForUpdateDto repairingModelForUpdate = new RepairingModelForUpdateDto();

                    Console.WriteLine("\n  Name:");
                    repairingModelForUpdate.Name = Console.ReadLine();
                    Console.WriteLine("  Type:");
                    repairingModelForUpdate.Type = GetEquipmentType();
                    Console.WriteLine("  Manufacturer:");
                    repairingModelForUpdate.Manufacturer = Console.ReadLine();
                    Console.WriteLine("  Specifications:");
                    repairingModelForUpdate.Specifications = Console.ReadLine();
                    Console.WriteLine("  ParticularQualities:");
                    repairingModelForUpdate.ParticularQualities = Console.ReadLine();

                    await repairingModelsService.Update(entityId, repairingModelForUpdate);
                    break;
                case "Fault":
                    break;
                case "SparePart":
                    break;
                case "UsedSparePart":
                    UsedSparePartForUpdateDto usedSparePartForUpdate = new UsedSparePartForUpdateDto();

                    Console.WriteLine("\n  FaultId:");
                    usedSparePartForUpdate.FaultId = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("  SparePartId:");
                    usedSparePartForUpdate.SparePartId = Guid.Parse(Console.ReadLine());

                    await usedSparePartsService.Update(entityId, usedSparePartForUpdate);
                    break;
                default:
                    throw new Exception("This type of model not supported!");
            }
        }

        #endregion
    }
}
