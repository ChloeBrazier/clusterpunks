namespace EnemyEditor
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
            this.Title = new System.Windows.Forms.Label();
            this.Subtitle = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CooldownTip = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.CooldownLabel = new System.Windows.Forms.Label();
            this.SpeedTip = new System.Windows.Forms.Label();
            this.DamageTip = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.NameTip = new System.Windows.Forms.Label();
            this.HealthTip = new System.Windows.Forms.Label();
            this.ImageLoader = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.ImageDisplayText = new System.Windows.Forms.Label();
            this.ImageDisplay = new System.Windows.Forms.PictureBox();
            this.Reminder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.DeepPink;
            this.Title.Location = new System.Drawing.Point(-5, -3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(848, 108);
            this.Title.TabIndex = 0;
            this.Title.Text = "CLUSTER PUNKS";
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.ForeColor = System.Drawing.SystemColors.Control;
            this.Subtitle.Location = new System.Drawing.Point(257, 90);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(312, 55);
            this.Subtitle.TabIndex = 1;
            this.Subtitle.Text = "Enemy Editor";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.NameLabel.Location = new System.Drawing.Point(9, 162);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(136, 24);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Enemy Name: ";
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.HealthLabel.Location = new System.Drawing.Point(9, 195);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(139, 24);
            this.HealthLabel.TabIndex = 3;
            this.HealthLabel.Text = "Enemy Health: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CooldownTip);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.CooldownLabel);
            this.groupBox1.Controls.Add(this.SpeedTip);
            this.groupBox1.Controls.Add(this.DamageTip);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.SpeedLabel);
            this.groupBox1.Controls.Add(this.DamageLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(3, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 133);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attack Stats";
            // 
            // CooldownTip
            // 
            this.CooldownTip.AutoSize = true;
            this.CooldownTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CooldownTip.ForeColor = System.Drawing.SystemColors.Control;
            this.CooldownTip.Location = new System.Drawing.Point(406, 98);
            this.CooldownTip.Name = "CooldownTip";
            this.CooldownTip.Size = new System.Drawing.Size(403, 18);
            this.CooldownTip.TabIndex = 13;
            this.CooldownTip.Text = "(Cooldown should be an int between 1-10. Higher is slower.)";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(148, 95);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(258, 24);
            this.textBox5.TabIndex = 12;
            // 
            // CooldownLabel
            // 
            this.CooldownLabel.AutoSize = true;
            this.CooldownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CooldownLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CooldownLabel.Location = new System.Drawing.Point(6, 95);
            this.CooldownLabel.Name = "CooldownLabel";
            this.CooldownLabel.Size = new System.Drawing.Size(106, 24);
            this.CooldownLabel.TabIndex = 11;
            this.CooldownLabel.Text = "Cooldown: ";
            // 
            // SpeedTip
            // 
            this.SpeedTip.AutoSize = true;
            this.SpeedTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedTip.ForeColor = System.Drawing.SystemColors.Control;
            this.SpeedTip.Location = new System.Drawing.Point(406, 65);
            this.SpeedTip.Name = "SpeedTip";
            this.SpeedTip.Size = new System.Drawing.Size(422, 18);
            this.SpeedTip.TabIndex = 10;
            this.SpeedTip.Text = "(Attack Speed should be an int between 1-10. Higher is slower.)";
            // 
            // DamageTip
            // 
            this.DamageTip.AutoSize = true;
            this.DamageTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageTip.ForeColor = System.Drawing.SystemColors.Control;
            this.DamageTip.Location = new System.Drawing.Point(406, 32);
            this.DamageTip.Name = "DamageTip";
            this.DamageTip.Size = new System.Drawing.Size(318, 18);
            this.DamageTip.TabIndex = 9;
            this.DamageTip.Text = "(Attack Damage should be an int between 1-10)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(148, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(258, 24);
            this.textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(148, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(258, 24);
            this.textBox3.TabIndex = 7;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.SpeedLabel.Location = new System.Drawing.Point(6, 62);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(131, 24);
            this.SpeedLabel.TabIndex = 5;
            this.SpeedLabel.Text = "Attack Speed: ";
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.DamageLabel.Location = new System.Drawing.Point(6, 29);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(136, 24);
            this.DamageLabel.TabIndex = 4;
            this.DamageLabel.Text = "Attack Damage";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(151, 195);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(258, 20);
            this.textBox2.TabIndex = 6;
            // 
            // NameTip
            // 
            this.NameTip.AutoSize = true;
            this.NameTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTip.ForeColor = System.Drawing.SystemColors.Control;
            this.NameTip.Location = new System.Drawing.Point(415, 166);
            this.NameTip.Name = "NameTip";
            this.NameTip.Size = new System.Drawing.Size(337, 18);
            this.NameTip.TabIndex = 7;
            this.NameTip.Text = "(Name the save file the same as the enemy name)";
            // 
            // HealthTip
            // 
            this.HealthTip.AutoSize = true;
            this.HealthTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthTip.ForeColor = System.Drawing.SystemColors.Control;
            this.HealthTip.Location = new System.Drawing.Point(415, 195);
            this.HealthTip.Name = "HealthTip";
            this.HealthTip.Size = new System.Drawing.Size(344, 18);
            this.HealthTip.TabIndex = 8;
            this.HealthTip.Text = "(Typical Enemy Health is 2-3 digits, in intervals of 5)";
            // 
            // ImageLoader
            // 
            this.ImageLoader.BackColor = System.Drawing.Color.HotPink;
            this.ImageLoader.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageLoader.Location = new System.Drawing.Point(12, 392);
            this.ImageLoader.Name = "ImageLoader";
            this.ImageLoader.Size = new System.Drawing.Size(397, 68);
            this.ImageLoader.TabIndex = 9;
            this.ImageLoader.Text = "Select Sprite";
            this.ImageLoader.UseVisualStyleBackColor = false;
            this.ImageLoader.Click += new System.EventHandler(this.ImageLoader_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.BackColor = System.Drawing.Color.HotPink;
            this.LoadFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFileButton.Location = new System.Drawing.Point(12, 478);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(397, 68);
            this.LoadFileButton.TabIndex = 10;
            this.LoadFileButton.Text = "Load File";
            this.LoadFileButton.UseVisualStyleBackColor = false;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.BackColor = System.Drawing.Color.HotPink;
            this.SaveFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveFileButton.Location = new System.Drawing.Point(13, 568);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(397, 68);
            this.SaveFileButton.TabIndex = 11;
            this.SaveFileButton.Text = "Save Current File";
            this.SaveFileButton.UseVisualStyleBackColor = false;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // ImageDisplayText
            // 
            this.ImageDisplayText.AutoSize = true;
            this.ImageDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageDisplayText.ForeColor = System.Drawing.SystemColors.Control;
            this.ImageDisplayText.Location = new System.Drawing.Point(425, 397);
            this.ImageDisplayText.Name = "ImageDisplayText";
            this.ImageDisplayText.Size = new System.Drawing.Size(109, 18);
            this.ImageDisplayText.TabIndex = 12;
            this.ImageDisplayText.Text = "Current Image: ";
            // 
            // ImageDisplay
            // 
            this.ImageDisplay.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImageDisplay.Location = new System.Drawing.Point(428, 429);
            this.ImageDisplay.Name = "ImageDisplay";
            this.ImageDisplay.Size = new System.Drawing.Size(395, 207);
            this.ImageDisplay.TabIndex = 13;
            this.ImageDisplay.TabStop = false;
            // 
            // Reminder
            // 
            this.Reminder.AutoSize = true;
            this.Reminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reminder.ForeColor = System.Drawing.SystemColors.Control;
            this.Reminder.Location = new System.Drawing.Point(177, 651);
            this.Reminder.Name = "Reminder";
            this.Reminder.Size = new System.Drawing.Size(487, 18);
            this.Reminder.TabIndex = 14;
            this.Reminder.Text = "Remember! When you save your file, save it to the game\'s content folder,";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(209, 669);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "and be sure to add the sprite you used to the content manager.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(835, 693);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reminder);
            this.Controls.Add(this.ImageDisplay);
            this.Controls.Add(this.ImageDisplayText);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.ImageLoader);
            this.Controls.Add(this.HealthTip);
            this.Controls.Add(this.NameTip);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HealthLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Cluster Punks Enemy Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label SpeedTip;
        private System.Windows.Forms.Label DamageTip;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label NameTip;
        private System.Windows.Forms.Label HealthTip;
        private System.Windows.Forms.Button ImageLoader;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Label ImageDisplayText;
        private System.Windows.Forms.PictureBox ImageDisplay;
        private System.Windows.Forms.Label CooldownTip;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label CooldownLabel;
        private System.Windows.Forms.Label Reminder;
        private System.Windows.Forms.Label label1;
    }
}

