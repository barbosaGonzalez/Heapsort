using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heapsort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] vector;
        int totalElementos;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si es Cualquier otro Digito
            if (Char.IsDigit(e.KeyChar))  //Entra
            {
                e.Handled = false;    // indica que el evento de KeyPress no se controló.
            }
            //Si es Espacio
            else if (e.KeyChar == 255)  //Entra
            {
                e.Handled = false;    // indica que el evento de KeyPress no se controló.
            }
            //Si es Cualquier tecla de Control
            else if (Char.IsControl(e.KeyChar))  //Entra
            {
                e.Handled = false;    // indica que el evento de KeyPress no se controló.
            }
            //Si es Separador
            else if (Char.IsSeparator(e.KeyChar))  //Entra
            {
                e.Handled = false;    // indica que el evento de KeyPress no se controló.
            }
            //Si es Número
            else  //Entra
            {
                e.Handled = true;    // indica que el evento de KeyPress si se controló.
            }
            //Si es la Tecla ENTER
            if (e.KeyChar == (char)13)  //Entra
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalElementos = listBox1.Items.Count;
            vector = new int[totalElementos];
            for (int i = 0; i < listBox1.Items.Count; i++)
                vector[i] = Convert.ToInt32(listBox1.Items[i]);
            
            int temp; //Necesaria para el intercambio
            //Ordena un vector de elementos
            for (int i = (totalElementos / 2) - 1; i >= 0; i--) //Desde la mitad menos 1, mientras sea menor que 0, se resta 1
                siftDown(i, totalElementos);

            //Ordena el vector9/2

            for (int i = totalElementos - 1; i >= 1; i--)
            {
                temp = vector[0];
                vector[0] = vector[i];
                vector[i] = temp;
                siftDown(0, i - 1);
            }

            //Imprimir vector ordenado
            for (int i = 0; i < totalElementos; i++)
                listBox2.Items.Add(vector[i]);
        }

        public void siftDown(int root, int totalElementos)  //Metodo necesario para ordenacion descendente
        {
            bool hecho = false;
            int maxChild;
            int temporal;

            while ((root * 2 <= totalElementos) && (!hecho))
            {
                if (root * 2 == totalElementos)
                    maxChild = root * 2;
                else if (vector[root * 2] > vector[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;
                if (vector[root] < vector[maxChild])
                {
                    temporal = vector[root];
                    vector[root] = vector[maxChild];
                    vector[maxChild] = temporal;
                    root = maxChild;
                }
                else
                    hecho = true;
            }
        }
    }
}
