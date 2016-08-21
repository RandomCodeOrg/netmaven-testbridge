using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using RandomCodeOrg.NetMaven.TestBridge.IO;

namespace RandomCodeOrg.NetMaven.TestBridge.Data {
	public class TestConfig {

		private static readonly string[] SELFTEST_OPTIONS = new string[]{ "s", "-selftest" };

		private readonly IList<string> sources = new List<string>();

		private readonly ReadOnlyCollection<string> sources_ReadOnly;

		private readonly ILog log;

		public ILog Log{
			get{
				return log;
			}
		}

		public ITestLog TestLog{ get; set; }

		public ReadOnlyCollection<string> Sources {
			get {
				return sources_ReadOnly;
			}
		}

		public TestConfig(ILog log) {
			TestLog = new ConsoleTestLog();
			sources_ReadOnly = new ReadOnlyCollection<string>(sources);
			this.log = log;
		}

		public void AddSource(string filePath) {
			if(filePath == null)
				throw new ArgumentNullException("filePath");
			if(!File.Exists(filePath))
				throw new FileNotFoundException("The specified file could not be found.", filePath);
			if(sources.Contains(filePath))
				return;
			sources.Add(filePath);
		}


		public void Load(IOOutput output, CommandLineInterpreter cli) {
			try {
				foreach(string source in cli.Arguments) {
					AddSource(source);
				}
				if(cli.HasOption(SELFTEST_OPTIONS))
					AddSelf();
			} catch(FileNotFoundException e) {
				output.Err.WriteLine("The specified source file does not exist: {0}", e.FileName);
				throw TerminationException.Error(e);
			}
			if(sources.Count == 0)
				throw new TerminationException(TerminationException.SUCCESS_EXIT_CODE);
		}

		private void AddSelf() {
			string path = System.Reflection.Assembly.GetEntryAssembly().Location;
			log.Debug("Adding selftest source: {0}", path);
			AddSource(path);
		}

	}
}

