using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MedLink.Logic.Models;
using MedLink.Logic.Services;

namespace medLinkMaui.ViewModel
{
    public partial class PatientViewModel : BaseViewModel
    {
        PatientsService patientsService;   
        public ObservableCollection<Patient> Patients { get; } = new();

        public PatientViewModel(PatientsService patientsService)
        {
            Title = "Patients";
            this.patientsService = patientsService;
        }

        [RelayCommand]
        async Task GetPatientsAsync()
        {
            if (Isbusy)
                return;

            try
            {
                Isbusy = true;
                var patients = await patientsService.GetAllAsync();

                if (Patients.Count != 0)
                    Patients.Clear();

                foreach (var patient in patients)
                {
                    Patients.Add(patient); 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get patients: {ex.Message}", "OK");
            }
            finally
            {
                Isbusy = false;
            }
        }
    }
}
