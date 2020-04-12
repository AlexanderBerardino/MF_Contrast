using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MFContrast.Models;
using MFContrast.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MFContrast.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        // Dependency Injection for MutualFundDataStore
        public IMutualFundDataStore MutualFundDataStore =>
           DependencyService.Get<IMutualFundDataStore>() ?? new MutualFundDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        //event handler
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Function for adding funds to an observable collection
        // Executed through a Command property
        public async Task ExecuteLoadItemsCommand(ObservableCollection<MutualFund> Funds)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Funds.Clear();
                var funds = await MutualFundDataStore.GetItemsAsync();
                foreach (var fund in funds)
                {
                    Funds.Add(fund);
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
        #endregion
    }
}
