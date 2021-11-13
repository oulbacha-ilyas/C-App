
namespace AseProgramingLanguage1
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
            this.outputWindow = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.commandLine = new System.Windows.Forms.TextBox();
            this.synthaxButton = new System.Windows.Forms.Button();
            this.drawButton = new System.Windows.Forms.Button();
            this.ProgramLines = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.BackColor = System.Drawing.Color.Linen;
            this.outputWindow.Location = new System.Drawing.Point(321, 2);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(479, 346);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            this.outputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.outputWindow_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 258);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(303, 20);
            this.commandLine.TabIndex = 3;
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLine_KeyDown);
            // 
            // synthaxButton
            // 
            this.synthaxButton.Location = new System.Drawing.Point(184, 294);
            this.synthaxButton.Name = "synthaxButton";
            this.synthaxButton.Size = new System.Drawing.Size(75, 23);
            this.synthaxButton.TabIndex = 5;
            this.synthaxButton.Text = "Synthax";
            this.synthaxButton.UseVisualStyleBackColor = true;
            this.synthaxButton.Click += new System.EventHandler(this.synthaxButton_Click);
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(46, 294);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 7;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // ProgramLines
            // 
            this.ProgramLines.Location = new System.Drawing.Point(12, 12);
            this.ProgramLines.Multiline = true;
            this.ProgramLines.Name = "ProgramLines";
            this.ProgramLines.Size = new System.Drawing.Size(303, 229);
            this.ProgramLines.TabIndex = 8;
            this.ProgramLines.TextChanged += new System.EventHandler(this.ProgramLines_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProgramLines);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.synthaxButton);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.outputWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox outputWindow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.Button synthaxButton;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox ProgramLines;
    }
}

