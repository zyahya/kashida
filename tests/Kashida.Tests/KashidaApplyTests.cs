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
        var result = Kashida.ApplyKashida(_normalText);

        Assert.Equal(_normalTextExpected, result);
    }

    [Fact]
    public void ApplyKashida_Transforms_Vowelled_Text()
    {
        var result = Kashida.ApplyKashida(_vowelledText);

        Assert.Equal(_vowelledTextExpected, result);
    }
}
