namespace NotepadClone
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            findToolStripMenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            systemToolStripMenuItem = new ToolStripMenuItem();
            mainText = new TextBox();
            findPanel = new Panel();
            useRegularExpressions = new CheckBox();
            findNext = new Button();
            closeFindPanel = new Button();
            wrapAround = new CheckBox();
            findQuery = new TextBox();
            findLabel = new Label();
            fontDialog = new FontDialog();
            statusStrip = new StatusStrip();
            systemStatus = new ToolStripStatusLabel();
            statusTimer = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            findPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = SystemColors.Control;
            menuStrip.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 3, 0, 3);
            menuStrip.Size = new Size(895, 38);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(56, 32);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(207, 32);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeyDisplayString = "";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(207, 32);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(207, 32);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { findToolStripMenuItem, fontToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(60, 32);
            editToolStripMenuItem.Text = "Edit";
            // 
            // findToolStripMenuItem
            // 
            findToolStripMenuItem.Name = "findToolStripMenuItem";
            findToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            findToolStripMenuItem.Size = new Size(203, 32);
            findToolStripMenuItem.Text = "Find";
            findToolStripMenuItem.Click += findToolStripMenuItem_Click;
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new Size(203, 32);
            fontToolStripMenuItem.Text = "Font";
            fontToolStripMenuItem.Click += fontToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { themeToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(67, 32);
            viewToolStripMenuItem.Text = "View";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lightToolStripMenuItem, darkToolStripMenuItem, systemToolStripMenuItem });
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(156, 32);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new Size(247, 32);
            lightToolStripMenuItem.Text = "Light Mode";
            lightToolStripMenuItem.Click += lightToolStripMenuItem_Click;
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new Size(247, 32);
            darkToolStripMenuItem.Text = "Dark Mode";
            darkToolStripMenuItem.Click += darkToolStripMenuItem_Click;
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(247, 32);
            systemToolStripMenuItem.Text = "Sync with System";
            systemToolStripMenuItem.Click += systemDefaultToolStripMenuItem_Click;
            // 
            // mainText
            // 
            mainText.BackColor = SystemColors.Window;
            mainText.BorderStyle = BorderStyle.None;
            mainText.Dock = DockStyle.Fill;
            mainText.Location = new Point(0, 71);
            mainText.MaxLength = 0;
            mainText.Multiline = true;
            mainText.Name = "mainText";
            mainText.ScrollBars = ScrollBars.Both;
            mainText.Size = new Size(895, 489);
            mainText.TabIndex = 2;
            mainText.TextChanged += mainText_TextChanged;
            // 
            // findPanel
            // 
            findPanel.BackColor = SystemColors.Control;
            findPanel.Controls.Add(useRegularExpressions);
            findPanel.Controls.Add(findNext);
            findPanel.Controls.Add(closeFindPanel);
            findPanel.Controls.Add(wrapAround);
            findPanel.Controls.Add(findQuery);
            findPanel.Controls.Add(findLabel);
            findPanel.Dock = DockStyle.Top;
            findPanel.Location = new Point(0, 38);
            findPanel.Name = "findPanel";
            findPanel.Size = new Size(895, 33);
            findPanel.TabIndex = 3;
            findPanel.Visible = false;
            // 
            // useRegularExpressions
            // 
            useRegularExpressions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            useRegularExpressions.AutoSize = true;
            useRegularExpressions.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            useRegularExpressions.Location = new Point(555, 5);
            useRegularExpressions.Name = "useRegularExpressions";
            useRegularExpressions.Size = new Size(162, 24);
            useRegularExpressions.TabIndex = 6;
            useRegularExpressions.Text = "Regular Expressions";
            useRegularExpressions.TextAlign = ContentAlignment.MiddleCenter;
            useRegularExpressions.UseVisualStyleBackColor = true;
            // 
            // findNext
            // 
            findNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            findNext.BackColor = Color.WhiteSmoke;
            findNext.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            findNext.Location = new Point(453, 2);
            findNext.Name = "findNext";
            findNext.Size = new Size(96, 28);
            findNext.TabIndex = 5;
            findNext.Text = "Find Next";
            findNext.UseVisualStyleBackColor = false;
            findNext.Click += findNext_Click;
            // 
            // closeFindPanel
            // 
            closeFindPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeFindPanel.BackColor = Color.WhiteSmoke;
            closeFindPanel.FlatAppearance.BorderSize = 0;
            closeFindPanel.FlatStyle = FlatStyle.System;
            closeFindPanel.Font = new Font("Segoe UI", 10.2F);
            closeFindPanel.Location = new Point(849, 3);
            closeFindPanel.Name = "closeFindPanel";
            closeFindPanel.Size = new Size(34, 28);
            closeFindPanel.TabIndex = 4;
            closeFindPanel.Text = "✖";
            closeFindPanel.UseVisualStyleBackColor = false;
            closeFindPanel.Click += closeFindPanel_Click;
            // 
            // wrapAround
            // 
            wrapAround.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            wrapAround.AutoSize = true;
            wrapAround.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            wrapAround.Location = new Point(723, 5);
            wrapAround.Name = "wrapAround";
            wrapAround.Size = new Size(120, 24);
            wrapAround.TabIndex = 2;
            wrapAround.Text = "Wrap Around";
            wrapAround.TextAlign = ContentAlignment.MiddleCenter;
            wrapAround.UseVisualStyleBackColor = true;
            // 
            // findQuery
            // 
            findQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            findQuery.BorderStyle = BorderStyle.None;
            findQuery.Font = new Font("Segoe UI", 10.2F);
            findQuery.Location = new Point(55, 4);
            findQuery.Name = "findQuery";
            findQuery.Size = new Size(392, 23);
            findQuery.TabIndex = 1;
            // 
            // findLabel
            // 
            findLabel.AutoSize = true;
            findLabel.Font = new Font("Segoe UI", 10.2F);
            findLabel.Location = new Point(3, 4);
            findLabel.Name = "findLabel";
            findLabel.Size = new Size(46, 23);
            findLabel.TabIndex = 0;
            findLabel.Text = "Find:";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { systemStatus });
            statusStrip.Location = new Point(0, 560);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(895, 26);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "statusStrip1";
            // 
            // systemStatus
            // 
            systemStatus.Name = "systemStatus";
            systemStatus.Size = new Size(50, 20);
            systemStatus.Text = "Ready";
            // 
            // statusTimer
            // 
            statusTimer.Interval = 3000;
            statusTimer.Tick += statusTimer_Tick;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 586);
            Controls.Add(mainText);
            Controls.Add(statusStrip);
            Controls.Add(findPanel);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(4);
            Name = "Dashboard";
            Text = "Notepad Clone by Muhammad Magdi";
            FormClosing += Dashboard_FormClosing;
            Load += Dashboard_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            findPanel.ResumeLayout(false);
            findPanel.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private TextBox mainText;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private Panel findPanel;
        private CheckBox wrapAround;
        private TextBox findQuery;
        private Label findLabel;
        private Button closeFindPanel;
        private Button findNext;
        private CheckBox useRegularExpressions;
        private ToolStripMenuItem fontToolStripMenuItem;
        private FontDialog fontDialog;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel systemStatus;
        private System.Windows.Forms.Timer statusTimer;
    }
}
