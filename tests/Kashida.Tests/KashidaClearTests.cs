namespace Kashida.Tests;

public class KashidaClearTests
{
    private const string _normalText = "الـسـلام عـلـيـكـم";
    private const string _normalTextExpected = "السلام عليكم";
    private const string _vowelledText = "الـسَّـلَامُ عَـلَـيْـكُـمْ";
    private const string _vowelledTextExpected = "السَّلَامُ عَلَيْكُمْ";

    private const string _normalComplexText = """
    إذا رأيـت نـيـوب اللـيـث بـارزة
    فـلا تـظـنـن أن اللـيـث يـبـتـسـم
    """;

    private const string _normalComplexTextExpected = """
    إذا رأيت نيوب الليث بارزة
    فلا تظنن أن الليث يبتسم
    """;

    private const string _vowelledComplexText = """
    إذا رأيـتَ نـيـوبَ اللـيـث بـارزةً
    فَـلا تَـظُـنَّـنَّ أنَّ الـلَـيـثَ يـبـتَـسِـمُ
    """;

    private const string _vowelledComplexTextExpected = """
    إذا رأيتَ نيوبَ الليث بارزةً
    فَلا تَظُنَّنَّ أنَّ اللَيثَ يبتَسِمُ
    """;

    [Theory]
    [InlineData(_normalText, _normalTextExpected)]
    [InlineData(_normalComplexText, _normalComplexTextExpected)]
    public void ClearKashida_GivenNormalText_ShouldReturnClearedText(string input, string expectedResult)
    {
        var result = input.ClearKashida();

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(_vowelledText, _vowelledTextExpected)]
    [InlineData(_vowelledComplexText, _vowelledComplexTextExpected)]
    public void ClearKashida_GivenVowelledText_ShouldReturnClearedText(string input, string expectedResult)
    {
        var result = input.ClearKashida();

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ClearKashida_ToEmptyString()
    {
        var result = string.Empty.ClearKashida();

        Assert.Equal(string.Empty, result);
    }
}
