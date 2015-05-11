using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScrapTwitter
{
    public partial class Followers : System.Web.UI.Page
    {
        private string UrlValue = string.Empty;
        private int counter = 1;
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        private string GetAccountHolder(string username)
        {
            var webGet = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDoc = webGet.Load("https://mobile.twitter.com/" + username);
            htmlDoc.OptionFixNestedTags = true;


            string classToFind = "fullname";
            var allElementsWithClassFloat = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));


            string fullname = "fullname";
            string screenname = "screen-name";

            var findbyFullName = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[1]/table[1]/tr[1]/td[2]/div[1]");
            var UserscreenName = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", screenname));
            var follower = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[1]/table[2]/tr[1]/td[3]/a[1]/div[1]");
            var following = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[1]/table[2]/tr[1]/td[2]/a[1]/div[1]");

            var twitterUser = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[1]/table[1]/tr[1]/td[2]/div[1]");

            Label5.Text = follower.InnerText;
            Label4.Text = following.InnerText;
            Label1.Text = findbyFullName.InnerText;
            //Label7.Text = following.ToString();
            //follower.Text = follower.ToString();
            //following.Text = following.ToString();
            //Label2.Text = following.ToString();



            var result = "";
            if (allElementsWithClassFloat != null)
            {
                foreach (HtmlNode div in allElementsWithClassFloat)
                {
                    result = div.InnerText + "</br>";
                }
                GetFollowing(username);
                return result;

            }
            else
            {
                return "Not found";
            }
        }

        private string GetFollowing(string username)
        {
            var webGet = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument htmlDoc = webGet.Load("https://mobile.twitter.com/" + username + "/followers");
            htmlDoc.OptionFixNestedTags = true;
            string classToFind = "fullname";
            string twittername = "username";
            var allElementsWithClassFloat = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));
            var twitterids = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", twittername));


            var result = "";
            if (allElementsWithClassFloat != null)
            {
                foreach (HtmlNode div in allElementsWithClassFloat)
                {
                    result = div.InnerText;
                    Label2.Text += counter + ". " + result + " " + "</br>";
                    counter++;


                }
                foreach (HtmlNode div in twitterids)
                {
                    result = div.InnerText;
                    Label3.Text += result + " " + "</br>";
                    // counter++;


                }


                var urlString = "https://mobile.twitter.com/" + username + "/followers?cursor=";
                UrlValue = findurlValue(username);

                while (UrlValue != null)
                {
                    var url = urlString + UrlValue;
                    GetNextFollowerList(url);
                    hasMorebutton(url);

                    UrlValue = NetxUrlCursur(url);
                }
                return result;
            }
            else
            {
                return "z";
            }
        }

        private string findurlValue(string username)
        {

            var webGet = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument htmlDoc = webGet.Load("https://mobile.twitter.com/" + username + "/followers");
            htmlDoc.OptionFixNestedTags = true;
            string classToFind = "w-button-more";
            var allElementsWithClassFloat = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));
            string myresult = "";

            if (allElementsWithClassFloat != null)
            {
                foreach (HtmlNode div in allElementsWithClassFloat)
                {
                    myresult = (div.InnerHtml).Split('?').Single(x => x.StartsWith("cursor=")).Substring(3);

                    return DigitsOnly(myresult);
                }
            }
            else
            {
                return myresult = string.Empty;
            }


            return " No Result found";

        }

        public static string DigitsOnly(string strRawData)
        {
            return Regex.Replace(strRawData, "[^0-9]", "");
        }
        private string RunURL(string url)
        {
            return null;
        }


        private string GetNextFollowerList(string url)
        {
            var webGet = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument htmlDoc = webGet.Load(url);
            htmlDoc.OptionFixNestedTags = true;
            // string classToFind = "w-button-more";
            // var allElementsWithClassFloat = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));
            //var myresult = "";



            //if (allElementsWithClassFloat != null)
            //{
            //    foreach (HtmlNode div in allElementsWithClassFloat)
            //    {

            //        myresult = div.InnerText;
            //        Label2.Text += counter + ". " + myresult + " " + "</br>";
            //        counter++;
            //    }
            // return myresult;
            string classToFindFollwer = "fullname";
            var NextFollower = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFindFollwer));
            string twittername = "username";
            var twitterids = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", twittername));

            var resultQuery = "";
            if (NextFollower != null)
            {
                foreach (HtmlNode div in NextFollower)
                {
                    resultQuery = div.InnerText;
                    Label2.Text += counter + ". " + resultQuery + " " + "</br>";
                    counter++;
                }

                foreach (HtmlNode div in twitterids)
                {
                    resultQuery = div.InnerText;
                    Label3.Text += resultQuery + " " + "</br>";
                    counter++;


                }


                return resultQuery;
            }
            return resultQuery;

        }

        private bool hasMorebutton(string url)
        {
            var webGet = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument htmlDoc = webGet.Load(url);
            htmlDoc.OptionFixNestedTags = true;
            string classToFind = "w-button-more";
            var moreButton = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));




            if (moreButton != null)
            {
                return true;
            }
            else
            {
                UrlValue = null;
            }
            return false;
        }

        private string NetxUrlCursur(string url)
        {

            var webGet = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument htmlDoc = webGet.Load(url);
            htmlDoc.OptionFixNestedTags = true;
            string classToFind = "w-button-more";
            var allElementsWithClassFloat = htmlDoc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));
            string myresult = "";

            if (allElementsWithClassFloat != null)
            {
                foreach (HtmlNode div in allElementsWithClassFloat)
                {
                    myresult = (div.InnerHtml).Split('?').Single(x => x.StartsWith("cursor=")).Substring(3);

                    return DigitsOnly(myresult);
                }
            }
            else
            {
                return myresult = null;
            }


            return " No Result found";

        }

        protected void btnquery_Click(object sender, EventArgs e)
        {
            var useraccount = txtquery.Text;

            GetAccountHolder(useraccount);
        }
    }
}