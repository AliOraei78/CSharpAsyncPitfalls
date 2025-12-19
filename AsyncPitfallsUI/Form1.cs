using System.Threading.Tasks;

namespace AsyncPitfallsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"Thread before await: {Thread.CurrentThread.ManagedThreadId}\r\n";

            await Task.Delay(1000);

            textBox1.Text += $"Thread after await (without ConfigureAwait): {Thread.CurrentThread.ManagedThreadId}\r\n";

            await Task.Delay(1000).ConfigureAwait(false);

            textBox1.Text += $"Thread after await (with ConfigureAwait(false)): {Thread.CurrentThread.ManagedThreadId}\r\n";


            label1.Text = "Test completed!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Starting operation...";

            // This line causes a deadlock!
            string result = DownloadDataAsync().Result; // or .Wait()

            textBox1.Text += $"\r\nResult: {result}";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Starting operation...";

            string result = await DownloadDataAsync(); // Correct — fully async

            textBox1.Text += $"\r\nResult: {result}";
        }

        private async Task<string> DownloadDataAsync()
        {
            await Task.Delay(3000); // Async operation
            return "Download completed!";
        }
    }
}
