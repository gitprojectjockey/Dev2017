using System.Net;
using System.Net.Mail;
using System.Text;
using OnlineShoppingStore.Domain.Abstract;


namespace OnlineShoppingStore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private Entities.EmailSettings emailSettings;

        public EmailOrderProcessor(Entities.EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Entities.Cart cart, Entities.ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials= new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                StringBuilder emailBody = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");
                foreach (var line in cart.CartItems)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    emailBody.AppendFormat("{0} x {1} (subtotal: {2:c})\n",
                        line.Quantity,
                        line.Product.Name,
                        subtotal);
                }
                emailBody.AppendFormat("Total order value: {0:c}",
                    cart.ComputeTotalPrice())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.AddressLine1)
                    .AppendLine(shippingInfo.AddressLine2 ?? "")
                    .AppendLine(shippingInfo.AddressLine3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.State ?? "")
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");
                MailMessage mailMessage = new MailMessage(new MailAddress(emailSettings.MailFromAddress).Address,
                    new MailAddress(emailSettings.MailToAddress).Address,
                    "New order submitted!",
                    emailBody.ToString());

                smtpClient.Send(mailMessage);
            }
        }
    }
}
