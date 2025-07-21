using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedLink.Logic.Models;
using MedLink.Logic.Services;

namespace medLinkMaui.ViewModel
{
    [QueryProperty("Patient", "Patient")]   
    public partial class PatientDetailsViewModel : BaseViewModel
    {
        PatientsService patientsService;
        public PatientDetailsViewModel(PatientsService patientsService)
        {
            this.patientsService = patientsService;
        }

        partial void OnPatientChanged(Patient value)
        {
            EditablePatient = Clone(value);
        }

        [ObservableProperty]
        Patient patient;

        [ObservableProperty]
        Patient editablePatient;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsReadOnly))]
        bool isEditing;
        public bool IsReadOnly => !IsEditing;

        [ObservableProperty]
        string fullNameEditable;

        [RelayCommand]
        void ToggleEdit()
        {
            if (IsEditing)
            {
                EditablePatient = Clone(Patient);
            }
            else
            {
                EditablePatient = Clone(Patient);
                FullNameEditable = $"{EditablePatient.FirstName} {EditablePatient.LastName}";
            }
            IsEditing = !IsEditing;
            OnPropertyChanged(nameof(IsReadOnly));
        }

        [RelayCommand]
        void Cancel()
        {
            if (Isbusy || EditablePatient == null)
                return;           
            IsEditing = false;
            EditablePatient = Clone(Patient);
            OnPropertyChanged(nameof(IsReadOnly));
        }

        [RelayCommand]
        async Task Save()
        {
            if (Isbusy || EditablePatient == null)
                return;
           
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to save changes?", "Yes", "No");

            if (!confirm)
                return;  
            try
            {
                if(!string.IsNullOrWhiteSpace(fullNameEditable))
                {
                    var parts = FullNameEditable.Trim().Split(' ', 2);
                    EditablePatient.FirstName = parts[0];
                    EditablePatient.LastName = parts.Length > 1 ? parts[1] : string.Empty;
                }
                Isbusy = true;
                await patientsService.UpdateAsync(Patient.Id, EditablePatient);
                
                Patient = Clone(EditablePatient);
                IsEditing = false;
                OnPropertyChanged(nameof(IsReadOnly));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to save patient: {ex.Message}", "OK");
            }     
            finally
            {
                Isbusy = false;
            }
        }

        Patient Clone(Patient p)
        {
            return new Patient
            {
                DOB = p.DOB,
                Email = p.Email,
                Phone = p.Phone,
                MedHistory = p.MedHistory,
                Id = p.Id,
                CreatedAt = p.CreatedAt,
                LastModified = p.LastModified,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Note = p.Note
            };
        }
    }
}
