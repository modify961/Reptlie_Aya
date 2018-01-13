using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Base.Common
{
    public class Mail
    {
        ///发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="strSmtpServer">邮件服务器。如smtp.sohu.com</param>
        /// <param name="strFrom">发件人邮箱</param>
        /// <param name="strUserID">发送者用户名</param>
        /// <param name="strPwd">发送者密码</param>
        /// <param name="strTo">收件人邮箱</param>
        /// <param name="strSubject">邮件主题</param>
        /// <param name="strBody">邮件正文</param>
        public static void SendMail(string strSmtpServer, string strFrom, string strUserID, string strPwd, string strTo, string strSubject, string strBody)
        {
            SmtpClient client = new SmtpClient(strSmtpServer);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(strUserID, strPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(strFrom);
            message.To.Add(new MailAddress(strTo));
            message.Subject = strSubject;
            message.Body = strBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        ///发送错误报告
        /// <summary>
        /// 发送错误报告
        /// </summary>
        /// <param name="Body">邮件正文</param>
        public static void SendMail(string Body)
        {
            SmtpClient client = new SmtpClient("smtp.sohu.com");
            client.Credentials = new System.Net.NetworkCredential("ID", "PWD");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ID@sohu.com", "错误报告");
            message.To.Add(new MailAddress("@qq.com", "小林子"));
            message.Subject = "错误报告";
            message.Body = System.DateTime.Now.ToString() + Body;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
