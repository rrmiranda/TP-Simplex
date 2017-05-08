namespace Simplex
{
    partial class frmPrincipal
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
            this.rbtmax = new System.Windows.Forms.RadioButton();
            this.rbtmin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_editPR = new System.Windows.Forms.Button();
            this.btn_inserirPR = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtrest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnum = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_inserir4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_valorresultine = new System.Windows.Forms.TextBox();
            this.btn_inserir3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_valorine = new System.Windows.Forms.TextBox();
            this.btn_inserir2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_valorr = new System.Windows.Forms.TextBox();
            this.btn_inserir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_valorp = new System.Windows.Forms.TextBox();
            this.btn_calcular = new System.Windows.Forms.Button();
            this.txtfase = new System.Windows.Forms.TextBox();
            this.txtresult2 = new System.Windows.Forms.TextBox();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.txtresultvalores = new System.Windows.Forms.TextBox();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtmax
            // 
            this.rbtmax.AutoSize = true;
            this.rbtmax.Location = new System.Drawing.Point(27, 19);
            this.rbtmax.Name = "rbtmax";
            this.rbtmax.Size = new System.Drawing.Size(48, 17);
            this.rbtmax.TabIndex = 0;
            this.rbtmax.TabStop = true;
            this.rbtmax.Text = "MAX";
            this.rbtmax.UseVisualStyleBackColor = true;
            this.rbtmax.CheckedChanged += new System.EventHandler(this.rbtmax_CheckedChanged);
            // 
            // rbtmin
            // 
            this.rbtmin.AutoSize = true;
            this.rbtmin.Location = new System.Drawing.Point(100, 19);
            this.rbtmin.Name = "rbtmin";
            this.rbtmin.Size = new System.Drawing.Size(45, 17);
            this.rbtmin.TabIndex = 1;
            this.rbtmin.TabStop = true;
            this.rbtmin.Text = "MIN";
            this.rbtmin.UseVisualStyleBackColor = true;
            this.rbtmin.CheckedChanged += new System.EventHandler(this.rbtmin_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtmax);
            this.groupBox1.Controls.Add(this.rbtmin);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_editPR);
            this.groupBox2.Controls.Add(this.btn_inserirPR);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtrest);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtnum);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 96);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nº de Produtos e Restrições";
            // 
            // btn_editPR
            // 
            this.btn_editPR.Location = new System.Drawing.Point(270, 47);
            this.btn_editPR.Name = "btn_editPR";
            this.btn_editPR.Size = new System.Drawing.Size(75, 23);
            this.btn_editPR.TabIndex = 7;
            this.btn_editPR.Text = "Editar";
            this.btn_editPR.UseVisualStyleBackColor = true;
            this.btn_editPR.Click += new System.EventHandler(this.btn_editPR_Click);
            // 
            // btn_inserirPR
            // 
            this.btn_inserirPR.Location = new System.Drawing.Point(270, 21);
            this.btn_inserirPR.Name = "btn_inserirPR";
            this.btn_inserirPR.Size = new System.Drawing.Size(75, 23);
            this.btn_inserirPR.TabIndex = 6;
            this.btn_inserirPR.Text = "OK";
            this.btn_inserirPR.UseVisualStyleBackColor = true;
            this.btn_inserirPR.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nº de restrições";
            // 
            // txtrest
            // 
            this.txtrest.Location = new System.Drawing.Point(164, 50);
            this.txtrest.Name = "txtrest";
            this.txtrest.Size = new System.Drawing.Size(54, 20);
            this.txtrest.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nº de produtos";
            // 
            // txtnum
            // 
            this.txtnum.Location = new System.Drawing.Point(164, 26);
            this.txtnum.Name = "txtnum";
            this.txtnum.Size = new System.Drawing.Size(54, 20);
            this.txtnum.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_inserir4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_valorresultine);
            this.groupBox3.Controls.Add(this.btn_inserir3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_valorine);
            this.groupBox3.Controls.Add(this.btn_inserir2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txt_valorr);
            this.groupBox3.Controls.Add(this.btn_inserir);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt_valorp);
            this.groupBox3.Location = new System.Drawing.Point(12, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(372, 141);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valor de Produtos e Restrições";
            // 
            // btn_inserir4
            // 
            this.btn_inserir4.Location = new System.Drawing.Point(270, 105);
            this.btn_inserir4.Name = "btn_inserir4";
            this.btn_inserir4.Size = new System.Drawing.Size(75, 23);
            this.btn_inserir4.TabIndex = 11;
            this.btn_inserir4.Text = "Inserir";
            this.btn_inserir4.UseVisualStyleBackColor = true;
            this.btn_inserir4.Click += new System.EventHandler(this.btn_inserir4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Valor Resultante ine";
            // 
            // txt_valorresultine
            // 
            this.txt_valorresultine.Location = new System.Drawing.Point(164, 105);
            this.txt_valorresultine.Name = "txt_valorresultine";
            this.txt_valorresultine.Size = new System.Drawing.Size(54, 20);
            this.txt_valorresultine.TabIndex = 9;
            // 
            // btn_inserir3
            // 
            this.btn_inserir3.Location = new System.Drawing.Point(270, 80);
            this.btn_inserir3.Name = "btn_inserir3";
            this.btn_inserir3.Size = new System.Drawing.Size(75, 23);
            this.btn_inserir3.TabIndex = 8;
            this.btn_inserir3.Text = "Inserir";
            this.btn_inserir3.UseVisualStyleBackColor = true;
            this.btn_inserir3.Click += new System.EventHandler(this.btn_inserir3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Valor Inequação";
            // 
            // txt_valorine
            // 
            this.txt_valorine.Location = new System.Drawing.Point(164, 80);
            this.txt_valorine.Name = "txt_valorine";
            this.txt_valorine.Size = new System.Drawing.Size(54, 20);
            this.txt_valorine.TabIndex = 6;
            // 
            // btn_inserir2
            // 
            this.btn_inserir2.Location = new System.Drawing.Point(270, 55);
            this.btn_inserir2.Name = "btn_inserir2";
            this.btn_inserir2.Size = new System.Drawing.Size(75, 23);
            this.btn_inserir2.TabIndex = 5;
            this.btn_inserir2.Text = "Inserir";
            this.btn_inserir2.UseVisualStyleBackColor = true;
            this.btn_inserir2.Click += new System.EventHandler(this.btn_inserir2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor Restrição";
            // 
            // txt_valorr
            // 
            this.txt_valorr.Location = new System.Drawing.Point(164, 55);
            this.txt_valorr.Name = "txt_valorr";
            this.txt_valorr.Size = new System.Drawing.Size(54, 20);
            this.txt_valorr.TabIndex = 3;
            // 
            // btn_inserir
            // 
            this.btn_inserir.Location = new System.Drawing.Point(270, 29);
            this.btn_inserir.Name = "btn_inserir";
            this.btn_inserir.Size = new System.Drawing.Size(75, 23);
            this.btn_inserir.TabIndex = 2;
            this.btn_inserir.Text = "Inserir";
            this.btn_inserir.UseVisualStyleBackColor = true;
            this.btn_inserir.Click += new System.EventHandler(this.btn_inserir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Valor Num";
            // 
            // txt_valorp
            // 
            this.txt_valorp.Location = new System.Drawing.Point(164, 29);
            this.txt_valorp.Name = "txt_valorp";
            this.txt_valorp.Size = new System.Drawing.Size(54, 20);
            this.txt_valorp.TabIndex = 0;
            // 
            // btn_calcular
            // 
            this.btn_calcular.Location = new System.Drawing.Point(309, 329);
            this.btn_calcular.Name = "btn_calcular";
            this.btn_calcular.Size = new System.Drawing.Size(75, 23);
            this.btn_calcular.TabIndex = 5;
            this.btn_calcular.Text = "Calcular";
            this.btn_calcular.UseVisualStyleBackColor = true;
            this.btn_calcular.Click += new System.EventHandler(this.btn_calcular_Click);
            // 
            // txtfase
            // 
            this.txtfase.Location = new System.Drawing.Point(400, 18);
            this.txtfase.Name = "txtfase";
            this.txtfase.Size = new System.Drawing.Size(271, 20);
            this.txtfase.TabIndex = 7;
            // 
            // txtresult2
            // 
            this.txtresult2.Location = new System.Drawing.Point(400, 77);
            this.txtresult2.Multiline = true;
            this.txtresult2.Name = "txtresult2";
            this.txtresult2.Size = new System.Drawing.Size(271, 67);
            this.txtresult2.TabIndex = 8;
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(400, 44);
            this.txtresult.Name = "txtresult";
            this.txtresult.Size = new System.Drawing.Size(271, 20);
            this.txtresult.TabIndex = 9;
            // 
            // txtresultvalores
            // 
            this.txtresultvalores.Location = new System.Drawing.Point(400, 156);
            this.txtresultvalores.Multiline = true;
            this.txtresultvalores.Name = "txtresultvalores";
            this.txtresultvalores.Size = new System.Drawing.Size(271, 67);
            this.txtresultvalores.TabIndex = 10;
            // 
            // btn_fechar
            // 
            this.btn_fechar.Location = new System.Drawing.Point(228, 329);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(75, 23);
            this.btn_fechar.TabIndex = 11;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 398);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.txtresultvalores);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.txtresult2);
            this.Controls.Add(this.txtfase);
            this.Controls.Add(this.btn_calcular);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrincipal";
            this.Text = "Simplex";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtmax;
        private System.Windows.Forms.RadioButton rbtmin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtrest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnum;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_inserir2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_valorr;
        private System.Windows.Forms.Button btn_inserir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_valorp;
        private System.Windows.Forms.Button btn_editPR;
        private System.Windows.Forms.Button btn_inserirPR;
        private System.Windows.Forms.Button btn_calcular;
        private System.Windows.Forms.Button btn_inserir3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_valorine;
        private System.Windows.Forms.Button btn_inserir4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_valorresultine;
        private System.Windows.Forms.TextBox txtfase;
        private System.Windows.Forms.TextBox txtresult2;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.TextBox txtresultvalores;
        private System.Windows.Forms.Button btn_fechar;
    }
}

