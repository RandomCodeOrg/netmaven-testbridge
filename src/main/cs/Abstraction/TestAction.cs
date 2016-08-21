using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {
	public abstract class TestAction {

		private readonly string actionName;
		private readonly int order;

		private const int DEFAULT_PHASE_SPACING = 4;

		private readonly IList<Requirement> requirements = new List<Requirement>();
		private readonly ReadOnlyCollection<Requirement> readOnly_requirements;

		public ReadOnlyCollection<Requirement> Requirements{
			get{
				return readOnly_requirements;
			}
		}

		public int Order{
			get{ return order; }
		}

		private TestAction(string actionName, int order) {
			this.actionName = actionName;
			this.order = order;
			readOnly_requirements = new ReadOnlyCollection<Requirement>(requirements);
		}

		protected TestAction(string actionName, TestPhase phase) : this(actionName, ((int) phase) * DEFAULT_PHASE_SPACING){

		}

		protected abstract void Perform(TestContext context);

		protected void Requires<C,T>(ComponentInitializationDelegate<C,T> callback) where C : ITestComponent<T> {
			requirements.Add(new Requirement<C,T>(callback));
		}

	}
}

