using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MedLink.Logic.Models;

namespace medLinkMaui.ViewModel
{
    [QueryProperty("Patient", "Patient")]   
    public partial class PatientDetailsViewModel : BaseViewModel
    {
        public PatientDetailsViewModel()
        {         
        }

        [ObservableProperty]
        Patient patient;
    }
}
