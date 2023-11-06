using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EasyTrain_UnitTests.TestsDAL
{
    [Collection("sequential")]
    [DbCleanUp]
    public class PresenceServiceTest
    {
        [Fact]
        public void TestGetPresences()
        {
            //Initialisation
            Client client = new Client
            {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                //DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            };
            List<Presence> presences = new List<Presence>
            {
                new Presence {
                    HeureArrivee = new DateTime(2023, 1, 1, 13, 30, 45),
                    Client = client
                },
                new Presence {
                    HeureArrivee = new DateTime(2023, 3, 10, 16, 9, 57),
                    Client = client
                },

            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.Add(client);
                ctx.SaveChanges();
                ctx.Presences.AddRange(presences);
                ctx.SaveChanges();
            }
            //Execution
            List<Presence> presenceDb;
            using (IDalPresence service = new PresenceService())
            {
                presenceDb = service.GetPresences();
            }
            //Verification
            Assert.NotEmpty(presenceDb);
            Assert.NotNull(presenceDb[0].Client);
            Assert.NotNull(presenceDb[1].Client);
        }

        [Fact]
        public void TestGetPresence()
        {
            //Initialisation
            Client client = new Client
            {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                //DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            };
            Presence presence = new Presence
            {
                HeureArrivee = new DateTime(2023, 1, 1, 13, 30, 45),
                Client = client
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.Add(client);
                ctx.SaveChanges();
                ctx.Presences.Add(presence);
                ctx.SaveChanges();
            }
            //Execution
            Presence presenceDb;
            using (IDalPresence service = new PresenceService())
            {
                presenceDb = service.GetPresence(presence.Id);
            }
            //Verification
            Assert.NotNull(presenceDb);
            Assert.Equal(presence.HeureArrivee, presenceDb.HeureArrivee);
            Assert.NotNull(presenceDb.Client);
            Assert.Equal(presence.Client.Id, presenceDb.Client.Id);
        }

        [Fact]
        public void TestUpdatePresence()
        {
            //Initialisation
            Client client = new Client
            {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                //DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            };
            Presence presence = new Presence
            {
                HeureArrivee = new DateTime(2023, 1, 1, 13, 30, 45),
                Client = client
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.Add(client);
                ctx.SaveChanges();
                ctx.Presences.Add(presence);
                ctx.SaveChanges();
            }
            //Execution
            presence.HeureDepart = new DateTime(2023, 1, 1, 15, 0, 0, 0);
            using (IDalPresence service = new PresenceService())
            {
                service.UpdatePresence(presence);
            }
            //Verification
            Presence presenceDb;
            using (BddContext ctx = new BddContext())
            {
                presenceDb = ctx.Presences
                    .Include(p => p.Client)
                    .FirstOrDefault(p => p.Id == presence.Id);
            }
            Assert.NotNull(presenceDb);
            Assert.Equal(presence.Id, presenceDb.Id);
            Assert.Equal(presence.HeureArrivee, presenceDb.HeureArrivee);
            Assert.Equal(presence.HeureDepart, presenceDb.HeureDepart);
            Assert.NotNull(presence.Client);
            Assert.Equal(presence.Client.Id, presenceDb.Client.Id);
        }
    }
}
