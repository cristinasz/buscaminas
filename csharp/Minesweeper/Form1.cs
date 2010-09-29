using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private Tablero t;
        public Form1()
        {
            InitializeComponent();
        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            t = new Tablero(10, 10, 10);
            this.pTablero.Controls.Clear();
            for (int f = 0; f < t.Filas; f++)
                for (int c = 0; c < t.Cols; c++)
                {
                    CheckBox b = new CheckBox();
                    b.Appearance = Appearance.Button;
                    b.Size = new Size(25, 25);
                    b.Location = new Point(c * 25, f * 25);
                    b.Tag = new Point(c, f);
                    b.CheckedChanged += new EventHandler(b_CheckedChanged);
                    b.MouseUp += new MouseEventHandler(b_MouseUp);
                    this.pTablero.Controls.Add(b);
                }
            pTablero.Enabled = true;
        }

        void b_CheckedChanged(object sender, EventArgs e)
        {
            Point p = (Point)((sender as Control).Tag);
            t.Descubrir(p.Y, p.X);
            ActualizarUI();
        }

        void ActualizarUI()
        {
            Color[] colores = {Color.Transparent, Color.Blue, Color.Purple, Color.Red, Color.Purple, Color.Green, 
                Color.Tan, Color.Tomato, Color.SpringGreen};
            for (int f = 0; f < t.Filas; f++)
            {
                for (int c = 0; c < t.Cols; c++)
                {
                    CheckBox b = this.pTablero.Controls[f*t.Filas + c] as CheckBox;
                    b.BackColor = t.IsSet(f, c, Estado.Boom) ? Color.Red :
                        t.IsSet(f, c, Estado.HasFlag) ? Color.Lime : 
                        t.IsSet(f, c, Estado.Open) ? Color.Silver :
                        t.HaGanado ? Color.Lime :
                        SystemColors.Control;
                    b.Checked = t.IsSet(f, c, Estado.Open) && !t.IsSet(f, c, Estado.HasFlag);

                    if (t.IsSet(f, c, Estado.Open))
                    {
                        int n = t.ObtenerMinasAdyacentes(f, c);
                        b.Text = n <= 0 ? "" : n.ToString();
                        b.ForeColor = colores[n];
                    }
                }
            }
            pTablero.Enabled = !t.GameOver && t.CeldasCerradas > t.Minas;
        }

        private void b_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = (Point)(sender as Control).Tag;
                t.MarcarPosicion(p.Y, p.X);
                ActualizarUI();
            }
        }
    }
}
