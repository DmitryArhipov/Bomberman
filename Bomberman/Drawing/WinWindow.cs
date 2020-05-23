using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class WinWindow : Form
    {
        public WinWindow()
        {
            InitializeComponent();
        }
        
        private void CloseButton_Click(object sender, EventArgs e) => Application.Exit();
        
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }
    }
}