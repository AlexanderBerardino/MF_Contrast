using System;
using MFContrast.Models;

namespace MFContrast.ViewModels
{
    public class AboutDetailViewModel : BaseViewModel
    {
        public FAQ DetailFAQ { get; set; }
        public string Answer => DetailFAQ.Answer;

        public AboutDetailViewModel(FAQ faq)
        {
            DetailFAQ = faq;
        }
    }
}
