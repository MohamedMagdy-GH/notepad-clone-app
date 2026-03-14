using NotepadCloneLibrary;

namespace NotepadCloneWinFormsUI;

public partial class Dashboard : Form
{
    private const string DefaultTitle = "Untitled - Notepad Clone by Muhammad Magdi";

    private readonly FileHandler fileHandler = new();
    private string currentFilePath = string.Empty;

    public Dashboard()
    {
        InitializeComponent();

        // TODO: Add right-click menu option to open file in explorer, and test if it works.
        string[] args = Environment.GetCommandLineArgs();
        if (args.Length > 1)
        {
            LoadFromStart(args[1]);
        }

        this.Text = DefaultTitle;
    }

    private void LoadFromStart(string path)
    {
        try
        {
            mainText.Text = fileHandler.OpenFile(path);

            UpdateFileState(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Text = DefaultTitle;
        }
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new()
        {
            Filter = "Text Files|*.txt|All Files|*.*",
            DefaultExt = "txt"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            mainText.Text = fileHandler.OpenFile(openFileDialog.FileName);

            UpdateFileState(openFileDialog.FileName);
        }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using SaveFileDialog saveFileDialog = new()
        {
            Filter = "Text Files|*.txt|All Files|*.*",
            DefaultExt = "txt",
            FileName = string.IsNullOrWhiteSpace(currentFilePath) ? string.Empty : Path.GetFileName(currentFilePath)
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                fileHandler.SaveFile(saveFileDialog.FileName, mainText.Text);

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
        currentFilePath = path;

        this.Text = $"{Path.GetFileName(path)} - {DefaultTitle}";
    }

    private void mainText_TextChanged(object sender, EventArgs e)
    {
        // TODO: Add asterisk to title if there are unsaved changes, and remove it when the file is saved.
    }
}
