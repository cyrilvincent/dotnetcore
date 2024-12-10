﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    // TP Créer la classe Client (id, prenom, nom, tel, mail)
    // Un compte possède 1 et 1 seul client
    // Créer la classe transaction (id, datetime, montant) si montant < 0 débit sinon c'est un crédit
    // Un compte possède n transactions
    // Créditer => Créer automatiquement une transaction et l'ajouter à la liste de transactions
    // Idem pour débiter


    public class Compte
    {
        private ulong numero;  // Lecture seul ancienne écriture
        public decimal Solde { get; private set; }
        public string Devise { get; set; }
        public decimal Decouvert { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public ulong Numero
        {
            get { return numero; }
            private set { numero = value; }
        }

        public Compte(ulong numero, decimal solde = 0, string devise = "EUR", decimal decouvert = 0m)
        {
            this.Numero = numero;
            this.Solde = solde;
            this.Devise = devise;
            this.Decouvert = decouvert;
        }
        public Compte() { }

        /// <summary>
        /// Créditer le compte
        /// </summary>
        /// <param name="montant">Le montant à créditer</param>
        public void Crediter(decimal montant)
        {
            Solde += montant;
        }

        public void Debiter(decimal montant)
        {
            if ((montant < 0) || (Solde - Decouvert < montant))
            {
                Console.WriteLine("Interdit");
            }
            else
            {
                Solde -= montant;
            }
        }

        public override string ToString()
        {
            return $"Compte {Numero}:{Solde} {Devise}";
        }
    }
}
