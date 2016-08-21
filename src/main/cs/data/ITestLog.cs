using System;
using System.Reflection;
using NUnit.Framework.Constraints;

namespace RandomCodeOrg.NetMaven.TestBridge.Data {
	public interface ITestLog {

		void BeginInvoke(object instance, MethodBase method);
		void EndInvoke(object instance, MethodBase method, object result);


	}
}

