
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
            this.commandLines = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.commandLine = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.synthaxButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.Location = new System.Drawing.Point(321, 2);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(479, 346);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            // 
            // commandLines
            // 
            this.commandLines.Location = new System.Drawing.Point(12, 12);
            this.commandLines.Name = "commandLines";
            this.commandLines.Size = new System.Drawing.Size(303, 231);
            this.commandLines.TabIndex = 1;
            this.commandLines.Text = "";
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
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(23, 294);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // synthaxButton
            // 
            this.synthaxButton.Location = new System.Drawing.Point(184, 294);
            this.synthaxButton.Name = "synthaxButton";
            this.synthaxButton.Size = new System.Drawing.Size(75, 23);
            this.synthaxButton.TabIndex = 5;
            this.synthaxButton.Text = "Synthax";
            this.synthaxButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.synthaxButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.commandLines);
            this.Controls.Add(this.outputWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox outputWindow;
        private System.Windows.Forms.RichTextBox commandLines;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button synthaxButton;
    }
}

