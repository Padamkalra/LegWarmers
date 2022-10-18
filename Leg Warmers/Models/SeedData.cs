using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Leg_Warmers.Data;
using Microsoft.EntityFrameworkCore;

namespace Leg_Warmers.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcLegWarmersContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcLegWarmersContext>>()))
            {
                // Look for any movies.
                if (context.LegWarmers.Any())
                {
                    return;   // DB has been seeded
                }

                context.LegWarmers.AddRange(
                    new Legwarmers
                    {
                        Name = "ABC",
                        Price = 5779,
                        Colour = "Grey",
                        Height = 180,
                        Design = "Standard",
                        Brand = "Gucci"
                    },
                     new Legwarmers
                     {
                         Name = "ABC",
                         Price = 1569,
                         Colour = "Midnight Blue",
                         Height = 25,
                         Design = "Chesterfield",
                         Brand = "reebok"
                     },
                      new Legwarmers
                      {
                          Name = "ABC",
                          Price = 1299,
                          Colour = "Aubergine",
                          Height = 33 ,
                          Design = "Standard",
                          Brand = "nike"
                      },
                       new Legwarmers
                       {
                           Name = "ABC",
                           Price = 749,
                           Colour = "Creamr Polyster",
                           Height = 26 ,
                           Design = "Standard",
                           Brand= "nike"
                       },
                        new Legwarmers
                        {
                            Name = "ABC",
                            Price = 749,
                            Colour = "Pink Velvet",
                            Height = 25 ,
                            Design = "sleek",
                            Brand = "Reebox"
                        },
                         new Legwarmers
                         {
                             Name = "ABC",
                             Price = 959,
                             Colour = "Green",
                             Height = 190,
                             Design = "snake",
                             Brand = "gucci"
                         },
                          new Legwarmers
                          {
                              Name = "ABC",
                              Price = 959,
                              Colour = "Green",
                              Height = 190,
                              Design = "snake",
                              Brand = "gucci"
                          },
                           new Legwarmers
                           {
                               Name = "ABC",
                               Price = 959,
                               Colour = "Green",
                               Height = 190,
                               Design = "snake",
                               Brand = "gucci"
                           },
                            new Legwarmers
                            {
                                Name = "ABC",
                                Price = 959,
                                Colour = "Green",
                                Height = 190,
                                Design = "snake",
                                Brand = "gucci"
                            },
                             new Legwarmers
                             {
                                 Name = "ABC",
                                 Price = 959,
                                 Colour = "Green",
                                 Height = 190,
                                 Design = "snake",
                                 Brand = "gucci"
                             }
                );
                context.SaveChanges();
            }
        }
    }
}