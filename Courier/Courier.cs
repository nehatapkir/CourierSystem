using CalculateDeliveryCost;
using Courier.ViewModel;
using System;
using System.Windows.Forms;

namespace Courier
{
    public partial class Courier : Form
    {
        ICalculateOrderPrice calculateOrderPrice;
        Box box;
        Order order;

        public Courier()
        {
            InitializeComponent();
            InitSources();
        }

        private void InitSources()
        {
            box = new Box();
            CurrentOrder = new Order();
            boxBindingSource.DataSource = box;
            calculateOrderPrice = new CalculateOrderPrice(CurrentOrder);
        }

        private Order CurrentOrder
        {
            get
            {
                return (bindingSourceOrder.DataSource as Order);
            }
            set
            {
                bindingSourceOrder.DataSource = value;
            }
        }

        private void addBox_Click(object sender, EventArgs e)
        {
            var box = boxBindingSource.DataSource as Box;
            calculateOrderPrice.AddBoxToCurrentOrder(box);

            MessageBox.Show("Added box successfully");
            boxBindingSource.DataSource = new Box();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var output = calculateOrderPrice.CalculateTotalOrderPrice();

            Output outputForm = new Output();
            outputForm.CurrentPricePerBox = output.PricePerBoxes;
            outputForm.CurrentOutput = output;
            outputForm.Show();
            InitSources();
        }
    }
}
