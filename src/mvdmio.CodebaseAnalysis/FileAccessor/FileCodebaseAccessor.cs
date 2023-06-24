namespace mvdmio.CodebaseAnalysis.FileAccessor;

public class FileCodebaseAccessor : ICodebaseAccessor
{
   private readonly DirectoryInfo _rootDirectory;
   private readonly bool _recursive;

   public string Path => _rootDirectory.FullName;

   public FileCodebaseAccessor(string rootPath, bool recursive = true)
   {
      _rootDirectory = new DirectoryInfo(rootPath);
      _recursive = recursive;
   }

   public Task<IEnumerable<ICodeContentAccessor>> RetrieveCodeContentAsync()
   {
      IEnumerable<ICodeContentAccessor> result;

      if (_rootDirectory.Exists)
      {
         var files = _rootDirectory.EnumerateFiles(
            "*.cs",
            new EnumerationOptions {
               RecurseSubdirectories = _recursive
            }
         );

         result = files.Select(x => new FileCodeContentAccessor(x));
      }
      else
      {
         result = Enumerable.Empty<ICodeContentAccessor>();
      }

      return Task.FromResult(result);
   }
}