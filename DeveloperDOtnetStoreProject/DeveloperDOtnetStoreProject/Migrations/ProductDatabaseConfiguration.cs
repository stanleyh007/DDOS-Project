using DeveloperDOtnetStoreProject.Models;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Migrations
{
    public class ProductDatabaseConfiguration
    {
        public ApplicationDbContext getProductDatabaseUpdate(ApplicationDbContext context)
        {
            // CateGoryHeader
            context.CategoryHeaderModels.AddOrUpdate(s => s.Name, new CategoryHeaderModel[] {
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 1,
                                                   Name = "Grafikkort"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 2,
                                                   Name = "Harddisk"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 3,
                                                   Name = "Bundkort"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 4,
                                                   Name = "Ram"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                    CategoryHeaderModelId = 5,
                                                    Name = "Lydkort"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                    CategoryHeaderModelId = 6,
                                                    Name = "Processor-CPU"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                    CategoryHeaderModelId = 7,
                                                    Name = "Cooling"
                                               }
            });

            /*
                1	Grafikkort
                2	Harddisk
                3	Bundkort
                4	Ram
                5	Lydkort
                6   Processor CPU
                7   Cooling
             */

            // Products
            context.Products.AddOrUpdate(s => s.NameHeader, new ProductModel[] {
                                        // Grafikkort 1
                                        new ProductModel
                                        {
                                            NameHeader = "Nvidia GFx 9000 Series",
                                            NameDescription = "Grafikkort",
                                            Price = 4599,
                                            QuantityStorage = 2,
                                            CategoryHModelId = 1
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "ASUS GeForce GTX 1070 ROG Strix Gaming",
                                            NameDescription = "Grafikkort, PCI-Express 3.0, 8GB GDDR5, DirectCU III, Aura RGB, OC- version",
                                            Price = 4190,
                                            QuantityStorage = 13,
                                            CategoryHModelId = 1
                                        },
                                        // Harddisk
                                        new ProductModel
                                        {
                                            NameHeader = "Seagate Barracuda 1TB 3.5\" HDD",
                                            NameDescription = "SATA 6.0Gb/s, 7200RPM, 64MB cache, 3.5\"",
                                            Price = 499,
                                            QuantityStorage = 1,
                                            CategoryHModelId = 2
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "WD Desktop Black 6TB 3.5\"",
                                            NameDescription = "SATA 6GB/s (SATA 3.0), 1 miljoner timmar MTBF, 7200RPM, 128MB, 3.5\"",
                                            Price = 2399,
                                            QuantityStorage = 1,
                                            CategoryHModelId = 2
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "Crucial MX300 525GB 2.5\" SSD",
                                            NameDescription = "SATA 6GB/s, 530/510MB/s read/write, 7mm med adapter",
                                            Price = 1069,
                                            QuantityStorage = 45,
                                            CategoryHModelId = 2
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "Kingston SSDNow UV400 240GB SSD",
                                            NameDescription = "SATA 3.0, Marvell 88SS1074, op til 550/490MB/s, 7mm, OEM",
                                            Price = 599,
                                            QuantityStorage = 47,
                                            CategoryHModelId = 2
                                        },
                                        // Bundkort
                                        new ProductModel
                                        {
                                            NameHeader = "ASUS A68HM-PLUS, Socket-FM2+",
                                            NameDescription = "Bundkort, m-ATX, A68, DDR3, 1xPCIe-x16, USB3.0, VGA, DVI, HDMI, UEFI",
                                            Price = 429,
                                            QuantityStorage = 15,
                                            CategoryHModelId = 3
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "ASUS SABERTOOTH X99, Socket-2011-3",
                                            NameDescription = "Bundkort, ATX, X99, DDR4, 3xPCIe-x16, SLI/CFX, USB 3.1, M.2, SATA Express, TUF",
                                            Price = 2895,
                                            QuantityStorage = 3,
                                            CategoryHModelId = 3
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "MSI 970A-G43 Plus, Socket-AM3+",
                                            NameDescription = "Bundkort, ATX, 970 & SB950, DDR3, 2xPCIe-x16, SATA 6 Gb/s, USB 3.1",
                                            Price = 599,
                                            QuantityStorage = 3,
                                            CategoryHModelId = 3
                                        },
                                        // RAM
                                        new ProductModel
                                        {
                                            NameHeader = "Corsair Vengeance Pro DDR3 2400MHz 16GB",
                                            NameDescription = "2x8GB 2400MHz (PC3-19200) DDR3 CL11, 1.65V, XMP",
                                            Price = 879,
                                            QuantityStorage = 17,
                                            CategoryHModelId = 4
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "Corsair Vengeance LPX DDR4 3000MHz 16GB",
                                            NameDescription = "2x8GB 3000MHz (PC4-24000) DDR4 CL15, XMP, Sort",
                                            Price = 879,
                                            QuantityStorage = 15,
                                            CategoryHModelId = 4
                                        },
                                        // Lydkort 
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/770571/hardware/lydkort/creative-sound-blaster-z-lydkort
                                            NameHeader = "Creative Sound Blaster Z Lydkort",
                                            NameDescription = "PCIe 1x, 5.1 kanals surround, hi fi, hovedtelefonforstærker, Core3D, 116 dB SRN",
                                            Price = 599,
                                            QuantityStorage = 19,
                                            CategoryHModelId = 5
                                        },
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/608554/hardware/lydkort/asus-xonar-dg-lydkort
                                            NameHeader = "ASUS Xonar DG Lydkort",
                                            NameDescription = "PCI, 5.1 kanals surround, hi fi, hörlursförstärkare, GX 2.5 lyd, 105 dB SRN",
                                            Price = 279,
                                            QuantityStorage = 1,
                                            CategoryHModelId = 5
                                        },
                                        // Prosessor CPU
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/888233/hardware/processorer/amd-fx-6350-black-edition-processor
                                            NameHeader = "AMD FX-6350 Black Edition Processor",
                                            NameDescription = "Socket-AM3+, 6-Core 3.9GHz, 14MB, 125W, 32nm, inkl. Wraith køler",
                                            Price = 1099,
                                            QuantityStorage = 2,
                                            CategoryHModelId = 15
                                        },
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/850037/hardware/processorer/intel-core-i7-6700k-skylake-processor#
                                            NameHeader = "Intel Core i7-6700K Skylake Processor",
                                            NameDescription = "Socket-LGA1151, Quad Core 4.0GHz, 8MB, 91W, 14nm, Boxed, u/køler",
                                            Price = 2848,
                                            QuantityStorage = 13,
                                            CategoryHModelId = 15
                                        },
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/850033/hardware/processorer/intel-core-i5-6500-skylake-processor
                                            NameHeader = "Intel Core i5-6500 Skylake Processor",
                                            NameDescription = "Socket-LGA1151, Quad Core 3.2GHz, 6MB, 65W, 14nm, Boxed m/køler",
                                            Price = 1679,
                                            QuantityStorage = 25,
                                            CategoryHModelId = 15
                                        },
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/857987/hardware/processorer/intel-core-i7-6700k-skylake-bundle
                                            NameHeader = "Intel Core i7-6700K Skylake Bundle",
                                            NameDescription = "Socket-LGA1151, Quad Core 4.0GHz, 8MB, 91W, 14nm, Boxed + CM TX3 Evo CPU Cooler",
                                            Price = 2999,
                                            QuantityStorage = 1,
                                            CategoryHModelId = 15
                                        },
                                        // Cooling Blæserer
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/850934/hardware/blaeserekoelerevandkoeling/cpu-luftkoeling/intel-ts15a-cpu-air-cooler
                                            NameHeader = "Intel TS15A CPU Air Cooler",
                                            NameDescription = "High performance air cooler for Skylake, 130w, works with all LGA115x",
                                            Price = 269,
                                            QuantityStorage = 4,
                                            CategoryHModelId = 16
                                        },
                                        new ProductModel
                                        {
                                            // LINK: https://www.komplett.dk/product/890826/hardware/blaeserekoelerevandkoeling/cpu-luftkoeling/noctua-nh-l9x65-cpu-koeler
                                            NameHeader = "Noctua NH-L9x65 CPU Køler",
                                            NameDescription = "115x/2011/2011-3, AM2(+)/AM3(+)/FM1/FM2(+), 600-2500 RPM, 57,5 m³/h, ~23,6 dBA",
                                            Price = 449,
                                            QuantityStorage = 9,
                                            CategoryHModelId = 16
                                        }
            });
            return context;
        }
    }
}