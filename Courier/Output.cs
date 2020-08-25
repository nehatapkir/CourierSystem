using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Courier
{
    public partial class Output : Form
    {
        public Output()
        {
            InitializeComponent();
        }

        public List<CalculateDeliveryCost.PricePerBox> CurrentPricePerBox
        {
            get
            {
                return bindingSource1.DataSource as List<CalculateDeliveryCost.PricePerBox>;
            }
            set
            {
                bindingSource1.DataSource = value;
            }
        }

        public CalculateDeliveryCost.Receipt CurrentOutput
        {
            get
            {
                return bindingSource2.DataSource as CalculateDeliveryCost.Receipt;
            }
            set
            {
                bindingSource2.DataSource = value;
            }
        }
    }
}
