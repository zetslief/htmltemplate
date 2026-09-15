namespace HtmlT.Tests;

public class BasicTests
{
    const string BasicHtml = """
    <html>
        <htmlt-example />
    </html>
    """;

    [Test]
    public async Task Divide_ByZero_ThrowsException()
    {
        await Assert.That(2 * 2).IsEqualTo(4);
    }
}
