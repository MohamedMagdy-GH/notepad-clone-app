namespace NotepadCloneLibrary
{
    public class FileHandler
    {
        public string OpenFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void SaveFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}
