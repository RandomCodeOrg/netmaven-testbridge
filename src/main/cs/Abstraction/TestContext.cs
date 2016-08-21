using System;

using RandomCodeOrg.NetMaven.TestBridge.Data;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {
	public class TestContext {

		private readonly Type testType;
		private readonly ITestLog log;
		private object instance;
		private readonly TestConfig config;

		public Type TestType{
			get{
				return testType;
			}
		}

		public ITestLog TestLog{
			get{
				return log;
			}
		}

		public TestConfig Config{
			get{
				return config;
			}
		}


		public TestContext(Type testType, ITestLog testLog) {
			this.testType = testType;
			this.log = testLog;
		}



	}
}

