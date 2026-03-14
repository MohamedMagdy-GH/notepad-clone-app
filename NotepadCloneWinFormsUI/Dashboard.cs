using NotepadCloneLibrary;

namespace NotepadCloneWinFormsUI;

public partial class Dashboard : Form
{
    private const string DefaultTitle = "Notepad Clone by Muhammad Magdi";

    private readonly FileHandler _fileHandler = new();

    private string _currentFilePath = string.Empty;
    private string _currentFileName = "Untitled";

    bool isTextChanged = false;

    public Dashboard()
    {
        InitializeComponent();

        HandleCommandLineArgs();

        ApplyTheme();

        UpdateTitle();
    }

    private static void ApplyTheme()
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
        try
        {
            mainText.Text = _fileHandler.OpenFile(path);

            UpdateFileState(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new()
        {
            Filter = "Text Files|*.txt|All Files|*.*",
            DefaultExt = "txt"
        };

        // TODO: Add a confirmation dialog if there are unsaved changes, to prevent data loss.
        // TODO: Extract file opening logic to a separate method, to use it in the LoadFromStart method as well. (optional)
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            mainText.Text = _fileHandler.OpenFile(openFileDialog.FileName);

            UpdateFileState(openFileDialog.FileName);
        }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // TODO: extract save logic to a separate method, to implement the "Save" option in the future.
        using SaveFileDialog saveFileDialog = new()
        {
            Filter = "Text Files|*.txt|All Files|*.*",
            DefaultExt = "txt",
            FileName = string.IsNullOrWhiteSpace(_currentFilePath) ? string.Empty : Path.GetFileName(_currentFilePath)
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _fileHandler.SaveFile(saveFileDialog.FileName, mainText.Text);

                isTextChanged = false;

                UpdateFileState(saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void UpdateFileState(string path)
    {
        _currentFilePath = path;
        _currentFileName = Path.GetFileName(path);

        UpdateTitle();
    }

    private void UpdateTitle()
    {
        string prefix = isTextChanged ? "*" : "";
        this.Text = $"{prefix}{_currentFileName} - {DefaultTitle}";
    }

    private void mainText_TextChanged(object sender, EventArgs e)
    {
        // TODO: Add asterisk to title if there are unsaved changes, and remove it when the file is saved.
        if (isTextChanged == false)
        {
            isTextChanged = true;
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

    private void ApplyTheme(SystemColorMode theme)
    {
        Application.SetColorMode(theme);

        Properties.Settings.Default.AppTheme = (int)theme;
        Properties.Settings.Default.Save();

        Application.Restart();
    }
}
