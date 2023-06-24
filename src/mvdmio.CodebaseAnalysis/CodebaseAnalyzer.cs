using mvdmio.CodebaseAnalysis.Analyzers;

namespace mvdmio.CodebaseAnalysis;

public class CodebaseAnalyzer
{
   private readonly ICodebaseAccessor _codebaseAccessor;
   private readonly ICodebaseAnalyzer[] _analyzers;

   public CodebaseAnalyzer(ICodebaseAccessor codebaseAccessor)
   {
      _codebaseAccessor = codebaseAccessor;

      _analyzers = new ICodebaseAnalyzer[] {
         new StructureMapAnalyzer()
      };
   }

   public async Task<IEnumerable<CodebaseAnalysisResult>> RunAsync()
   {
      var codeContentAccessors = await _codebaseAccessor.RetrieveCodeContentAsync();

      var result = new List<CodebaseAnalysisResult>();

      await Parallel.ForEachAsync(
         codeContentAccessors,
         async (codeContentAccessor, ct) => {
            var codeContent = await codeContentAccessor.RetrieveCodeContentAsync();

            foreach (var analyzer in _analyzers)
            {
               var analysisResult = await analyzer.AnalyzeAsync(codeContent);

               if (analysisResult is not null)
                  result.Add(analysisResult.Value);
            }
         }
      );

      return result;
   }
}