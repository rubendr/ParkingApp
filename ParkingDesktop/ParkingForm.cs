using ParkingDesktop;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace ParkingDesktopFrontend
{
    public partial class ParkingForm : Form
    {
        private readonly HttpClient _httpClient;
        public ParkingForm(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool ValidateCheckIn()
        {
            if (vehicleTextBox.Text.Length == 0) return false;
            if (slotComboBox.Text.Length == 0) return false;
            if (typeComboBox.Text.Length == 0) return false;
            if (colorComboBox.Text.Length == 0) return false;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateCheckIn())
            {
                vehicleTextBox.Focus();
                MessageBox.Show("Invalid Input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                var obj = new ParkingModel()
                {
                    Slot = Convert.ToInt32(slotComboBox.Text),
                    Status = "I",
                    VehicleColor = colorComboBox.Text,
                    VehicleNo = vehicleTextBox.Text,
                    VehicleType = typeComboBox.Text
                };
                string json = System.Text.Json.JsonSerializer.Serialize(obj);
                var link = new Uri("http://localhost:9999/api/parking");
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var resp = _httpClient.PostAsync(link, content).Result;
                resp.EnsureSuccessStatusCode();
                if (resp.IsSuccessStatusCode)
                {
                    var respok = resp.Content.ReadFromJsonAsync<ResponseModel>().Result;
                    if (respok?.Success == true)
                    {
                        dataGridView1.Rows.Add(new object[] {
                            vehicleTextBox.Text,
                            slotComboBox.Text,
                            typeComboBox.Text,
                            colorComboBox.Text,
                            DateTime.Now }
                        );
                        MessageBox.Show("OK", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(respok?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Request to the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resp = _httpClient.GetAsync("http://localhost:9999/api/parking").Result;
            resp.EnsureSuccessStatusCode();
            MessageBox.Show(resp.Content.ReadAsStringAsync().Result);

        }
    }
}