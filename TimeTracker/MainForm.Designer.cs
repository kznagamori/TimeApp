namespace TimeTracker
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer_10Mil = new System.Windows.Forms.Timer(this.components);
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.Panel_Clock = new System.Windows.Forms.Panel();
            this.DataGridView_Log = new System.Windows.Forms.DataGridView();
            this.Button_Register = new System.Windows.Forms.Button();
            this.Nutton_Clear = new System.Windows.Forms.Button();
            this.Button_Copy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer_10Mil
            // 
            this.Timer_10Mil.Interval = 10;
            this.Timer_10Mil.Tick += new System.EventHandler(this.Timer_10Mil_Tick);
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Main.MinimumSize = new System.Drawing.Size(0, 200);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            this.SplitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.Panel_Clock);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.Button_Copy);
            this.SplitContainer_Main.Panel2.Controls.Add(this.Nutton_Clear);
            this.SplitContainer_Main.Panel2.Controls.Add(this.Button_Register);
            this.SplitContainer_Main.Panel2.Controls.Add(this.DataGridView_Log);
            this.SplitContainer_Main.Size = new System.Drawing.Size(522, 428);
            this.SplitContainer_Main.SplitterDistance = 42;
            this.SplitContainer_Main.TabIndex = 0;
            this.SplitContainer_Main.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer_Main_SplitterMoved);
            this.SplitContainer_Main.Resize += new System.EventHandler(this.SplitContainer_Main_Resize);
            // 
            // Panel_Clock
            // 
            this.Panel_Clock.BackColor = System.Drawing.Color.White;
            this.Panel_Clock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Clock.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Panel_Clock.Location = new System.Drawing.Point(0, 0);
            this.Panel_Clock.Name = "Panel_Clock";
            this.Panel_Clock.Size = new System.Drawing.Size(522, 42);
            this.Panel_Clock.TabIndex = 0;
            this.Panel_Clock.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Clock_Paint);
            this.Panel_Clock.DoubleClick += new System.EventHandler(this.Panel_Clock_DoubleClick);
            // 
            // DataGridView_Log
            // 
            this.DataGridView_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Log.Location = new System.Drawing.Point(4, 2);
            this.DataGridView_Log.Name = "DataGridView_Log";
            this.DataGridView_Log.RowTemplate.Height = 21;
            this.DataGridView_Log.Size = new System.Drawing.Size(413, 380);
            this.DataGridView_Log.TabIndex = 0;
            this.DataGridView_Log.Resize += new System.EventHandler(this.DataGridView_Log_Resize);
            // 
            // Button_Register
            // 
            this.Button_Register.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Register.Location = new System.Drawing.Point(423, 3);
            this.Button_Register.MinimumSize = new System.Drawing.Size(0, 48);
            this.Button_Register.Name = "Button_Register";
            this.Button_Register.Size = new System.Drawing.Size(96, 268);
            this.Button_Register.TabIndex = 1;
            this.Button_Register.Text = "登録";
            this.Button_Register.UseVisualStyleBackColor = true;
            this.Button_Register.Click += new System.EventHandler(this.Button_Register_Click);
            // 
            // Nutton_Clear
            // 
            this.Nutton_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Nutton_Clear.Location = new System.Drawing.Point(423, 331);
            this.Nutton_Clear.MinimumSize = new System.Drawing.Size(0, 16);
            this.Nutton_Clear.Name = "Nutton_Clear";
            this.Nutton_Clear.Size = new System.Drawing.Size(96, 48);
            this.Nutton_Clear.TabIndex = 2;
            this.Nutton_Clear.Text = "クリア";
            this.Nutton_Clear.UseVisualStyleBackColor = true;
            this.Nutton_Clear.Click += new System.EventHandler(this.Nutton_Clear_Click);
            // 
            // Button_Copy
            // 
            this.Button_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Copy.Location = new System.Drawing.Point(423, 277);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.Size = new System.Drawing.Size(95, 48);
            this.Button_Copy.TabIndex = 3;
            this.Button_Copy.Text = "コピー";
            this.Button_Copy.UseVisualStyleBackColor = true;
            this.Button_Copy.Click += new System.EventHandler(this.Button_Copy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 428);
            this.Controls.Add(this.SplitContainer_Main);
            this.Name = "MainForm";
            this.Text = "TimeTracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Timer_10Mil;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.Panel Panel_Clock;
        private System.Windows.Forms.DataGridView DataGridView_Log;
        private System.Windows.Forms.Button Button_Register;
        private System.Windows.Forms.Button Nutton_Clear;
        private System.Windows.Forms.Button Button_Copy;
    }
}

