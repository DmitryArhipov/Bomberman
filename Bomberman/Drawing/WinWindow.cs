using System;
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
        
        
        protected override void OnClosed(EventArgs e)
        {
            Environment.Exit(0);
        }
        
        protected override CreateParams CreateParams 
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            } 
        }
    }
}