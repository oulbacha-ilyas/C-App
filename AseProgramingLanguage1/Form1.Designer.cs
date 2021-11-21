
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
            this.outputWindow = new System.Windows.Forms.PictureBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            this.synthaxButton = new System.Windows.Forms.Button();
            this.drawButton = new System.Windows.Forms.Button();
            this.ProgramLines = new System.Windows.Forms.TextBox();
            this.synthaxMessages = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.BackColor = System.Drawing.Color.Linen;
            this.outputWindow.Location = new System.Drawing.Point(321, 12);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(479, 413);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            this.outputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.outputWindow_Paint);
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 247);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(303, 20);
            this.commandLine.TabIndex = 3;
            this.commandLine.TextChanged += new System.EventHandler(this.commandLine_TextChanged);
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLine_KeyDown);
            // 
            // synthaxButton
            // 
            this.synthaxButton.Location = new System.Drawing.Point(196, 273);
            this.synthaxButton.Name = "synthaxButton";
            this.synthaxButton.Size = new System.Drawing.Size(75, 23);
            this.synthaxButton.TabIndex = 5;
            this.synthaxButton.Text = "Synthax";
            this.synthaxButton.UseVisualStyleBackColor = true;
            this.synthaxButton.Click += new System.EventHandler(this.synthaxButton_Click);
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(46, 273);
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
            // synthaxMessages
            // 
            this.synthaxMessages.Location = new System.Drawing.Point(12, 302);
            this.synthaxMessages.Multiline = true;
            this.synthaxMessages.Name = "synthaxMessages";
            this.synthaxMessages.ReadOnly = true;
            this.synthaxMessages.Size = new System.Drawing.Size(303, 147);
            this.synthaxMessages.TabIndex = 11;
            this.synthaxMessages.Text = "1\r\n2\r\n3";
            this.synthaxMessages.TextChanged += new System.EventHandler(this.synthaxMessages_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.synthaxMessages);
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
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.Button synthaxButton;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox ProgramLines;
        private System.Windows.Forms.TextBox synthaxMessages;
    }
}

