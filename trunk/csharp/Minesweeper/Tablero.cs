using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    enum Estado {Closed=0, Open=1, HasMine=2, Boom=4, HasFlag=8}
    class Tablero
    {
        public int Filas { get; private set; }
        public int Cols { get; private set; }
        public int Minas { get; private set; }

        public Estado[,] Campo {get; private set; }

        public bool GameOver { get; private set; }

        public int CeldasCerradas {get; private set; }

        public bool HaGanado
        {
            get
            {
                return CeldasCerradas == this.Minas;
            }
        }

        public Tablero(int filas, int cols, int minas)
        {
            this.Filas = filas;
            this.Cols = cols;
            this.Minas = minas;
            Inicializar();
        }

        public void Inicializar()
        {
            Random r = new Random();
            this.Campo = new Estado[this.Filas, this.Cols];

            int pF, pC;
            for (int i = 0; i < this.Minas; i++)
            {
                do
                {
                    pF = r.Next(Filas);
                    pC = r.Next(Cols);
                } while (IsSet(pF, pC, Estado.HasMine));
                Campo[pF, pC] |= Estado.HasMine;
            }
            this.GameOver = false;
            this.CeldasCerradas = this.Filas * this.Cols;
        }

        public int ObtenerMinasAdyacentes(int f, int c)
        {
            if (IsSet(f, c, Estado.HasMine) || IsSet(f, c, Estado.HasFlag))
                return 0;

            int counter = SumarVecino(f - 1, c - 1);
            counter += SumarVecino(f - 1, c);
            counter += SumarVecino(f - 1, c + 1);
            counter += SumarVecino(f, c + 1);
            counter += SumarVecino(f + 1, c + 1);
            counter += SumarVecino(f + 1, c);
            counter += SumarVecino(f + 1, c - 1 );
            counter += SumarVecino(f, c - 1);
            return counter;
        }

        private int SumarVecino(int f, int c)
        {
            return f < 0 || f >= Filas || c < 0 || c >= Cols || !IsSet(f, c, Estado.HasMine) ? 0 : 1;
        }

        public void DescubrirAdyacentes(int f, int c)
        {
            if (IsSet(f, c, Estado.HasMine))
                return;

            Descubrir(f - 1, c - 1);
            Descubrir(f - 1, c);
            Descubrir(f - 1, c + 1);
            Descubrir(f, c + 1);
            Descubrir(f + 1, c + 1);
            Descubrir(f + 1, c);
            Descubrir(f + 1, c - 1);
            Descubrir(f, c - 1);
        }

        internal void Descubrir(int f, int c)
        {
            if (f < 0 || f >= Filas || c < 0 || c >= Cols || IsSet(f, c, Estado.Open) || IsSet(f, c, Estado.HasFlag))
                return;

            if (IsSet(f, c, Estado.HasMine))
            {
                this.Campo[f, c] |= Estado.Boom;
                this.GameOver = true;
                DescubrirTodasLasMinas();
            }
            else
            {
                Campo[f, c] |= Estado.Open;
                CeldasCerradas--;
                if (ObtenerMinasAdyacentes(f, c) == 0)
                    DescubrirAdyacentes(f, c);
            }
        }

        private void DescubrirTodasLasMinas()
        {
            for (int f = 0; f < Filas; f++)
                for (int c = 0; c < Cols; c++)
                    if (IsSet(f, c, Estado.HasMine))
                        Campo[f, c] |= (Estado.Open | Estado.Boom);
        }

        public bool IsSet(int f, int c, Estado e)
        {
            return (Campo[f, c] & e) != 0;
        }

        internal void MarcarPosicion(int f, int c)
        {
            if (IsSet(f, c, Estado.Open))
                return;
            Campo[f, c] ^= Estado.HasFlag;
        }
    }
}
