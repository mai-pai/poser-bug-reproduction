
namespace PoserBugRepoduction
{
  public class ServiceOutput
  {
    public int _OperationStatus;
    public string _ExtendedDescription;

    public string Email { get; set; }
    public int Id { get; set; }

    public void SetStatus_Failure(Exception ex)
    {
      _OperationStatus = -1;
      _ExtendedDescription = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}";
    }

    public void SetStatus_Success()
    {
      _OperationStatus = 0;
      _ExtendedDescription = string.Empty;
    }

    public void SetStatus_Failure(string message)
    {
      _OperationStatus = -2;
      _ExtendedDescription = message;
    }
  }
}