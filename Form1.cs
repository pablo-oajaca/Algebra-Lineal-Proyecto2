using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algebra_Lineal_Proyecto2
{
    public partial class Form1 : Form
    {
        List<Coordenada> coordenadas = new List<Coordenada>();
        private float y1, x2, y2, delta = 0.1f;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void leer()
        {
            FileStream stream = new FileStream(@"..\..\coordenadas.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while(reader.Peek() > -1)
            {
                Coordenada coordenada = new Coordenada();
                //coordenada.Angulo = Convert.ToInt32(reader.ReadLine());
                //coordenada.Tipo = Convert.ToString(reader.ReadLine());
                //coordenada.X = Convert.ToInt32(reader.ReadLine());
                //coordenada.Y = Convert.ToInt32(reader.ReadLine());

                coordenadas.Add(coordenada);
            }
            reader.Close();

        }
 
        private void Guardar()
        {
            FileStream stream = new FileStream(@"..\..\coordenadas.txt", FileMode.Open, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var coordenada in coordenadas)
            {
                write.WriteLine(coordenada.Tipo);
                write.WriteLine(coordenada.Angulo);
                write.WriteLine(coordenada.X);
                write.WriteLine(coordenada.Y);
            }
            write.Close();
        }
        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            Coordenada coordenada = new Coordenada();

            coordenada.Tipo = comboBox1.SelectedItem.ToString();
            coordenada.Angulo = Convert.ToInt32(trackBarAngulo.Value);
            coordenada.X = Convert.ToInt32(trackBarX.Value);
            coordenada.Y = Convert.ToInt32(trackBarY.Value);


            coordenadas.Add(coordenada);

            Guardar();




        }
        private float fx(float x)
        {
            float y = (float)Math.Sin(x);

            return y*-1*10;
        }

        private void Pintar_origen()
        {
            float xm, ym;
            xm = pictureBox1.Width / 2;
            ym = pictureBox1.Height / 2;

            

            Graphics g = pictureBox1.CreateGraphics();

            g.TranslateTransform(xm, ym);
            g.ScaleTransform(2, 2);

            g.DrawLine(Pens.Black, -xm, 0, xm, 0);
            g.DrawLine(Pens.Black, 0, -ym, 0 , ym);

            float x1 = -xm;
            while (x1 < xm)
            {
                y1 = fx(x1);
                x2 = x1 + delta;
                y2 = fx(x2);
                g.DrawLine(Pens.Black, x1, y1, x2, y2);
                x1 = x2;

            }
      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Pintar_origen();
        }

        private void buttonGraficar_Click(object sender, EventArgs e)
        {
            Pintar_origen();
            leer();
        }
    }
}
