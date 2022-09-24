using AutoMapper;
using Lab2.BLL.Interfaces.Services;
using Lab2.BLL.Services;
using Lab2.ConsoleApp;
using Lab2.DAL;
using Lab2.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace Lab2.ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(@"D:\Labs\3\DB\Lab2\Lab2.ConsoleApp\");
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            try
            {
                using (AppDbContext dbContext = new AppDbContext(Extensions.GetDbContextOptions(config)))
                {
                    RepositoryManager repositoryManager = new RepositoryManager(dbContext);

                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new MappingProfile());
                    });

                    IMapper autoMapper = mappingConfig.CreateMapper();

                    RepairingModelsService repairingModelsService = new RepairingModelsService(repositoryManager, autoMapper);
                    FaultsService faultsService = new FaultsService(repositoryManager, autoMapper);
                    SparePartsService sparePartsService = new SparePartsService(repositoryManager, autoMapper);
                    UsedSparePartsService usedSparePartsService = new UsedSparePartsService(repositoryManager, autoMapper);

                    int menuItem = -1;

                    while (menuItem != 0)
                    {
                        Console.WriteLine(
                            "\n----------MENU----------\n" +
                            "1) Заполнить таблицы исходными данными\n" +
                            "2) Отобразть всю таблицу\n" +
                            "3) Отобразить ремонтируемые модели определённого типа и производителя\n" +
                            "4) Отобразить информацию о неисправности и запчасти с максимальной ценой неисправности\n" +
                            "5) Отобразить информацию о неисправностях, цена которых больше заданной\n" +
                            "6) Создать объект\n" +
                            "7) Удалить объект\n" +
                            "8) Обновить объект\n" +
                            "0) Выход\n"
                            );

                        if (!int.TryParse(Console.ReadLine(), out menuItem))
                        {
                            throw new Exception("Некорректный ввод!");
                        }

                        switch (menuItem)
                        {
                            case 1:
                                DbInitializer.Initialize();
                                await repairingModelsService.Create(DbInitializer.RepairingModels);
                                await repositoryManager.FaultsRepository.Create(DbInitializer.Faults);
                                await repositoryManager.SparePartsRepository.Create(DbInitializer.SpareParts);
                                await repositoryManager.UsedSparePartsRepository.Create(DbInitializer.UsedSpareParts);
                                break;
                            case 2:
                                var modelType = Helper.GetTableType();
                                if (modelType is null)
                                {
                                    Console.WriteLine("Такого пункта нет!");
                                }
                                else
                                {
                                    await Helper.GetAll(modelType.Name,
                                        repairingModelsService,
                                        faultsService,
                                        sparePartsService,
                                        usedSparePartsService);
                                }
                                break;
                            case 3:
                                var equipmentType = Helper.GetEquipmentType();
                                var manufacturer = Helper.GetManufacturer();
                                await Helper.GetRepairingModelsByTypeAndManufacturer(equipmentType, manufacturer, repairingModelsService);
                                break;
                            case 4:
                                var usedSpareParts = await usedSparePartsService.GetAll();
                                var usedSparePart = usedSpareParts.First(usp => usp.FaultPrice.Equals(usedSpareParts.Max(x => x.FaultPrice)));
                                Console.WriteLine(usedSparePart.ToString());
                                break;
                            case 5:
                                Console.WriteLine("\nВведите цену:\n");
                                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                                {
                                    Console.WriteLine("Некорректный ввод!");
                                }
                                else
                                {
                                    await Helper.GetFaultsByPrice(price, faultsService);
                                }
                                break;
                            case 6:
                                modelType = Helper.GetTableType();
                                if (modelType is null)
                                {
                                    Console.WriteLine("Такого пункта нет!");
                                }
                                else
                                {
                                    await Helper.CreateEntity(modelType.Name,
                                        repairingModelsService,
                                        faultsService,
                                        sparePartsService,
                                        usedSparePartsService);
                                }
                                break;
                            case 7:
                                modelType = Helper.GetTableType();
                                if (modelType is null)
                                {
                                    Console.WriteLine("Такого пункта нет!");
                                }
                                else
                                {
                                    Console.WriteLine("\nВведите Id сущности:");
                                    Guid id = Guid.Parse(Console.ReadLine());

                                    await Helper.DeleteEntity(modelType.Name, id,
                                        repairingModelsService,
                                        faultsService,
                                        sparePartsService,
                                        usedSparePartsService);
                                }
                                break;
                            case 8:
                                modelType = Helper.GetTableType();
                                if (modelType is null)
                                {
                                    Console.WriteLine("Такого пункта нет!");
                                }
                                else
                                {
                                    Console.WriteLine("\nВведите Id сущности:");
                                    Guid id = Guid.Parse(Console.ReadLine());

                                    await Helper.UpdateEntity(modelType.Name, id,
                                        repairingModelsService,
                                        faultsService,
                                        sparePartsService,
                                        usedSparePartsService);
                                }
                                break;
                            default:
                                Console.WriteLine("Такого пункта нет!");
                                break;
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}







