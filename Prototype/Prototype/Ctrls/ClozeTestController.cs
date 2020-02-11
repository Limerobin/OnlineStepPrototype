using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Prototype.Models;
using Newtonsoft.Json;

namespace Prototype.Ctrls
{
    class ClozeTestController
    {
        private const string url = "http://users.du.se/~h17najse/Android/assignment/ClozeTest.php";
        private RestClient.RestClient_Alpha RestClient;
        private readonly Label SentenceLbl;
        private readonly StackLayout MyLayout;
        private Button SendBtn;
        private List<ClozeTest> Sentences;
        private ClozeTest Sentence;
        private int Index = 0;
        private Entry EntryAnswer;
        private string LabelValue;

        public ClozeTestController(StackLayout Layout, Label Lbl, Button Btn, Entry answer)
        {
            this.MyLayout = Layout;
            this.SentenceLbl = Lbl;
            this.SendBtn = Btn;
            this.EntryAnswer = answer;
        }

        public void ShowSentence()
        {
            //Instantiation of our RestClient object
            RestClient = new RestClient.RestClient_Alpha { EndPoint = url };
            string Response = RestClient.DoRequest();
            Console.WriteLine(Response.ToString());
            Sentences = JsonConvert.DeserializeObject<List<ClozeTest>>(Response);           
            DoTransitions();
        }

        private string ModifiedSentence()
        {
            string Value = null;
            Sentence.MissingWords.RemoveAll(item => item == null);
            foreach(var i in Sentence.MissingWords)
            {
                if (Sentence.Sentence.Contains(i))
                {
                    Value = Sentence.Sentence.Replace(i, "______");                   
                    Console.WriteLine(i);
                }
            }
            return Value;
        }
  

        private void DoTransitions()
        {
            Sentence = Sentences[Index];
            LabelValue = ModifiedSentence();
            SentenceLbl.Text = LabelValue;          
            SendBtn.Clicked += SendBtnAction;
        }

        private void SendBtnAction(object sender, EventArgs e)
        {
            Console.WriteLine("Hey");
            foreach(var i in Sentence.MissingWords)
            {
                if (EntryAnswer.Text.Equals(i))
                {
                    Index++;
                    Sentence = Sentences[Index];
                    Console.WriteLine("Correct");
                    LabelValue = FillBack();
                    RefreshSentence();
                }
            }
        }

        private void RefreshSentence()
        {
            SentenceLbl.Text = LabelValue;
        }

        private string FillBack()
        {
            string Value = Sentence.Sentence.Replace("______", EntryAnswer.Text);
            return Value;
        }
    }
}
