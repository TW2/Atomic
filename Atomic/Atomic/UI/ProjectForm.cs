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
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
        }

        private void BtnSubtitles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Subtitles (*.ssa, *.ass)|*.ssa;*.ass";
            ofd.FilterIndex = 0;
            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                comboSubs.Items.AddRange(ofd.FileNames);
                if (comboSubs.SelectedIndex == -1) comboSubs.SelectedIndex = 0;
            }
        }

        private void BtnAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio (*.wav, *.mp3)|*.wav;*.mp3";
            ofd.FilterIndex = 0;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                comboAudio.Items.AddRange(ofd.FileNames);
                if (comboAudio.SelectedIndex == -1) comboAudio.SelectedIndex = 0;
            }
        }

        private void BtnVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video (*.avi, *.mp4)|*.avi;*.mp4";
            ofd.FilterIndex = 0;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                comboVideo.Items.AddRange(ofd.FileNames);
                if (comboVideo.SelectedIndex == -1) comboVideo.SelectedIndex = 0;
            }
        }

        private List<string> GetAllSubtitles()
        {
            List<string> list = new List<string>();
            foreach (object obj in comboSubs.Items)
            {
                list.Add(Convert.ToString(obj));
            }
            return list.Count > 0 ? list : null;
        }

        private List<string> GetAllAudioTracks()
        {
            List<string> list = new List<string>();
            foreach (object obj in comboAudio.Items)
            {
                list.Add(Convert.ToString(obj));
            }
            return list.Count > 0 ? list : null;
        }

        private List<string> GetAllVideoTracks()
        {
            List<string> list = new List<string>();
            foreach (object obj in comboVideo.Items)
            {
                list.Add(Convert.ToString(obj));
            }
            return list.Count > 0 ? list : null;
        }

        public List<string> Subtitles { get => GetAllSubtitles(); }
        public List<string> Audio { get => GetAllAudioTracks(); }
        public List<string> Video { get => GetAllVideoTracks(); }
        public bool IsAudioWanted { get => chkLoadAudio.Checked; }
        public bool IsVideoWanted { get => chkLoadVideo.Checked; }

        private void BtnRemoveSubtitle_Click(object sender, EventArgs e)
        {
            if(comboSubs.SelectedIndex >= 0)
            {
                comboSubs.Items.RemoveAt(comboSubs.SelectedIndex);
                if (comboSubs.SelectedIndex == -1) comboSubs.Text = "";
            }
        }

        private void BtnRemoveAudio_Click(object sender, EventArgs e)
        {
            if (comboAudio.SelectedIndex >= 0)
            {
                comboAudio.Items.RemoveAt(comboAudio.SelectedIndex);
                if (comboAudio.SelectedIndex == -1) comboAudio.Text = "";
            }
        }

        private void BtnRemoveVideo_Click(object sender, EventArgs e)
        {
            if (comboVideo.SelectedIndex >= 0)
            {
                comboVideo.Items.RemoveAt(comboVideo.SelectedIndex);
                if (comboVideo.SelectedIndex == -1) comboVideo.Text = "";
            }
        }
    }
}
