namespace PoserBugRepoduction
{
  public class ServiceUnderTest
  {
    public ServiceOutput Create(ServiceInput input)
    {
      var serviceOutput = new ServiceOutput();
      try
      {
        LegacyClass.FirstStaticMethodThatThrowsException();

        if (input.Id < 1)
        {
          serviceOutput.SetStatus_Failure("Id must be set");
          return serviceOutput;
        }

        serviceOutput.Email = input.Email?.Trim() ?? string.Empty;

        ClassWithStaticMethod.SecondStaticMethodThatThrowsException();
      }
      catch (Exception ex)
      {
        serviceOutput.SetStatus_Failure(ex);
      }
      finally
      {
        if (serviceOutput._OperationStatus != 0)
        {
          ErrorHandler.PublishError(serviceOutput._ExtendedDescription);
        }

        LegacyLogger.WriteLogInfo(serviceOutput._ExtendedDescription);
      }

      return serviceOutput;
    }
  }
}
