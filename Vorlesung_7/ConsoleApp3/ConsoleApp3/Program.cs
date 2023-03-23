
// 1 + 2 * 3


using System.Security;
using System.Transactions;

while (true)
{
    Console.Write(">");
    var text = Console.ReadLine();
    var parser = new Parser(text);
    if (string.IsNullOrWhiteSpace(text))
    {
        break;
    }
    var root = parser.Parse();
    PrettyPrint(root);
}


void PrettyPrint(SyntaxNode node, string indent = "")
{
    Console.Write(indent);
    Console.WriteLine($"n: '{node.Kind}': {(node is SyntaxToken st ? "[" + st.Text + "]" : "")}");
    indent += "    ";
    foreach (var children in node.GetChildren())
    {
        PrettyPrint(children, indent);
    }
}

public class Lexer
{
    private readonly string _text;
    private int _position;

    public Lexer(string text)
    {
        _text = text;
        _position = 0;
    }

    private char Current
    {
        get
        {
            if (_position >= _text.Length)
            {
                return '\0';
            }
            return _text[_position];
        }
    }

    public SyntaxToken GetNextToken()
    {
        //numbers(1,2,5,7,0)
        // +, *, /, -
        // ( )
        // <whitespaces>

        if (char.IsWhiteSpace(Current))
        {
            var start = _position;
            while (char.IsWhiteSpace(Current))
            {
                _position++;
            }
            return new SyntaxToken(SyntaxKind.Whitespace, start, _text.Substring(start, _position - start), null);
        }

        if (char.IsDigit(Current))
        {
            var start = _position;
            while (char.IsDigit(Current))
            {
                _position++;
            }
            var subStr = _text.Substring(start, _position - start);
            int.TryParse(subStr, out var number);
            return new SyntaxToken(SyntaxKind.Number, start, subStr, number);
        }

        if (Current == '*')
        {
            return new SyntaxToken(SyntaxKind.Star, _position++, "*", null);
        }
        if (Current == '/')
        {
            return new SyntaxToken(SyntaxKind.Slash, _position++, "/", null);
        }
        if (Current == '+')
        {
            return new SyntaxToken(SyntaxKind.Plus, _position++, "+", null);
        }
        if (Current == '-')
        {
            return new SyntaxToken(SyntaxKind.Minus, _position++, "-", null);
        }
        if (Current == '(')
        {
            return new SyntaxToken(SyntaxKind.OpenBracket, _position++, "(", null);
        }
        if (Current == ')')
        {
            return new SyntaxToken(SyntaxKind.CloseBracket, _position++, ")", null);
        }

        if (Current == '[')
        {
            return new SyntaxToken(SyntaxKind.OpenBracket, _position++, "[", null);
        }
        if (Current == ']')
        {
            return new SyntaxToken(SyntaxKind.CloseBracket, _position++, "]", null);
        }


        if (Current == '\0')
        {
            return new SyntaxToken(SyntaxKind.EndOfFile, _position++, "\0", null);
        }

        return new SyntaxToken(SyntaxKind.BadToken, _position++, _text[_position - 1].ToString(), null);
    }
}

public class SyntaxToken : SyntaxNode
{
    public SyntaxToken(SyntaxKind kind, int position, string text, object value)
    {
        Kind = kind;
        Position = position;
        Text = text;
        Value = value;
    }

    public override SyntaxKind Kind { get; }
    public int Position { get; }
    public string Text { get; }
    public object Value { get; }

    public override IEnumerable<SyntaxNode> GetChildren()
    {
        return Enumerable.Empty<SyntaxNode>();
    }
}

public enum SyntaxKind
{
    Whitespace,
    Number,
    Minus,
    Slash,
    Plus,
    EndOfFile,
    BadToken,
    Star,
    OpenBracket,
    CloseBracket,
    BinaryExpression
}


public class Parser
{
    private readonly string _text;
    private readonly SyntaxToken[] _tokens;
    private int _position;

    public Parser(string text)
    {
        _text = text;
        var lexer = new Lexer(text);
        var tokens = new List<SyntaxToken>();

        var token = lexer.GetNextToken();
        do
        {
            if (token.Kind is not SyntaxKind.Whitespace)
            {
                tokens.Add(token);
            }
            token = lexer.GetNextToken();
        } while (token.Kind is not SyntaxKind.EndOfFile);
        tokens.Add(token);

        _tokens = tokens.ToArray();
    }


    private SyntaxToken Peek(int offset)
    {
        if (_position + offset >= _tokens.Length)
        {
            return _tokens[_tokens.Length - 1];
        }

        return _tokens[_position + offset];
    }

    private SyntaxToken Current => Peek(0);


    public SyntaxNode Parse()
    {

        if (Current.Kind is SyntaxKind.EndOfFile)
        {
            return Current;
        }
        if (Current.Kind is SyntaxKind.Number && Peek(1).Kind is SyntaxKind.EndOfFile)
        {
            return Current;
        }

        if (Current.Kind is SyntaxKind.Number && Peek(1).Kind is SyntaxKind.Star or SyntaxKind.Slash)
        {
            var left2 = Parse();
            if (Current.Kind is SyntaxKind.Plus or SyntaxKind.Slash or SyntaxKind.Minus or SyntaxKind.Star)
            {
                var op = Current;
                _position++;
                var right = Current;
                _position++;
                return new BinaryExpression(left2, op, right);
            }
        }
        var left = Current;
        _position++;
        if (Current.Kind is SyntaxKind.Plus or SyntaxKind.Slash or SyntaxKind.Minus or SyntaxKind.Star)
        {
            var op = Current;
            _position++;
            var right = Parse();
            return new BinaryExpression(left, op, right);
        }

        return Current;
    }
}

public abstract class SyntaxNode
{
    public abstract SyntaxKind Kind { get; }

    public abstract IEnumerable<SyntaxNode> GetChildren();
}

public class BinaryExpression : SyntaxNode
{
    public BinaryExpression(SyntaxNode left, SyntaxToken @operator, SyntaxNode right)
    {
        Left = left;
        Operator = @operator;
        Right = right;
    }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

    public SyntaxNode Left { get; }

    public SyntaxToken Operator { get; }

    public SyntaxNode Right { get; }

    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return Left;
        yield return Operator;
        yield return Right;
    }
}