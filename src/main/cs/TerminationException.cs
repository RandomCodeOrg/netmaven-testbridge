using System;

namespace RandomCodeOrg.NetMaven.TestBridge {
	public class TerminationException : Exception {

		private readonly int exitCode;

		public int ExitCode {
			get{ return exitCode; }
		}

		public const int ERROR_EXIT_CODE = -1;
		public const int SUCCESS_EXIT_CODE = 0;

		public TerminationException(int exitCode) :
			base("An exception occured that requires this application to exit. Refer to the output for more details.") {
			this.exitCode = exitCode;
		}

		public TerminationException(int exitCode, Exception innerException) :
			base("An exception occured that requires this application to exit. Refer to the inner exception for more details.", innerException) {
			this.exitCode = exitCode;
		}

		public static TerminationException Error() {
			return new TerminationException(ERROR_EXIT_CODE);
		}

		public static TerminationException Error(Exception innerException){
			return new TerminationException(ERROR_EXIT_CODE, innerException);
		}

	}
}

