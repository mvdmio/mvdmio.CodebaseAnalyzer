namespace mvdmio.CodebaseAnalysis.FileAccessor;

public class FileCodeContentAccessor : ICodeContentAccessor
{
   private readonly FileInfo _file;

   public FileCodeContentAccessor(string filePath)
      : this(new FileInfo(filePath))
   {
   }

   public FileCodeContentAccessor(FileInfo file)
   {
      if (!file.Exists)
         throw new InvalidOperationException($"File does not exist: {file.FullName}");

      _file = file;
   }

   public async Task<CodeContent> RetrieveCodeContentAsync()
   {
      var content = await File.ReadAllTextAsync(_file.FullName);

      return new CodeContent {
         Name = _file.Name,
         Extension = _file.Extension,
         Content = content
      };
   }
}