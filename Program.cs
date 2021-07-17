using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SMTPUtility
{
    class Program
    {
        public static void Main(string[] args)
        {
            //file in disk
            var FileUrl = @"C:\DEV\projects\SMTPUtility\data\Addresses.txt";
            string[] lines = File.ReadAllLines(FileUrl);
            var addressList = new List<string>();
            foreach (string line in lines)
            {
                var lineList = new List<string>();
                lineList = line.Trim().Split(',').Where(x => x != "").ToList();
                addressList.AddRange(lineList);
            }

            foreach (var address in addressList)
            {
                // Command-line argument must be the SMTP host.
                try{
                SmtpClient smtpClient = new SmtpClient("hostname");
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("From email address",
                                            "FirstName " + (char)0xD8 + " LastName", System.Text.Encoding.UTF8),
                    Subject = "subject",
                    Body = "<h1>Hello</h1>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(address);
                mailMessage.Body = "This is a test email message sent by an application using address from notepad. ";
                smtpClient.Send(mailMessage);
                smtpClient.Dispose();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
