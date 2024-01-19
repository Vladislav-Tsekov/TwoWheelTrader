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
            Motorcycles = new ContextMenuStrip(components);
            addNewMotorcycleToolStripMenuItem = new ToolStripMenuItem();
            removeMotorcycleToolStripMenuItem = new ToolStripMenuItem();
            checkMotorcycleToolStripMenuItem = new ToolStripMenuItem();
            Data = new ContextMenuStrip(components);
            repositoryStatusToolStripMenuItem = new ToolStripMenuItem();
            mostProfitableOffersToolStripMenuItem = new ToolStripMenuItem();
            Control = new ContextMenuStrip(components);
            exitProgramToolStripMenuItem = new ToolStripMenuItem();
            checkedListBox1 = new CheckedListBox();
            checkedListBox2 = new CheckedListBox();
            checkedListBox3 = new CheckedListBox();
            Motorcycles.SuspendLayout();
            Data.SuspendLayout();
            Control.SuspendLayout();
            SuspendLayout();
            // 
            // Motorcycles
            // 
            Motorcycles.ImageScalingSize = new Size(20, 20);
            Motorcycles.Items.AddRange(new ToolStripItem[] { addNewMotorcycleToolStripMenuItem, removeMotorcycleToolStripMenuItem, checkMotorcycleToolStripMenuItem });
            Motorcycles.Name = "Motorcycles";
            Motorcycles.RenderMode = ToolStripRenderMode.System;
            Motorcycles.Size = new Size(226, 76);
            Motorcycles.Text = "Motorcycles";
            // 
            // addNewMotorcycleToolStripMenuItem
            // 
            addNewMotorcycleToolStripMenuItem.Name = "addNewMotorcycleToolStripMenuItem";
            addNewMotorcycleToolStripMenuItem.Size = new Size(225, 24);
            addNewMotorcycleToolStripMenuItem.Text = "Add New Motorcycle";
            // 
            // removeMotorcycleToolStripMenuItem
            // 
            removeMotorcycleToolStripMenuItem.Name = "removeMotorcycleToolStripMenuItem";
            removeMotorcycleToolStripMenuItem.Size = new Size(225, 24);
            removeMotorcycleToolStripMenuItem.Text = "Remove Motorcycle";
            // 
            // checkMotorcycleToolStripMenuItem
            // 
            checkMotorcycleToolStripMenuItem.Name = "checkMotorcycleToolStripMenuItem";
            checkMotorcycleToolStripMenuItem.Size = new Size(225, 24);
            checkMotorcycleToolStripMenuItem.Text = "Check Motorcycle Info";
            // 
            // Data
            // 
            Data.ImageScalingSize = new Size(20, 20);
            Data.Items.AddRange(new ToolStripItem[] { repositoryStatusToolStripMenuItem, mostProfitableOffersToolStripMenuItem });
            Data.Name = "Data";
            Data.RenderMode = ToolStripRenderMode.System;
            Data.Size = new Size(225, 52);
            Data.Text = "Data";
            // 
            // repositoryStatusToolStripMenuItem
            // 
            repositoryStatusToolStripMenuItem.Name = "repositoryStatusToolStripMenuItem";
            repositoryStatusToolStripMenuItem.Size = new Size(224, 24);
            repositoryStatusToolStripMenuItem.Text = "Repository Status";
            // 
            // mostProfitableOffersToolStripMenuItem
            // 
            mostProfitableOffersToolStripMenuItem.Name = "mostProfitableOffersToolStripMenuItem";
            mostProfitableOffersToolStripMenuItem.Size = new Size(224, 24);
            mostProfitableOffersToolStripMenuItem.Text = "Most Profitable Offers";
            // 
            // Control
            // 
            Control.ImageScalingSize = new Size(20, 20);
            Control.Items.AddRange(new ToolStripItem[] { exitProgramToolStripMenuItem });
            Control.Name = "Control";
            Control.RenderMode = ToolStripRenderMode.System;
            Control.Size = new Size(164, 28);
            Control.Text = "Control";
            // 
            // exitProgramToolStripMenuItem
            // 
            exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            exitProgramToolStripMenuItem.Size = new Size(163, 24);
            exitProgramToolStripMenuItem.Text = "Exit Program";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "250", "350", "450" });
            checkedListBox1.Location = new Point(36, 298);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(150, 114);
            checkedListBox1.Sorted = true;
            checkedListBox1.TabIndex = 15;
            // 
            // checkedListBox2
            // 
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024" });
            checkedListBox2.Location = new Point(230, 298);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(150, 114);
            checkedListBox2.TabIndex = 16;
            // 
            // checkedListBox3
            // 
            checkedListBox3.FormattingEnabled = true;
            checkedListBox3.Items.AddRange(new object[] { "Yamaha", "Honda", "Kawasaki", "Suzuki", "KTM", "Husqvarna", "GASGAS" });
            checkedListBox3.Location = new Point(450, 298);
            checkedListBox3.Name = "checkedListBox3";
            checkedListBox3.Size = new Size(150, 114);
            checkedListBox3.TabIndex = 17;
            // 
            // MakeSelector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 595);
            Controls.Add(checkedListBox3);
            Controls.Add(checkedListBox2);
            Controls.Add(checkedListBox1);
            Name = "MakeSelector";
            Text = "MakeSelector";
            Load += Form1_Load;
            Motorcycles.ResumeLayout(false);
            Data.ResumeLayout(false);
            Control.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip Motorcycles;
        private ToolStripMenuItem addNewMotorcycleToolStripMenuItem;
        private ToolStripMenuItem removeMotorcycleToolStripMenuItem;
        private ToolStripMenuItem checkMotorcycleToolStripMenuItem;
        private ContextMenuStrip Data;
        private ToolStripMenuItem repositoryStatusToolStripMenuItem;
        private ToolStripMenuItem mostProfitableOffersToolStripMenuItem;
        private ContextMenuStrip Control;
        private ToolStripMenuItem exitProgramToolStripMenuItem;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private CheckedListBox checkedListBox3;
    }
}
