using System.Collections.Generic;
using System.Windows.Forms;
using Atomic.FFmpeg;
using Atomic.GetMediaInfo;
using Atomic.UI;
using Atomic.UI.Element;
using CoolTable;
using CoolTable.Core;
using CSASS;

namespace Atomic
{
    public class Core
    {
        private Csass ca = new Csass();
        private List<string> ass_fullpath = new List<string>();
        private List<string> video_fullpath = new List<string>();
        private List<string> audio_fullpath = new List<string>();
        private bool useAudio = true;
        private bool useVideo = true;

        private MediaInfoWrapper MI = null;


        private Table subtitlesTable = new Table();
        private VideoEditorView vev = new VideoEditorView();
        private AudioEditorView aev = new AudioEditorView();

        public Core()
        {

        }

        public List<string> AssFile { get => ass_fullpath; set => ass_fullpath = value; }
        public List<string> VideoFile { get => video_fullpath; set => video_fullpath = value; }
        public List<string> AudioFile { get => audio_fullpath; set => audio_fullpath = value; }
        public Csass CSASS { get => ca; }
        public bool UseAudio { get => useAudio; set => useAudio = value; }
        public bool UseVideo { get => useVideo; set => useVideo = value; }
        public MediaInfoWrapper MediaInfo { get => MI; }


        public void CoreResize(AtomicMainForm atomicFrame)
        {
            if(atomicFrame.FirstInit == true)
            {
                // Loading
                atomicFrame.PanelTop.Controls.Add(vev);
                atomicFrame.PanelBottom.Controls.Add(subtitlesTable);
                atomicFrame.PanelTop.Controls.Add(aev);

                // Settings
                subtitlesTable.Dock = DockStyle.Fill;
                int aWidth = atomicFrame.Width - 16;
                int aHeight = atomicFrame.Height - 2;
                atomicFrame.PanelTop.Width = aWidth;
                atomicFrame.PanelMiddle.Width = aWidth;
                atomicFrame.PanelBottom.Width = aWidth;

                // Subtitles resize
                atomicFrame.PanelBottom.Location = new System.Drawing.Point(0, (aHeight - atomicFrame.ToolbarTop.Height) * 2 / 3);
                atomicFrame.PanelBottom.Height = aHeight / 3;

                // MiddleToolbar resize
                atomicFrame.PanelMiddle.Location = new System.Drawing.Point(0, (aHeight - atomicFrame.ToolbarTop.Height) * 2 / 3 - atomicFrame.ToolbarMiddle.Height);
                atomicFrame.PanelMiddle.Height = atomicFrame.ToolbarMiddle.Height;

                // Top (Video + Wave + Editing) resize
                atomicFrame.PanelTop.Location = new System.Drawing.Point(0, atomicFrame.ToolbarTop.Height);
                atomicFrame.PanelTop.Height = aHeight - atomicFrame.PanelBottom.Height - atomicFrame.ToolbarMiddle.Height - atomicFrame.ToolbarTop.Height;
                
                // Now it's loaded
                atomicFrame.FirstInit = false;
            }
            else
            {
                // Size
                int aWidth = atomicFrame.Width - 16;
                int aHeight = atomicFrame.Height - 2;
                atomicFrame.PanelTop.Width = aWidth;
                atomicFrame.PanelMiddle.Width = aWidth;
                atomicFrame.PanelBottom.Width = aWidth;

                // Subtitles resize
                atomicFrame.PanelBottom.Location = new System.Drawing.Point(0, (aHeight - atomicFrame.ToolbarTop.Height) * 2 / 3);
                atomicFrame.PanelBottom.Height = aHeight / 3;

                // MiddleToolbar resize
                atomicFrame.PanelMiddle.Location = new System.Drawing.Point(0, (aHeight - atomicFrame.ToolbarTop.Height) * 2 / 3 - atomicFrame.ToolbarMiddle.Height);
                atomicFrame.PanelMiddle.Height = atomicFrame.ToolbarMiddle.Height;

                // Top (Video + Wave + Editing) resize
                atomicFrame.PanelTop.Location = new System.Drawing.Point(0, atomicFrame.ToolbarTop.Height);
                atomicFrame.PanelTop.Height = aHeight - atomicFrame.PanelBottom.Height - atomicFrame.ToolbarMiddle.Height - atomicFrame.ToolbarTop.Height;

            }

            if (AssFile.Count > 0)
            {
                if(subtitlesTable.GetColumnsCount() == 0)
                {
                    subtitlesTable.AddLineNumberColumn("#");
                    subtitlesTable.AddColumn(Column.Create(typeof(string), "Type", 20));
                    subtitlesTable.AddColumn(Column.Create(typeof(int), "Layer", 30));
                    subtitlesTable.AddColumn(Column.Create(typeof(string), "Start", 80));
                    subtitlesTable.AddColumn(Column.Create(typeof(string), "End", 80));
                    subtitlesTable.AddColumn(Column.Create(typeof(string), "Style"));
                    subtitlesTable.AddColumn(Column.Create(
                        typeof(CoolTableReadableObject), "Indice", 80, false, new CoolTableReadableRenderer()));
                    subtitlesTable.AddColumn(Column.Create(typeof(string), "Content", 2000));
                }

                if(subtitlesTable.GetLinesCount() < ca.Events.Count | subtitlesTable.GetLinesCount() == 0)
                {
                    ca.LoadASS(AssFile[0]); // TODO Complete the choice of list

                    CoolTableReadableObject obj = new CoolTableReadableObject();
                    obj.Subtitles = ca;

                    foreach (CA_Event ev in ca.Events)
                    {
                        subtitlesTable.AddRow(new object[] {
                            "",
                            ev.Comment == true ? "C" : "D",
                            ev.Layer,
                            ev.StartString,
                            ev.EndString,
                            ev.Style.ToString(),
                            obj,
                            ev.Text
                        }) ;
                    }
                }

                if (VideoFile != null && VideoFile.Count > 0)
                {
                    if(vev.Core == null)
                    {
                        MI = new MediaInfoWrapper(VideoFile[0]);
                        vev.Core = this;
                    }

                    vev.Location = new System.Drawing.Point(0, 0);
                    int videoWidth = atomicFrame.PanelTop.Height * 16 / 9;
                    vev.Size = new System.Drawing.Size(videoWidth, atomicFrame.PanelTop.Height);

                    vev.Frame = 300;

                    vev.Refresh();

                    // Now work for audio searching
                    // 1. If we have an audio file specified
                    // 2. If we have embedded audio streams

                    if (AudioFile != null && AudioFile.Count > 0)
                    {
                        aev.Location = new System.Drawing.Point(vev.Width, 0);

                    }
                    else
                    {
                        AudioDetector a_detector = new AudioDetector(VideoFile[0]);
                        int audio_count = a_detector.AudioList.Count;

                        if (audio_count > 0)
                        {
                            MessageBox.Show("There is " + audio_count + " audio " + (audio_count > 1 ? "tracks" : "track"));
                            FFmpegAutoGenWrapper wr = new FFmpegAutoGenWrapper(this);
                            wr.GetWav(VideoFile[0]);
                        }
                    }

                }
                else if (AudioFile != null && AudioFile.Count > 0)
                {
                    aev.Location = new System.Drawing.Point(0, 0);

                }
            }
        }

    }
}
