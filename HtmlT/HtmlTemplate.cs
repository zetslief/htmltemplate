using System.Collections.Immutable;

namespace HtmlT;

public record Component(string Content);

public record HtmlTemplate(Dictionary<string, Component> components)
{
    public string Render(string page)
        => page;

    public class Builder
    {
        private readonly Dictionary<string, Component> _components = [];

        public Builder AddComponent(string name, Component component) { _components[name] = component; return this; }
        public HtmlTemplate Build() => new(_components);
    }
}
