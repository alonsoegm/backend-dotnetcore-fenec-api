namespace FenecApi.DTOs.utils
{
	public class ServiceResponse<T>
	{
		public bool IsSuccess { get; set; } = true;
		public string Message { get; set; } = "Transaction successful";
		public int HttpCode { get; set; } = StatusCodes.Status200OK;
		public T Data { get; set; }

		public void SetError(string message, int httpCode)
		{
			IsSuccess = false;
			Message = message;
			HttpCode = httpCode;
		}
	}
}
