using NotepadCloneLibrary;

namespace NotepadClone;

public partial class Dashboard : Form
{
    private const string DefaultTitle = "Notepad Clone by Muhammad Magdi";

    private readonly FileHandler _fileHandler = new();

    private string _currentFilePath = string.Empty;
    private string _currentFileName = "Untitled";

    private bool _isTextChanged = false;
    private bool _isLoading = false;
    private bool _isChangingTheme = false;

    public Dashboard()
    {
        InitializeComponent();
        InitializeTheme();
        HandleCommandLineArgs();
        UpdateTitle();
    }

    #region Startup Logic
    private void InitializeTheme()
    {
        int savedTheme = Properties.Settings.Default.AppTheme;
        SystemColorMode mode = (SystemColorMode)savedTheme;

        Application.SetColorMode(mode);
    }

    private void HandleCommandLineArgs()
    {
        string[] args = Environment.GetCommandLineArgs();
        if (args.Length > 1)
        {
            LoadFromStart(args[1]);
        }
    }

    private void LoadFromStart(string path)
    {
        HandleFileOpening(path);
    }
    #endregion

    #region Events
    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_isTextChanged)
        {
            DialogResult result = MessageBox.Show("Opening a new file will discard unsaved changes. Do you want to continue?", "Confirm Open", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
        }

        using OpenFileDialog openFileDialog = new()
        {
            Filter = "Text Files|*.txt|All Files|*.*",
            DefaultExt = "txt"
        };
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            HandleFileOpening(openFileDialog.FileName);
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_currentFilePath))
        {
            saveAsToolStripMenuItem_Click(sender, e);
        }
        else
        {
            HandleFileSaving(_currentFilePath);
        }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using SaveFileDialog saveFileDialog = new()
        {
            Filter = "Text Files|*.txt|All Files|*.*",
            DefaultExt = "txt",
            FileName = string.IsNullOrWhiteSpace(_currentFilePath) ? string.Empty : Path.GetFileName(_currentFilePath)
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            HandleFileSaving(saveFileDialog.FileName);
        }
    }

    private void mainText_TextChanged(object sender, EventArgs e)
    {
        if (_isLoading)
        {
            return;
        }

        if (_isTextChanged == false)
        {
            _isTextChanged = true;
            UpdateTitle();
        }

        // TODO: Think of a way to handle scrollbars without causing performance issues (optional).
        //Size size = TextRenderer.MeasureText(mainText.Text, mainText.Font, mainText.ClientSize, TextFormatFlags.WordBreak);

        //if (size.Height > mainText.ClientSize.Height)
        //{
        //    mainText.ScrollBars = ScrollBars.Vertical;
        //}
        //else
        //{
        //    mainText.ScrollBars = ScrollBars.None;
        //}
    }

    private void lightToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ApplyTheme(SystemColorMode.Classic);
    }

    private void systemDefaultToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ApplyTheme(SystemColorMode.System);
    }

    private void darkToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ApplyTheme(SystemColorMode.Dark);
    }

    private void findToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (mainText.SelectionLength == 0 && mainText.SelectionStart == mainText.TextLength)
        {
            mainText.SelectionStart = 0;
        }

        findPanel.Visible ^= true;

        findQuery.Text = string.Empty;
        findQuery.Focus();
    }

    private void findNext_Click(object sender, EventArgs e)
    {
        try
        {
            (int start, int length) = _fileHandler.FindNext(
                mainText.Text,
                findQuery.Text,
                mainText.SelectionStart + mainText.SelectionLength,
                wrapAround.Checked,
                useRegularExpressions.Checked
            );

            if (start != -1 && length != -1)
            {
                mainText.SelectionStart = start;
                mainText.SelectionLength = length;
                mainText.Focus();
            }
            else
            {
                MessageBox.Show("No matches found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);

                mainText.SelectionStart = 0;
                mainText.SelectionLength = 0;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void closeFindPanel_Click(object sender, EventArgs e)
    {
        findPanel.Visible = false;
    }

    private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_isChangingTheme)
        {
            return;
        }

        if (_isTextChanged == true)
        {
            DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save before exiting?", "Confirm Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
    #endregion

    #region Helper Methods
    private void UpdateFileState(string path)
    {
        _currentFilePath = path;
        _currentFileName = Path.GetFileName(path);

        UpdateTitle();
    }

    private void UpdateTitle()
    {
        string prefix = _isTextChanged ? "*" : "";
        this.Text = $"{prefix}{_currentFileName} - {DefaultTitle}";
    }

    private void ApplyTheme(SystemColorMode theme)
    {
        if (WarnUser("Changing the theme will discard unsaved changes. Do you want to continue?", "Confirm Theme Change") == false)
        {
            return;
        }

        _isChangingTheme = true;

        Application.SetColorMode(theme);

        Properties.Settings.Default.AppTheme = (int)theme;
        Properties.Settings.Default.Save();

        if (!string.IsNullOrWhiteSpace(_currentFilePath))
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath, $"\"{_currentFilePath}\"");
            Application.Exit();
        }
        else
        {
            Application.Restart();
        }
    }

    private bool WarnUser(
        string message = "Doing this will discard unsaved changes. Do you want to continue?",
        string caption = "Confirm Action"
    )
    {
        if (_isTextChanged)
        {
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return false;
            }
        }

        return true;
    }

    private void HandleFileOpening(string path)
    {
        try
        {
            _isLoading = true;
            mainText.Text = _fileHandler.OpenFile(path);

            mainText.SelectionStart = mainText.Text.Length;
            mainText.SelectionLength = 0;

            _isTextChanged = false;
            UpdateFileState(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _isLoading = false;
        }
    }

    private void HandleFileSaving(string path)
    {
        try
        {
            _fileHandler.SaveFile(path, mainText.Text);

            _isTextChanged = false;

            UpdateFileState(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion 
}
