using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Gestionnaire> Gestionnaires {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Permet de se connecter à la Bdd
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=EasyTrain"); // Chaine de caractères de connexion
        }

        public void InitializeDb() // Permet la création de la Bdd et le remplissage des tables
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //Remplissage des tables
            this.Clients.AddRange(new List<Client>()
            {
                new Client() {Nom = "Patpat", Prenom = "Patrick", DateCreationCompte = DateTime.Now  },
                new Client() {Nom = "Dupont", Prenom = "Roger", DateCreationCompte = DateTime.Now  }
            });

            this.Coachs.AddRange(new List<Coach>()
            {
                new Coach() {Nom = "Frau" , Prenom = "Richard", DateEmbauche = DateTime.Now},
                new Coach() {Nom = "Vida" , Prenom = "Thibault", DateEmbauche = DateTime.Now},
                new Coach() {Nom = "Vince" , Prenom = "charles", DateEmbauche = DateTime.Now}
            });

            this.Gestionnaires.AddRange(new List<Gestionnaire>()
            {
                new Gestionnaire(){Nom="Smith" , Prenom ="John", DateEmbauche= DateTime.Now}
            });
            //Sauvegarde les changements dans la Bdd
            this.SaveChanges();
        }
    }
}
