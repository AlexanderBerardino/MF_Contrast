using System.Collections.Generic;
using MFContrast.Models;

namespace MFContrast.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public List<FAQ> FAQ_List { get; set; }

        public AboutViewModel()
        {
            Title = "About";

            FAQ_List = new List<FAQ>
            {
                new FAQ
                {
                    Question = "What is each page for?",
                    Answer = "When opening the application, you have access to three pages: Browse, Compare and About. " +
                    "The Compare page contains the functionality for comparing two mutual funds."
                },
                 new FAQ
                {
                    Question = "How do I use the compare functionality?",
                    Answer = "Use the picker selectors to choose two mutual funds and click the 'Compare' Button."
                },
                  new FAQ
                {
                    Question = "Where does this data come from?",
                    Answer = "This data comes from Wharton Research Data Services, the global standard for business research."
                },
                   new FAQ
                {
                    Question = "How often are the funds updated?",
                    Answer = "Every quarterly update."
                },
                    new FAQ
                {
                    Question =  "Are all fund assets present?",
                    Answer = "Currently only the first 100 biggest holdings in each fund are being indexed, " +
                    "but if the fund contains less than 100 holdings, all will be indexed."
                }
            };
        }
    }
}