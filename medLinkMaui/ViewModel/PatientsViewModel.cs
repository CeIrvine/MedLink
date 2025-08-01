﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedLink.Logic.DTOs.Get;
using MedLink.Logic.Models;
using MedLink.Logic.Services;
using medLinkMaui.View;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Dispatching;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medLinkMaui.ViewModel
{
    public partial class PatientsViewModel : BaseViewModel
    {
        PatientsService patientsService;
        public ObservableCollection<GetPatientDto> Patients { get; } = new();
        public ObservableCollection<GetPatientDto> FilteredPatients { get; } = new();

        public PatientsViewModel(PatientsService patientsService)
        {
            this.patientsService = patientsService;
        }

        public string FullName { get; set; }

        private string searchKeyword;
        public string SearchKeyword
        {
            get => searchKeyword;
            set
            {
                if (SetProperty(ref searchKeyword, value))
                {
                    _ = DebouncedSearchPatientsAsync();
                }
            }
        }

        [RelayCommand]
        async Task GetPatientsAsync()
        {
            if (Isbusy)
                return;

            try
            {
                Isbusy = true;
                var patients = await patientsService.GetAllAsync<GetPatientDto>();

                if (Patients.Count != 0)
                    Patients.Clear();

                foreach (var patient in patients)
                    Patients.Add(patient);               
                
                FilteredPatients.Clear();
                foreach (var patient in Patients)               
                    FilteredPatients.Add(patient);               
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

        private CancellationTokenSource _debounceCts;

        [RelayCommand]
        async Task DebouncedSearchPatientsAsync()
        {
            _debounceCts?.Cancel();
            _debounceCts = new CancellationTokenSource();
            var token = _debounceCts.Token;

            try
            {
                await Task.Delay(300, token);
                if (token.IsCancellationRequested)
                    return;

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    SearchPatients();
                });
            }
            catch (TaskCanceledException)
            {
            }
        }

        private void SearchPatients()
        {
            if (Isbusy)
                return;

            var keyword = SearchKeyword?.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                FilteredPatients.Clear();
                foreach (var p in Patients)
                    FilteredPatients.Add(p);
                return;
            }

            IEnumerable<GetPatientDto> filtered;

            if (char.IsDigit(keyword[0]))
            {
                if (int.TryParse(keyword, out int idValue))
                {
                    filtered = Patients.Where(p => p.Id == idValue);
                }
                else
                {
                    filtered = Enumerable.Empty<GetPatientDto>();
                }                
            }
            else
            {
                filtered = Patients.Where(p =>
                    (p.FirstName?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.LastName?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false));
            }                

            FilteredPatients.Clear();
            foreach (var p in filtered)
                FilteredPatients.Add(p);
        }

        [RelayCommand]
        async Task GoToDetailsAsync(GetPatientDto patient)
        {
            if (patient is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Patient", patient}
                });
        }
    }
}
/*try
            {
                Isbusy = true;
                var keyword = SearchKeyword?.Trim() ?? "";
                var patients = await patientsService.SearchAsync(keyword);
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
                await Shell.Current.DisplayAlert("Error!", $"Unable to search patients: {ex.Message}", "OK");
            }
            finally
            {
                Isbusy = false;
            }*/
