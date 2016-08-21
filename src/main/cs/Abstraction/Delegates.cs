using System;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {

	public delegate void ComponentInitializationDelegate<C, T>(C sender, T value) where C : ITestComponent<T>;
	public delegate void ComponentInitializationDelegate(object sender, object value);


}

