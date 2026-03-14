using NotepadCloneLibrary;

namespace NotepadCloneWinFormsUI;

public partial class Dashboard : Form
{
    private const string DefaultTitle = "Notepad Clone by Muhammad Magdi";

    private readonly FileHandler _fileHandler = new();

    private string _currentFilePath = string.Empty;
    private string _currentFileName = "Untitled";

    private bool _isTextChanged = false;
    private bool _isLoading = false;

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
        using OpenFileDialog openFileDialog = new()
        {
            Filter = "Text Files|*.txt|All Files|*.*",
            DefaultExt = "txt"
        };

        // TODO: Add a confirmation dialog if there are unsaved changes, to prevent data loss.
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
