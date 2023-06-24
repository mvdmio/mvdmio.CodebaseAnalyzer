namespace mvdmio.CodebaseAnalysis;

public interface ICodebaseAnalyzer
{
   public Task<CodebaseAnalysisResult?> AnalyzeAsync(CodeContent codeContent);
}