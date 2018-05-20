namespace EVProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtScale = new System.Windows.Forms.NumericUpDown();
            this.chkPorgress = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ColFit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.txtMutProb = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCrosProb = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGen = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPop = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cb_cross = new System.Windows.Forms.ComboBox();
            this.cb_mutation = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMutProb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrosProb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPop)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(224, 14);
            this.txtScale.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.txtScale.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(120, 20);
            this.txtScale.TabIndex = 24;
            this.txtScale.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // chkPorgress
            // 
            this.chkPorgress.AutoSize = true;
            this.chkPorgress.Location = new System.Drawing.Point(15, 150);
            this.chkPorgress.Name = "chkPorgress";
            this.chkPorgress.Size = new System.Drawing.Size(15, 14);
            this.chkPorgress.TabIndex = 22;
            this.chkPorgress.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(245, 24);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 21;
            // 
            // ColFit
            // 
            this.ColFit.FillWeight = 50F;
            this.ColFit.HeaderText = "Fitness";
            this.ColFit.Name = "ColFit";
            this.ColFit.Width = 50;
            // 
            // colSol
            // 
            this.colSol.FillWeight = 235F;
            this.colSol.HeaderText = "Solution";
            this.colSol.Name = "colSol";
            this.colSol.Width = 235;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Board Scale";
            // 
            // dgResults
            // 
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSol,
            this.ColFit});
            this.dgResults.Location = new System.Drawing.Point(12, 174);
            this.dgResults.Name = "dgResults";
            this.dgResults.RowHeadersVisible = false;
            this.dgResults.Size = new System.Drawing.Size(332, 347);
            this.dgResults.TabIndex = 20;
            // 
            // txtMutProb
            // 
            this.txtMutProb.DecimalPlaces = 2;
            this.txtMutProb.Location = new System.Drawing.Point(224, 118);
            this.txtMutProb.Name = "txtMutProb";
            this.txtMutProb.Size = new System.Drawing.Size(120, 20);
            this.txtMutProb.TabIndex = 16;
            this.txtMutProb.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mutation Probability";
            // 
            // txtCrosProb
            // 
            this.txtCrosProb.DecimalPlaces = 2;
            this.txtCrosProb.Location = new System.Drawing.Point(224, 92);
            this.txtCrosProb.Name = "txtCrosProb";
            this.txtCrosProb.Size = new System.Drawing.Size(120, 20);
            this.txtCrosProb.TabIndex = 17;
            this.txtCrosProb.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Crossover Probability";
            // 
            // txtGen
            // 
            this.txtGen.Location = new System.Drawing.Point(224, 66);
            this.txtGen.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtGen.Name = "txtGen";
            this.txtGen.Size = new System.Drawing.Size(120, 20);
            this.txtGen.TabIndex = 18;
            this.txtGen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Generations";
            // 
            // txtPop
            // 
            this.txtPop.Location = new System.Drawing.Point(224, 40);
            this.txtPop.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtPop.Name = "txtPop";
            this.txtPop.Size = new System.Drawing.Size(120, 20);
            this.txtPop.TabIndex = 19;
            this.txtPop.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(347, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "The Best Solution";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Population Size";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(284, 144);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 24);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cb_cross
            // 
            this.cb_cross.FormattingEnabled = true;
            this.cb_cross.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_cross.Location = new System.Drawing.Point(140, 91);
            this.cb_cross.Name = "cb_cross";
            this.cb_cross.Size = new System.Drawing.Size(78, 21);
            this.cb_cross.TabIndex = 25;
            this.cb_cross.Text = "Methods";
            // 
            // cb_mutation
            // 
            this.cb_mutation.FormattingEnabled = true;
            this.cb_mutation.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_mutation.Location = new System.Drawing.Point(140, 118);
            this.cb_mutation.Name = "cb_mutation";
            this.cb_mutation.Size = new System.Drawing.Size(78, 21);
            this.cb_mutation.TabIndex = 26;
            this.cb_mutation.Text = "Methods";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 546);
            this.Controls.Add(this.cb_mutation);
            this.Controls.Add(this.cb_cross);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.chkPorgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.txtMutProb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCrosProb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.txtScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMutProb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrosProb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtScale;
        private System.Windows.Forms.CheckBox chkPorgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.NumericUpDown txtMutProb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtCrosProb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtGen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtPop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cb_cross;
        private System.Windows.Forms.ComboBox cb_mutation;
    }
}

