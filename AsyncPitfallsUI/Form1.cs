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
            //string result = DownloadDataAsync().Result; // or .Wait()

            //textBox1.Text += $"\r\nResult: {result}";

            DownloadDataAsync().Wait(); // or .Wait()

            textBox1.Text += $"\r\nResult: Completed";
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Starting operation with bad library...\r\n";

            // This line causes a deadlock because the library captures the context
            string result = AsyncLibrary.GetDataBadAsync().Result;

            textBox1.Text += $"Result: {result}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Starting operation with good library...\r\n";

            // This line does not cause a deadlock because it uses ConfigureAwait(false)
            string result = AsyncLibrary.GetDataGoodAsync().Result;

            textBox1.Text += $"Result: {result}";
        }

        private async Task ThrowExceptionAsync()
        {
            await Task.Delay(1000);
            throw new Exception("Exception in Fire-and-Forget in the UI!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bad Fire-and-Forget started in the UI...\r\n";

            // Bad Fire-and-Forget — the exception is lost and the UI may crash
            ThrowExceptionAsync();

            textBox1.Text += "The method returned (but the exception was lost!)";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Safe Fire-and-Forget started in the UI...\r\n";

            // Safe — the exception is caught
            _ = ThrowExceptionSafeAsync();

            textBox1.Text += "The method returned (exception was caught)";
        }
        private async Task ThrowExceptionSafeAsync()
        {
            try
            {
                await Task.Delay(1000);
                throw new Exception("Exception was caught!");
            }
            catch (Exception ex)
            {
                textBox1.Invoke((MethodInvoker)(() =>
                {
                    textBox1.Text += $"\r\nException caught: {ex.Message}";
                }));
            }
        }
    }
}
