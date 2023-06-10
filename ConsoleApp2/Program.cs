// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {
        string folderPath = @"C:\RMS_Cyclo\Uploaded_Files"; // Replace with the actual folder path

        DateTime createdOnFilter = new DateTime(2022, 6, 5); // Replace with your desired "created on" filter

        DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
        long totalSize = GetTotalSize(directoryInfo, createdOnFilter);

        Console.WriteLine($"Total Size: {(totalSize / 1024f) / 1024f} bytes");
    }

    static long GetTotalSize(DirectoryInfo directory, DateTime createdOnFilter)
    {
        long totalSize = 0;

        foreach (FileInfo file in directory.GetFiles())
        {
            if (file.CreationTime >= createdOnFilter)
            {
                totalSize += file.Length;
            }
        }

        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            totalSize += GetTotalSize(subDirectory, createdOnFilter);
        }

        return totalSize;
    }
}