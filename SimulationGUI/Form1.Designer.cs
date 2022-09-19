
namespace SimulationGUI
{
    partial class Form1
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
            this.textBoxSubscribe = new System.Windows.Forms.TextBox();
            this.buttonSubscribe = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonUnsubscribe = new System.Windows.Forms.Button();
            this.dataGridViewSubscriptions = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonInstruments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubscriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSubscribe
            // 
            this.textBoxSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSubscribe.Location = new System.Drawing.Point(12, 12);
            this.textBoxSubscribe.Name = "textBoxSubscribe";
            this.textBoxSubscribe.Size = new System.Drawing.Size(576, 27);
            this.textBoxSubscribe.TabIndex = 0;
            this.textBoxSubscribe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSubscribe_KeyPress);
            // 
            // buttonSubscribe
            // 
            this.buttonSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubscribe.Location = new System.Drawing.Point(694, 10);
            this.buttonSubscribe.Name = "buttonSubscribe";
            this.buttonSubscribe.Size = new System.Drawing.Size(94, 29);
            this.buttonSubscribe.TabIndex = 1;
            this.buttonSubscribe.Text = "Subscribe";
            this.buttonSubscribe.UseVisualStyleBackColor = true;
            this.buttonSubscribe.Click += new System.EventHandler(this.buttonSubscribe_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStart.Location = new System.Drawing.Point(12, 409);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(94, 29);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.Location = new System.Drawing.Point(112, 409);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(94, 29);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonUnsubscribe
            // 
            this.buttonUnsubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnsubscribe.Location = new System.Drawing.Point(685, 409);
            this.buttonUnsubscribe.Name = "buttonUnsubscribe";
            this.buttonUnsubscribe.Size = new System.Drawing.Size(103, 29);
            this.buttonUnsubscribe.TabIndex = 5;
            this.buttonUnsubscribe.Text = "Unsubscribe";
            this.buttonUnsubscribe.UseVisualStyleBackColor = true;
            this.buttonUnsubscribe.Click += new System.EventHandler(this.buttonUnsubscribe_Click);
            // 
            // dataGridViewSubscriptions
            // 
            this.dataGridViewSubscriptions.AllowUserToAddRows = false;
            this.dataGridViewSubscriptions.AllowUserToDeleteRows = false;
            this.dataGridViewSubscriptions.AllowUserToOrderColumns = true;
            this.dataGridViewSubscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSubscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubscriptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked});
            this.dataGridViewSubscriptions.Location = new System.Drawing.Point(12, 45);
            this.dataGridViewSubscriptions.MultiSelect = false;
            this.dataGridViewSubscriptions.Name = "dataGridViewSubscriptions";
            this.dataGridViewSubscriptions.RowHeadersWidth = 51;
            this.dataGridViewSubscriptions.RowTemplate.Height = 29;
            this.dataGridViewSubscriptions.Size = new System.Drawing.Size(776, 358);
            this.dataGridViewSubscriptions.TabIndex = 6;
            // 
            // Checked
            // 
            this.Checked.HeaderText = "";
            this.Checked.MinimumWidth = 6;
            this.Checked.Name = "Checked";
            this.Checked.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Checked.Width = 125;
            // 
            // buttonInstruments
            // 
            this.buttonInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstruments.Location = new System.Drawing.Point(594, 10);
            this.buttonInstruments.Name = "buttonInstruments";
            this.buttonInstruments.Size = new System.Drawing.Size(94, 29);
            this.buttonInstruments.TabIndex = 7;
            this.buttonInstruments.Text = "Instruments";
            this.buttonInstruments.UseVisualStyleBackColor = true;
            this.buttonInstruments.Click += new System.EventHandler(this.buttonInstruments_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonInstruments);
            this.Controls.Add(this.dataGridViewSubscriptions);
            this.Controls.Add(this.buttonUnsubscribe);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonSubscribe);
            this.Controls.Add(this.textBoxSubscribe);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubscriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSubscribe;
        private System.Windows.Forms.Button buttonSubscribe;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonUnsubscribe;
        private System.Windows.Forms.DataGridView dataGridViewSubscriptions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.Button buttonInstruments;
    }
}

