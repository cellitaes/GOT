using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOT.Models;

namespace GOT.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LancuchGorski>().HasData(
                new LancuchGorski()
                {
                    IdL = 1,
                    Name = "Tatry"
                },
                new LancuchGorski()
                {
                    IdL = 2,
                    Name = "Beskidy Zachodnie"
                },
                new LancuchGorski()
                {
                    IdL = 3,
                    Name = "Beskidy Wschodnie"
                },
                new LancuchGorski()
                {
                    IdL = 4,
                    Name = "Góry Świętokrzyskie"
                },
                new LancuchGorski()
                {
                    IdL = 5,
                    Name = "Sudety"
                }

                );

            // ------------ Punkty --------------

            modelBuilder.Entity<Punkt>().HasData(
                // --------- Tatry --------------
                new Punkt()
                {
                    IdP = 1,
                    Name = "Rusinowa Polana",
                    Height = 1300,
                    IdL = 1
                },
                new Punkt()
                {
                    IdP = 2,
                    Name = "Dolina Filipka",
                    IdL = 1
                },
                new Punkt()
                {
                    IdP = 3,
                    Name = "Wierch Porońca",
                    Height = 1036,
                    IdL = 1
                },
                new Punkt()
                {
                    IdP = 4,
                    Name = "Łysa Polana",
                    IdL = 1
                },
                new Punkt()
                {
                    IdP = 5,
                    Name = "Gęsia Szyja",
                    Height = 1489,
                    IdL = 1
                },
                new Punkt()
                {
                    IdP = 6,
                    Name = "Rówień Waksmundzka ",
                    IdL = 1
                },
                new Punkt()
                {
                    IdP = 7,
                    Name = "Psia Trawka",
                    IdL = 1
                },

                // --------- Beskidy Zachodnie --------------
                new Punkt()
                {
                    IdP = 8,
                    Name = "Dzięgielów - Zamek",
                    IdL = 2
                },
                new Punkt()
                {
                    IdP = 9,
                    Name = "Cieszyn przez Mniszewo",
                    IdL = 2
                },
                new Punkt()
                {
                    IdP = 10,
                    Name = "Jasieniowa",
                    Height = 521,
                    IdL = 2
                },
                new Punkt()
                {
                    IdP = 11,
                    Name = "Bażantowice",
                    IdL = 2
                },
                new Punkt()
                {
                    IdP = 12,
                    Name = "Schronisko PTTK Tuł",
                    Height = 621,
                    IdL = 2
                },
                new Punkt()
                {
                    IdP = 13,
                    Name = "Mała Czantoria",
                    Height = 864,
                    IdL = 2
                },

                //--------- Beskidy Wschodnie --------------
                new Punkt()
                {
                    IdP = 14,
                    Name = "Góra św. Marcina",
                    Height = 384,
                    IdL = 3
                },
                new Punkt()
                {
                    IdP = 15,
                    Name = "Słona Góra",
                    Height = 403,
                    IdL = 3
                },
                new Punkt()
                {
                    IdP = 16,
                    Name = "Trzemeska Góra",
                    Height = 390,
                    IdL = 3
                },
                new Punkt()
                {
                    IdP = 17,
                    Name = "Mochnaczka Niżna",
                    IdL = 3
                },
                new Punkt()
                {
                    IdP = 18,
                    Name = "Banica",
                    IdL = 3
                },
                new Punkt()
                {
                    IdP = 19,
                    Name = "Izby",
                    IdL = 3
                },
                new Punkt()
                {
                    IdP = 20,
                    Name = "Dzielec",
                    Height = 792,
                    IdL = 3
                },

                //--------- Góry Świętokrzyskie --------------
                new Punkt()
                {
                    IdP = 21,
                    Name = "Fajna ryba",
                    Height = 347,
                    IdL = 4
                },
                new Punkt()
                {
                    IdP = 22,
                    Name = "Buczyna",
                    Height = 336,
                    IdL = 4
                },
                new Punkt()
                {
                    IdP = 23,
                    Name = "Kozłowa",
                    Height = 337,
                    IdL = 4
                },
                new Punkt()
                {
                    IdP = 24,
                    Name = "Kuźniaki",
                    IdL = 4
                },
                new Punkt()
                {
                    IdP = 25,
                    Name = "Siniewska Góra",
                    Height = 449,
                    IdL = 4
                },
                new Punkt()
                {
                    IdP = 26,
                    Name = "Góra Dobrzeszowska",
                    Height = 364,
                    IdL = 4
                },

                //--------- Sudety --------------
                new Punkt()
                {
                    IdP = 27,
                    Name = "Czerniawa Zdrój",
                    IdL = 5
                },
                new Punkt()
                {
                    IdP = 28,
                    Name = "Czerniawska Kopa",
                    Height = 776,
                    IdL = 5
                },
                new Punkt()
                {
                    IdP = 29,
                    Name = "Smrek (TPG Stóg Izerski)",
                    Height = 1124,
                    IdL = 5
                },
                new Punkt()
                {
                    IdP = 30,
                    Name = "Łącznik",
                    Height = 1066,
                    IdL = 5
                },
                new Punkt()
                {
                    IdP = 31,
                    Name = "Stóg Izerski",
                    Height = 1105,
                    IdL = 5
                },
                new Punkt()
                {
                    IdP = 32,
                    Name = "Polana Izerska",
                    Height = 965,
                    IdL = 5
                },
                new Punkt()
                {
                    IdP = 33,
                    Name = "Rozdroże pod Kopą",
                    Height = 998,
                    IdL = 5
                }

                );


            modelBuilder.Entity<Turysta>().HasData(
                new Turysta()
                {
                    IdT = 1,
                    Login = "Janek123",
                    Password = "Haselko123",
                    Name = "Jan",
                    Surname = "Kowalski",
                    PostCode = "59-243",
                    City = "Wrocław",
                    Street = "Kazimierska",
                    AppartNr = 9,
                    FlatNr = 2,
                },
                 new Turysta()
                 {
                     IdT = 2,
                     Login = "Janek1234",
                     Password = "Haselko123",
                     Name = "Jan",
                     Surname = "Kowalski",
                     PostCode = "59-243",
                     City = "Wrocław",
                     Street = "Kazimierska",
                     AppartNr = 9,
                     FlatNr = 2,
                 },
                  new Turysta()
                  {
                      IdT = 3,
                      Login = "Janek12345",
                      Password = "Haselko123",
                      Name = "Jan",
                      Surname = "Kowalski",
                      PostCode = "59-243",
                      City = "Wrocław",
                      Street = "Kazimierska",
                      AppartNr = 9,
                      FlatNr = 2,
                  },
                   new Turysta()
                   {
                       IdT = 4,
                       Login = "Janek123456",
                       Password = "Haselko123",
                       Name = "Jan",
                       Surname = "Kowalski",
                       PostCode = "59-243",
                       City = "Wrocław",
                       Street = "Kazimierska",
                       AppartNr = 9,
                       FlatNr = 2,
                   }
                );


            modelBuilder.Entity<Przodownik>().HasData(
                new Przodownik
                {
                    NrLegitymacji = 1,
                    IdT = 1
                },
                 new Przodownik
                 {
                     NrLegitymacji = 2,
                     IdT = 4
                 }
                );

            modelBuilder.Entity<Uprawnienia>().HasData(
               new Uprawnienia
               {
                   IdU = 1,
                   NrLegitymacji = 1,
                   IdL = 1
               },
                new Uprawnienia
                {
                    IdU = 2,
                    NrLegitymacji = 1,
                    IdL = 4
                }
               );


        }
    }
}
