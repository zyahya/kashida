namespace Kashida.Tests;

public class KashidaClearTests
{
    private readonly static string _normalText = "الـسـلام عـلـيـكـم";
    private readonly static string _normalTextExpected = "السلام عليكم";
    private readonly static string _vowelledText = "الـسَّـلَامُ عَـلَـيْـكُـمْ";
    private readonly static string _vowelledTextExpected = "السَّلَامُ عَلَيْكُمْ";

    [Fact]
    public void ClearKashida_GivenNormalText_ShouldReturnClearedText()
    {
        var result = _normalText.ClearKashida();

        Assert.Equal(_normalTextExpected, result);
    }

    [Fact]
    public void ClearKashida_GivenVowelledText_ShouldReturnClearedText()
    {
        var result = _vowelledText.ClearKashida();

        Assert.Equal(_vowelledTextExpected, result);
    }

    [Fact]
    public void ClearKashida_ToEmptyString()
    {
        var result = string.Empty.ClearKashida();

        Assert.Equal(string.Empty, result);
    }
}
