using System;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {

	public interface ITestComponent {

		object Perform(TestContext context);

	}

	public interface ITestComponent<T> : ITestComponent{

		new T Perform(TestContext context);

	}

}

