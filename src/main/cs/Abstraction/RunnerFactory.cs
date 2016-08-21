using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using RandomCodeOrg.NetMaven.TestBridge.Data;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {
	public class RunnerFactory {

		private readonly ComponentResolver componentResolver;

		public RunnerFactory(ICollection<ITestComponent> components) {
			this.componentResolver = new ComponentResolver(components);
		}

		public ITestRunner Create(TestConfig config){
			IStepFactory stepFactory = componentResolver.Resolve<IStepFactory>();
			IDictionary<Type, IList<TestAction>> actions = new Dictionary<Type, IList<TestAction>>();
			Assembly assembly;
			foreach(string source in config.Sources) {
				assembly = Assembly.LoadFile(source);
				foreach(Type t in assembly.GetTypes()) {
					if(actions.ContainsKey(t))
						continue;
					Load(stepFactory, actions, new TestContext(t, config.TestLog));
				}
			}

			return null;
		}

		protected virtual void Load(IStepFactory stepFactory, IDictionary<Type, IList<TestAction>> actions, TestContext context){
			ICollection<TestAction> result = stepFactory.Perform(context);
			if(result == null || result.Count == 0)
				return;
			List<TestAction> sorted = new List<TestAction>();
			sorted.AddRange(result);
			sorted.Sort((a, b) => a.Order.CompareTo(b.Order));
			actions[context.TestType] = sorted;
		}

	}
}

