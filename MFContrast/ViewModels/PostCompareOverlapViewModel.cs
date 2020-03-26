using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MFContrast.Models;
using MFContrast.Services;
using Xamarin.Forms;

namespace MFContrast.ViewModels
{
    public class PostCompareOverlapViewModel : BaseViewModel
    {
        public PostCompareModel PostCompareModel;

        public Grid UniqueHoldings;
        public Grid UniqueHoldingsHeader;
        public StackLayout UniqueHoldingsLayout;

        // public ObservableCollection<string> Unique1;
        // public ObservableCollection<string> Unique2;

        public Command LoadItemsCommandOne { get; set; }
        public Command LoadItemsCommandTwo { get; set; }



        public PostCompareOverlapViewModel(PostCompareModel compareModel)

        {
            PostCompareModel = compareModel;
            // LoadItemsCommandOne = new Command(async () => await ExecuteLoadItemsCommandOne());
            // LoadItemsCommandTwo = new Command(async () => await ExecuteLoadItemsCommandTwo());

        }
        /*
        async Task ExecuteLoadItemsCommandOne()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Unique1.Clear();

                var uniques = await CalculatePostCompare.CalculateUniqueHoldings1(PostCompareModel.Fund1, PostCompareModel.Fund2);
                foreach (var unique in uniques)
                {
                    Unique1.Add(unique);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadItemsCommandTwo()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Unique2.Clear();

                var uniques = await CalculatePostCompare.CalculateUniqueHoldings2(PostCompareModel.Fund1, PostCompareModel.Fund2);
                foreach (var unique in uniques)
                {
                    Unique2.Add(unique);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        */
    }
}
