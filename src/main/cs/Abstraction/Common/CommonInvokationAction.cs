using System;
using System.Reflection;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction.Common {
	public class CommonInvokationAction : AbstractInvokationAction{

		private readonly MethodInfo methodInfo;

		protected MethodInfo Method{
			get{
				return methodInfo;
			}
		}

		public CommonInvokationAction(string name, TestPhase phase, MethodInfo method) : base(name, phase) {

		}

		protected override void Perform(TestContext context) {
			object instance = Instance;
			try{
				context.TestLog.BeginInvoke(instance, Method);
				object result = Method.Invoke(Instance, new object[]{});
				context.TestLog.EndInvoke(instance, Method, result);
			}catch(TargetInvocationException e){
				HandleException(e);
			}
		}

		protected virtual void HandleException(TargetInvocationException e){
			throw new TestException(String.Format("An exception occured invoking '{0}.{1}'. Refer to the inner exception for more details.", Instance.GetType().FullName, Method.Name), e.InnerException);
		}

	}
}

