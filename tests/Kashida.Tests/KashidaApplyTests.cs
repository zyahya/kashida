namespace Kashida.Tests;

public class KashidaApplyTests
{
    [Fact]
    public void ApplyKashida_Transforms_Normal_Text()
    {
        var result = Kashida.ApplyKashida("السلام عليكم");
        var expectedResult = "الـسـلام عـلـيـكـم";

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ApplyKashida_Transforms_Vowelled_Text()
    {
        var result = Kashida.ApplyKashida("السَّلَامُ عَلَيْكُمْ");
        var expectedResult = "الـسَّـلَامُ عَـلَـيْـكُـمْ";

        Assert.Equal(expectedResult, result);
    }
}
