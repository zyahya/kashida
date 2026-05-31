namespace Kashida.Tests;

public class KashidaApplyTests
{
    [Fact]
    public void ApplyKashida_Transforms_Normal_Text()
    {
        var result = Kashida.Apply("السلام عليكم");
        var expectedResult = "الـسـلام عـلـيـكـم";

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ApplyKashida_Transforms_Vowelled_Text()
    {
        var result = Kashida.Apply("السَّلَامُ عَلَيْكُمْ");
        var expectedResult = "الـسَّـلَامُ عَـلَـيْـكُـمْ";

        Assert.Equal(expectedResult, result);
    }
}
