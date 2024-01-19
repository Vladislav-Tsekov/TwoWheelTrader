namespace FormTest
{
    partial class MakeSelector
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            yamahaButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            hondaButton = new Button();
            husqButton = new Button();
            kawaButton = new Button();
            gasButton = new Button();
            suzukiButton = new Button();
            ktmButton = new Button();
            SuspendLayout();
            // 
            // yamahaButton
            // 
            yamahaButton.BackColor = Color.Transparent;
            yamahaButton.BackgroundImage = Properties.Resources.Yamaha_Motor_Company_Emblem;
            yamahaButton.BackgroundImageLayout = ImageLayout.Stretch;
            yamahaButton.Location = new Point(12, 12);
            yamahaButton.Name = "yamahaButton";
            yamahaButton.Size = new Size(154, 94);
            yamahaButton.TabIndex = 0;
            yamahaButton.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // hondaButton
            // 
            hondaButton.BackgroundImage = Properties.Resources.honda_11_logo_png_transparent;
            hondaButton.BackgroundImageLayout = ImageLayout.Stretch;
            hondaButton.Location = new Point(245, 13);
            hondaButton.Name = "hondaButton";
            hondaButton.Size = new Size(154, 94);
            hondaButton.TabIndex = 3;
            hondaButton.UseVisualStyleBackColor = true;
            hondaButton.Click += hondaButton_Click;
            // 
            // husqButton
            // 
            husqButton.BackgroundImage = Properties.Resources.Husqvarna_logo;
            husqButton.BackgroundImageLayout = ImageLayout.Stretch;
            husqButton.Location = new Point(365, 126);
            husqButton.Name = "husqButton";
            husqButton.Size = new Size(154, 94);
            husqButton.TabIndex = 4;
            husqButton.UseVisualStyleBackColor = true;
            // 
            // kawaButton
            // 
            kawaButton.BackgroundImage = Properties.Resources.Kawasaki_Logo;
            kawaButton.BackgroundImageLayout = ImageLayout.Stretch;
            kawaButton.Location = new Point(489, 13);
            kawaButton.Name = "kawaButton";
            kawaButton.Size = new Size(154, 94);
            kawaButton.TabIndex = 5;
            kawaButton.UseVisualStyleBackColor = true;
            // 
            // gasButton
            // 
            gasButton.BackgroundImage = Properties.Resources.GASGAS_logo_logotipo_Gas_Gas;
            gasButton.BackgroundImageLayout = ImageLayout.Stretch;
            gasButton.Location = new Point(597, 126);
            gasButton.Name = "gasButton";
            gasButton.Size = new Size(154, 94);
            gasButton.TabIndex = 6;
            gasButton.UseVisualStyleBackColor = true;
            gasButton.Click += gasButton_Click;
            // 
            // suzukiButton
            // 
            suzukiButton.BackgroundImage = Properties.Resources.Suzuki_Emblem;
            suzukiButton.BackgroundImageLayout = ImageLayout.Stretch;
            suzukiButton.Location = new Point(694, 13);
            suzukiButton.Name = "suzukiButton";
            suzukiButton.Size = new Size(154, 94);
            suzukiButton.TabIndex = 7;
            suzukiButton.UseVisualStyleBackColor = true;
            // 
            // ktmButton
            // 
            ktmButton.BackgroundImage = Properties.Resources.KTM_logo;
            ktmButton.BackgroundImageLayout = ImageLayout.Stretch;
            ktmButton.Location = new Point(122, 126);
            ktmButton.Name = "ktmButton";
            ktmButton.Size = new Size(154, 94);
            ktmButton.TabIndex = 8;
            ktmButton.UseVisualStyleBackColor = true;
            ktmButton.Click += button1_Click;
            // 
            // MakeSelector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 634);
            Controls.Add(ktmButton);
            Controls.Add(suzukiButton);
            Controls.Add(gasButton);
            Controls.Add(kawaButton);
            Controls.Add(husqButton);
            Controls.Add(hondaButton);
            Controls.Add(yamahaButton);
            Name = "MakeSelector";
            Text = "MakeSelector";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button yamahaButton;
        private ContextMenuStrip contextMenuStrip1;
        private Button hondaButton;
        private Button husqButton;
        private Button kawaButton;
        private Button gasButton;
        private Button suzukiButton;
        private Button ktmButton;
    }
}
