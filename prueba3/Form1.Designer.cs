namespace prueba3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_boardid = new System.Windows.Forms.TextBox();
            this.txt_mpp = new System.Windows.Forms.TextBox();
            this.txt_reqtitle = new System.Windows.Forms.TextBox();
            this.txt_reqdescription = new System.Windows.Forms.TextBox();
            this.txt_reqresp = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(21, 353);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(282, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Actualizar proyecto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(21, 317);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(282, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Inicializar proyecto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Board ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre MPP";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Título";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Descripción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Responsable";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txt_boardid
            // 
            this.txt_boardid.Location = new System.Drawing.Point(117, 96);
            this.txt_boardid.Name = "txt_boardid";
            this.txt_boardid.Size = new System.Drawing.Size(185, 20);
            this.txt_boardid.TabIndex = 7;
            // 
            // txt_mpp
            // 
            this.txt_mpp.Location = new System.Drawing.Point(117, 122);
            this.txt_mpp.Name = "txt_mpp";
            this.txt_mpp.Size = new System.Drawing.Size(185, 20);
            this.txt_mpp.TabIndex = 8;
            // 
            // txt_reqtitle
            // 
            this.txt_reqtitle.Location = new System.Drawing.Point(117, 148);
            this.txt_reqtitle.Name = "txt_reqtitle";
            this.txt_reqtitle.Size = new System.Drawing.Size(185, 20);
            this.txt_reqtitle.TabIndex = 9;
            this.txt_reqtitle.TextChanged += new System.EventHandler(this.txt_reqtitle_TextChanged);
            // 
            // txt_reqdescription
            // 
            this.txt_reqdescription.Location = new System.Drawing.Point(117, 174);
            this.txt_reqdescription.Name = "txt_reqdescription";
            this.txt_reqdescription.Size = new System.Drawing.Size(185, 20);
            this.txt_reqdescription.TabIndex = 10;
            // 
            // txt_reqresp
            // 
            this.txt_reqresp.Location = new System.Drawing.Point(117, 200);
            this.txt_reqresp.Name = "txt_reqresp";
            this.txt_reqresp.Size = new System.Drawing.Size(185, 20);
            this.txt_reqresp.TabIndex = 11;
            this.txt_reqresp.TextChanged += new System.EventHandler(this.txt_reqresp_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(282, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Crear Request";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(21, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 2);
            this.label6.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(83, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 35);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 400);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txt_reqresp);
            this.Controls.Add(this.txt_reqdescription);
            this.Controls.Add(this.txt_reqtitle);
            this.Controls.Add(this.txt_mpp);
            this.Controls.Add(this.txt_boardid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Gestor de Projects";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_boardid;
        private System.Windows.Forms.TextBox txt_mpp;
        private System.Windows.Forms.TextBox txt_reqtitle;
        private System.Windows.Forms.TextBox txt_reqdescription;
        private System.Windows.Forms.TextBox txt_reqresp;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

