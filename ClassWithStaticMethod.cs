namespace PoserBugRepoduction
{
  public class ClassWithStaticMethod
  {
    public static void SecondStaticMethodThatThrowsException()
    {
      throw new Exception("This exception should not have occurred.");
    }
  }
}
