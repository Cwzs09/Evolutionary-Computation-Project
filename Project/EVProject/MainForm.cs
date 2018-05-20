using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace EVProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        static int scale;
        private Board1 board1;

        private void updateProgress(int progress)
        {

            progressBar1.Value = progress;

            int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) /
            (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
            using (Graphics gr = progressBar1.CreateGraphics())
            {
                gr.DrawString(percent.ToString() + "%",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }
        }

        private List<Chromosome> GetInitialPopulation(int population)
        {
            List<Chromosome> initPop = new List<Chromosome>();
            GeneticAlgo RandomGen = new GeneticAlgo(scale);
            for (int i = 0; i < population; i++)
            {
                int[] geneScale = new int[scale];
                for (int g = 0; g < geneScale.Length; g++)
                {
                    geneScale[g] = g;
                }
                List<int> genes = new List<int>(geneScale);/*Board boyutuna göre for ile oluşturulcak*/
                Chromosome chromosome = new Chromosome();
                chromosome.genes = new int[scale];/*boyutun sayısına göre dizi dinamik olcak*/
                for (int j = 0; j < scale; j++)/*boyuta göre dinamikleştirilcek*/
                {
                    int geneIndex = (int)(RandomGen.GetRandomVal(0, genes.Count - 1) + 0.5);
                    chromosome.genes[j] = genes[geneIndex];
                    genes.RemoveAt(geneIndex);
                }

                initPop.Add(chromosome);
            }
            return initPop;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string crossMethod = "2";
            string mutaMethod = "2";
            try
            {
                crossMethod = cb_cross.SelectedItem.ToString();
            }
            catch (Exception)
            {
                
            }
            try
            {
                mutaMethod = cb_mutation.SelectedItem.ToString();
            }
            catch (Exception)
            {

            }

            scale = Convert.ToInt16(txtScale.Text);
            this.Controls.RemoveByKey("board1");
            this.board1 = new EVProject.Board1(scale);
            this.board1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.board1.Location = new System.Drawing.Point(350, 34);
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(467, 465);
            this.board1.TabIndex = 4;
            this.Controls.Add(this.board1);
            GeneticAlgo geneticAlgo = new GeneticAlgo(scale);
            List<Chromosome> initPopulation = GetInitialPopulation((int)txtPop.Value);
            if (chkPorgress.Checked)
                geneticAlgo.progress += new Progress(updateProgress);
            progressBar1.Maximum = (int)txtGen.Value;
            progressBar1.Value = 0;
            geneticAlgo.DoMating(ref initPopulation, (int)txtGen.Value, (double)txtCrosProb.Value, (double)txtMutProb.Value, crossMethod,mutaMethod);

            dgResults.Rows.Clear();
            for (int i = 0; i < initPopulation.Count - 1; i++)
            {
                String sol = "| ";
                for (int j = 0; j < scale; j++)
                {
                    sol = sol + initPopulation[i].genes[j] + " | ";
                }
                dgResults.Rows.Add(new Object[] { sol, initPopulation[i].fitness });

            }
            this.Controls.RemoveByKey("board1");
            this.board1 = new EVProject.Board1(scale);
            this.board1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.board1.Location = new System.Drawing.Point(350, 34);
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(467, 465);
            this.board1.TabIndex = 4;
            this.Controls.Add(this.board1);
            board1.Genes = initPopulation[0].genes;
        }
    }
}
