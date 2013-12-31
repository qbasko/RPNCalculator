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
    public partial class TimeForm : Form
    {
        public TimeForm()
        {
            InitializeComponent();
            resultLabel.Text = String.Empty;
            dateTimePickerFrom.ShowUpDown = true;
            dateTimePickerTo.ShowUpDown = true;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            TimeSpan timeFrom = dateTimePickerFrom.Value.TimeOfDay;
            TimeSpan timeTo = dateTimePickerTo.Value.TimeOfDay;
            TimeSpan ts = timeFrom - timeTo;
          
            
            resultLabel.Text = String.Format("{0}:{1}:{2}", Math.Abs(ts.Hours), Math.Abs(ts.Minutes), Math.Abs(ts.Seconds)); 
        }

        
    }
}
