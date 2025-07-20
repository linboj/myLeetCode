public class Solution
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        List<string> ans = new();
        Array.Sort(folder);
        ans.Add(folder[0]);
        string lastFolder = folder[0] + "/";
        for (int i = 1; i < folder.Length; i++)
        {
            if (!isSubFolder(lastFolder, folder[i]))
            {
                ans.Add(folder[i]);
                lastFolder = folder[i] + "/";
            }
        }
        return ans;
    }

    private bool isSubFolder(string folder1, string folder2)
    {
        if (folder1.Length > folder2.Length)
            return false;
        for (int i = 0; i < folder1.Length; i++)
        {
            if (folder1[i] != folder2[i])
                return false;
        }
        return true;
    }
}