using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Forum.Utilities
{
    public static class Utils
    {
        public static String GetWebConfigParameter(string appSetting)
        {
            String result = ConfigurationManager.AppSettings[appSetting];

            return result;
        }

        public static ViewResult GetErrorViewResult(ViewDataDictionary viewData, string errorMessage)
        {
            if (viewData == null)
                viewData = new ViewDataDictionary();

            if (!String.IsNullOrEmpty(errorMessage))
                viewData.Add("ErrorMessage", errorMessage);

            return new ViewResult()
            {
                ViewName = "Error",
                ViewData = viewData
            };
        }

        public static async Task SendBySendGridAsync(string to, string from, string subject, string body, Dictionary<string, string> keywords = null, string absoluteTemplateFilePath = null, List<AttachmentViewModel> attachmentsStream = null)
        {
            var apiKey = ConfigurationManager.AppSettings["SendGridKey"].ToString();
            var client = new SendGridClient(apiKey);
            var source = new EmailAddress(from);
            var destination = new EmailAddress(to);

            #region protection

            if (ConfigurationManager.AppSettings["TestEmail"] != null && ConfigurationManager.AppSettings["TestEmail"].ToString() != String.Empty)
            {
                destination.Email = ConfigurationManager.AppSettings["TestEmail"].ToString();
            }

            if (ConfigurationManager.AppSettings["CancelMailNotification"] != null && Convert.ToBoolean(ConfigurationManager.AppSettings["CancelMailNotification"]))
                return;

            #endregion

            var htmlContent = body ?? ReplaceKeyValue(keywords, ReadFile(absoluteTemplateFilePath));
            var msg = MailHelper.CreateSingleEmail(source, destination, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public static string ReadFile(string absolutFilePath)
        {
            string result = string.Empty;
            try
            {
                result = System.IO.File.ReadAllText(absolutFilePath);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        public static string ReplaceKeyValue(Dictionary<string, string> keywords, string content)
        {
            //string result = string.Empty;

            foreach (KeyValuePair<string, string> kv in keywords)
                content = content.Replace(kv.Key, kv.Value);

            return content;
        }

        /// <summary>
        /// Return template filepath depending the culture
        /// </summary>
        /// <param name="fileName">File name with extension</param>
        /// <returns></returns>
        public static string MailTemplateFilePath(string fileName)
        {
            string filePath = string.Empty;
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            string culture = CultureInfo.CurrentCulture.Name;

            filePath = Path.Combine(basePath, string.Format("Content\\MailTemplates\\{0}", culture), fileName);

            return filePath;
        }

        #region TESTING
        //public static string getIPAddress(HttpRequestBase request)
        //{
        //    string szRemoteAddr = request.UserHostAddress;
        //    string szXForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];
        //    string szIP = "";

        //    if (szXForwardedFor == null)
        //    {
        //        szIP = szRemoteAddr;
        //    }
        //    else
        //    {
        //        szIP = szXForwardedFor;
        //        if (szIP.IndexOf(",") > 0)
        //        {
        //            string[] arIPs = szIP.Split(',');

        //            foreach (string item in arIPs)
        //            {
        //                if (!IsPrivateIP(item))
        //                {
        //                    return item;
        //                }
        //            }
        //        }
        //    }
        //    return szIP;
        //}

        //private static bool IsPrivateIP(string ipAddress)
        //{
        //    int[] ipParts = ipAddress.Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries)
        //                             .Select(s => int.Parse(s)).ToArray();
        //    // in private ip range
        //    if (ipParts[0] == 10 ||
        //        (ipParts[0] == 192 && ipParts[1] == 168) ||
        //        (ipParts[0] == 172 && (ipParts[1] >= 16 && ipParts[1] <= 31)))
        //    {
        //        return true;
        //    }

        //    // IP Address is probably public.
        //    // This doesn't catch some VPN ranges like OpenVPN and Hamachi.
        //    return false;
        //}

        #endregion

    }

    public class AttachmentViewModel
    {
        public string Content { get; set; }
        public string ContentId { get; set; }
        public string Disposition { get; set; }
        public string Filename { get; set; }
        public string Type { get; set; }
    }
}
