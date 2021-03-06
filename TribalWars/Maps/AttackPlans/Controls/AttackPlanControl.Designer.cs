using TribalWars.Controls.Finders;
using TribalWars.Controls.TimeConverter;

namespace TribalWars.Maps.AttackPlans.Controls
{
    partial class AttackPlanControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Coords = new TribalWars.Controls.Finders.VillagePlayerTribeSelector();
            this.Close = new System.Windows.Forms.LinkLabel();
            this._Player = new System.Windows.Forms.Label();
            this._Village = new System.Windows.Forms.Label();
            this._Tribe = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ToggleComments = new System.Windows.Forms.Button();
            this.CommentsToggle1 = new System.Windows.Forms.Panel();
            this.Comments = new System.Windows.Forms.TextBox();
            this.AttackCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Date = new TribalWars.Controls.TimeConverter.TimeConverterControl();
            this.DistanceContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CommentsToggle1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DistanceContainer, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 173);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Coords);
            this.panel1.Controls.Add(this.Close);
            this.panel1.Controls.Add(this._Player);
            this.panel1.Controls.Add(this._Village);
            this.panel1.Controls.Add(this._Tribe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 40);
            this.panel1.TabIndex = 0;
            // 
            // Coords
            // 
            this.Coords.BackColor = System.Drawing.Color.White;
            this.Coords.DisplayVillagePurposeImage = true;
            this.Coords.GameLocation = null;
            this.Coords.Location = new System.Drawing.Point(6, 3);
            this.Coords.Name = "Coords";
            this.Coords.PlaceHolderText = "";
            this.Coords.ShowImage = false;
            this.Coords.Size = new System.Drawing.Size(50, 20);
            this.Coords.TabIndex = 14;
            this.Coords.VillageSelected += new System.EventHandler<TribalWars.Worlds.Events.Impls.VillageEventArgs>(this.Coords_VillageSelected);
            // 
            // Close
            // 
            this.Close.ActiveLinkColor = System.Drawing.Color.Black;
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.AutoSize = true;
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.DisabledLinkColor = System.Drawing.Color.Black;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.LinkColor = System.Drawing.Color.Black;
            this.Close.Location = new System.Drawing.Point(256, 3);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(15, 16);
            this.Close.TabIndex = 13;
            this.Close.TabStop = true;
            this.Close.Text = "x";
            this.toolTip1.SetToolTip(this.Close, "Delete this plan");
            this.Close.VisitedLinkColor = System.Drawing.Color.Black;
            this.Close.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Close_LinkClicked);
            // 
            // _Player
            // 
            this._Player.AutoSize = true;
            this._Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Player.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._Player.Location = new System.Drawing.Point(3, 23);
            this._Player.Name = "_Player";
            this._Player.Size = new System.Drawing.Size(53, 16);
            this._Player.TabIndex = 11;
            this._Player.Text = "Player";
            this._Player.DoubleClick += new System.EventHandler(this.Player_DoubleClick);
            this._Player.MouseClick += new System.Windows.Forms.MouseEventHandler(this._Player_MouseClick);
            // 
            // _Village
            // 
            this._Village.AutoSize = true;
            this._Village.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Village.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._Village.Location = new System.Drawing.Point(57, 4);
            this._Village.Name = "_Village";
            this._Village.Size = new System.Drawing.Size(95, 16);
            this._Village.TabIndex = 10;
            this._Village.Text = "Villagename";
            this._Village.DoubleClick += new System.EventHandler(this._Village_DoubleClick);
            this._Village.MouseClick += new System.Windows.Forms.MouseEventHandler(this._Village_MouseClick);
            // 
            // _Tribe
            // 
            this._Tribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Tribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tribe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._Tribe.Location = new System.Drawing.Point(206, 23);
            this._Tribe.Name = "_Tribe";
            this._Tribe.Size = new System.Drawing.Size(65, 16);
            this._Tribe.TabIndex = 12;
            this._Tribe.Text = "Tag";
            this._Tribe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Tribe.DoubleClick += new System.EventHandler(this.Tribe_DoubleClick);
            this._Tribe.MouseClick += new System.Windows.Forms.MouseEventHandler(this._Tribe_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CommentsToggle1);
            this.panel3.Controls.Add(this.Comments);
            this.panel3.Controls.Add(this.ToggleComments);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 30);
            this.panel3.TabIndex = 4;
            // 
            // ToggleComments
            // 
            this.ToggleComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleComments.Image = global::TribalWars.Properties.Resources.pencil1;
            this.ToggleComments.Location = new System.Drawing.Point(251, 3);
            this.ToggleComments.Name = "ToggleComments";
            this.ToggleComments.Size = new System.Drawing.Size(20, 23);
            this.ToggleComments.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ToggleComments, "Add a comment to this attack plan");
            this.ToggleComments.UseVisualStyleBackColor = true;
            this.ToggleComments.Click += new System.EventHandler(this.ToggleComments_Click);
            // 
            // CommentsToggle1
            // 
            this.CommentsToggle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentsToggle1.Controls.Add(this.AttackCountLabel);
            this.CommentsToggle1.Controls.Add(this.label1);
            this.CommentsToggle1.Controls.Add(this.Date);
            this.CommentsToggle1.Location = new System.Drawing.Point(0, 0);
            this.CommentsToggle1.Margin = new System.Windows.Forms.Padding(0);
            this.CommentsToggle1.Name = "CommentsToggle1";
            this.CommentsToggle1.Size = new System.Drawing.Size(248, 30);
            this.CommentsToggle1.TabIndex = 5;
            // 
            // Comments
            // 
            this.Comments.AcceptsReturn = true;
            this.Comments.AcceptsTab = true;
            this.Comments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comments.Location = new System.Drawing.Point(3, 5);
            this.Comments.Name = "Comments";
            this.Comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Comments.Size = new System.Drawing.Size(245, 20);
            this.Comments.TabIndex = 4;
            this.Comments.Visible = false;
            this.Comments.TextChanged += new System.EventHandler(this.Comments_TextChanged);
            // 
            // AttackCountLabel
            // 
            this.AttackCountLabel.AutoSize = true;
            this.AttackCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackCountLabel.Location = new System.Drawing.Point(3, 5);
            this.AttackCountLabel.Name = "AttackCountLabel";
            this.AttackCountLabel.Size = new System.Drawing.Size(16, 16);
            this.AttackCountLabel.TabIndex = 3;
            this.AttackCountLabel.Text = "0";
            this.AttackCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.AttackCountLabel, "Amount of attacks");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "attacks on";
            // 
            // Date
            // 
            this.Date.BackColor = System.Drawing.Color.Transparent;
            this.Date.CustomFormat = "MMM, dd yyyy HH:mm:ss";
            this.Date.Location = new System.Drawing.Point(81, 3);
            this.Date.Margin = new System.Windows.Forms.Padding(0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(167, 25);
            this.Date.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Date, "Set the time the attacks should reach the target");
            this.Date.Value = new System.DateTime(2008, 4, 10, 0, 26, 44, 906);
            this.Date.DateSelected += new System.EventHandler<TribalWars.Controls.TimeConverter.DateEventArgs>(this.Date_DateSelected);
            // 
            // DistanceContainer
            // 
            this.DistanceContainer.AutoScroll = true;
            this.DistanceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DistanceContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DistanceContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.DistanceContainer.Location = new System.Drawing.Point(0, 70);
            this.DistanceContainer.Margin = new System.Windows.Forms.Padding(0);
            this.DistanceContainer.Name = "DistanceContainer";
            this.DistanceContainer.Size = new System.Drawing.Size(274, 103);
            this.DistanceContainer.TabIndex = 5;
            this.DistanceContainer.WrapContents = false;
            // 
            // AttackPlanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AttackPlanControl";
            this.Size = new System.Drawing.Size(274, 173);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CommentsToggle1.ResumeLayout(false);
            this.CommentsToggle1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _Village;
        private System.Windows.Forms.Label _Player;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel Close;
        private TimeConverterControl Date;
        private VillagePlayerTribeSelector Coords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel DistanceContainer;
        private System.Windows.Forms.Label AttackCountLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label _Tribe;
        private System.Windows.Forms.Button ToggleComments;
        private System.Windows.Forms.Panel CommentsToggle1;
        private System.Windows.Forms.TextBox Comments;
    }
}
