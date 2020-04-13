using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace CSVFileUpdater
{
    [DesignerGenerated()]
    public partial class FileUpdateUtilInfo : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FileUpdateUtilInfo));
            _lblInfo = new Label();
            _btnInfoExit = new Button();
            _btnInfoExit.Click += new EventHandler(btnInfoExit_Click);
            SuspendLayout();
            // 
            // lblInfo
            // 
            _lblInfo.AutoSize = true;
            _lblInfo.BorderStyle = BorderStyle.Fixed3D;
            _lblInfo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblInfo.Location = new Point(21, 9);
            _lblInfo.Name = "lblInfo";
            _lblInfo.Size = new Size(753, 274);
            _lblInfo.TabIndex = 8;
            _lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // btnInfoExit
            // 
            _btnInfoExit.BackColor = Color.Red;
            _btnInfoExit.ForeColor = Color.White;
            _btnInfoExit.Location = new Point(656, 302);
            _btnInfoExit.Name = "btnInfoExit";
            _btnInfoExit.Size = new Size(118, 23);
            _btnInfoExit.TabIndex = 9;
            _btnInfoExit.Text = "Exit";
            _btnInfoExit.UseVisualStyleBackColor = false;
            // 
            // CSVUpdaterInfo
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 347);
            Controls.Add(_btnInfoExit);
            Controls.Add(_lblInfo);
            Name = "CSVUpdaterInfo";
            Text = "CSVUpdaterInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label _lblInfo;

        internal Label lblInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInfo != null)
                {
                }

                _lblInfo = value;
                if (_lblInfo != null)
                {
                }
            }
        }

        private Button _btnInfoExit;

        internal Button btnInfoExit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnInfoExit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnInfoExit != null)
                {
                    _btnInfoExit.Click -= btnInfoExit_Click;
                }

                _btnInfoExit = value;
                if (_btnInfoExit != null)
                {
                    _btnInfoExit.Click += btnInfoExit_Click;
                }
            }
        }
    }
}