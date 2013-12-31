using Jakub.Skoczen.RPNCalculator.Operations;
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
        private StackCache _stackCache;
        private bool _line1EditMode = true;
        private bool _enterPressed = false;

        public RPNCalc()
        {
            InitializeComponent();
            _stack = new Stack<StackElement>();
            _stackCache = new StackCache();
            FillCalcDisplay();
            this.BringToFront();
            this.Focus();
            this.KeyPreview = true;
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

        #region NumbersButtons

        private void btnZero_Click(object sender, EventArgs e)
        {
            NumberButtonClicked(sender);
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
        #endregion

        private void btnEnter_Click(object sender, EventArgs e)
        {
            EnterClicked();
        }

        private void EnterClicked()
        {
            SaveStackState();
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
            SaveStackState();
          
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

        private string GetValueFromStack(List<StackElement> s)
        {
            if (s.Count() > 0)
            {
                string val = s[s.Count - 1].Value;
                s.Remove(s[s.Count - 1]);
                return val;
            }
            else
                return String.Empty;
        }

        private void btnComa_Click(object sender, EventArgs e)
        {
            //Line1Label.Text = Properties.Resources.EditLabel;          
            //Line1.Text = ((Button)sender).Text + Line1.Text;
            NumberButtonClicked(sender);
        }

        private void ToFewArgumentsMessage()
        {
            MessageBox.Show("To few arguments");
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            OneArgumentOperation(sender);
        }

        private void OneArgumentOperation(object sender)
        {
            try
            {
                IOperation op = GetOperation(((Button)sender).Text);

                if (_line1EditMode)
                {
                    Line1Label.Text = Properties.Resources.Line1Label;
                    _line1EditMode = false;
                    _stack.Push(new StackElement(Line1.Text));
                }
                if (_stack.Count >= 1)
                {
                    StackElement e1 = _stack.Pop();
                    _stack.Push(op.Operate(e1, null));
                    FillCalcDisplay();
                    _enterPressed = true;
                }
                else
                    ToFewArgumentsMessage();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void TwoArgumentOperation(object sender)
        {
            try
            {
                IOperation op = GetOperation(((Button)sender).Text);
                if (_line1EditMode)
                {
                    Line1Label.Text = Properties.Resources.Line1Label;
                    _line1EditMode = false;
                    _stack.Push(new StackElement(Line1.Text));
                }
                if (_stack.Count >= 2)
                {                  
                    SaveStackState();
                    StackElement e2 = _stack.Pop();
                    StackElement e1 = _stack.Pop();
                    _stack.Push(op.Operate(e1, e2));
                    FillCalcDisplay();
                    _enterPressed = true;
                }
                else
                    ToFewArgumentsMessage();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }       

        private void SwapTwoStackElements(object sender)
        {
       
            SaveStackState();
            if (_line1EditMode)
            {
                Line1Label.Text = Properties.Resources.Line1Label;
                _line1EditMode = false;
                _stack.Push(new StackElement(Line1.Text));
            }

            if (_stack.Count >= 2)
            {
                StackElement e2 = _stack.Pop();
                StackElement e1 = _stack.Pop();
                _stack.Push(e2);
                _stack.Push(e1);
                FillCalcDisplay();
                _enterPressed = true;
            }
            else
                ToFewArgumentsMessage();

        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            TwoArgumentOperation(sender);
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            new DateForm().ShowDialog();
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            new TimeForm().ShowDialog();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            SwapTwoStackElements(sender);
        }

        private void btnInvertSign_Click(object sender, EventArgs e)
        {
            OneArgumentOperation(sender);
        }

        private void btnVat_Click(object sender, EventArgs e)
        {
            OneArgumentOperation(sender);
        }

        private void btnOneDivX_Click(object sender, EventArgs e)
        {
            OneArgumentOperation(sender);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            TwoArgumentOperation(sender);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            TwoArgumentOperation(sender);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            TwoArgumentOperation(sender);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            TwoArgumentOperation(sender);
        }

        private IOperation GetOperation(string op)
        {
            switch (op)
            {
                case Constants.Add:
                    return new Add();
                case Constants.Sub:
                    return new Sub();
                case Constants.Div:
                    return new Div();
                case Constants.Mul:
                    return new Mul();
                case Constants.InvertSign:
                    return new InvertSign();
                case Constants.Inv:
                    return new Inv();
                case Constants.Pow:
                    return new Pow();
                case Constants.Sqrt:
                    return new Sqrt();
                case Constants.Vat:
                    return new Vat();
                default:
                    break;
            }
            return new Add();
        }

        private void RPNCalc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    NumberButtonClicked(btnZero);
                    break;

                case Keys.D1:
                case Keys.NumPad1:
                    NumberButtonClicked(btnOne);
                    break;

                case Keys.D2:
                case Keys.NumPad2:
                    NumberButtonClicked(btnTwo);
                    break;

                case Keys.D3:
                case Keys.NumPad3:
                    NumberButtonClicked(btnThree);
                    break;

                case Keys.D4:
                case Keys.NumPad4:
                    NumberButtonClicked(btnFour);
                    break;

                case Keys.D5:
                case Keys.NumPad5:
                    NumberButtonClicked(btnFive);
                    break;

                case Keys.D6:
                case Keys.NumPad6:
                    NumberButtonClicked(btnSix);
                    break;

                case Keys.D7:
                case Keys.NumPad7:
                    NumberButtonClicked(btnSeven);
                    break;

                case Keys.D8:
                case Keys.NumPad8:
                    NumberButtonClicked(btnEight);
                    break;

                case Keys.D9:
                case Keys.NumPad9:
                    NumberButtonClicked(btnNine);
                    break;

                case Keys.Enter:
                    EnterClicked();
                    break;

                case Keys.Add:
                    TwoArgumentOperation(btnPlus);
                    break;

                case Keys.Subtract:
                    TwoArgumentOperation(btnMinus);
                    break;

                case Keys.Divide:
                    TwoArgumentOperation(btnDiv);
                    break;

                case Keys.Multiply:
                    TwoArgumentOperation(btnMul);
                    break;

                case Keys.Oemcomma:
                case Keys.Decimal:
                    NumberButtonClicked(btnComa);
                    break;

                case Keys.Back:
                    btnDrop_Click(null, null);
                    break;

                default:
                    break;
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _stack = new Stack<StackElement>(_stackCache.GetCache());
            FillCalcDisplay();
        }

        private void SaveStackState()
        {
            _stackCache = new StackCache(_stack);
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            _stack = new Stack<StackElement>();
            _enterPressed = false;
            Line1Label.Text = Properties.Resources.Line1Label;
            FillCalcDisplay();
        }

    }
}
