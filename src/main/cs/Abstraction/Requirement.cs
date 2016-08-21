using System;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {

	public class Requirement {


		private readonly Type componentType;

		public virtual Type ComponentType{
			get{
				return componentType;
			}
		}

		private readonly Type resultType;

		public virtual Type ResultType{
			get{
				return resultType;
			}
		}

		private readonly ComponentInitializationDelegate initDelegate;

		public virtual ComponentInitializationDelegate InitDelegate{
			get{
				return initDelegate;
			}
		}

		public Requirement(Type componentType, Type resultType, ComponentInitializationDelegate initDelegate){
			this.componentType = componentType;
			this.initDelegate = initDelegate;
			this.resultType = resultType;
		}

	}

	public class Requirement<C,T> : Requirement where C : ITestComponent<T>{

		private readonly ComponentInitializationDelegate<C, T> initDelegate;

		public Requirement(ComponentInitializationDelegate<C, T> initDelegate):base(typeof(C), typeof(T), (sender, value) => initDelegate((C) sender, (T) value)){
		
		}

	}

}

