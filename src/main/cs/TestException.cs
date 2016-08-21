using System;

namespace RandomCodeOrg.NetMaven.TestBridge {
	public class TestException : Exception {
		public TestException(string message) : base(message) {
		}

		public TestException(string message, Exception innerException) : base(message, innerException) {
			
		}
	}
}

