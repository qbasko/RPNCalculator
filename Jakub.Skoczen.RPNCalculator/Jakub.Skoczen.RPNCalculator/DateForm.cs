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
    public partial class DateForm : Form
    {
        public DateForm()
        {
            InitializeComponent();
            resultLabel.Text = String.Empty;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTimePickerFrom.Value.Date;
            DateTime dateTo = dateTimePickerTo.Value.Date;           
            TimeSpan ts = dateFrom - dateTo;
            resultLabel.Text = String.Format("{0} days",Math.Abs(ts.TotalDays)); 
        }

        private void DateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
