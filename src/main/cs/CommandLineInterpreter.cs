using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomCodeOrg.NetMaven.TestBridge {
	public class CommandLineInterpreter {

		private IList<string> arguments = new List<string>();
		private IDictionary<string, IList<string>> options = new Dictionary<string, IList<string>>();
		private const string OPTION_CHAR = "-";

		public const string DEBUG_OPTION = "X";


		public IList<string> Arguments {
			get{
				return arguments;
			}
		}

		public ICollection<string> Options{
			get{
				return options.Keys;
			}
		}

		public CommandLineInterpreter(string[] args) {
			string argName = null;
			foreach(string arg in args) {
				if(arg.StartsWith(OPTION_CHAR)) {
					argName = arg.Substring(OPTION_CHAR.Length);
					if(!options.ContainsKey(argName))
						options[argName] = new List<string>();
				} else {
					if(argName == null) {
						arguments.Add(arg);
					} else {
						options[argName].Add(arg);
					}
				}
			}
		}

		public bool HasOption(string option){
			return options.ContainsKey(option);
		}

		public bool HasOption(params string[] alternatives){
			foreach(string alt in alternatives)
				if(HasOption(alt))
					return true;
			return false;
		}

		public IList<string> Get(string option){
			if(!HasOption(option))
				new List<string>();
			return options[option];
		}

		public IList<string> Get(params string[] alternatives){
			List<string> result = new List<string>();
			foreach(string alt in alternatives)
				result.AddRange(Get(alt));
			return result;
		}

		public string GetFirst(string option){
			IList<string> res = Get(option);
			if(res.Count < 1)
				return string.Empty;
			return res[0];
		}

		public string GetFirst(params string[] alternatives){
			IList<string> res = Get(alternatives);
			if(res.Count < 1)
				return string.Empty;
			return res[0];
		}



	}
}

