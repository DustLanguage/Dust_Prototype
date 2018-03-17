using System;
using System.Globalization;
using System.Threading;
using Antlr4.Runtime;
using Dust.Compiler;
using Dust.Language;
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
        try
        {
          AntlrInputStream inputStream = new AntlrInputStream(input);
          DustLexer lexer = new DustLexer(inputStream);
          CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
          DustParser parser = new DustParser(commonTokenStream);
          DustVisitor visitor = new DustVisitor(context);
          Module module = (Module) visitor.VisitModule(parser.module());

          Console.WriteLine(compiler.CompileModule(module));
        }
        catch (Exception e)
        {
          // Console.WriteLine(e.GetBaseException().Message);
          Console.WriteLine(e);
        }
      }
    }
  }
}