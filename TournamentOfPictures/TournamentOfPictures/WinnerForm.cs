﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TournamentOfPictures
{
    public partial class WinnerForm : Form
    {
        private string filePath;
		private List<ScoredItem<string>> standings;
		private List<string> playlistOrder;

        public WinnerForm()
        {
            InitializeComponent();
        }

        public void ShowWinner(string path, IEnumerable<ScoredItem<string>> standings, IEnumerable<string> playlistOrder)
        {
			filePath = path;
			this.standings = standings.OrderByDescending(i => i.Score).ToList();
			this.playlistOrder = playlistOrder.ToList();
			pictureBox1.Image = ImageLoader.LoadImage(path);
            if (pictureBox1.Image.Width < pictureBox1.Width && pictureBox1.Image.Height < pictureBox1.Height)
            {
				pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
				pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
			label2.Text = string.Format("File at {0} (click to open)", path);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Program Files (x86)\\IrfanView\\i_view32.exe";
            process.StartInfo.Arguments = filePath;
            process.Start();
        }

		private void LLbViewStandings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			new StandingsForm(standings, playlistOrder).ShowDialog();
		}
    }
}
