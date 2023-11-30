using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TimeTracker
{
    public partial class MainForm : Form
    {

        private bool _HasMilSec = true;
        private float _FontSize = 8.0f;
        private double _SplitterDistanceRatio = 0.1;

        public class LogData
        {
            public string DateTime { get; set; }
            public string Comment { get; set; }
        }

        BindingList<LogData> _LogData = new BindingList<LogData>();

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ダブルバッファリング
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.Timer_10Mil.Enabled = true;
            ControlDoubleBuffered(Panel_Clock, true);
            SetSplitterDistance(SplitContainer_Main, _SplitterDistanceRatio);

            //行ヘッダーを非表示にする
            DataGridView_Log.RowHeadersVisible = false;
            // DataGridViewにバインド
            DataGridView_Log.DataSource = _LogData;

            DataGridView_Log.Columns[0].Width = Properties.Settings.Default.日時幅;

            if ((DataGridView_Log.Width - DataGridView_Log.Columns[0].Width) < Properties.Settings.Default.コメント幅)
            {
                DataGridView_Log.Columns[1].Width = Properties.Settings.Default.コメント幅;

            }
            else
            {
                DataGridView_Log.Columns[1].Width = DataGridView_Log.Width - DataGridView_Log.Columns[0].Width;
            }
            this.Size = Properties.Settings.Default.起動サイズ;

        }
        void ControlDoubleBuffered(Control control, bool IsDoubleBuffered)
        {
            control.GetType().InvokeMember(
            "DoubleBuffered",       
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { IsDoubleBuffered });
        }
        private void Panel_Clock_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            // 描画に関連する値をコントロールのプロパティ等から取得する
            int width = Panel_Clock.ClientSize.Width;
            int height = Panel_Clock.ClientSize.Height;

            // 描画領域を指定する
            var rect = new Rectangle(0, 0, width, height);

            // 背景描画用のブラシを生成する
            using (var backColorBrush = new SolidBrush(Panel_Clock.BackColor))
            {
                // 背景を描画する
                g.FillRectangle(backColorBrush, rect);
            }
            DateTime t = DateTime.Now;
            string time_text = "";
            if (this._HasMilSec)
            {
                time_text = String.Format("{0:yyyy年MM月dd日HH時mm分ss秒ff}", t);

            }
            else
            {
                time_text = String.Format("{0:yyyy年MM月dd日HH時mm分ss秒}", t);

            }

            var size = new Size(width, height);
            var fontSize = CalcFontSize(time_text, size, g);

            using (var font = new Font(Panel_Clock.Font.Name, fontSize))
            {
                var stringFormat = new StringFormat();
                var num = (Int32)System.Math.Log((Double)HorizontalAlignment.Center, 2);
                stringFormat.LineAlignment = (StringAlignment)(num / 4);
                stringFormat.Alignment = (StringAlignment)(num % 4);

                // 文字描画用のブラシを生成する
                using (var foreColorBrush = new SolidBrush(this.ForeColor))
                {
                    // 文字を描画する
                    g.DrawString(time_text, font, foreColorBrush, rect, stringFormat);
                    rect.Y += ((int)font.Size);
                }

            }
        }

        private float CalcFontSize(string str, Size size, Graphics g)
        {
            var str_size = new SizeF(0.1F, 0.1F);
            var ratio_width = 0.1F;
            var ratio_height = 0.1F;

            if (!string.IsNullOrEmpty(str))
            {
                str_size = g.MeasureString(str, new Font(this.Font.Name, this.Font.Size));
                ratio_width = (size.Width / str_size.Width) * _FontSize;
                ratio_height = (size.Height / str_size.Height) * _FontSize;
            }
            return Math.Min(ratio_width, ratio_height);
        }

        private void Timer_10Mil_Tick(object sender, EventArgs e)
        {
            Panel_Clock.Invalidate();
        }

        private void Panel_Clock_DoubleClick(object sender, EventArgs e)
        {
            this._HasMilSec = !this._HasMilSec;
        }
        private void SetSplitterDistance(SplitContainer splitContainer, double percentage)
        {
            // 分割の割合を設定（0.0～1.0）
            if (percentage < 0.0 || percentage > 1.0)
            {
                throw new ArgumentOutOfRangeException("percentage must be between 0.0 and 1.0.");
            }

            // 境界線の位置を計算して設定
            int distance = (int)(splitContainer.Height * percentage);
            splitContainer.SplitterDistance = distance;
        }

        private void SplitContainer_Main_Resize(object sender, EventArgs e)
        {
            SetSplitterDistance(SplitContainer_Main, _SplitterDistanceRatio);
        }

        private void SplitContainer_Main_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double distance = (double)SplitContainer_Main.SplitterDistance / (double)SplitContainer_Main.Height;
            _SplitterDistanceRatio = distance;
        }

        private void DataGridView_Log_Resize(object sender, EventArgs e)
        {
            DataGridView_Log.Columns[0].Width = Properties.Settings.Default.日時幅;

            if ((DataGridView_Log.Width - DataGridView_Log.Columns[0].Width) < Properties.Settings.Default.コメント幅)
            {
                DataGridView_Log.Columns[1].Width = Properties.Settings.Default.コメント幅;

            }
            else
            {
                DataGridView_Log.Columns[1].Width = DataGridView_Log.Width - DataGridView_Log.Columns[0].Width;
            }
        }

        private void Button_Register_Click(object sender, EventArgs e)
        {
            _LogData.Add(new LogData { DateTime = String.Format("{0:yyyy年MM月dd日HH時mm分ss秒ff}", DateTime.Now), Comment = "" });
        }

        private void Nutton_Clear_Click(object sender, EventArgs e)
        {
            _LogData.Clear();
        }

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < DataGridView_Log.Columns.Count; i++)
            {
                // カラムヘッダーを取得
                buffer.Append(DataGridView_Log.Columns[i].HeaderText);
                if (i < DataGridView_Log.Columns.Count - 1)
                    buffer.Append(",");
                else
                    buffer.Append("\n");
            }

            // データの行を読み取る
            for (int i = 0; i < DataGridView_Log.Rows.Count; i++)
            {
                for (int j = 0; j < DataGridView_Log.Columns.Count; j++)
                {
                    // セルのデータを取得
                    buffer.Append(DataGridView_Log.Rows[i].Cells[j].Value ?? string.Empty);

                    if (j < DataGridView_Log.Columns.Count - 1)
                        buffer.Append(",");
                }

                buffer.Append("\n");
            }

            // クリップボードにデータをセット
            Clipboard.SetText(buffer.ToString());
        }
    }
}
