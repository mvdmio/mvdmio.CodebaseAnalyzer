namespace mvdmio.CodebaseAnalysis;

public record struct CodebaseAnalysisResult (
   string AnalyzerType,
   CodeContent CodeContent,
   string Result,
   long Score
);