using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApplication
{
    public class App
    {
		internal static AppConfiguration Configuration { get; private set; }

		public static void Configure(AppConfiguration configuration)
		{
			Configuration = configuration;

			// Registering the global/centralized exceptional handler
			//GlobalExceptionHandler globalExceptionHandler = new GlobalExceptionHandler();
			//globalExceptionHandler.RegisterGlobalExceptionHandler();

		}

		//internal static void ValidateUserToken(string userToken)
		//{
		//	bool isValid = false;

		//	if (String.IsNullOrEmpty(userToken) == false)
		//	{
		//		List<string> tokenValues = null;
		//		Guid userGuid;
		//		string decryptedUserToken = EncryptDecryptHelper.Decrypt(userToken);
		//		isValid = TokenHelper.IsUserTokenValid(decryptedUserToken, out userGuid, out tokenValues);
		//	}

		//	if (!isValid)
		//	{
		//		throw new Exceptions.CustomBusinessException("Invalid/Expired user token. Please login.");
		//	}
		//}
	}
	public class AppConfiguration
	{
		//internal string ConsumerUserToken { get; set; }
		public string ConnectionString { get; set; }
        public string ErrorLogDestination { get; set; }
        public bool IsDbQueryTraceEnabled { get; set; }
        public string DbQueryTraceDestination { get; set; }
        public string TextLogDirectory { get; set; }
    }
}
