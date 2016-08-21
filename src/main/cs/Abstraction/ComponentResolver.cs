using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomCodeOrg.NetMaven.TestBridge.Abstraction {
	public class ComponentResolver {


		private readonly ICollection<ITestComponent> components;

		private readonly IDictionary<Type, ITestComponent> cache = new Dictionary<Type, ITestComponent>();

		public ComponentResolver(ICollection<ITestComponent> components) {
			this.components = components;
		}


		protected ITestComponent ResolveBasic(Requirement r){
			Type componentType = r.ComponentType;
			if(cache.ContainsKey(componentType))
				return cache[componentType];
			ITestComponent result = null;
			foreach(ITestComponent current in components) {
				if(componentType.IsAssignableFrom(current.GetType())) {
					result = current;
					break;
				}
			}
			if(result != null)
				cache[componentType] = result;
			return result;
		}

		public ITestComponent Resolve(Requirement r){
			return ResolveBasic(r);
		}

		public C Resolve<C,T>(Requirement<C, T> r) where C : ITestComponent<T> {
			return (C) ResolveBasic(r);
		}

		public C Resolve<C, T>() where C : ITestComponent<T>{
			return Resolve<C,T>(new Requirement<C,T>(null));
		}

		public C Resolve<C>() where C : ITestComponent{
			return (C) Resolve(new Requirement(typeof(C), typeof(object), null));
		}

	}
}

