using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length==0)
            {
                resultLabel.Text = "Please enter a name.";
                resultLabel.Visible = true;
                return;
            }
            if (addressTextBox.Text.Trim().Length == 0)
            {
                resultLabel.Text = "Please enter an address.";
                resultLabel.Visible = true;
                return;
            }
            if (zipTextBox.Text.Trim().Length == 0)
            {
                resultLabel.Text = "Please enter a zipcode.";
                resultLabel.Visible = true;
                return;
            }
            if (phoneTextBox.Text.Trim().Length == 0)
            {
                resultLabel.Text = "Please enter a contact phone number.";
                resultLabel.Visible = true;
                return;
            }

            try
            {
                var order = buildOrder();
                Domain.OrderManager.CreateOrder(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
                resultLabel.Visible = true;
                return;
            }

        }

        private DTO.OrderDTO buildOrder()
        {
            var order = new DTO.OrderDTO();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onion = onionsCheckBox.Checked;
            order.GreenPepper = peppersCheckBox.Checked;
            order.Name = nameTextBox.Text;
            order.Address = addressTextBox.Text;
            order.Zipcode = zipTextBox.Text;
            order.Phone = phoneTextBox.Text;
            order.PaymentType = determinePaymentType();
            return order;
        }
        private DTO.Enums.Sizes determineSize()
        {
            DTO.Enums.Sizes size;
            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            {
                throw new Exception("Please select a pizza size.");
            }
            return size;
        }

        private DTO.Enums.Crusts determineCrust()
        {
            DTO.Enums.Crusts crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            {
                throw new Exception("Please select a crust type.");
            }
            return crust;
        }
        
        private DTO.Enums.PaymentType determinePaymentType()
        {
            DTO.Enums.PaymentType payment;
            if (cashRadioButton.Checked)
            {
                payment = DTO.Enums.PaymentType.Cash;
            }
            else if (creditRadioButton.Checked)
            {
                payment = DTO.Enums.PaymentType.Credit;
            }
            else if (giftCardRadioButton.Checked)
            {
                payment = DTO.Enums.PaymentType.GiftCard;
            }
            else
            {
                throw new Exception("Please select a payment method.");
            }
            return payment;
        }
        
        protected void recalculateTotalCost(object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == String.Empty) return;
            if (crustDropDownList.SelectedValue == String.Empty) return;
            var order = buildOrder();
            try
            {
                totalLabel.Text = Domain.PizzaPriceManager.CalculatePizzaPrice(order).ToString("C");
            }
            catch 
            {

                //swallow the error (Exception ex)throw;
            }

        }

    }
}