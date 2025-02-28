using HospitalBusiness;
using HospitalRepositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GenericRepository<Appointment> _appointmentRepository;
        private readonly GenericRepository<Doctor> _doctorRepository;
        private readonly GenericRepository<Patient> _patientRepository;



        public MainWindow()
        {
            InitializeComponent();
            _appointmentRepository = new GenericRepository<Appointment>();
            _patientRepository = new GenericRepository<Patient>();
            _doctorRepository = new GenericRepository<Doctor>();
            LoadData();

        }

        private async void LoadData()
        {
            var data = await _appointmentRepository.GetAllAsync(includeProperties: "Patient,Doctor");
            dgvAppointments.ItemsSource = data;
            cboPatient.ItemsSource = await _patientRepository.GetAllAsync();
            cboPatient.DisplayMemberPath = "PatientName";
            cboPatient.SelectedIndex = 0;

            cboDoctor.ItemsSource = await _doctorRepository.GetAllAsync();
            cboDoctor.DisplayMemberPath = "DoctorName";
            cboDoctor.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }
            if(txtAppointmentId.Text != string.Empty)
            {
                var appointment = await _appointmentRepository.GetFirstOrDefaultAsync(x => x.AppointmentId == int.Parse(txtAppointmentId.Text));
                appointment.Reason = txtReason.Text;
                appointment.AppointmentDateTime = DateTime.Parse(txtAppointmentDate.Text);
                appointment.PatientId = ((Patient)cboPatient.SelectedItem).PatientId;
                appointment.DoctorId = ((Doctor)cboDoctor.SelectedItem).DoctorId;
                await _appointmentRepository.UpdateAsync(appointment);
                MessageBox.Show("Appointment updated", "Update Appointment");
            }
            else
            {
                // Add
                var appointment = new Appointment();
                appointment.Reason = txtReason.Text;
                appointment.AppointmentDateTime = DateTime.Parse(txtAppointmentDate.Text);
                appointment.PatientId = ((Patient)cboPatient.SelectedItem).PatientId;
                appointment.DoctorId = ((Doctor)cboDoctor.SelectedItem).DoctorId;
                await _appointmentRepository.AddAsync(appointment);
                MessageBox.Show("Appointment added", "Add Appointment");
            }
            LoadData();
            ClearForm();
        }

        private void ClearForm()
        {
            txtAppointmentId.Text = string.Empty;
            txtAppointmentDate.Text = string.Empty;
            cboPatient.SelectedIndex = 0;
            cboDoctor.SelectedIndex = 0;
            txtReason.Text = string.Empty;
            btnDelete.IsEnabled = false;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var appointment = await _appointmentRepository.GetFirstOrDefaultAsync(x => x.AppointmentId == int.Parse(txtAppointmentId.Text));
            await _appointmentRepository.DeleteAsync(appointment.AppointmentId);
            MessageBox.Show("Appointment deleted", "Delete Appointment");
            LoadData();
            ClearForm();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void dgvAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var appointment = (Appointment)dgvAppointments.SelectedItem;
            if (appointment == null) return;
            txtAppointmentId.Text = appointment.AppointmentId.ToString();
            txtReason.Text = appointment.Reason;
            txtAppointmentDate.Text = appointment.AppointmentDateTime.ToString();

            var patientIndex = cboPatient.Items
                .Cast<Patient>()
                .ToList()
                .FindIndex(p => p.PatientId == appointment.Patient.PatientId);
            cboPatient.SelectedIndex = patientIndex;

            var doctorIndex = cboDoctor.Items
                .Cast<Doctor>()
                .ToList()
                .FindIndex(d => d.DoctorId == appointment.Doctor.DoctorId);
            cboDoctor.SelectedIndex = doctorIndex;

            if (txtAppointmentId.Text != string.Empty)
            {
                btnDelete.IsEnabled = true;
            }
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtAppointmentId.Text == string.Empty)
            {
                btnDelete.IsEnabled = false;
            }
        }
        //validation
        private bool ValidateForm()
        {
            // Check if Name is empty
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Reason is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtReason.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAppointmentDate.Text))
            {
                MessageBox.Show("Date is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtAppointmentDate.Focus();
                return false;
            }

            //// Check if Price is a valid positive number
            //if (string.IsNullOrWhiteSpace(txtPrice.Text) || !double.TryParse(txtPrice.Text, out double price) || price <= 0)
            //{
            //    MessageBox.Show("Please enter a valid positive price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    txtPrice.Focus();
            //    return false;
            //}

            // Check if a Category is selected
            if (cboPatient.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cboPatient.Focus();
                return false;
            }

            // Check if a Category is selected
            if (cboDoctor.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cboPatient.Focus();
                return false;
            }

            return true;
        }
    }
}