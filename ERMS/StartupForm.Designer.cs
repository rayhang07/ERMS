namespace ERMS
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            PnlWelcomePanel = new Panel();
            LblWelcomeMessage = new Label();
            PnlContainer = new Panel();
            PnlWelcomePanel.SuspendLayout();
            SuspendLayout();
            // 
            // PnlWelcomePanel
            // 
            PnlWelcomePanel.BackColor = Color.FromArgb(128, 64, 0);
            PnlWelcomePanel.Controls.Add(LblWelcomeMessage);
            PnlWelcomePanel.Dock = DockStyle.Left;
            PnlWelcomePanel.Location = new Point(0, 0);
            PnlWelcomePanel.Name = "PnlWelcomePanel";
            PnlWelcomePanel.Size = new Size(718, 911);
            PnlWelcomePanel.TabIndex = 2;
            PnlWelcomePanel.Paint += PnlWelcomePanel_Paint;
            // 
            // LblWelcomeMessage
            // 
            LblWelcomeMessage.AutoSize = true;
            LblWelcomeMessage.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            LblWelcomeMessage.ForeColor = Color.White;
            LblWelcomeMessage.Location = new Point(140, 480);
            LblWelcomeMessage.Name = "LblWelcomeMessage";
            LblWelcomeMessage.Size = new Size(465, 45);
            LblWelcomeMessage.TabIndex = 0;
            LblWelcomeMessage.Text = "Track Your Students Progress.";
            LblWelcomeMessage.Click += LblWelcomeMessage_Click;
            // 
            // PnlContainer
            // 
            PnlContainer.Dock = DockStyle.Fill;
            PnlContainer.Location = new Point(718, 0);
            PnlContainer.Name = "PnlContainer";
            PnlContainer.Size = new Size(1166, 911);
            PnlContainer.TabIndex = 3;
            PnlContainer.Paint += PnlContainer_Paint;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1884, 911);
            Controls.Add(PnlContainer);
            Controls.Add(PnlWelcomePanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1900, 950);
            Name = "StartupForm";
            Text = "StartupForm";
            PnlWelcomePanel.ResumeLayout(false);
            PnlWelcomePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlWelcomePanel;
        private Label LblWelcomeMessage;
        private Panel PnlContainer;
    }
}