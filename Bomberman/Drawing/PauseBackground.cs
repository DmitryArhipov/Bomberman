using System;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class PauseBackground : Form
    {
        private Pause pause; 
        
        public PauseBackground()
        {
            InitializeComponent();
        }

        public PauseBackground(Pause pause)
        {
            this.pause = pause;
            InitializeComponent();
            ClientSize = this.pause.ClientSize;
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