namespace Kashida.Tests;

public class KashidaApplyTests
{
    private const string _normalText = "السلام عليكم";
    private const string _normalTextExpected = "الـسـلام عـلـيـكـم";
    private const string _vowelledText = "السَّلَامُ عَلَيْكُمْ";
    private const string _vowelledTextExpected = "الـسَّـلَامُ عَـلَـيْـكُـمْ";

    private const string _normalComplexText = """
    إذا رأيت نيوب الليث بارزة
    فلا تظنن أن الليث يبتسم
    """;

    private const string _normalComplexTextExpected = """
    إذا رأيـت نـيـوب اللـيـث بـارزة
    فـلا تـظـنـن أن اللـيـث يـبـتـسـم
    """;

    private const string _vowelledComplexText = """
    إذا رأيتَ نيوبَ الليث بارزةً
    فَلا تَظُنَّنَّ أنَّ اللَيثَ يبتَسِمُ
    """;

    private const string _vowelledComplexTextExpected = """
    إذا رأيـتَ نـيـوبَ اللـيـث بـارزةً
    فَـلا تَـظُـنَّـنَّ أنَّ الـلَـيـثَ يـبـتَـسِـمُ
    """;

    [Theory]
    [InlineData(_normalText, _normalTextExpected)]
    [InlineData(_normalComplexText, _normalComplexTextExpected)]
    public void ApplyKashida_Transforms_Normal_Text(string input, string expectedResult)
    {
        var result = input.ApplyKashida();

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(_vowelledText, _vowelledTextExpected)]
    [InlineData(_vowelledComplexText, _vowelledComplexTextExpected)]
    public void ApplyKashida_Transforms_Vowelled_Text(string input, string expectedResult)
    {
        var result = input.ApplyKashida();

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ApplyKashida_ToEmptyString()
    {
        var result = string.Empty.ApplyKashida();

        Assert.Equal(string.Empty, result);
    }
}
