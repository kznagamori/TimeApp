using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace DebugClock
{
    public partial class MainForm : Form
    {
        public class SineWaveProvider : WaveProvider16
        {
            private double _PhaseAngle;

            public float Frequency { get; set; }
            public float Amplitude { get; set; }

            public SineWaveProvider()
            {
                Frequency = 1000;  // デフォルトの周波数
                Amplitude = 0.25f; // デフォルトの振幅
            }

            public override int Read(short[] buffer, int offset, int sample_count)
            {
                var samples = new short[sample_count / 2];
                for (var n = 0; n < samples.Length; n++)
                {
                    samples[n] = (short)(Amplitude * short.MaxValue * Math.Sin(_PhaseAngle));
                    _PhaseAngle += 2 * Math.PI * Frequency / WaveFormat.SampleRate;

                    if (_PhaseAngle > 2 * Math.PI)
                        _PhaseAngle -= 2 * Math.PI;
                }
                Buffer.BlockCopy(samples, 0, buffer, offset, sample_count);
                return sample_count;
            }
        }


        private float _FontSize = 1.0f;
        private bool _HasMilSec = true;
        private int _PrevSec = -1;
        private DateTime _StartTime = DateTime.Now;
        private bool _IsPlay = false; 

        private SineWaveProvider _SineWaveProvider = new SineWaveProvider();
        private WaveOutEvent _WaveOutEvent = new WaveOutEvent();


        public MainForm()
        {
            InitializeComponent();
            this._FontSize = this.Font.Size;
            this._HasMilSec = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ダブルバッファリング
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            _SineWaveProvider.SetWaveFormat(16000, 1);  // 16kHz mono
            _SineWaveProvider.Frequency = 800;
            _SineWaveProvider.Amplitude = 0.25f;
            _WaveOutEvent.Init(_SineWaveProvider);
            Timer_10Mil.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            // 描画に関連する値をコントロールのプロパティ等から取得する
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // 描画領域を指定する
            var rect = new Rectangle(0, 0, width, height);

            // 背景描画用のブラシを生成する
            using (var backColorBrush = new SolidBrush(this.BackColor))
            {
                // 背景を描画する
                g.FillRectangle(backColorBrush, rect);
            }
            DateTime t = DateTime.Now;
            string time_text = "";
            if (this._HasMilSec)
            {
                time_text = String.Format("{0:HH時mm分ss秒ff}", t);

            }
            else
            {
                time_text = String.Format("{0:HH時mm分ss秒}", t);

            }

            var size = new Size(width, height);
            var fontSize = CalcFontSize(time_text, size, g);

            using (var font = new Font(this.Font.Name, fontSize))
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
            if (Properties.Settings.Default.ビープ有効)
            {
                if (t.Second != _PrevSec)
                {
                    _PrevSec = t.Second;
                    _StartTime = t;
                    if (!_IsPlay)
                    {
                        if (_WaveOutEvent != null)
                        {
                            _WaveOutEvent.Play();
                            _IsPlay = true;
                        }
                    }
                }
                if (_IsPlay)
                {
                    var diff_time = t - _StartTime;
                    if (diff_time.Milliseconds >= 100)
                    {
                        if (_WaveOutEvent != null)
                        {
                            _WaveOutEvent.Stop();
                            _IsPlay = false;
                        }
                    }
                }
            }
        }
        private float CalcFontSize(string str, Size size, Graphics g)
        {
            var str_size = new SizeF(0.1F, 0.1F);
            var ratio_width  = 0.1F;
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
            this.Invalidate();
        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this._HasMilSec = !this._HasMilSec;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Timer_10Mil.Enabled = false;
            if (_IsPlay)
            {
                _WaveOutEvent.Stop();
            }
            _WaveOutEvent.Dispose();
            _WaveOutEvent = null;
            _SineWaveProvider = null;
        }
    }
}
