namespace hospital_project
{
    partial class Form2
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
            this.buttonPatient = new System.Windows.Forms.Button();
            this.buttonAdmin = new System.Windows.Forms.Button();
            this.buttonDoctor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPatient
            // 
            this.buttonPatient.Image = global::hospital_project.Properties.Resources.Copilot_20260122_003925;
            this.buttonPatient.Location = new System.Drawing.Point(536, 320);
            this.buttonPatient.Name = "buttonPatient";
            this.buttonPatient.Size = new System.Drawing.Size(127, 114);
            this.buttonPatient.TabIndex = 3;
            this.buttonPatient.UseVisualStyleBackColor = true;
            // 
            // buttonAdmin
            // 
            this.buttonAdmin.AutoSize = true;
            this.buttonAdmin.BackgroundImage = global::hospital_project.Properties.Resources._101;
            this.buttonAdmin.Location = new System.Drawing.Point(407, 174);
            this.buttonAdmin.Name = "buttonAdmin";
            this.buttonAdmin.Size = new System.Drawing.Size(127, 114);
            this.buttonAdmin.TabIndex = 2;
            this.buttonAdmin.UseVisualStyleBackColor = true;
            // 
            // buttonDoctor
            // 
            this.buttonDoctor.Image = global::hospital_project.Properties.Resources.Copilot_20260122_004546;
            this.buttonDoctor.Location = new System.Drawing.Point(268, 320);
            this.buttonDoctor.Name = "buttonDoctor";
            this.buttonDoctor.Size = new System.Drawing.Size(127, 114);
            this.buttonDoctor.TabIndex = 1;
            this.buttonDoctor.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::hospital_project.Properties.Resources.Copilot_20260122_002846;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(932, 555);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(761, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 64);
            this.button1.TabIndex = 4;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 553);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPatient);
            this.Controls.Add(this.buttonAdmin);
            this.Controls.Add(this.buttonDoctor);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "loginOptions ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDoctor;
        private System.Windows.Forms.Button buttonAdmin;
        private System.Windows.Forms.Button buttonPatient;
        private System.Windows.Forms.Button button1;
    }
}