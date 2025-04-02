using Pose;

namespace PoserBugRepoduction
{
  public class UnitTest
  {
    [Fact]
    public void PoseBugReproductionTests()
    {
      var secondStaticMethodCalled = false;
      var shim1 = Shim
        .Replace(() => LegacyClass.FirstStaticMethodThatThrowsException())
        .With(delegate () { });

      var shim2 = Shim
        .Replace(() => ClassWithStaticMethod.SecondStaticMethodThatThrowsException())
        .With(delegate ()
        {
          secondStaticMethodCalled = true;
        });

      var outObj = default(ServiceOutput);
      PoseContext.Isolate(() =>
      {
        var inputObj = new ServiceInput
        {
          Email = "user@example.com",
          Id = 0
        };

        var service = new ServiceUnderTest();
        outObj = service.Create(inputObj);
      }, shim1, shim2);

      Assert.NotNull(outObj);
      Assert.Equal("Id must be set", outObj._ExtendedDescription);
      Assert.Equal(-2, outObj._OperationStatus);
      Assert.False(secondStaticMethodCalled);
    }
  }
}
