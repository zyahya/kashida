namespace Kashida.Tests;

public class KashidaApplyTests
{
    private readonly static string _normalText = "السلام عليكم";
    private readonly static string _normalTextExpected = "الـسـلام عـلـيـكـم";
    private readonly static string _vowelledText = "السَّلَامُ عَلَيْكُمْ";
    private readonly static string _vowelledTextExpected = "الـسَّـلَامُ عَـلَـيْـكُـمْ";

    [Fact]
    public void ApplyKashida_Transforms_Normal_Text()
    {
        var result = _normalText.ApplyKashida();

        Assert.Equal(_normalTextExpected, result);
    }

    [Fact]
    public void ApplyKashida_Transforms_Vowelled_Text()
    {
        var result = _vowelledText.ApplyKashida();

        Assert.Equal(_vowelledTextExpected, result);
    }
}
