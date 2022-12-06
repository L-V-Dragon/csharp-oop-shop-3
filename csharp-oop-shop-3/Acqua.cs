using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_oop_shop_3.CostumeExceptions;

namespace csharp_oop_shop_3
{
    public class Acqua : Prodotto
    {
        // CARATTERISTICHE

        private double litri;
        private double pH;
        private string sorgente;
        private double maxCapienza;

        // COSTRUTTORE

        public Acqua(string nome, string descrizione, float prezzo, int iva, double litri, double pH, string sorgente) : base(nome, descrizione, prezzo, iva)
        {
            this.litri = litri;
            this.pH = Math.Round(pH, 2);
            this.sorgente = sorgente;
            this.maxCapienza = 1.5;
        }

        // GETTERS

        public double GetLitri()
        {
            return this.litri;
        }
        public double GetPH()
        {
            return this.pH;
        }
        public string GetSorgente()
        {
            return this.sorgente;
        }

        // SETTERS
        public void SetLitri(double litri)
        {
            this.litri = litri;
        }
        public void SetPH(double pH)
        {
            if (pH < 0 || pH > 14)
            {
                throw new phException("Il ph di un liquido non può esere maggiore di 14 o minore di 0");
            } else
            {
                this.pH = pH;
            }
        }
        public void SetSorgente(string sorgente)
        {
            if (string.IsNullOrEmpty(sorgente))
            {
                throw new noSorgenteEx("L'acqua ha perforza una sorgente");
            }
            else
            {
                this.sorgente = sorgente;
            }
            
        }

        // METODO

        public void BeviAcqua(double litriDaBere)
        {
            if (litriDaBere <= this.litri)
            {
                this.litri = this.litri - litriDaBere;

                if (this.litri == 0)
                {
                    throw new noLitri("Hai finito l'acqua.");
                }
                else if (this.litri < 0)
                {
                    throw new noLitri("Non puoi bere acqua che non c'è.");
                }
                else
                {
                    this.litri = litri;
                }
            }
            
        }

        public void RiempiBottiglia(float litriDaRiempire)
        {
            if (this.maxCapienza - this.litri >= litriDaRiempire) // litriDaRiempiere <= this.maxCapienza - this.litri
            {
                this.litri += Math.Round(litriDaRiempire, 2);
            }
            else if (litriDaRiempire > this.maxCapienza - this.litri )
            {
                throw new litriOverflow("Hai già riempito al massimo l'acqua");
            } 
            else 
            {
                this.litri = this.maxCapienza;
            }
         
        }

        public void SvuotaBottiglia()
        {
            this.litri = 0;
        }

        public override void StampaProdotto()
        {
            base.StampaProdotto();
            Console.WriteLine();
            Console.WriteLine("Dati acqua:");
            Console.WriteLine();
            Console.WriteLine("Litri: " + GetLitri());
            Console.WriteLine("pH: " + GetPH());
            Console.WriteLine("Sorgente: " + GetSorgente());
            Console.WriteLine();

        }


    }
}
