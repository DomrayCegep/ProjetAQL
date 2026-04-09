using MQTestBench.MQSystem;
using MQTestBench.MQSystem.Messages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MQTestBench2
{
    public partial class frmTestBench : Form
    {

        MQConnection? _mqc = null;
        public frmTestBench()
        {
            InitializeComponent();
        }

        private void txtFileReception_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeConnectionState(bool isConnected)
        {
            this.btnConnecter.Enabled = !isConnected;
            this.txtAddress.Enabled = !isConnected;
            this.txtFileReception.Enabled = !isConnected;

            this.btnEnvoyer.Enabled = isConnected;
        }

        private async void btnConnecter_Click(object sender, EventArgs e)
        {
            ChangeConnectionState(true);
            try
            {
                _mqc = new MQConnection(txtFileReception.Text, txtAddress.Text);
                await _mqc.Connect();

                _mqc.MessageReceived += MessageReceived;

                txtReceive.Text = $"Connecté sur {_mqc.QueueName}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChangeConnectionState(false);
            }

        }

        private void MessageReceived(object? sender, IMessageActions e)
        {
            //MessageBox.Show($"Message reçu: {e.MessageName} \n {e.GetMessageText()}", "Message Reçu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtReceive.Invoke(() => txtReceive.Text += Environment.NewLine + e.GetMessageText());
  
        }

        private async void btnEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                await _mqc.SendMessage(txtDestination.Text, txtNomMessage.Text, txtSend.Text, null);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
