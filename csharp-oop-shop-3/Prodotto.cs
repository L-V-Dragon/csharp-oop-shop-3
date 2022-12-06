using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_oop_shop_3.CostumeExceptions;

namespace csharp_oop_shop_3
{
    public class Prodotto
    {
        private int codice;
        private string name;
        private string description;
        private double prezzo;
        private double IVA;

        /// <summary>
        /// In questo Costruttore di base sono già presenti obbligatoriamente nome, prezzo e IVA, in quanto base obbligatoria per qualsiasi prodotto in vendita
        /// </summary>
        /// <param name="name">Il nome del prodotto</param>
        /// <param name="prezzo">il prezzo deve presentare massimo 2 decimali, in caso ne presenti ulteriori verrà tagliato a un formato corretto</param>
        /// <param name="IVA">l'IVA non ha bisogno di essere presentata in percentuale, ma semplicemente in numero</param>
        public Prodotto(string name, double prezzo, double IVA)
        {
            this.SetName(name);
            this.SetPrezzo(prezzo);
            this.SetIVA(IVA);
            this.codice = CalcoloCodice();
            this.name = name;
            this.prezzo = Math.Round(prezzo, 2); //In questo passaggio arrotondo il prezzo a due cifre decimali
            this.IVA = IVA;
        }

        /// <summary>
        /// Creo il costruttore completo
        /// </summary>
        /// <param name="name">Il nome del prodotto</param>
        /// <param name="description">La descrizione del prodotto</param>
        /// <param name="prezzo">il prezzo deve presentare massimo 2 decimali, in caso ne presenti ulteriori verrà tagliato a un formato corretto</param>
        /// <param name="IVA">l'IVA non ha bisogno di essere presentata in percentuale, ma semplicemente in numero</param>
        public Prodotto(string name, string description, double prezzo, double IVA)
        {
            this.SetName(name);
            this.SetDescription(description);
            this.SetPrezzo(prezzo);
            this.SetIVA(IVA);
            this.codice = CalcoloCodice();
            this.name = name;
            this.description = description;
            this.prezzo = Math.Round(prezzo, 2);
            this.IVA = IVA;
        }

        public int GetCodice()
        {
            return this.codice;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new noName("I prodotti hanno perforza un nome");
            }
            else
            {
                this.name = name;
            }
            
        }

        public string GetDescription()
        {
            return this.description;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public double GetPrezzo()
        {
            return this.prezzo;
        }

        public double GetPrezzoIVA()
        {
            double prezzoIVA = (this.prezzo + (this.prezzo * this.IVA) / 100);
            prezzoIVA = Math.Round(prezzoIVA, 2);
            return prezzoIVA;

        }

        public void SetPrezzo(double prezzo)
        {
            if (prezzo > 0)
            {
                this.prezzo = prezzo;
            }
            else
            {
                throw new excPrezzo("Il prezzo non può avere un valore negativo!");
            }
        }

        public double GetIVA()
        {
            return this.IVA;
        }

        public void SetIVA(double IVA)
        {
            if (IVA < 0)
            {
                throw new evasioneFiscale("NON SI EVADE IL FISCO! ORA TI ARRIVA LA GUARDIA DI FINANZA!");
            }
            else
            {
                this.IVA = IVA;
            }
            
        }

        /// <summary>
        /// Creo un metodo, privato, che calcoli in maniera randomica il codice da assegnare a un prodotto, da 0 a 99999999
        /// </summary>
        /// <returns>Il valore che ritorna sarà un INT di massimo 8 cifre</returns>
        private int CalcoloCodice()
        {

            Random generatoreRandom = new Random();
            int numeroCodice = generatoreRandom.Next(100000000);
            return numeroCodice;
        }



        public string StampaPrezzoBase()
        {
            string prezzoBase = (this.prezzo).ToString();
            prezzoBase += " euro";
            return prezzoBase;
        }

        public string StampaPrezzoIVA()
        {
            double prezzoIVA = this.GetPrezzoIVA();
            string prezzo = prezzoIVA.ToString();
            prezzo += " euro";
            return prezzo;
        }

        public string GetNomeEsteso()  //Qui ho unito il bonus al compito Nome Esteso, generando di base un codice prodotto nella forma CodiceNome, con padding di 0 se necessario
        {
            string codiceStringa = this.codice.ToString();
            codiceStringa = codiceStringa.PadLeft(8, '0');
            return codiceStringa + this.name;
        }

        public virtual void StampaProdotto()
        {
            Console.WriteLine("------ " + this.name + " -----");
            Console.WriteLine();
            Console.WriteLine(this.description);
            Console.WriteLine("Il codice del prodotto è: " + this.codice);
            Console.WriteLine("Il prezzo senza IVA del prodotto è: " + this.StampaPrezzoBase());
            Console.WriteLine("Il prezzo comprensivo di IVA è: " + this.StampaPrezzoIVA());
            Console.WriteLine("L'IVA del prodotto è al: " + this.IVA + "%");
            Console.WriteLine();
            Console.WriteLine("Il codice NomeEsteso è: " + this.GetNomeEsteso());
            Console.WriteLine();
        }
    }

}
