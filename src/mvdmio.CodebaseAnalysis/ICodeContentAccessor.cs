namespace mvdmio.CodebaseAnalysis;

public interface ICodeContentAccessor
{
   Task<CodeContent> RetrieveCodeContentAsync();
}