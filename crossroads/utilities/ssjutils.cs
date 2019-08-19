using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Crossroads.utilities
{
    public class ssjutils
    {
        static readonly string PasswordHash = "M3thod!$t";
        static readonly string SaltKey = "Cr0$$r0@d$";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public static bool SendEmail(string From, string to, string subject, string body, MailPriority priority = MailPriority.Normal, string attachment = "")
        {
            var sInfo = string.Empty;
            sInfo += "<html>";
            sInfo += "<style>";
            sInfo += "  body, th, td { font-size: 12px; font-family: arial, tahoma, verdana; }";
            sInfo += "  .messageTitle { font-size: 1.5em; }";
            sInfo += "  .margin-5 { margin: 5px; }";
            sInfo += "  .padding-20 { padding: 20px; }";
            sInfo += "</style>";
            sInfo += "<body>";

            sInfo += body;

            sInfo += "</body>";
            sInfo += "</html>";

            var bResult = true;
            var message = new MailMessage();
            var client = new SmtpClient();
            message.From = new MailAddress(From);

            if (to.Contains(","))
            {
                foreach (var em in to.Split(','))
                {
                    message.To.Add(new MailAddress(em));
                }
            }
            else
            {
                message.To.Add(new MailAddress(to));
            }

            message.Subject = subject;
            message.Body = sInfo;
            message.IsBodyHtml = true;
            message.Priority = priority;

            client.Host = "mail.ssjhost.com";
            client.Port = 25;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["adminEmail"], ConfigurationManager.AppSettings["adminEmailPassword"]);
            client.EnableSsl = false;
            try
            {
                var urlPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
                if (urlPath.ToLower().Contains("localhost"))
                {
                    bResult = true;
                }
                else
                {
                    client.Send(message);
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                var errorMsg = new MailMessage();
                errorMsg.From = new MailAddress(ConfigurationManager.AppSettings["adminEmail"]);
                errorMsg.To.Add(new MailAddress(ConfigurationManager.AppSettings["adminEmail"]));
                errorMsg.Subject = "SMTPError";
                errorMsg.Body = ex.InnerException.ToString();

                var newClient = new SmtpClient();
                newClient.Host = "mail.ssjhost.com";
                newClient.Port = 25;
                newClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["adminEmail"], ConfigurationManager.AppSettings["adminEmailPassword"]);
                newClient.EnableSsl = false;

                newClient.Send(errorMsg);

                bResult = false;
            }

            return bResult;
        }

        public static string GetSafeFileName(string fileName)
        {
            var strFileName = string.Empty;
            strFileName = fileName.Replace(" ", "_");

            return strFileName;
        }

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }

                memoryStream.Close();
            }

            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}