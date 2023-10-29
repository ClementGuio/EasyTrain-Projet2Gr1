using EasyTrain_P2Gr1.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EasyTrain_P2Gr1.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Gestionnaire> Gestionnaires { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<CoursProgramme> CoursProgrammes { get; set; }
        public DbSet<Abonnement> Abonnement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Permet de se connecter à la Bdd
        {


            try{
                optionsBuilder.UseMySql("server=localhost;user id=root;password=rootroot;database=EasyTrain"); // Chaine de caractères de connexion
            }finally {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=root;database=EasyTrain"); // Chaine de caractères de connexion
            }
             // Chaine de caractères de connexion
        }

        public void InitializeDb() // Permet la création de la Bdd et le remplissage des tables
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //Remplissage des tables
            this.Clients.AddRange(new List<Client>()
            {
                new Client
                {
                Nom = "Bonner",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = UtilisateurService.EncodeMD5("Prune"),
                DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            },
            new Client
            {
                Nom = "Dupond",
                Prenom = "Pierre",
                DateNaissance = new DateTime(1975, 12, 12),
                AdresseMail = "dupont.pierre@gmail.com",
                MotDePasse = UtilisateurService.EncodeMD5("Datte"),
                DateAbonnement = new DateTime(2022, 3, 15),
                Abonnement= Abonnement.FirstOrDefault(a => a.Id==1),
                DateCreationCompte = new DateTime(2022, 7, 27)
            } });

            this.Coachs.AddRange(new List<Coach>()
            {
                new Coach() {
                    Nom = "Dupont",
                    Prenom = "Pierre",
                    DateNaissance = new DateTime(1975, 12, 12),
                    AdresseMail = "dupont.pierre@gmail.com",
                    MotDePasse = UtilisateurService.EncodeMD5("Kiwi"),
                    DateEmbauche = new DateTime(2022, 3, 15)
                },
                new Coach() {
                    Nom = "Amery",  
                    Prenom = "Smet",
                    DateNaissance = new DateTime(1985,12,1),
                    AdresseMail = "a-smet@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("Abricot"),
                    DateEmbauche = new DateTime(2023,1,23)
                 },
                new Coach() {
                    Nom = "May",
                    Prenom = "Berger",
                    DateNaissance = new DateTime(1961,2,13),
                    AdresseMail = "bergermay@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("Poire"),
                    DateEmbauche = new DateTime(2023,3,14)
    }
            }); ;

            this.Gestionnaires.AddRange(new List<Gestionnaire>()
            {
                new Gestionnaire(){
                    Nom = "Dubois",
                    Prenom = "Stella",
                    DateNaissance = new DateTime(1989,6,10),
                    AdresseMail = "stella.dubois@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("Fraise"),
                    DateEmbauche = new DateTime(2023,2,13)
                },
                new Gestionnaire(){
                    Nom = "Lester",
                    Prenom = "Vincent",
                    DateNaissance = new DateTime(2003,9,22),
                    AdresseMail = "vincent.lester@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("Framboise"),
                    DateEmbauche = new DateTime(2023,8,5)
                },
                new Gestionnaire(){
                    Nom="Sadeq",
                    Prenom ="Hossame",
                    DateNaissance= new DateTime(1997,5,17),
                    AdresseMail = "hossame.sadeq@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("Pomme"),
                    DateEmbauche = new DateTime(2023,8,5)
                }
            });
            //Sauvegarde les changements dans la Bdd
            this.SaveChanges();

            this.Equipements.AddRange(new List<Equipement>()
            {
                new Equipement(){ Nom = "Banc de musculation"},
                new Equipement(){ Nom = "Banc de musculation"},
                new Equipement(){ Nom = "Banc de musculation"},
                new Equipement(){ Nom = "Cage de musculation"},
                new Equipement(){ Nom = "Cage de musculation"},
                new Equipement(){ Nom = "Cage de musculation"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Vélo"},
                new Equipement(){ Nom = "Vélo"},
                new Equipement(){ Nom = "Vélo"},
                new Equipement(){ Nom = "Vélo elliptique"},
                new Equipement(){ Nom = "Vélo elliptique"},
                new Equipement(){ Nom = "Vélo elliptique"}
            });

            this.SaveChanges();


            this.Abonnement.AddRange(new List<Abonnement>()
            {
                new Abonnement(){Titre= "Mensuel", Prix = 20},
                new Abonnement(){Titre= "Annuel", Prix = 200},
            });
            this.SaveChanges();

            this.Salles.AddRange(new List<Salle>()
            {
                new Salle(){Nom = "The Rock", Type = "Musculation", Equipements = Equipements.Where(e => (e.Nom == "Cage de musculation")
                || (e.Nom == "Set d'haltères") || (e.Nom == "Banc de musculation")).ToList() },
                new Salle(){Nom = "Maillot jaune", Type = "Cyclisme", Equipements = Equipements.Where(e => (e.Nom.Contains("Vélo"))).ToList()},
                new Salle(){Nom = "exercices collective", Type = "aérobic", Equipements = Equipements.Where(e => (e.Nom.Contains("Vélo"))).ToList()}
            });
            this.SaveChanges();

            this.Cours.AddRange(new List<Cours>()
            {
                new Cours(){Titre = "Musculation débutant", NbParticipants = 10, Prix = 23.5,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Frau") && (c.Prenom == "Richard")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "The Rock") },
                new Cours(){Titre = "Musculation avancé", NbParticipants = 7, Prix = 26.5,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Frau") && (c.Prenom == "Richard")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "The Rock") },
                new Cours(){Titre = "Cyclisme", NbParticipants = 5, Prix = 20,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Vida") && (c.Prenom == "Thibault")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "Maillot jaune") }
            });
            this.SaveChanges();

            this.CoursProgrammes.AddRange(new List<CoursProgramme>()
            {
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 30, 0), DateFin = new DateTime(2023, 11, 8, 17, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 16, 30, 0), DateFin = new DateTime(2023, 11, 8, 17, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 10, 16, 30, 0), DateFin = new DateTime(2023, 11, 8, 17, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 10, 30, 0), DateFin = new DateTime(2023, 11, 8, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 0, 0), DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 10, 30, 0), DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation débutant"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation débutant").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 0, 0), DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation débutant"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation débutant").NbParticipants}
            });
            this.SaveChanges();
        }
    }
}
