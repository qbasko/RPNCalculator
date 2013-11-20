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
        private StackCache<Stack<StackElement>> _stackCache;
        private bool _line1EditMode = false;
        private bool _enterPressed = false;

        public RPNCalc()
        {
            InitializeComponent();
            _stack = new Stack<StackElement>();
            _stackCache = new StackCache<Stack<StackElement>>();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void NumberButtonClicked(object sender)
        {
            
            Line1Label.Text = Properties.Resources.EditLabel;
            _line1EditMode = true;
            if (_enterPressed)
            {                
                FillCalcDisplayFromButton();
                Line1.Text = String.Empty;
                _enterPressed = false;
            }
            Line1.Text += ((Button)sender).Text;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            _stackCache = new StackCache<Stack<StackElement>>(_stack);

            if (!String.IsNullOrEmpty(Line1.Text))
                _stack.Push(new StackElement(Line1.Text));
            Line1Label.Text = Properties.Resources.Line1Label;
            Line1.Text = String.Empty;
            FillCalcDisplay();
            _enterPressed = true;
            _line1EditMode = false;
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            _stackCache = new StackCache<Stack<StackElement>>(_stack);
            if (_line1EditMode && !String.IsNullOrEmpty(Line1.Text))
                Line1.Text = Line1.Text.Substring(0, Line1.Text.Length - 1);
            else
            {
                
                _line1EditMode = false;
                Line1Label.Text = Properties.Resources.Line1Label;
                
                if (_enterPressed)
                {
                    if (_stack.Count > 0)
                        _stack.Pop();
                 
                    _enterPressed = false;
                }
                _enterPressed = true;
                FillCalcDisplay();
            }
           
        }

        private void FillCalcDisplay()
        {
            List<StackElement> tempStack = _stack.ToList();
            tempStack.Reverse();
            Line1.Text = GetValueFromStack(tempStack);
            Line2.Text = GetValueFromStack(tempStack);
            Line3.Text = GetValueFromStack(tempStack);
            Line4.Text = GetValueFromStack(tempStack);
        }

        private void FillCalcDisplayFromButton()
        {
            List<StackElement> tempStack = _stack.ToList();
            tempStack.Reverse(); 
            //Line1.Text = GetValueFromStack(tempStack);
            Line2.Text = GetValueFromStack(tempStack);
            Line3.Text = GetValueFromStack(tempStack);
            Line4.Text = GetValueFromStack(tempStack);
        }

        //private string GetValueFromStack(Stack<StackElement> s)
        //{
        //    if (s.Count > 0)
        //        return s.Pop().Value;
        //    else
        //        return String.Empty;
        //}

        private string GetValueFromStack(List<StackElement> s)
        {
            if (s.Count() > 0)
            {
                string val= s[s.Count - 1].Value;
                s.Remove(s[s.Count - 1]);
                return val;
            }
            else
                return String.Empty;
        }

        private void btnComa_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
        }
    }
}
