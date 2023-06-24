namespace mvdmio.CodebaseAnalysis;

public interface ICodebaseAccessor
{
   public Task<IEnumerable<ICodeContentAccessor>> RetrieveCodeContentAsync();
}