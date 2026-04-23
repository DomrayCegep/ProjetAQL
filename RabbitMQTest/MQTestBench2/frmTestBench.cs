using MQTestBench.MQSystem;
using MQTestBench.MQSystem.Messages;
using RMQHelperDLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MQTestBench2
{
    public partial class frmTestBench : Form
    {

        MQConnection? _mqc = null;
        string _historyFolderPath = string.Empty;
        List<HistoryItem> _historyItems;
        public frmTestBench()
        {
            InitializeComponent();
            InitializeHistoryFolder();
            LoadHistory();
        }

        private void InitializeHistoryFolder()
        {
            _historyFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "History");
            if (!Directory.Exists(_historyFolderPath))
            {
                Directory.CreateDirectory(_historyFolderPath);
            }
        }

        private void LoadHistory()
        {
            _historyItems = HistoryItem.LoadAll(_historyFolderPath);
            dgvHistoryMsg.Rows.Clear();
            dgvHistoryMsg.DataSource = _historyItems;
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
            this.btnDeconnecter.Enabled = isConnected;
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

        private void MessageReceived(object? sender, RMQEnveloppe e)
        {
            //MessageBox.Show($"Message reçu: {e.MessageName} \n {e.GetMessageText()}", "Message Reçu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtReceive.Invoke(() => txtReceive.Text += $"Message reçu! [{e.Sender}] [{e.MessageName}]");
            _historyItems.Add(new HistoryItem(e, "In"));
            RefreshHistoryGrid();
        }

        private void RefreshHistoryGrid()
        {
            dgvHistoryMsg.Invoke(() =>
            {
                dgvHistoryMsg.DataSource = null;
                dgvHistoryMsg.DataSource = _historyItems;
            });

            //sélectionner la dernière ligne
            if (dgvHistoryMsg.Rows.Count > 0)
            {
                dgvHistoryMsg.ClearSelection();

                dgvHistoryMsg.Rows[dgvHistoryMsg.Rows.Count - 1].Selected = true;
                //dgvHistoryMsg.FirstDisplayedScrollingRowIndex = dgvHistoryMsg.Rows.Count - 1;
            }
        }

        private async void btnEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                RMQEnveloppe env;

                txtReceive.Text += $"Envoye du message! [{txtDestination.Text}] [{txtNomMessage.Text}]";
                env = await _mqc?.SendMessage(txtDestination.Text, txtNomMessage.Text, txtSend.Text, null);
                _historyItems.Add(new HistoryItem(env, "Out"));
                RefreshHistoryGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            try
            {
                _mqc?.Deconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ChangeConnectionState(false);
            }
        }

        private void btnOpenDlg_Click(object sender, EventArgs e)
        {
            dlgOpenFile.ShowDialog();
            if (!string.IsNullOrEmpty(dlgOpenFile.FileName))
            {
                txtNomMessage.Text = dlgOpenFile.FileName;

                txtSend.Text = File.ReadAllText(dlgOpenFile.FileName);
            }
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            _historyItems.Clear();
            RefreshHistoryGrid();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            _historyItems.ForEach(item => item.Save(_historyFolderPath));
        }

        private void dgvHistoryMsg_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvHistoryMsg.CurrentRow != null && dgvHistoryMsg.CurrentRow.Index >= 0 && dgvHistoryMsg.CurrentRow.DataBoundItem != null)
                {
                    HistoryItem item = dgvHistoryMsg.CurrentRow.DataBoundItem as HistoryItem;
                    if (item != null)
                    {
                        txtHistoryMessage.Text = item.Content.MessageText;
                    }
                }
                else
                {
                    txtHistoryMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                txtHistoryMessage.Text = string.Empty;
            }
        }

        private void dgvHistoryMsg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvHistoryMsg.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvHistoryMsg.Rows[e.RowIndex].Cells[1].Value.ToString() == "In" ? Color.LightGreen : Color.LightBlue;
        }

        private void dgvHistoryMsg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
