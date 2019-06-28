namespace Atomic.UI
{
    partial class ProjectForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubtitles = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnAudio = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkLoadAudio = new System.Windows.Forms.CheckBox();
            this.chkLoadVideo = new System.Windows.Forms.CheckBox();
            this.comboAudio = new System.Windows.Forms.ComboBox();
            this.comboSubs = new System.Windows.Forms.ComboBox();
            this.btnRemoveSubtitle = new System.Windows.Forms.Button();
            this.comboVideo = new System.Windows.Forms.ComboBox();
            this.btnRemoveAudio = new System.Windows.Forms.Button();
            this.btnRemoveVideo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveSubtitle);
            this.groupBox1.Controls.Add(this.comboSubs);
            this.groupBox1.Controls.Add(this.btnSubtitles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subtitle file";
            // 
            // btnSubtitles
            // 
            this.btnSubtitles.Location = new System.Drawing.Point(435, 11);
            this.btnSubtitles.Name = "btnSubtitles";
            this.btnSubtitles.Size = new System.Drawing.Size(75, 23);
            this.btnSubtitles.TabIndex = 2;
            this.btnSubtitles.Text = "Add";
            this.btnSubtitles.UseVisualStyleBackColor = true;
            this.btnSubtitles.Click += new System.EventHandler(this.BtnSubtitles_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveAudio);
            this.groupBox2.Controls.Add(this.btnRemoveVideo);
            this.groupBox2.Controls.Add(this.comboVideo);
            this.groupBox2.Controls.Add(this.comboAudio);
            this.groupBox2.Controls.Add(this.chkLoadVideo);
            this.groupBox2.Controls.Add(this.btnVideo);
            this.groupBox2.Controls.Add(this.chkLoadAudio);
            this.groupBox2.Controls.Add(this.btnAudio);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio / Video files";
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(435, 74);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(75, 23);
            this.btnVideo.TabIndex = 3;
            this.btnVideo.Text = "Add";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.BtnVideo_Click);
            // 
            // btnAudio
            // 
            this.btnAudio.Location = new System.Drawing.Point(435, 25);
            this.btnAudio.Name = "btnAudio";
            this.btnAudio.Size = new System.Drawing.Size(75, 23);
            this.btnAudio.TabIndex = 2;
            this.btnAudio.Text = "Add";
            this.btnAudio.UseVisualStyleBackColor = true;
            this.btnAudio.Click += new System.EventHandler(this.BtnAudio_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Video";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Audio";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(447, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(527, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // chkLoadAudio
            // 
            this.chkLoadAudio.AutoSize = true;
            this.chkLoadAudio.Checked = true;
            this.chkLoadAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoadAudio.Location = new System.Drawing.Point(79, 53);
            this.chkLoadAudio.Name = "chkLoadAudio";
            this.chkLoadAudio.Size = new System.Drawing.Size(239, 17);
            this.chkLoadAudio.TabIndex = 4;
            this.chkLoadAudio.Text = "Do you want to load audio from video if any ?";
            this.chkLoadAudio.UseVisualStyleBackColor = true;
            // 
            // chkLoadVideo
            // 
            this.chkLoadVideo.AutoSize = true;
            this.chkLoadVideo.Checked = true;
            this.chkLoadVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoadVideo.Location = new System.Drawing.Point(79, 103);
            this.chkLoadVideo.Name = "chkLoadVideo";
            this.chkLoadVideo.Size = new System.Drawing.Size(205, 17);
            this.chkLoadVideo.TabIndex = 4;
            this.chkLoadVideo.Text = "Do you want to load the video if any ?";
            this.chkLoadVideo.UseVisualStyleBackColor = true;
            // 
            // comboAudio
            // 
            this.comboAudio.FormattingEnabled = true;
            this.comboAudio.Location = new System.Drawing.Point(79, 27);
            this.comboAudio.Name = "comboAudio";
            this.comboAudio.Size = new System.Drawing.Size(350, 21);
            this.comboAudio.TabIndex = 5;
            // 
            // comboSubs
            // 
            this.comboSubs.FormattingEnabled = true;
            this.comboSubs.Location = new System.Drawing.Point(79, 13);
            this.comboSubs.Name = "comboSubs";
            this.comboSubs.Size = new System.Drawing.Size(350, 21);
            this.comboSubs.TabIndex = 5;
            // 
            // btnRemoveSubtitle
            // 
            this.btnRemoveSubtitle.Location = new System.Drawing.Point(516, 11);
            this.btnRemoveSubtitle.Name = "btnRemoveSubtitle";
            this.btnRemoveSubtitle.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSubtitle.TabIndex = 6;
            this.btnRemoveSubtitle.Text = "Remove";
            this.btnRemoveSubtitle.UseVisualStyleBackColor = true;
            this.btnRemoveSubtitle.Click += new System.EventHandler(this.BtnRemoveSubtitle_Click);
            // 
            // comboVideo
            // 
            this.comboVideo.FormattingEnabled = true;
            this.comboVideo.Location = new System.Drawing.Point(79, 76);
            this.comboVideo.Name = "comboVideo";
            this.comboVideo.Size = new System.Drawing.Size(350, 21);
            this.comboVideo.TabIndex = 4;
            // 
            // btnRemoveAudio
            // 
            this.btnRemoveAudio.Location = new System.Drawing.Point(515, 25);
            this.btnRemoveAudio.Name = "btnRemoveAudio";
            this.btnRemoveAudio.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAudio.TabIndex = 7;
            this.btnRemoveAudio.Text = "Remove";
            this.btnRemoveAudio.UseVisualStyleBackColor = true;
            this.btnRemoveAudio.Click += new System.EventHandler(this.BtnRemoveAudio_Click);
            // 
            // btnRemoveVideo
            // 
            this.btnRemoveVideo.Location = new System.Drawing.Point(516, 74);
            this.btnRemoveVideo.Name = "btnRemoveVideo";
            this.btnRemoveVideo.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveVideo.TabIndex = 6;
            this.btnRemoveVideo.Text = "Remove";
            this.btnRemoveVideo.UseVisualStyleBackColor = true;
            this.btnRemoveVideo.Click += new System.EventHandler(this.BtnRemoveVideo_Click);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 227);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSubtitles;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnAudio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkLoadAudio;
        private System.Windows.Forms.Button btnRemoveSubtitle;
        private System.Windows.Forms.ComboBox comboSubs;
        private System.Windows.Forms.ComboBox comboVideo;
        private System.Windows.Forms.ComboBox comboAudio;
        private System.Windows.Forms.CheckBox chkLoadVideo;
        private System.Windows.Forms.Button btnRemoveAudio;
        private System.Windows.Forms.Button btnRemoveVideo;
    }
}