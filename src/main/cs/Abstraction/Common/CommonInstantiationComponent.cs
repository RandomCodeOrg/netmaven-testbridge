using System;
using System.Reflection;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction.Common {
	public class CommonInstantiationComponent : IInstantiationComponent {
		public CommonInstantiationComponent() {
		}


		public object Perform(TestContext context) {
			Type targetType = context.TestType;
			ConstructorInfo constructor = targetType.GetConstructor(new Type[]{ });
			if(constructor == null)
				throw new TestException(String.Format("Could not find a public parameterless constructor for '{0}'.", targetType.FullName));
			try{
				return constructor.Invoke(new object[0]);
			}catch(Exception e){
				throw new TestException(String.Format("Could not create an instance of '{0}' because an exception occured invoking the consturctor. Refer to the inner exception for more details.", targetType.FullName), e);
			}
		}

	}
}

