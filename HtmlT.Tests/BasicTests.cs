using System.Text;
using DoctypeHtml.Parser;

namespace HtmlT.Tests;

public class BasicTests
{
    const string BasicHtml = """
    <html>
        <htmlt-component-example />
    </html>
    """;

    const string ComponentExample = """
    <div>
        <h1>Hello, HTML!</h1>
    </div>
    """;

    [Test]
    public async Task BasicComponent()
    {
        var builder = new StringBuilder(BasicHtml.Length + ComponentExample.Length);
        var template = new HtmlT.HtmlTemplate.Builder()
            .AddComponent("htmlt-component-example", new HtmlT.Component(ComponentExample))
            .Build();
        var page = template.Render(BasicHtml);
        Console.WriteLine(page);
    }
}
