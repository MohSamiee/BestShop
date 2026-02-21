namespace BestShop.Common.OperationResult
{

	public class OperationResult<TEntity> where TEntity : class
	{
		#region Constructor
		public OperationResult(bool isSuccess, TEntity? data, string? message, List<ModelStateError> modelStateErrors) : base()
		{
			IsSuccess = isSuccess;
			Message = message;
			Data = data!;
			ModelStateErrors = modelStateErrors;
		}

		public OperationResult(bool isSuccess, TEntity? data, string? message, ModelStateError? modelStateError = null) : base()
		{
			IsSuccess = isSuccess;
			Message = message;
			Data = data!;
			ModelStateErrors = modelStateError == null ? null : new List<ModelStateError>
			{
				modelStateError
			};
		}
		#endregion Constructor

		#region Properties
		public bool IsSuccess { get; set; }
		public TEntity? Data { get; set; }
		public string? Message { get; set; }
		public List<ModelStateError>? ModelStateErrors { get; set; }

		#endregion Properties

		#region Methods
		public static ModelStateError MakeModelStateError(string field, string message)
		{
			return new ModelStateError()
			{
				ModelStateField = field,
				ModelStateErrorMessage = message
			};
		}
		#endregion Methods
	}
	public class ModelStateError
	{
		public string ModelStateField { get; set; }
		public string ModelStateErrorMessage { get; set; }
	}

	public enum ErrorMessageEnum
	{
		UserNotFound = 1,

		SomethingWentWrong = 999
	}
}
