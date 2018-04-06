using System;
using System.Globalization;
using System.Threading;
using Antlr4.Runtime;
using Dust.Compiler;
using Dust.Language;
using Dust.Language.Errors;
using Dust.Language.Nodes;

namespace Dust.CLI
{
  public static class Program
  {
    private static void Main(string[] args)
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

      DustContext context = new DustContext();
      DustRuntimeCompiler compiler = new DustRuntimeCompiler(context);

      string input;

      while ((input = Console.ReadLine()) != "exit")
      {
        AntlrInputStream inputStream = new AntlrInputStream(input);
        DustLexer lexer = new DustLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
        DustParser parser = new DustParser(commonTokenStream);
        DustVisitor visitor = new DustVisitor(context);
        Module module = (Module) visitor.VisitModule(parser.module());

        object result = compiler.Compile(module).Value;

        bool hasErrored = false;
        
        foreach (Error error in context.ErrorHandler.Errors)
        {
          hasErrored = true;
          
          Console.WriteLine(error);
        }

        if (result != null && hasErrored == false)
        {
          Console.WriteLine(result);
        }
      }
    }
  }
}