using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace mfb
{
    class Facebook
    {
        static string userAgent = "Mozilla/2.0 (Windows NT 6.1; WOW64;) Gecko/20100101 Firefox/11.0";

        CookieCollection myLoginCookies;

        private Facebook(CookieCollection cok)
        {
            myLoginCookies = cok;
        }

        public string GetHtml(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(myLoginCookies);
            request.UserAgent = userAgent;
            request.KeepAlive = false;
            request.AllowAutoRedirect = true;
            request.Timeout = 45000;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string html = sr.ReadToEnd();

            return html;
        }

        public static Facebook Login(string username, string password)
        {
            CookieCollection myLoginCookies = new CookieCollection();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.facebook.com/");
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(myLoginCookies);
            request.UserAgent = userAgent;
            request.KeepAlive = false;
            request.Timeout = 45000;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            myLoginCookies.Add(response.Cookies);

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string mainHTML = sr.ReadToEnd();
            string html = mainHTML;
            html = html.Substring(html.IndexOf("login_form"));
            html = html.Remove(html.IndexOf("/form"));
            Regex reg = new Regex(@"name=""[^""]+"" value=""[^""]+""");
            MatchCollection mc = reg.Matches(html);
            List<string> values = new List<string>();
            string postData = "";
            for (int k = 0; k < mc.Count; k++)
            {
                if (k != 0)
                    postData += "&";
                if (k == 1)
                {
                    postData += "email=" + username + "&pass=" + password + "&";
                }
                string m = mc[k].Value.Replace("\"", "");
                m = m.Replace("name=", "");
                m = m.Replace(" value=", "=");
                postData += m;
            }

            string getUrl = "https://www.facebook.com/login.php?login_attempt=1";

            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            getRequest.CookieContainer = new CookieContainer();
            getRequest.CookieContainer.Add(myLoginCookies); //recover myLoginCookies First request
            getRequest.Method = WebRequestMethods.Http.Post;
            getRequest.UserAgent = userAgent;
            getRequest.AllowWriteStreamBuffering = true;
            getRequest.ProtocolVersion = HttpVersion.Version11;
            getRequest.AllowAutoRedirect = false;
            getRequest.ContentType = "application/x-www-form-urlencoded";
            getRequest.Referer = "https://www.facebook.com";
            getRequest.KeepAlive = false;

            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            getRequest.ContentLength = byteArray.Length;
            Stream newStream = getRequest.GetRequestStream(); //open connection
            newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
            newStream.Close();

            HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
            myLoginCookies.Add(getResponse.Cookies);

            if (myLoginCookies.Count > 6)
            {
                return new Facebook(myLoginCookies);
            }
            else
            {
                MessageBox.Show("Failed To Login, Check Your Browser");
            }
            return null;
        }

        public bool StatusUpdate(string txt)
        {
            string url = "https://m.facebook.com/home.php";
            CookieCollection cok = new CookieCollection();
            cok.Add(myLoginCookies);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cok);
            request.UserAgent = userAgent;
            request.KeepAlive = false;
            request.Timeout = 45000;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            cok.Add(response.Cookies);

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string mainHTML = sr.ReadToEnd();
            string html = mainHTML.Replace("&quot;", "\"");
            html = html.Replace(@"\/", "/");
            html = html.Replace(@"\u0025", "%");
            html = html.Replace("&amp;", "&");
            html = html.Replace("&quot;", "\"");

            if (html.Contains("id=\"composer_form"))
            {
                Regex regAct = new Regex("action=\"(/a/[^\"]+?)\"");
                Match matAct = regAct.Match(html);
                string action = "https://m.facebook.com" + (matAct.Groups[1].Value);

                html = html.Substring(html.IndexOf("id=\"composer_form"));
                html = html.Remove(html.IndexOf("form>"));

                Regex reg = new Regex(@"name=""([^""]+)"" value=""([^""]+)""");
                MatchCollection mc = reg.Matches(html);
                List<string> values = new List<string>();
                string postData = "";
                List<string> names = new List<string>() { "fb_dtsg", "charset_test", "target", "xhpc_timeline" };
                if (url.Contains("/home.php"))
                    names.RemoveRange(2, 2);

                for (int k = 0; k < mc.Count; k++)
                {
                    if (names.Contains(mc[k].Groups[1].Value))
                    {
                        string m = mc[k].Value.Replace("\"", "");
                        m = m.Replace("name=", "");
                        m = m.Replace(" value=", "=");
                        postData += m + "&";
                    }
                }

                if (url.Contains("/home.php"))
                    postData += "status=" + txt;
                else
                    postData += "message=" + txt;


                HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(action);
                getRequest.CookieContainer = new CookieContainer();
                getRequest.CookieContainer.Add(cok); //recover cookies First request
                getRequest.Method = WebRequestMethods.Http.Post;
                getRequest.UserAgent = userAgent;
                getRequest.AllowWriteStreamBuffering = true;
                getRequest.ProtocolVersion = HttpVersion.Version11;
                getRequest.AllowAutoRedirect = false;
                getRequest.ContentType = "application/x-www-form-urlencoded";
                getRequest.Referer = "https://www.facebook.com";

                byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                getRequest.ContentLength = byteArray.Length;
                Stream newStream = getRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

                HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
                cok.Add(getResponse.Cookies);

                return true;
            }
            return false;
        }

        public void UploadPhoto(string filepath, string caption)
        {
            CookieCollection cok = new CookieCollection();
            cok.Add(myLoginCookies);

            FileInfo fi = new FileInfo(filepath);
            string paramName = "file1";
            string fileName = fi.Name;
            string contentType = "image/" + fi.Extension.Replace(".", "");

            //requesting upload page
            string url = "https://m.facebook.com/photos/upload/";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(cok);
            req.AllowAutoRedirect = true;
            req.UserAgent = userAgent;

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            cok.Add(resp.Cookies);
            StreamReader sr = new StreamReader(resp.GetResponseStream());

            string html = sr.ReadToEnd();
            string action = "https://upload.facebook.com/_mupload_/composer/?site_category=m_basic";

            Regex reg = new Regex("(?<=action=\")[^\"]+upload[^\"]+");
            Match mAction = reg.Match(html);
            if (mAction.Value != "")
                action = mAction.Value.Replace("&amp;", "&");

            reg = new Regex(@"name=""[^""]+"" value=""[^""]+""");
            MatchCollection mc = reg.Matches(html);
            List<string> values = new List<string>();
            foreach (Match m in mc)
            {
                string s = m.Value.Replace(" value=\"", "\r\n\r\n");
                s = s.Remove(s.LastIndexOf("\""));
                values.Add(s);
            }
            values.Add("name=\"target\"\r\n\r\n");
            values.Add("name=\"caption\"\r\n\r\n" + caption);

            //preparing data to send
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(action);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.KeepAlive = true;
            wr.CookieContainer = new CookieContainer();
            wr.CookieContainer.Add(cok); //recover cookies First request
            wr.Method = WebRequestMethods.Http.Post;
            wr.UserAgent = userAgent;
            wr.AllowWriteStreamBuffering = true;
            wr.ProtocolVersion = HttpVersion.Version11;
            wr.AllowAutoRedirect = true;
            wr.Referer = url;

            //sending data
            Stream rs = wr.GetRequestStream();
            string formdataTemplate = "Content-Disposition: form-data; ";
            foreach (string v in values)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = formdataTemplate + v;
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            //prepairing file for upload
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, fileName, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            //uploading file
            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            //closing upload
            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();


            HttpWebResponse wresp = (HttpWebResponse)wr.GetResponse();
            string h = new StreamReader(wresp.GetResponseStream()).ReadToEnd();
        }

        public DataTable SearchGroups(string keyword, int scount)
        {
            //Dictionary<string, string> ids = new Dictionary<string, string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("GroupId");
            dt.Columns.Add("GroupName");

            string url = "https://m.facebook.com/search/?query=" + keyword + "&search=group&s=" + scount.ToString();
            //string url = "https://m.facebook.com/search/?search=group&search_source=search_bar&query=" + keyword + "&=search";

            string html = GetHtml(url);
            html = html.Replace(@"\/", "/");
            html = html.Replace(@"\u0025", "%");
            html = html.Replace("&amp;", "&");
            html = html.Replace("&quot;", "\"");

            Regex reg = new Regex("/groups/([0-9]{6,30})[^>]+>([^<]+)");
            MatchCollection mc = reg.Matches(html);

            List<string> keys = new List<string>();
            foreach (Match m in mc)
            {
                if (!keys.Contains(m.Groups[1].Value))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = m.Groups[1].Value;
                    dr[1] = m.Groups[2].Value;
                    //ids.Add(m.Groups[1].Value, m.Groups[2].Value);
                    dt.Rows.Add(dr);
                    keys.Add(m.Groups[1].Value);
                }
            }

            //return ids;
            return dt;
        }

        public DataTable LoadGroups()
        {
            //Dictionary<string, string> ids = new Dictionary<string, string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("GroupId");
            dt.Columns.Add("GroupName");

            string url = "https://m.facebook.com/browsegroups/?category=membership";
            //string url = "https://m.facebook.com/search/?search=group&search_source=search_bar&query=" + keyword + "&=search";

            string html = GetHtml(url);
            html = html.Replace(@"\/", "/");
            html = html.Replace(@"\u0025", "%");
            html = html.Replace("&amp;", "&");
            html = html.Replace("&quot;", "\"");

            Regex reg = new Regex("/groups/([0-9]{6,30})[^>]+>([^<]+)");
            MatchCollection mc = reg.Matches(html);

            List<string> keys = new List<string>();
            foreach (Match m in mc)
            {
                if (!keys.Contains(m.Groups[1].Value))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = m.Groups[1].Value;
                    dr[1] = m.Groups[2].Value;
                    //ids.Add(m.Groups[1].Value, m.Groups[2].Value);
                    dt.Rows.Add(dr);
                    keys.Add(m.Groups[1].Value);
                }
            }

            //return ids;
            return dt;
        }

        public Dictionary<string, string> SearchPages(string keyword, int scount)
        {
            Dictionary<string, string> ids = new Dictionary<string, string>();

            string url = "https://m.facebook.com/search/?query=" + keyword + "&search=page&s=" + scount.ToString();
            string html = GetHtml(url);
            html = html.Replace(@"\/", "/");
            html = html.Replace(@"\u0025", "%");
            html = html.Replace("&amp;", "&");
            html = html.Replace("&quot;", "\"");

            Regex reg = new Regex("<td class=\"name\"><a href=\"([^\"]+)\">([^<]+)<");
            MatchCollection mc = reg.Matches(html);

            List<string> keys = new List<string>();
            foreach (Match m in mc)
            {
                string u = m.Groups[1].Value;
                if (u.Contains("&searchloggerdata"))
                    u = u.Remove(u.IndexOf("&searchloggerdata"));
                if (u.Contains("?searchloggerdata"))
                    u = u.Remove(u.IndexOf("?searchloggerdata"));
                if (!keys.Contains(u))
                {
                    ids.Add(u, m.Groups[2].Value);
                    keys.Add(u);
                }
            }

            return ids;
        }
    }
}