using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Atomic.UI
{
    public partial class AtomicMainForm : Form
    {
        Core core = new Core();
        bool first_init = true;

        public bool FirstInit { get => first_init; set => first_init = value; }
        public Control ToolbarTop { get => toolStrip1; }
        public Control ToolbarMiddle { get => toolStrip2; }
        public Control PanelTop { get => panelLVL2; }
        public Control PanelMiddle { get => panelLVL3; }
        public Control PanelBottom { get => panelLVL4; }

        public AtomicMainForm()
        {
            InitializeComponent();

            InitializeProject();
            InitializeForm();
        }

        private void InitializeProject()
        {
            ProjectForm pf = new ProjectForm();
            DialogResult dr = pf.ShowDialog();
            if(dr == DialogResult.OK)
            {
                core.AssFile = pf.Subtitles;
                core.AudioFile = pf.Audio;
                core.VideoFile = pf.Video;
            }
        }

        private void InitializeForm()
        {
            if(core.AssFile != null)
            {
                core.CoreResize(this);
            }
        }

        private void AtomicMainForm_Resize(object sender, EventArgs e)
        {
            InitializeForm();
        }
    }
}
