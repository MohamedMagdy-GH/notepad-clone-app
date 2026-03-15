using System.Text.RegularExpressions;

namespace NotepadCloneLibrary;

public class FileHandler
{
    //private Match? _searchMatch = null;
    //private string _lastSearchQuery = string.Empty;

    public string OpenFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public void SaveFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    public (int start, int length) FindNext(
        string content,
        string query,
        int startIndex = 0,
        bool wrapAround = true,
        bool useRegex = true
    )
    {
        if (string.IsNullOrEmpty(query))
        {
            return (-1, -1);
        }

        Regex regex;
        if (useRegex)
        {
            regex = new Regex(query, RegexOptions.IgnoreCase);
        }
        else
        {
            regex = new(Regex.Escape(query), RegexOptions.IgnoreCase);
        }

        Match match = regex.Match(content, startIndex);
        if (match.Success == true)
        {
            return (match.Index, match.Length);
        }
        else if (wrapAround == true)
        {
            return FindNext(content, query, 0, false, useRegex);
        }
        else
        {
            return (-1, -1);
        }
    }
}
