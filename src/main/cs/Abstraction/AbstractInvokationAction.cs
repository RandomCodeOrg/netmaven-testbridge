using System;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {
	public abstract class AbstractInvokationAction : TestAction {

		private object instance;

		protected object Instance{
			get{
				return instance;
			}
		}

		protected AbstractInvokationAction(string actionName, TestPhase phase) : base(actionName, phase){
			Requires<IInstantiationComponent, object>(InitInstance);
		}


		private void InitInstance(IInstantiationComponent component, object instance){
			this.instance = instance;
		}



	}
}

