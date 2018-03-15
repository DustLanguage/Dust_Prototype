//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from E:/PROJECTS/Active/Dust/Dust\Dust.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Dust.Language {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="DustParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface IDustVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.module"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModule([NotNull] DustParser.ModuleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] DustParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BangUnaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBangUnaryExpression([NotNull] DustParser.BangUnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DeleteUnaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeleteUnaryExpression([NotNull] DustParser.DeleteUnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>TypeOfExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeOfExpression([NotNull] DustParser.TypeOfExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NotEqualBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotEqualBinaryExpression([NotNull] DustParser.NotEqualBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BiggerEqualBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBiggerEqualBinaryExpression([NotNull] DustParser.BiggerEqualBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DotMemberExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDotMemberExpression([NotNull] DustParser.DotMemberExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DivisionBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivisionBinaryExpression([NotNull] DustParser.DivisionBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>LiteralExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteralExpression([NotNull] DustParser.LiteralExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>MultiplicationUnaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicationUnaryExpression([NotNull] DustParser.MultiplicationUnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ArrayLiteralExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayLiteralExpression([NotNull] DustParser.ArrayLiteralExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>AdditionUnaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditionUnaryExpression([NotNull] DustParser.AdditionUnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SubstractionUnaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubstractionUnaryExpression([NotNull] DustParser.SubstractionUnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>EqualBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualBinaryExpression([NotNull] DustParser.EqualBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BiggerBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBiggerBinaryExpression([NotNull] DustParser.BiggerBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>GroupExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupExpression([NotNull] DustParser.GroupExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>MultiplicationBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicationBinaryExpression([NotNull] DustParser.MultiplicationBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IdentifierExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpression([NotNull] DustParser.IdentifierExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SmallerBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSmallerBinaryExpression([NotNull] DustParser.SmallerBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DivisionUnaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivisionUnaryExpression([NotNull] DustParser.DivisionUnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>AdditionBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditionBinaryExpression([NotNull] DustParser.AdditionBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>AssignmentExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentExpression([NotNull] DustParser.AssignmentExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SmallerEqualBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSmallerEqualBinaryExpression([NotNull] DustParser.SmallerEqualBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SubstractionBinaryExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubstractionBinaryExpression([NotNull] DustParser.SubstractionBinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>CallExpression</c>
	/// labeled alternative in <see cref="DustParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCallExpression([NotNull] DustParser.CallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] DustParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnStatement([NotNull] DustParser.ReturnStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.expressionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionStatement([NotNull] DustParser.ExpressionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.propertyDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPropertyDeclaration([NotNull] DustParser.PropertyDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.functionDeclarationBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDeclarationBase([NotNull] DustParser.FunctionDeclarationBaseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDeclaration([NotNull] DustParser.FunctionDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionName([NotNull] DustParser.FunctionNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.functionModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionModifier([NotNull] DustParser.FunctionModifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.functionParameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionParameterList([NotNull] DustParser.FunctionParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.functionFragmentator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionFragmentator([NotNull] DustParser.FunctionFragmentatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.functionParameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionParameter([NotNull] DustParser.FunctionParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.parameterName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterName([NotNull] DustParser.ParameterNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.memberName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMemberName([NotNull] DustParser.MemberNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.identifierName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierName([NotNull] DustParser.IdentifierNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.statementBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementBlock([NotNull] DustParser.StatementBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>Bool</c>
	/// labeled alternative in <see cref="DustParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBool([NotNull] DustParser.BoolContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>String</c>
	/// labeled alternative in <see cref="DustParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] DustParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>Int</c>
	/// labeled alternative in <see cref="DustParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt([NotNull] DustParser.IntContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>Float</c>
	/// labeled alternative in <see cref="DustParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFloat([NotNull] DustParser.FloatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.arrayLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayLiteral([NotNull] DustParser.ArrayLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.callParameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCallParameterList([NotNull] DustParser.CallParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.callParameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCallParameter([NotNull] DustParser.CallParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DustParser.eos"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEos([NotNull] DustParser.EosContext context);
}
} // namespace Dust.Language
