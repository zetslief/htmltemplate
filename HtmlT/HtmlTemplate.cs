using System.Collections.Immutable;

namespace HtmlT;

public class Component(string Name, string Content);

public class HtmlTemplate(ImmutableArray<Component> Components)
{
    public string Render(string page)
    {
    }
}
