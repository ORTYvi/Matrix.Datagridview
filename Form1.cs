using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 5;
            dataGridView1.ColumnCount = 5;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] S = new double[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    S[i, j] = dataGridView1.Rows[i].Cells[j].Value == null ||
                                     dataGridView1.Rows[i].Cells[j].Value is DBNull ? double.NaN : Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);

            int length1 = S.GetLength(0);
            int length2 = S.GetLength(1);
            List<int> ls1 = new List<int>();
            List<int> ls2 = new List<int>();

           
    

            for (int i = 0; i < length1; ++i)
            {
            richTextBox2.SelectionFont = new Font("Tahoma", 12, FontStyle.Bold);

                bool b = false;
                for (int j = 0; j < length2; ++j)
                {
                    if (S[i, j] >= 0)
                        richTextBox2.AppendText("   " + S[i, j]);
                    else richTextBox2.AppendText("   " + S[i, j]);
                    if (S[i, j] != 0) b = true;
                }
                if (!b) ls1.Add(i);
                richTextBox2.AppendText("\n");
            }

          

            //  находим нулевые столбцы
            for (int i = 0; i < length2; ++i)
            {
                bool b = false;
                for (int j = 0; j < length1; ++j)
                {

                    if (S[j, i] != 0) b = true;
                }
                if (!b) ls2.Add(i);
           if (!ls1.Contains(i))
                    richTextBox2.AppendText("\n");
            }

            bool B = false; int? Ind = null;
          
            for (int i = 0; i < length1; ++i)
            {
            richTextBox1.SelectionFont = new Font("Tahoma", 12, FontStyle.Bold);
                if (!ls1.Contains(i))
                {
                    for (int j = 0; j < length2; ++j)
                    {
                        if (!ls2.Contains(j))
                        {
                            if (S[i, j] >= 0)
                            {
                                if (!B)
                                {
                                    Ind = i;
                                    B = true;
                                }
                                richTextBox1.AppendText("   " + S[i, j]);
                            }
                            else richTextBox1.AppendText("   " + S[i, j]);
                        }

                    }

                }
                if (!ls1.Contains(i))
                    richTextBox1.AppendText("\n");
            }
            textBox1.Text += Ind + 1;
        }

       
    }
    }


