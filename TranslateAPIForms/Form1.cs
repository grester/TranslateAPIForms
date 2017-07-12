using System;
using System.Windows;
using System.Net;
using System.Web;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Translator.Samples;
using System.Data.SqlClient;


namespace TranslateAPIForms
{
    public partial class Form1 : Form
    {
        // Before running the application, input the secret key for your subscription to Translator Text Translation API.
        //private const string TEXT_TRANSLATION_API_SUBSCRIPTION_KEY = "f25c0d27622240d29357a5fa0be7191e";

        // Object to get an authentication token
        private AzureAuthToken tokenProvider;
        // Cache language friendly names
        private string[] friendlyName = { " " };
        // Cache list of languages for speech synthesis
        //private List<string> speakLanguages;
        // Dictionary to map language code from friendly name
        private Dictionary<string, string> languageCodesAndTitles = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTransl_Click(object sender, EventArgs e)
        {
            tokenProvider = new AzureAuthToken(tbAuthkey.Text);
            string languageCode = cbLang.Text;
            // languageCodesAndTitles.TryGetValue(cbLang.Text, out languageCode); //get the language code from the dictionary based on the selection in the combobox

            if (languageCode == null || languageCode.Equals(""))  //in case no language is selected.
            {
                languageCode = "en";
                LogOut.Text = "Inglês por defeito";
            }
            else
            {
                LogOut.Text = string.Empty;
            }


            //*****BEGIN CODE TO MAKE THE CALL TO THE TRANSLATOR SERVICE TO PERFORM A TRANSLATION FROM THE USER TEXT ENTERED

            string txtToTranslate = tbT2t.Text;

            tbTransl.Text = translate(txtToTranslate, languageCode);

        }
        private string translate(string txtToTranslate, string languageCode)
        {


            string uri = string.Format("http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(txtToTranslate) + "&to={0}", languageCode);

            WebRequest translationWebRequest = WebRequest.Create(uri);

            translationWebRequest.Headers.Add("Authorization", tokenProvider.GetAccessToken()); //header value is the "Bearer plus the token from ADM

            WebResponse response = null;

            response = translationWebRequest.GetResponse();

            Stream stream = response.GetResponseStream();

            Encoding encode = Encoding.GetEncoding("utf-8");

            StreamReader translatedStream = new StreamReader(stream, encode);

            System.Xml.XmlDocument xTranslation = new System.Xml.XmlDocument();

            xTranslation.LoadXml(translatedStream.ReadToEnd());

            String text = xTranslation.InnerText;
            text = HttpUtility.HtmlEncode(text);
            text = text.Replace("&lt;p&gt;", "<p>");
            text = text.Replace("&lt;/p&gt;", "</p>");
            return text;
        }

        /*  public MainWindow()
          {
              InitializeComponent();
              tokenProvider = new AzureAuthToken(TEXT_TRANSLATION_API_SUBSCRIPTION_KEY);
              GetLanguagesForTranslate(); //List of languages that can be translated
              GetLanguageNamesMethod(tokenProvider.GetAccessToken(), friendlyName); //Friendly name of languages that can be translated            
              enumLanguages(); //Create the drop down list of langauges
          }*/

        //*****POPULATE COMBOBOX*****
        /*   private void enumLanguages()
           {
               //run a loop to load the combobox from the dictionary
               var count = languageCodesAndTitles.Count;

               for (int i = 0; i < count; i++)
               {
                   cbLang.Items.Add(languageCodesAndTitles.ElementAt(i).Key);
               }
           }*/

        //*****BUTTON TO START TRANSLATION PROCESS
        private void translateButton_Click(object sender, EventArgs e)
        {


            /*if (speakLanguages.Contains(languageCode) && txtToTranslate != "")
            {
                //call the method to speak the translated text
                SpeakMethod(tokenProvider.GetAccessToken(), xTranslation.InnerText, languageCode);
            }*/
        }

        //*****CODE TO GET TRANSLATABLE LANGAUGE CODES*****
        private void GetLanguagesForTranslate()
        {

            string uri = "http://api.microsofttranslator.com/v2/Http.svc/GetLanguagesForTranslate";
            WebRequest WebRequest = WebRequest.Create(uri);
            WebRequest.Headers.Add("Authorization", tokenProvider.GetAccessToken());

            WebResponse response = null;

            try
            {
                response = WebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {

                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(List<string>));
                    List<string> languagesForTranslate = (List<string>)dcs.ReadObject(stream);
                    friendlyName = languagesForTranslate.ToArray(); //put the list of language codes into an array to pass to the method to get the friendly name.

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }


        //*****CODE TO GET TRANSLATABLE LANGAUGE FRIENDLY NAMES FROM THE TWO CHARACTER CODES*****
        private void GetLanguageNamesMethod(string authToken, string[] languageCodes)
        {
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/GetLanguageNames?locale=en";
            // create the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", tokenProvider.GetAccessToken());
            request.ContentType = "text/xml";
            request.Method = "POST";
            System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String[]"));
            using (System.IO.Stream stream = request.GetRequestStream())
            {
                dcs.WriteObject(stream, languageCodes);
            }
            WebResponse response = null;
            try
            {
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    string[] languageNames = (string[])dcs.ReadObject(stream);

                    for (int i = 0; i < languageNames.Length; i++)
                    {

                        languageCodesAndTitles.Add(languageNames[i], languageCodes[i]); //load the dictionary for the combo box

                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            /*
            tokenProvider = new AzureAuthToken("f25c0d27622240d29357a5fa0be7191e");
            GetLanguagesForTranslate(); //List of languages that can be translated
            GetLanguageNamesMethod(tokenProvider.GetAccessToken(), friendlyName); //Friendly name of languages that can be translated            
            enumLanguages(); //Create the drop down list of langauges
            */
        }

        private void buttonTranslateAgenda_Click(object sender, EventArgs e)
        {
            LogOut.Text = "initiating connection";
            
            SqlConnection myConnection = new SqlConnection("user id=ELVIO-TOSH\\Elvio;" +
                                       "password=;server=ELVIO-TOSH\\SQLExpress;" +
                                       "Trusted_Connection=yes;" +
                                       "database=DESCUBRA_BD;" +
                                       "connection timeout=120");

            //Data Source = tcp:k22x2gwhfr.database.windows.net,1433; Initial Catalog = DESCUBRA_BD; User ID = wit5@k22x2gwhfr; Password = @worldit2008

            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                tbTransl.Text = ex.ToString() + "   falha abrir connection";
                MessageBox.Show("falha abrir connection");
            }
            MessageBox.Show("This operation will make changes to your database.\n\rAre you sure you want to continue?");
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from tbl_translate_agenda where language_id=1", myConnection);

                myReader = myCommand.ExecuteReader();
                System.Collections.ArrayList sqlCommandList = new System.Collections.ArrayList();


                tokenProvider = new AzureAuthToken(tbAuthkey.Text);
                //*****BEGIN CODE TO MAKE THE CALLS TO THE TRANSLATOR SERVICE TO PERFORM A TRANSLATION for each row*****
                tbTransl.Text = String.Empty;
                tbTransl2.Text = String.Empty;
                tbTransl3.Text = String.Empty;
                tbTransl4.Text = String.Empty;

                string languageCode = "";
                int lID;
                int agenda_id = 0;
                string queryUpdate = "";
                string description = "";
                string title = "";
                string subtitle = "";
                string editorHTML = "";
                int rows_Affected;


                while (myReader.Read())
                {
                    lID = Convert.ToInt32(myReader["language_id"]);
                    agenda_id = Convert.ToInt32(myReader["agenda_id"]);

                    languageCode = "en";


                    description = translate(myReader["description"].ToString(), languageCode);
                    if (description.Equals(""))
                    {
                        description = null;
                    }
                    tbTransl.Text += description;
                    tbTransl.Text += System.Environment.NewLine;

                    title = translate(myReader["title"].ToString(), languageCode);
                    if (title.Equals(""))
                    {
                        title = null;
                    }
                    tbTransl2.Text += title;
                    tbTransl2.Text += System.Environment.NewLine;

                    subtitle = translate(myReader["subtitle"].ToString(), languageCode);
                    if (subtitle.Equals(""))
                    {
                        subtitle = null;
                    }
                    tbTransl3.Text += subtitle;
                    tbTransl3.Text += System.Environment.NewLine;

                    editorHTML = translate(myReader["editorHTML"].ToString(), languageCode);
                    if (editorHTML.Equals(""))
                    {
                        editorHTML = null;
                    }
                    tbTransl4.Text += editorHTML;
                    tbTransl4.Text += System.Environment.NewLine;


                    queryUpdate = "UPDATE tbl_translate_agenda" + " " +
                        "SET " +
                        "description = " + "'" + description + "'" + "," +
                        "title = " + "'" + title + "'" + "," +
                        "subtitle = " + "'" + subtitle + "'" + " " + "," +
                        "editorHTML = " + "'" + editorHTML + "'" + " " +

                        "WHERE language_id = 2 " +
                        "AND agenda_id = " + agenda_id + ";";

                    LogOut.Text = queryUpdate;
                    sqlCommandList.Add(queryUpdate);

                }
                myConnection.Close();
                LogOut.Text = sqlCommandList.Count.ToString() +  "rows translated";


                myConnection.Open();
                
                foreach (string _cmd in sqlCommandList)
                {
                    SqlCommand updateRow = new SqlCommand(_cmd, myConnection);
                    rows_Affected = updateRow.ExecuteNonQuery();
                }
                myConnection.Close();
                MessageBox.Show("Update concluded");
            }
            catch (Exception ex)
            {
                myConnection.Close();
                MessageBox.Show("   falha ler colunas, " + ex.ToString());

            }
        }

        private void buttonTranslateInfo_Click(object sender, EventArgs e)
        {
            LogOut.Text = "initiating connection";
            SqlConnection myConnection = new SqlConnection("user id=ELVIO-TOSH\\Elvio;" +
                                       "password=;server=ELVIO-TOSH\\SQLExpress;" +
                                       "Trusted_Connection=yes;" +
                                       "database=DESCUBRA_BD;" +
                                       "connection timeout=120");
            //Data Source = tcp:k22x2gwhfr.database.windows.net,1433; Initial Catalog = DESCUBRA_BD; User ID = wit5@k22x2gwhfr; Password = @worldit2008
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                tbTransl.Text = ex.ToString() + "   falha abrir connection";
                MessageBox.Show("falha abrir connection");
            }
            MessageBox.Show("This operation will make changes to your database.\n\rAre you sure you want to continue?");
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from tbl_translate_info where language_id=1", myConnection);
                myReader = myCommand.ExecuteReader();
                System.Collections.ArrayList sqlCommandList = new System.Collections.ArrayList();


                tokenProvider = new AzureAuthToken(tbAuthkey.Text);
                //*****BEGIN CODE TO MAKE THE CALLS TO THE TRANSLATOR SERVICE TO PERFORM A TRANSLATION for each row*****
                tbTransl.Text = String.Empty;
                tbTransl2.Text = String.Empty;
                tbTransl3.Text = String.Empty;
                tbTransl4.Text = String.Empty;

                string languageCode = "";
                int lID;
                int info_id;
                string queryUpdate = "";

                string restaurantHTML = "";
                string description = "";
                string subtitle = "";
                int rows_Affected;


                while (myReader.Read())
                {
                    lID = Convert.ToInt32(myReader["language_id"]);
                    info_id = Convert.ToInt32(myReader["info_id"]);
                    languageCode = "en";


                    restaurantHTML = translate(myReader["restaurantHTML"].ToString(), languageCode);
                    if (restaurantHTML.Equals(""))
                    {
                        restaurantHTML = null;
                    }
                    tbTransl.Text += restaurantHTML;
                    tbTransl.Text += System.Environment.NewLine;

                    description = translate(myReader["description"].ToString(), languageCode);
                    if (description.Equals(""))
                    {
                        description = null;
                    }
                    tbTransl2.Text += description;
                    tbTransl2.Text += System.Environment.NewLine;

                    subtitle = translate(myReader["subtitle"].ToString(), languageCode);
                    if (subtitle.Equals(""))
                    {
                        subtitle = null;
                    }
                    tbTransl3.Text += subtitle;
                    tbTransl3.Text += System.Environment.NewLine;

                    queryUpdate = "UPDATE tbl_translate_info" + " " +
                        "SET " +
                        "restaurantHTML = " + "'" + restaurantHTML + "'" + "," +
                        "description = " + "'" + description + "'" + "," +
                        "subtitle = " + "'" + subtitle + "'" + " " +

                        "WHERE language_id = 2 " +
                        "AND info_id = " + info_id + ";";
                    LogOut.Text = queryUpdate;
                    sqlCommandList.Add(queryUpdate);


                }
                myConnection.Close();

                LogOut.Text = sqlCommandList.Count.ToString() + "rows translated";

                myConnection.Open();
                foreach (string _cmd in sqlCommandList)
                {
                    SqlCommand updateRow = new SqlCommand(_cmd, myConnection);
                    rows_Affected = updateRow.ExecuteNonQuery();
                }
                myConnection.Close();
                MessageBox.Show("Update concluded");


            }
            catch (Exception ex)
            {
                LogOut.Text = ex.ToString() + "   falha ler colunas";
                myConnection.Close();
                MessageBox.Show("   falha ler colunas, " + ex.ToString());

            }
        }

        private void buttonTranslateRoteiro_Click(object sender, EventArgs e)
        {
            LogOut.Text = "initiating connection";
            SqlConnection myConnection = new SqlConnection("user id=ELVIO-TOSH\\Elvio;" +
                                       "password=;server=ELVIO-TOSH\\SQLExpress;" +
                                       "Trusted_Connection=yes;" +
                                       "database=DESCUBRA_BD;" +
                                       "connection timeout=120");
            //Data Source = tcp:k22x2gwhfr.database.windows.net,1433; Initial Catalog = DESCUBRA_BD; User ID = wit5@k22x2gwhfr; Password = @worldit2008
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                tbTransl.Text = ex.ToString() + "   falha abrir connection";
                MessageBox.Show("   falha abrir connection, " + ex.ToString());
            }
            MessageBox.Show("This operation will make changes to your database.\n\rAre you sure you want to continue?");
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from tbl_translate_roteiro where language_id = 1", myConnection);
                myReader = myCommand.ExecuteReader();
                System.Collections.ArrayList sqlCommandList = new System.Collections.ArrayList();


                tokenProvider = new AzureAuthToken(tbAuthkey.Text);
                //*****BEGIN CODE TO MAKE THE CALLS TO THE TRANSLATOR SERVICE TO PERFORM A TRANSLATION for each row*****
                tbTransl.Text = String.Empty;
                tbTransl2.Text = String.Empty;
                tbTransl3.Text = String.Empty;
                tbTransl4.Text = String.Empty;

                string languageCode = "";
                int lID;
                int roteiro_id;
                string queryUpdate = "";

                string name = "";
                string subtitle = "";
                string editorHTML = "";
                int rows_Affected;


                while (myReader.Read())
                {
                    lID = Convert.ToInt32(myReader["language_id"]);
                    roteiro_id = Convert.ToInt32(myReader["roteiro_id"]);
                    languageCode = "en";

                    name = translate(myReader["name"].ToString(), languageCode);
                    if (name.Equals(""))
                    {
                        name = null;
                    }
                    tbTransl.Text += name;
                    tbTransl.Text += System.Environment.NewLine;

                    subtitle = translate(myReader["subtitle"].ToString(), languageCode);
                    if (subtitle.Equals(""))
                    {
                        subtitle = null;
                    }
                    tbTransl2.Text += subtitle;
                    tbTransl2.Text += System.Environment.NewLine;

                    editorHTML = translate(myReader["editorHTML"].ToString(), languageCode);
                    if (editorHTML.Equals(""))
                    {
                        editorHTML = null;
                    }
                    tbTransl3.Text += editorHTML;
                    tbTransl3.Text += System.Environment.NewLine;

                    queryUpdate = "UPDATE tbl_translate_roteiro" + " " +
                        "SET " +
                        "name = " + "'" + name + "'" + "," +
                        "subtitle = " + "'" + subtitle + "'" + "," +
                        "editorHTML = " + "'" + editorHTML + "'" + " " +

                        "WHERE language_id = " + 2 + " " +
                        "AND roteiro_id = " + roteiro_id + ";";
                    LogOut.Text = queryUpdate;
                    sqlCommandList.Add(queryUpdate);


                }
                myConnection.Close();
                LogOut.Text = sqlCommandList.Count.ToString() + "rows translated";

                myConnection.Open();
                foreach (string _cmd in sqlCommandList)
                {
                    SqlCommand updateRow = new SqlCommand(_cmd, myConnection);
                    rows_Affected = updateRow.ExecuteNonQuery();
                }
                myConnection.Close();
                MessageBox.Show("Update concluded");
            }
            catch (Exception ex)
            {
                LogOut.Text = ex.ToString() + "   falha ler colunas";
                myConnection.Close();
                MessageBox.Show("   falha ler colunas, " + ex.ToString());

            }
        }

        private void buttonTranslateTag_Click(object sender, EventArgs e)
        {
            LogOut.Text = "initiating connection";
            SqlConnection myConnection = new SqlConnection("user id=ELVIO-TOSH\\Elvio;" +
                                       "password=;server=ELVIO-TOSH\\SQLExpress;" +
                                       "Trusted_Connection=yes;" +
                                       "database=DESCUBRA_BD;" +
                                       "connection timeout=120");
            //Data Source = tcp:k22x2gwhfr.database.windows.net,1433; Initial Catalog = DESCUBRA_BD; User ID = wit5@k22x2gwhfr; Password = @worldit2008
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                tbTransl.Text = ex.ToString() + "   falha abrir connection";
                MessageBox.Show("falha abrir connection");
            }
            MessageBox.Show("This operation will make changes to your database.\n\rAre you sure you want to continue?");
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from tbl_translate_tag where language_id=1", myConnection);
                myReader = myCommand.ExecuteReader();
                System.Collections.ArrayList sqlCommandList = new System.Collections.ArrayList();


                tokenProvider = new AzureAuthToken(tbAuthkey.Text);
                //*****BEGIN CODE TO MAKE THE CALLS TO THE TRANSLATOR SERVICE TO PERFORM A TRANSLATION for each row*****
                tbTransl.Text = String.Empty;
                tbTransl2.Text = String.Empty;
                tbTransl3.Text = String.Empty;
                tbTransl4.Text = String.Empty;

                string languageCode = "";
                int lID;
                int tag_id;
                string queryUpdate = "";
                string name = "";
                int rows_Affected;

                while (myReader.Read())
                {
                    lID = Convert.ToInt32(myReader["language_id"]);
                    tag_id = Convert.ToInt32(myReader["tag_id"]);
                    languageCode = "en";


                    name = translate(myReader["name"].ToString(), languageCode);
                    if (name.Equals(""))
                    {
                        name = null;
                    }
                    tbTransl.Text += name;
                    tbTransl.Text += System.Environment.NewLine;

                    queryUpdate = "UPDATE tbl_translate_tag" + " " +
                        "SET " +
                        "name = " + "'" + name + "'" + " " +

                        "WHERE language_id = " + 2 + " " +
                        "AND tag_id = " + tag_id + ";";

                    sqlCommandList.Add(queryUpdate);

                }
                myConnection.Close();

                LogOut.Text = sqlCommandList.Count.ToString() + "rows translated";

                myConnection.Open();
                foreach (string _cmd in sqlCommandList)
                {
                    SqlCommand updateRow = new SqlCommand(_cmd, myConnection);
                    rows_Affected = updateRow.ExecuteNonQuery();
                }
                myConnection.Close();
                MessageBox.Show("Update concluded");
            }
            catch (Exception ex)
            {
                LogOut.Text = ex.ToString() + "   falha ler colunas";
                myConnection.Close();
                MessageBox.Show("   falha ler colunas, " + ex.ToString());

            }
        }


    }
}
