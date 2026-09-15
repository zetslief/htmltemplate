using System.Text;

using DoctypeHtml.Parser;

namespace HtmlT;

public record Component(string Content);

public record HtmlTemplate(Dictionary<string, Component> Components)
{
    public string Render(string page)
    {
        var output = new StringBuilder(page.Length * 2);
        Tokenizer.Run(page.AsMemory(), t => output.Append(TokenToString(t)));
        return output.ToString();
    }

    private string TokenToString(Token token) => token switch
    {
        DoctypeToken doctype => $"<!DOCTYPE {doctype.Name}>",
        StartTagToken startTag => startTag.SelfClosing ? SelfClosingTagToString(startTag) : $"<{startTag.Name}>",
        EndTagToken endTag => $"</{endTag.Name}>",
        CharacterToken character => $"{character.Character}",
        CommentToken comment => $"<!--{comment.Data}-->",
        EndOfFileToken _ => Environment.NewLine,
        var unknown => throw new NotImplementedException($"Token is not supported: {unknown}"),
    };

    private string SelfClosingTagToString(StartTagToken token) => Components.TryGetValue(token.Name, out var component)
        ? component.Content
        : $"<{token.Name} />";

    public class Builder
    {
        private readonly Dictionary<string, Component> _components = [];

        public Builder AddComponent(string name, Component component) { _components[name] = component; return this; }
        public HtmlTemplate Build() => new(_components);
    }
}
