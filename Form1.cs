using System;
using System.Configuration;
using System.Text.Json;
using System.Windows.Forms;

namespace CodeFormatterApp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Logger.InitializeLogger();
            //this.Icon = new Icon("CodeFormatterApp.ico");
        }

        private async void btnFormat_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar.Visible = true;
                string sourceCode = txtSourceCode.Text;
                string? language = cbLanguage.SelectedItem?.ToString();
                string formattedCode = sourceCode;

                Logger.Log("Source Code: " + Environment.NewLine + sourceCode);

                // Format the code using Roslyn for C# and VB
                if (string.IsNullOrEmpty(language))
                {
                    MessageBox.Show("Please select a language", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Log("No language selected by user.");
                    return;
                }
                else if (language.ToLower() == "c#")
                {
                    formattedCode = await CodeFormatter.FormatCSharpCodeAsync(formattedCode);
                    // Logger.Log("Formatted C# Code: " + Environment.NewLine + formattedCode);
                    if (formattedCode.Contains("ERROR:")) 
                        Logger.Log("C# formatting errors: " + formattedCode);
                    else 
                        Logger.Log("C# code formatted successfully.");
                }
                else if (language.ToLower() == "vb" || language.ToLower() == "vb.net")
                {
                    formattedCode = await CodeFormatter.FormatVBCodeAsync(formattedCode);
                    if (formattedCode.Contains("ERROR:")) 
                        Logger.Log("VB formatting errors: " + formattedCode);
                    else 
                        Logger.Log("VB code formatted successfully.");
                }
                else if (language.ToLower() == "sql" || language.ToLower() == "SQL")
                {
                    formattedCode = await CodeFormatter.FormatSQLCodeAsync(formattedCode);
                    // Logger.Log("Formatted C# Code: " + Environment.NewLine + formattedCode);
                    if (formattedCode.Contains("ERROR:")) 
                        Logger.Log("SQL formatting errors: " + formattedCode);
                    else 
                        Logger.Log("SQL code formatted successfully.");
                }

                txtFormattedCode.Text = formattedCode;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }


        private void btnCopyFormatted_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFormattedCode.Text))
            {
                Clipboard.SetText(txtFormattedCode.Text);
                MessageBox.Show("Formatted code copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearFormMenuItem_Click(object sender, EventArgs e)
        {
            txtSourceCode.Clear();
            txtFormattedCode.Clear();
            cbLanguage.ResetText();
        }

        private void contactMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Code Formatter v1.0\nFor any issues, queries, or feedback, please contact Manthan Gandhi at mannthann@gmail.com.\nThank you!", "About");
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Code Files (*.cs;*.vb;*.sql)|*.cs;*.vb;*.sql|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSourceCode.Text = File.ReadAllText(openFileDialog.FileName);
                    string ext = Path.GetExtension(openFileDialog.FileName).ToLower();
                    cbLanguage.SelectedItem = ext switch
                    {
                        ".cs" => "C#",
                        ".vb" => "VB",
                        ".sql" => "SQL",
                        _ => null
                    };
                }
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFormattedCode.Text)) return;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, txtFormattedCode.Text);
                    MessageBox.Show("Formatted code saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
    }
}
