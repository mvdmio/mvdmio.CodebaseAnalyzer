using mvdmio.CodebaseAnalysis;
using mvdmio.CodebaseAnalysis.Analyzers;
using mvdmio.CodebaseAnalysis.FileAccessor;

Console.WriteLine("Starting CodebaseAnalyzer CLI");

var jewelCodebaseAnalyzer = new FileCodebaseAccessor("D:\\Projects\\jewel\\devops\\jewel-products");
var analyzer = new CodebaseAnalyzer(jewelCodebaseAnalyzer);

var results = (await analyzer.RunAsync()).ToArray();

Console.WriteLine($"Finished Analyzing codebase: {jewelCodebaseAnalyzer.Path}");
Console.WriteLine($"# files analyzed: {results.DistinctBy(x => x.CodeContent).Count()}");

Console.WriteLine("StructureMap results");
foreach (var result in results.Where(x => x.AnalyzerType == nameof(StructureMapAnalyzer)))
{
   Console.WriteLine(result.CodeContent.Name);
   Console.WriteLine(result.Result);
}