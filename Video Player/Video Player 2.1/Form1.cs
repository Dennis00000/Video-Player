using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Player_2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
         using(OpenFileDialog ofd=new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv"})
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach (string filename in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(filename);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fi.FullName });
                    }
                    listFiles.DataSource = files;
                }
            }
         }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listFiles.SelectedItem as MediaFile;
            if (file != null)
            {
                axWindowsMediaPlayer1.URL = file.Path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
      private void Form1_Load(object sender, EventArgs e)
    {
        listFiles.ValueMember = "Path";
        listFiles.DisplayMember = "FileName";
    }
    }
}
