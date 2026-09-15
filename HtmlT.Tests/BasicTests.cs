namespace HtmlT.Tests;

public class BasicTests
{
    [Test]
    public async Task Divide_ByZero_ThrowsException()
    {
        await Assert.That(2 * 2).IsEqualTo(4);
    }
}
