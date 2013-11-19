using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jakub.Skoczen.RPNCalculator
{
    public partial class RPNCalc : Form
    {
        private Stack<StackElement> _stack;
        private StackCache<StackElement> _stackCache;

        public RPNCalc()
        {
            InitializeComponent();
            _stack = new Stack<StackElement>();
            _stackCache = new StackCache<StackElement>();            
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void NumberButtonCliceked(object sender)
        {
            Line1.Text += ((Button)sender).Text;
            Line1Label.Text = Properties.Resources.EditLabel;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            NumberButtonCliceked(sender);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Line1.Text))
                _stack.Push(new StackElement(Line1.Text));
            Line1Label.Text = Properties.Resources.Line1Label;
        }

    

     
    }
}
