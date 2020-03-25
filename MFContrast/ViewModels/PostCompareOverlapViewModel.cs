using System;
using MFContrast.Models;
using MFContrast.Services;

namespace MFContrast.ViewModels
{
    public class PostCompareOverlapViewModel
    {
        public CalculatePostCompare CalculatePostCompare;

        public PostCompareOverlapViewModel(CalculatePostCompare calculatePostCompare)
        {
            CalculatePostCompare = calculatePostCompare;
        }
    }
}
