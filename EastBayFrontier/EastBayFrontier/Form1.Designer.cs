namespace EastBayFrontier
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblSake = new System.Windows.Forms.Label();
            this.lblRum = new System.Windows.Forms.Label();
            this.lblWhiskey = new System.Windows.Forms.Label();
            this.tmrStep = new System.Windows.Forms.Timer(this.components);
            this.picNinja = new System.Windows.Forms.PictureBox();
            this.picPirate = new System.Windows.Forms.PictureBox();
            this.picCowboy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picNinja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPirate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCowboy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gold:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sake:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Whiskey:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(65, 12);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(13, 13);
            this.lblGold.TabIndex = 4;
            this.lblGold.Text = "0";
            // 
            // lblSake
            // 
            this.lblSake.AutoSize = true;
            this.lblSake.Location = new System.Drawing.Point(65, 34);
            this.lblSake.Name = "lblSake";
            this.lblSake.Size = new System.Drawing.Size(24, 13);
            this.lblSake.TabIndex = 5;
            this.lblSake.Text = "0/0";
            // 
            // lblRum
            // 
            this.lblRum.AutoSize = true;
            this.lblRum.Location = new System.Drawing.Point(65, 47);
            this.lblRum.Name = "lblRum";
            this.lblRum.Size = new System.Drawing.Size(24, 13);
            this.lblRum.TabIndex = 6;
            this.lblRum.Text = "0/0";
            // 
            // lblWhiskey
            // 
            this.lblWhiskey.AutoSize = true;
            this.lblWhiskey.Location = new System.Drawing.Point(65, 64);
            this.lblWhiskey.Name = "lblWhiskey";
            this.lblWhiskey.Size = new System.Drawing.Size(24, 13);
            this.lblWhiskey.TabIndex = 7;
            this.lblWhiskey.Text = "0/0";
            // 
            // tmrStep
            // 
            this.tmrStep.Enabled = true;
            this.tmrStep.Interval = 33;
            this.tmrStep.Tick += new System.EventHandler(this.tmrStep_Tick);
            // 
            // picNinja
            // 
            this.picNinja.Location = new System.Drawing.Point(13, 94);
            this.picNinja.Name = "picNinja";
            this.picNinja.Size = new System.Drawing.Size(159, 99);
            this.picNinja.TabIndex = 8;
            this.picNinja.TabStop = false;
            this.picNinja.Click += new System.EventHandler(this.Faction_Click);
            // 
            // picPirate
            // 
            this.picPirate.Location = new System.Drawing.Point(196, 94);
            this.picPirate.Name = "picPirate";
            this.picPirate.Size = new System.Drawing.Size(159, 99);
            this.picPirate.TabIndex = 9;
            this.picPirate.TabStop = false;
            this.picPirate.Click += new System.EventHandler(this.Faction_Click);
            // 
            // picCowboy
            // 
            this.picCowboy.Location = new System.Drawing.Point(377, 94);
            this.picCowboy.Name = "picCowboy";
            this.picCowboy.Size = new System.Drawing.Size(159, 99);
            this.picCowboy.TabIndex = 10;
            this.picCowboy.TabStop = false;
            this.picCowboy.Click += new System.EventHandler(this.Faction_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 261);
            this.Controls.Add(this.picCowboy);
            this.Controls.Add(this.picPirate);
            this.Controls.Add(this.picNinja);
            this.Controls.Add(this.lblWhiskey);
            this.Controls.Add(this.lblRum);
            this.Controls.Add(this.lblSake);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "East Bay Frontier";
            ((System.ComponentModel.ISupportInitialize)(this.picNinja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPirate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCowboy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblSake;
        private System.Windows.Forms.Label lblRum;
        private System.Windows.Forms.Label lblWhiskey;
        private System.Windows.Forms.PictureBox picNinja;
        private System.Windows.Forms.Timer tmrStep;
        private System.Windows.Forms.PictureBox picPirate;
        private System.Windows.Forms.PictureBox picCowboy;
    }
}

