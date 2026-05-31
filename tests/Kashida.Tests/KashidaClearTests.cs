namespace Kashida.Tests;

public class KashidaClearTests
{
    [Fact]
    public void ClearKashida_GivenNormalText_ShouldReturnClearedText()
    {
        var result = Kashida.ClearKashida("الـسـلام عـلـيـكـم");
        var expectedResult = "السلام عليكم";

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ClearKashida_GivenVowelledText_ShouldReturnClearedText()
    {
        var result = Kashida.ClearKashida("الـسَّـلَامُ عَـلَـيْـكُـمْ");
        var expectedResult = "السَّلَامُ عَلَيْكُمْ";

        Assert.Equal(expectedResult, result);
    }
}
