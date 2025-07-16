using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace medLinkMaui.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isbusy;   

        public bool IsNotBusy => !Isbusy;       
    }
}
