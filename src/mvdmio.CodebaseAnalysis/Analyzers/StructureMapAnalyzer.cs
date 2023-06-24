using System.Text.RegularExpressions;

namespace mvdmio.CodebaseAnalysis.Analyzers;

public class StructureMapAnalyzer : ICodebaseAnalyzer
{
   // Should remove all characters except '{', '}', and ';'
   public async Task<CodebaseAnalysisResult?> AnalyzeAsync(CodeContent codeContent)
   {
      if (codeContent.Extension != ".cs")
         return null;
      
      var regex = new Regex("[{};]+");
      var structureMap = regex.Match(codeContent.Content).ToString();

      return new CodebaseAnalysisResult {
         AnalyzerType = nameof(StructureMapAnalyzer),
         CodeContent = codeContent,
         Result = structureMap,
         Score = structureMap.Length
      };
   }
}