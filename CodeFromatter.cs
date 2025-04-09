using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using PoorMansTSqlFormatterLib; 
using Microsoft.SqlServer.TransactSql.ScriptDom;
using PoorMansTSqlFormatterLib.Formatters;

namespace CodeFormatterApp
{
    public static class CodeFormatter
    {
        private static OptionSet GetCSharpOptions(AdhocWorkspace workspace)
        {
            var options = workspace.Options;
            options = options.WithChangedOption(FormattingOptions.UseTabs, LanguageNames.CSharp, false);
            options = options.WithChangedOption(FormattingOptions.TabSize, LanguageNames.CSharp, 4);
            options = options.WithChangedOption(FormattingOptions.IndentationSize, LanguageNames.CSharp, 4);
            options = options.WithChangedOption(FormattingOptions.NewLine, LanguageNames.CSharp, Environment.NewLine);
            return options;
        }

        private static OptionSet GetVBOptions(AdhocWorkspace workspace)
        {
            var options = workspace.Options;
            options = options.WithChangedOption(FormattingOptions.UseTabs, LanguageNames.VisualBasic, false);
            options = options.WithChangedOption(FormattingOptions.TabSize, LanguageNames.VisualBasic, 4);
            options = options.WithChangedOption(FormattingOptions.IndentationSize, LanguageNames.VisualBasic, 4);
            options = options.WithChangedOption(FormattingOptions.NewLine, LanguageNames.VisualBasic, Environment.NewLine);
            return options;
        }

        public static async Task<string> FormatCSharpCodeAsync(string code)
        {
            // var workspace = new AdhocWorkspace();
            // var syntaxTree = CSharpSyntaxTree.ParseText(code);
            // var root = await syntaxTree.GetRootAsync();
            // var formattedRoot = Formatter.Format(root, workspace, GetCSharpOptions(workspace));
            // return formattedRoot.ToFullString();

            // Parse the C# code into a syntax tree
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var diagnostics = syntaxTree.GetDiagnostics()
                                       .Where(d => d.Severity == DiagnosticSeverity.Error)
                                       .ToList();

            if (diagnostics.Any())
            {
                // Split the code into individual lines
                // var lines = code.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                var lines = code.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
                var errorLines = new HashSet<int>();

                // Collect line numbers with errors
                foreach (var diagnostic in diagnostics)
                {
                    var lineNumber = diagnostic.Location.GetLineSpan().StartLinePosition.Line;
                    errorLines.Add(lineNumber);
                }

                // Build output with only the error lines and their messages
                var errorOutput = new List<string>();
                foreach (var lineNumber in errorLines.OrderBy(n => n))
                {
                    var lineText = lines[lineNumber];
                    var errorsOnLine = diagnostics
                        .Where(d => d.Location.GetLineSpan().StartLinePosition.Line == lineNumber)
                        .Select(d => d.GetMessage());

                    errorOutput.Add($"Line {lineNumber + 1}: {lineText}");
                    foreach (var error in errorsOnLine)
                    {
                        errorOutput.Add($"    ERROR: {error}");
                    }
                }

                return string.Join(Environment.NewLine, errorOutput);
            }
            else
            {
                // No errors: format and return the entire code
                var workspace = new AdhocWorkspace();
                var root = await syntaxTree.GetRootAsync();
                var formattedRoot = Formatter.Format(root, workspace);
                return formattedRoot.ToFullString();
            }
        }

        public static async Task<string> FormatVBCodeAsync(string code)
        {
            // var workspace = new AdhocWorkspace();
            // var syntaxTree = VisualBasicSyntaxTree.ParseText(code);
            // var root = await syntaxTree.GetRootAsync();
            // var formattedRoot = Formatter.Format(root, workspace, GetVBOptions(workspace));
            // return formattedRoot.ToFullString();

            // Parse the VB.Net code into a syntax tree
            var syntaxTree = VisualBasicSyntaxTree.ParseText(code);
            var diagnostics = syntaxTree.GetDiagnostics()
                                       .Where(d => d.Severity == DiagnosticSeverity.Error)
                                       .ToList();

            if (diagnostics.Any())
            {
                // Split the code into individual lines
                // var lines = code.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                var lines = code.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
                var errorLines = new HashSet<int>();

                // Collect line numbers with errors
                foreach (var diagnostic in diagnostics)
                {
                    var lineNumber = diagnostic.Location.GetLineSpan().StartLinePosition.Line;
                    errorLines.Add(lineNumber);
                }

                // Build output with only the error lines and their messages
                var errorOutput = new List<string>();
                foreach (var lineNumber in errorLines.OrderBy(n => n))
                {
                    var lineText = lines[lineNumber];
                    var errorsOnLine = diagnostics
                        .Where(d => d.Location.GetLineSpan().StartLinePosition.Line == lineNumber)
                        .Select(d => d.GetMessage());

                    errorOutput.Add($"Line {lineNumber + 1}: {lineText}");
                    foreach (var error in errorsOnLine)
                    {
                        errorOutput.Add($"    ERROR: {error}");
                    }
                }

                return string.Join(Environment.NewLine, errorOutput);
            }
            else
            {
                // No errors: format and return the entire code
                var workspace = new AdhocWorkspace();
                var root = await syntaxTree.GetRootAsync();
                var formattedRoot = Formatter.Format(root, workspace);
                return formattedRoot.ToFullString();
            }
        }

        public static async Task<string> FormatSQLCodeAsync(string sqlCode)
        {
            // var formatter = new SqlFormattingManager();
            // return formatter.Format(sqlCode);

            // Use TSql150Parser for SQL Server 2019 (adjust version as needed)
            var parser = new TSql150Parser(false);
            IList<ParseError> parseErrors;
            using (var reader = new StringReader(sqlCode))
            {
                var fragment = parser.Parse(reader, out parseErrors);
            }

            if (parseErrors.Any())
            {
                // Split the SQL code into lines
                // var lines = sqlCode.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                var lines = sqlCode.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
                var errorLines = new HashSet<int>();

                // Collect line numbers with errors (ScriptDom uses 1-based indexing)
                foreach (var error in parseErrors)
                {
                    errorLines.Add(error.Line - 1); // Convert to 0-based for array access
                }

                // Build output showing only error lines with messages
                var errorOutput = new List<string>();
                foreach (var lineNumber in errorLines.OrderBy(n => n))
                {
                    var lineText = lines[lineNumber];
                    var errorsOnLine = parseErrors
                        .Where(e => e.Line - 1 == lineNumber)
                        .Select(e => e.Message);

                    errorOutput.Add($"Line {lineNumber + 1}: {lineText}");
                    foreach (var error in errorsOnLine)
                    {
                        errorOutput.Add($"    ERROR: {error}");
                    }
                }

                return await Task.Run(() =>
                {
                    return string.Join(Environment.NewLine, errorOutput);
                });
            }
            else
            {
                // No errors: format the SQL using PoorMansTSqlFormatterLib
                var formatter = new TSqlStandardFormatter();
                var formattingManager = new SqlFormattingManager(formatter);
                return await Task.Run(() =>
                {
                    return formattingManager.Format(sqlCode);
                });
            }
        }
    }
}   