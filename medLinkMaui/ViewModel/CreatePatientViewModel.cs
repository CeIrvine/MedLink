using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedLink.Logic.DTOs.Get;
using MedLink.Logic.DTOs.Post;
using MedLink.Logic.DTOs.Push;
using MedLink.Logic.Models;
using MedLink.Logic.Services;
using medLinkMaui.View;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace medLinkMaui.ViewModel
{
    public partial class CreatePatientViewModel : BaseViewModel
    {
        PatientsService patientsService;
        BiometricsService biometricsService;
        InsurancesService insurancesService;

        private DateTime _selectedDate;
        private string _dateFormat;

        public CreatePatientViewModel(PatientsService patientsService, BiometricsService biometricsService, InsurancesService insurancesService)
        {
            this.patientsService = patientsService;
            this.biometricsService = biometricsService;
            this.insurancesService = insurancesService;
            
            PostPatient = new PostPatientDto();
            PostBiometric = new PostBiometricDto();
            PostInsurance = new PostInsuranceDto();
        }
        
        [ObservableProperty]
        PostPatientDto postPatient;

        [ObservableProperty]
        PostBiometricDto postBiometric;

        [ObservableProperty]
        PostInsuranceDto postInsurance;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotValid))]
        bool isValid = true;

        public bool IsNotValid => !IsValid;

        [RelayCommand]
        private async Task SavePatientAsync()
        {            
            if (Validate())
            {
                GetPatientDto createdPatient = await patientsService.PostAndReceiveAsync<PostPatientDto, GetPatientDto>(PostPatient);              
                if (createdPatient == null)
                    return;

                PostBiometric.PatientId = createdPatient.Id;
                var biometricResult = await biometricsService.AddAsync(PostBiometric);
                if (!biometricResult)
                    return;

                PostInsurance.PatientId = createdPatient.Id;
                var insuranceResult = await insurancesService.AddAsync(PostInsurance);
                if (!insuranceResult)
                    return;

                await Application.Current.MainPage.DisplayAlert("Success", "Patient created successfully!", "OK");
            }
        }        

        [RelayCommand]
        private void CancelPatient()
        {
            PostPatient = new PostPatientDto();
            PostBiometric = new PostBiometricDto();
            PostInsurance = new PostInsuranceDto();

            OnPropertyChanged(nameof(PostPatient));
            OnPropertyChanged(nameof(PostBiometric));
            OnPropertyChanged(nameof(PostInsurance));

            Errors.Clear();
            OnPropertyChanged(nameof(Errors));
        }

        public Dictionary<string, string> Errors { get; private set; } = new ();

        private bool Validate()
        {           
            PostPatient.DOB = SelectedDate;
            Errors.Clear();

            if (string.IsNullOrWhiteSpace(PostPatient.FirstName))
            {
                Errors["FirstName"] = "First name is required";
                IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(PostPatient.LastName))
            {
                Errors["LastName"] = "Last name is required";
                IsValid = false;
            }

            if (PostPatient.DOB >= DateTime.Today)
            {
                Errors["DOB"] = "Date of birth must be in the past";
                IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(PostPatient.Phone))
            {
                Errors["Phone"] = "Phone number is required";
                IsValid = false;
            }                       

            if (string.IsNullOrWhiteSpace(PostBiometric.BloodType))
            {
                Errors["BloodType"] = "Please select a blood type";
                IsValid = false;
            }

            if (!Regex.IsMatch(PostBiometric.Height.ToString() ?? "", @"^\d+$"))
            {
                Errors["Height"] = "Height must be a number";
                IsValid = false;
            }

            if (!Regex.IsMatch(PostBiometric.Weight.ToString() ?? "", @"^\d+$"))
            {
                Errors["Weight"] = "Weight must be a number";
                IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(PostBiometric.Gender))
            {
                Errors["Gender"] = "Please select a gender";
                IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(PostInsurance.InsuranceNum))
            {
                Errors["InsuranceNum"] = "Insurance Number is Required";
                IsValid = false;
            }

            OnPropertyChanged(nameof(Errors));
            return IsValid;
        }

        public string this[string propertyName]
        {
            get
            {
                if (Errors.TryGetValue(propertyName, out var errorMessage))
                    return errorMessage;
                return string.Empty;
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged();

                    if (_selectedDate != DateTime.MinValue)
                    {
                        DateFormat = "MM/dd/yyyy";
                    }
                }
            }
        }

        public string DateFormat
        {
            get => _dateFormat;
            set
            {
                if (_dateFormat != value)
                {
                    _dateFormat = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ResetDateCommand { get; }

        private void ResetDate()
        {
            SelectedDate = DateTime.MinValue;
            DateFormat = "Select a date";
        }       
    }
}
