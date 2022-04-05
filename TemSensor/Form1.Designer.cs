namespace TemSensor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnStartPreHeat = new System.Windows.Forms.Button();
            this.tempTimer = new System.Windows.Forms.Timer(this.components);
            this.prgBarPreHeat = new System.Windows.Forms.ProgressBar();
            this.lblPreHeatStatus = new System.Windows.Forms.Label();
            this.lblMainTemp = new System.Windows.Forms.Label();
            this.lblTempType = new System.Windows.Forms.Label();
            this.lblTargetTemp = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label_bodyTemp = new System.Windows.Forms.Label();
            this.label_mattressTemp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartPreHeat
            // 
            this.btnStartPreHeat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartPreHeat.AutoSize = true;
            this.btnStartPreHeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPreHeat.Location = new System.Drawing.Point(0, 0);
            this.btnStartPreHeat.Name = "btnStartPreHeat";
            this.btnStartPreHeat.Size = new System.Drawing.Size(273, 54);
            this.btnStartPreHeat.TabIndex = 0;
            this.btnStartPreHeat.Text = "Start Pre-Heat";
            this.btnStartPreHeat.UseVisualStyleBackColor = true;
            this.btnStartPreHeat.Click += new System.EventHandler(this.btnStartPreHeat_Click);
            // 
            // tempTimer
            // 
            this.tempTimer.Interval = 500;
            this.tempTimer.Tick += new System.EventHandler(this.tempTimer_Tick);
            // 
            // prgBarPreHeat
            // 
            this.prgBarPreHeat.Location = new System.Drawing.Point(399, 92);
            this.prgBarPreHeat.Maximum = 37;
            this.prgBarPreHeat.Name = "prgBarPreHeat";
            this.prgBarPreHeat.Size = new System.Drawing.Size(275, 37);
            this.prgBarPreHeat.TabIndex = 1;
            this.prgBarPreHeat.Value = 37;
            this.prgBarPreHeat.Visible = false;
            // 
            // lblPreHeatStatus
            // 
            this.lblPreHeatStatus.AutoSize = true;
            this.lblPreHeatStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreHeatStatus.Location = new System.Drawing.Point(110, 92);
            this.lblPreHeatStatus.Name = "lblPreHeatStatus";
            this.lblPreHeatStatus.Size = new System.Drawing.Size(323, 37);
            this.lblPreHeatStatus.TabIndex = 2;
            this.lblPreHeatStatus.Text = "PRE-HEAT-STATUS:";
            this.lblPreHeatStatus.Visible = false;
            this.lblPreHeatStatus.Click += new System.EventHandler(this.lblPreHeatStatus_Click);
            // 
            // lblMainTemp
            // 
            this.lblMainTemp.AutoSize = true;
            this.lblMainTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTemp.Location = new System.Drawing.Point(226, 230);
            this.lblMainTemp.Name = "lblMainTemp";
            this.lblMainTemp.Size = new System.Drawing.Size(193, 91);
            this.lblMainTemp.TabIndex = 3;
            this.lblMainTemp.Text = "38.7";
            this.lblMainTemp.Visible = false;
            // 
            // lblTempType
            // 
            this.lblTempType.AutoSize = true;
            this.lblTempType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempType.Location = new System.Drawing.Point(193, 172);
            this.lblTempType.Name = "lblTempType";
            this.lblTempType.Size = new System.Drawing.Size(360, 46);
            this.lblTempType.TabIndex = 6;
            this.lblTempType.Text = "MATTRESS TEMP";
            this.lblTempType.Visible = false;
            // 
            // lblTargetTemp
            // 
            this.lblTargetTemp.AutoSize = true;
            this.lblTargetTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetTemp.Location = new System.Drawing.Point(205, 349);
            this.lblTargetTemp.Name = "lblTargetTemp";
            this.lblTargetTemp.Size = new System.Drawing.Size(210, 37);
            this.lblTargetTemp.TabIndex = 7;
            this.lblTargetTemp.Text = "Target Temp:";
            this.lblTargetTemp.Visible = false;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(411, 349);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(53, 37);
            this.lblTarget.TabIndex = 8;
            this.lblTarget.Text = "37";
            this.lblTarget.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TemSensor.Properties.Resources.Red_icon;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0, 10, 3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 66);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TemSensor.Properties.Resources.IEC5009_Standby_Symbol_svg;
            this.pictureBox1.Location = new System.Drawing.Point(704, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 10, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 66);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label_bodyTemp
            // 
            this.label_bodyTemp.AutoSize = true;
            this.label_bodyTemp.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label_bodyTemp.Location = new System.Drawing.Point(111, 153);
            this.label_bodyTemp.Name = "label_bodyTemp";
            this.label_bodyTemp.Size = new System.Drawing.Size(563, 65);
            this.label_bodyTemp.TabIndex = 10;
            this.label_bodyTemp.Text = "Body Temperature = ... °C";
            // 
            // label_mattressTemp
            // 
            this.label_mattressTemp.AutoSize = true;
            this.label_mattressTemp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label_mattressTemp.Location = new System.Drawing.Point(169, 245);
            this.label_mattressTemp.Name = "label_mattressTemp";
            this.label_mattressTemp.Size = new System.Drawing.Size(433, 45);
            this.label_mattressTemp.TabIndex = 11;
            this.label_mattressTemp.Text = "Mattress Temperature = ... °C";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 409);
            this.Controls.Add(this.label_mattressTemp);
            this.Controls.Add(this.label_bodyTemp);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblTargetTemp);
            this.Controls.Add(this.lblTempType);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMainTemp);
            this.Controls.Add(this.lblPreHeatStatus);
            this.Controls.Add(this.prgBarPreHeat);
            this.Controls.Add(this.btnStartPreHeat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartPreHeat;
        private System.Windows.Forms.Timer tempTimer;
        private System.Windows.Forms.ProgressBar prgBarPreHeat;
        private System.Windows.Forms.Label lblPreHeatStatus;
        private System.Windows.Forms.Label lblMainTemp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTempType;
        private System.Windows.Forms.Label lblTargetTemp;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label_bodyTemp;
        private System.Windows.Forms.Label label_mattressTemp;
    }
}

