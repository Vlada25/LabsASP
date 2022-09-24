using Lab2.DAL.Extensions;
using Lab2.DAL.Models;
using Lab2.DAL.Models.Enums;

namespace Lab2.DAL
{
    public static class DbInitializer
    {
        public static List<Fault> Faults { get; private set; }
        public static List<RepairingModel> RepairingModels { get; private set; }
        public static List<SparePart> SpareParts { get; private set; }
        public static List<UsedSparePart> UsedSpareParts { get; private set; }


        public readonly static string[] Manufacturers =
        {
            "Atlant", "Sony", "Philips", "Xiaomi", "Samsung", "Apple", "Panasonyc", "ASUS"
        };

        private readonly static Dictionary<EquipmentType, string[]> _specifications = new Dictionary<EquipmentType, string[]>
        {
            {EquipmentType.Refrigerator, new string[] 
                {
                    "Type: refrigerator with freezer, Cameras: freezer, refrigerator, Energy class: A, Noise level: 40 dB",
                    "Type: refrigerator, Cameras: refrigerator, Energy class: A, Noise level: 40 dB",
                    "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB"
                } 
            },
            {EquipmentType.CoffeeMachine, new string[] 
                {
                    "Power: 1450 W, Temperature control: yes, Remote control: no, Water tank: 1.8 l",
                    "Power: 1500 W, Temperature control: yes, Remote control: yes, Water tank: 2 l",
                    "Power: 1400 W, Temperature control: no, Remote control: no, Water tank: 1.5 l"
                } 
            },
            {EquipmentType.Television, new string[]
                {
                    "Diagonal: 50, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz",
                    "Diagonal: 47, Permission: Ultra HD 4K-3420x1960 pix, Matrix frequency: 55 Hz",
                    "Diagonal: 49, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz"
                }
            },
            {EquipmentType.Computer, new string[]
                {
                    "Processor brand: Intel, Processor series: Core-i7, Number of Cores: 4",
                    "Processor brand: Intel, Processor series: Core-i5, Number of Cores: 2",
                    "Processor brand: Intel, Processor series: Core-i3, Number of Cores: 2"
                }
            },
            {EquipmentType.Telephone, new string[]
                {
                    "Number of Cores: 6, Number of SIM cards: 2, Camera Resolution: 48 MP",
                    "Number of Cores: 4, Number of SIM cards: 2, Camera Resolution: 24 MP",
                    "Number of Cores: 4, Number of SIM cards: 1, Camera Resolution: 12 MP"
                }
            },
            {EquipmentType.Headphones, new string[]
                {
                    "Impedance: 32 Ohm, Sensitivity: 105 dB, Operating frequency range: 20 Hz - 20 kHz",
                    "Impedance: 30 Ohm, Sensitivity: 90 dB, Operating frequency range: 20 Hz - 20 kHz",
                    "Impedance: 32 Ohm, Sensitivity: 100 dB, Operating frequency range: 20 Hz - 20 kHz"
                }
            },
            {EquipmentType.Iron, new string[]
                {
                    "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min",
                    "Max Power: 1.5, Water tank volume: 300 ml, Continuous steam: 35 g/min",
                    "Max Power: 2, Water tank volume: 350 ml, Continuous steam: 50 g/min"
                }
            },
            {EquipmentType.ElectricKettle, new string[]
                {
                    "Power: 2100, Water volume: 1.7, Heating element: closed",
                    "Power: 2400, Water volume: 2, Heating element: closed",
                    "Power: 2200, Water volume: 1.8, Heating element: closed"
                }
            },
        };

        private readonly static Dictionary<EquipmentType, string[]> _particularQualities = new Dictionary<EquipmentType, string[]>
        {
            {EquipmentType.Refrigerator, new string[]
                {
                    "Color: white, Lighting: LED",
                    "Color: black, Lighting: LED",
                    "Color: golden, Lighting: LED"
                }
            },
            {EquipmentType.CoffeeMachine, new string[]
                {
                    "Color: silver, black, Material: plastic",
                    "Color: white, Material: plastic",
                    "Color: golden, black, Material: plastic"
                }
            },
            {EquipmentType.Television, new string[]
                {
                    "Color: black, Number of USB inputs: 2, Screen shape: curved",
                    "Color: white, Number of USB inputs: 2, Screen shape: straight",
                    "Color: black, Number of USB inputs: 1, Screen shape: straight"
                }
            },
            {EquipmentType.Computer, new string[]
                {
                    "Color: silver, Material: plastic, Screen diagonal: 15.6",
                    "Color: black, Material: plastic, Screen diagonal: 14.7",
                    "Color: pink, Material: plastic, Screen diagonal: 15.6"
                }
            },
            {EquipmentType.Telephone, new string[]
                {
                    "Color: white, Screen diagonal: 6.1, Screen resolution: 2532×1170",
                    "Color: black, Screen diagonal: 5.9, Screen resolution: 2532×1170",
                    "Color: blue, Screen diagonal: 6.0, Screen resolution: 2532×1170"
                }
            },
            {EquipmentType.Headphones, new string[]
                {
                    "Color: white, Design: covering the ear",
                    "Color: black, Design: inserted into the ear",
                    "Color: lime, Design: covering the ear"
                }
            },
            {EquipmentType.Iron, new string[]
                {
                    "Color: black, Automatic shutdown: yes",
                    "Color: purple, Automatic shutdown: no",
                    "Color: darkblue, Automatic shutdown: yes"
                }
            },
            {EquipmentType.ElectricKettle, new string[]
                {
                    "Color: black, Water level indication: yes, Keep warm function: no",
                    "Color: white, Water level indication: no, Keep warm function: no",
                    "Color: silver, Water level indication: yes, Keep warm function: yes"
                }
            },
        };

        private readonly static Dictionary<EquipmentType, string[]> _faultsRepairingMethods = new Dictionary<EquipmentType, string[]>
        {
            {EquipmentType.Refrigerator, new string[] 
                {
                    "Refrigerator won't turn on*" +
                        "If the voltage is higher or lower than the specified range, then the refrigerator may simply not turn on. " +
                        "Remove the terminals from the wires connected to the thermostat and connect them together. " +
                        "If the refrigerator does not turn on and the light inside the refrigerator does not light up, " +
                        "then most likely the problem is precisely in the lack of power. Check if everything is in order with the cord, plug and socket.",
                    "Refrigerator shuts down after a short period of operation*" +
                        "Safety relay plate should be checked with an ohmmeter and replaced if a malfunction is detected. " +
                        "Start relay coil also checked with an ohmmeter and if a malfunction is detected, the part is replaced. " +
                        "The compressor motor needs to be replaced, for which you will have to call a refrigerator repairman.",
                    "Refrigerator not freezing*" +
                        "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the " +
                        "compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.",
                    "Refrigerator is freezing cold*" +
                        "The thermostat must either be replaced or sent in for repair for adjustment. Make sure the seal fits snugly against the door and sides " +
                        "of the refrigerator. If defects are found, the seal must be replaced.",
                    "Refrigerator is too cold*" +
                        "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. " +
                        "The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position."
                } 
            },
            {EquipmentType.CoffeeMachine, new string[]
                {
                    "Noisy*" +
                        "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. " +
                        "The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with " +
                        "the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.",
                    "Doesn't respond when turned on*" +
                        "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!",
                    "Control system not working*" +
                        "In some cases, the search for a defect is forced to remove the control panel - this way you can check the condition of the contacts with a special tester. " +
                        "The cause of the malfunction may be contamination of the mechanical buttons - sunken elements must be removed, cleaned and reinstalled.",
                    "The machine does not heat water*" +
                        "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is " +
                        "insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush " +
                        "the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace " +
                        "the heating element, which is performed by a service center specialist."
                }
            },
            {EquipmentType.Television, new string[]
                {
                    "There is no picture on the TV, but there is sound*" +
                        "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been " +
                        "pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is " +
                        "in working order and fits snugly into the socket.",
                    "No signal on TV*" +
                        "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of " +
                        "action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. " +
                        "The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.",
                    "No sound on TV*" +
                        "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.",
                }
            },
            {EquipmentType.Computer, new string[]
                {
                    "The system unit does not turn on, the Power indicator does not light up*" +
                        "Check the connection of the video cables of the monitor. Check the monitor's power cable.",
                    "Computer turns on, Power light is on, monitor is blank*" +
                        "Check the connection of the video cables of the monitor. Check the monitor's power cable.",
                    "The system unit beeps continuously, does not boot/reboot*" +
                        "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: " +
                        "a) Award Bios1 long, 3 short - video card not detected or defective."
                }
            },
            {EquipmentType.Telephone, new string[]
                {
                    "Doesn't turn on*" +
                        "There can be many reasons for this most common problem, ranging from failures in the operating system to malfunctioning boards. Also, the reason may be an unsuccessful flashing, " +
                        "and sometimes the phone simply cannot charge due to a clogged port.",
                    "Moisture ingress*" +
                        "Immediately after the incident, you need to turn off the gadget and try to dry it (if the battery is removable, then pull it out). Do not use a hair dryer or heat the device in " +
                        "any other way. Otherwise, there is a high risk of burning the electronics, and then even contacting a service center will not help.",
                    "Charging goes fast*" +
                        "To fully verify its malfunction, you need to measure the battery consumption for some time when the smartphone is not in use."
                }
            },
            {EquipmentType.Headphones, new string[]
                {
                    "Damage to the contact*" +
                        "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ",
                    "A thin cable can be torn if it is constantly pulled with force or strongly pulled*" +
                        "Such a malfunction is more difficult to detect, especially if a budget model is used, which has very thin wires or damage to the driver itself. It is not possible " +
                        "to see the break with the eyes, since the insulation will remain intact. In this case, diagnostics will be required and only then repair of the headphones. ",
                    "A frequent malfunction when one earpiece fails*" +
                        "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own."
                }
            },
            {EquipmentType.Iron, new string[]
                {
                    "Power cord damage*" +
                        "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. " +
                        "It needs to be shortened and checked again.",
                    "Heating element damage*" +
                        "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. " +
                        "You can determine that the breakdown is related specifically to the heating element as follows.",
                    "Damage to the thermostat*" +
                        "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special " +
                        "device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network."
                }
            },
            {EquipmentType.ElectricKettle, new string[]
                {
                    "The kettle that is plugged in does not heat the water*" +
                        "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we " +
                        "advise you to buy a new device.",
                    "Water flows from the kettle*" +
                        "The cause of the malfunction is in the glass with the water meter scale. The seals in the body are worn out if the heater is of an open type.",
                    "The kettle turns off before the water boils*" +
                        "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will " +
                        "inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle."
                }
            },
        };


        private readonly static Dictionary<EquipmentType, string[]> _sparePartsFunctions = new Dictionary<EquipmentType, string[]>
        {
            {EquipmentType.Refrigerator, new string[]
                {
                    "Refrigeratorr compressor motor*" +
                        "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.",
                    "Refrigerator thermostat*" +
                        "It is worth buying a thermostat (thermal relay) for a refrigerator if the refrigerator turns off, the temperature inside is too low or high.",
                    "Electronic control unit*" +
                        "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.",
                }
            },
            {EquipmentType.CoffeeMachine, new string[]
                {
                    "Termoblock*" +
                        "Allows to prepare a drink from water in a short time.",
                    "Boiler*" +
                        "Heat water to the required temperature.",
                    "Pump*" +
                        "Pump water into the coffee machine",
                }
            },
            {EquipmentType.Television, new string[]
                {
                    "Screen*" +
                        "Shows image.",
                    "Antenna*" +
                        "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.",
                    "Board*" +
                        "Contains a television tuner, decoders that amplify video and audio signals.",
                }
            },
            {EquipmentType.Computer, new string[]
                {
                    "CPU*" +
                        "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ " +
                        "аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.",
                    "Моthеrbоаrd*" +
                        "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, " +
                        "video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.",
                    "Cochet*" +
                        "Socket - a connector into which the central processor is inserted."
                }
            },
            {EquipmentType.Telephone, new string[]
                {
                    "Electronic board*" +
                        "This detail is the heart of the mobile device and ensures the performance of its main functions.",
                    "Display*" +
                        "Shows image.",
                    "Battery*" +
                        "A battery that provides autonomous operation of a mobile phone (it can be nickel-metal hydride, lithium-ion or lithium-polymer)."
                }
            },
            {EquipmentType.Headphones, new string[]
                {
                    "Cable*" +
                        "Provides connect with device.",
                    "Speaker*" +
                        "Provides sound output.",
                    "Plug*" +
                        "Provides connecting with device."
                }
            },
            {EquipmentType.Iron, new string[]
                {
                    "Electric wire*" +
                        "To connecting with electric web.",
                    "Chamber for water*" +
                        "To keep water",
                    "Thermostat*" +
                        "To control heating."
                }
            },
            {EquipmentType.ElectricKettle, new string[]
                {
                    "Heating element*" +
                        "To heat water.",
                    "Button*" +
                        "To turn on/off the kettle.",
                    "Cable*" +
                        "To connect with electric web."
                }
            },
        };

        public static void Initialize()
        {
            Faults = new List<Fault>();
            RepairingModels = new List<RepairingModel>();
            SpareParts = new List<SparePart>();
            UsedSpareParts = new List<UsedSparePart>();


            for (int i = 0; i < 500; i++)
            {
                int manufacturerIndex = new Random((int)DateTime.Now.Ticks + i).Next(Manufacturers.Length);
                int typeIndex = new Random((int)DateTime.Now.Ticks + i).Next(8);
                int specificationsIndex = new Random((int)DateTime.Now.Ticks + i).Next(3);
                int particularQualitiesIndex = new Random((int)DateTime.Now.Ticks + i).Next(3);

                RepairingModels.Add(new RepairingModel
                {
                    Id = Guid.NewGuid(),
                    Name = $"" +
                        $"{EnumExtensions.GetDisplayName(EnumExtensions.SetEquipmentType(typeIndex))} " +
                        $"{Manufacturers[manufacturerIndex]}",
                    Type = EnumExtensions.SetEquipmentType(typeIndex),
                    Manufacturer = Manufacturers[manufacturerIndex],
                    Specifications = _specifications[EnumExtensions.SetEquipmentType(typeIndex)][specificationsIndex],
                    ParticularQualities = _particularQualities[EnumExtensions.SetEquipmentType(typeIndex)][particularQualitiesIndex]
                });
            }

            for (int i = 0; i < 500; i++)
            {
                int repairingModelIndex = new Random((int)DateTime.Now.Ticks + i).Next(RepairingModels.Count);
                decimal price = new Random((int)DateTime.Now.Ticks + i).Next(25, 347);
                
                RepairingModel repairingModel = RepairingModels[repairingModelIndex];
                string[] faultsRepMethods = _faultsRepairingMethods[repairingModel.Type];

                int repMethodIndex = new Random((int)DateTime.Now.Ticks + i).Next(faultsRepMethods.Length);
                string repMethod = faultsRepMethods[repMethodIndex];

                Faults.Add(new Fault
                {
                    Id = Guid.NewGuid(),
                    Name = repMethod.Split('*')[0],
                    RepairingModelId = repairingModel.Id,
                    RepairingMethods = repMethod.Split('*')[1],
                    Price = price
                });
            }

            for (int i = 0; i < 500; i++)
            {
                decimal price = new Random((int)DateTime.Now.Ticks + i).Next(25, 347);
                int sparePartFuncIndex = new Random((int)DateTime.Now.Ticks + i).Next(8);
                int sparePartIndex = new Random((int)DateTime.Now.Ticks + i).Next(3);
                var sparePartDescription = _sparePartsFunctions[EnumExtensions.SetEquipmentType(sparePartFuncIndex)];

                SpareParts.Add(new SparePart
                {
                    Id = Guid.NewGuid(),
                    Name = sparePartDescription[sparePartIndex].Split('*')[0],
                    Functions = sparePartDescription[sparePartIndex].Split('*')[1],
                    Price = price,
                    EquipmentType = EnumExtensions.SetEquipmentType(sparePartFuncIndex)
                });
            }

            for (int i = 0; i < 5000; i++)
            {
                int faultIndex = new Random((int)DateTime.Now.Ticks + i).Next(500);
                var fault = Faults[faultIndex];

                List<SparePart> fitSpareParts = SpareParts
                    .Where(sp => sp.EquipmentType.Equals(RepairingModels
                    .First(rm => rm.Id.Equals(fault.RepairingModelId)).Type)).ToList();

                int sparePartIndex = new Random((int)DateTime.Now.Ticks + i).Next(fitSpareParts.Count);
                var sparePart = fitSpareParts[sparePartIndex];

                UsedSpareParts.Add(new UsedSparePart
                {
                    Id = Guid.NewGuid(),
                    FaultId = fault.Id,
                    SparePartId = sparePart.Id
                });
            }
        }
    }
}