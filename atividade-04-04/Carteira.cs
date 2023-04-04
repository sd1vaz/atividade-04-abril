using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_04_04
{

    public class Carteira
    {
        public double saldo
        {
            get;
            private set;
        }

        public string Dono { get; set; }

        public bool sacar(double valor)
        {
            this.saldo -= valor;
            return true;
        }

        public bool Depositar(double valor)
        {
            this.saldo += valor;
            return true;
        }
        public bool Transferir(Carteira destino, double valor)
        {
            if (this.saldo <= valor)
            {
                return false;
            }

            this.sacar(valor);
            bool tOK = destino.Depositar(valor);
            if (tOK)
            {
                return true;
            }
            else
            {
                this.Depositar(valor);
                return false;
            }
        }
    }
}


