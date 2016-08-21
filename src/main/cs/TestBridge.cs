using System;
using System.Reflection;

using RandomCodeOrg.NetMaven.TestBridge.Data;
using RandomCodeOrg.NetMaven.TestBridge.IO;

namespace RandomCodeOrg.NetMaven.TestBridge {
	public class TestBridge {

		public static void Main(string[] args) {
			IOOutput programOutput = new IOOutput(Console.Out, Console.Error);
			CommandLineInterpreter cli = new CommandLineInterpreter(args);
			ILog log = new StdLog(programOutput, cli.HasOption(CommandLineInterpreter.DEBUG_OPTION));
			try {
				
				TestConfig config = new TestConfig(log);
				config.Load(programOutput, cli);

				Assembly assembly;
				foreach(string source in config.Sources){
					assembly = Assembly.LoadFile(source);
					foreach(Type t in assembly.GetTypes()){
						log.Debug("Assembly {0} contains: {1}", assembly.FullName, t.FullName);
						foreach(MethodInfo m in t.GetMethods()){
							log.Debug("\t{0}", m.ToString());
						}
					}
				}

				/*
				var engine = new TestEngine();
				engine.Initialize();

				DefaultTestEventListener listener = new DefaultTestEventListener(log);
				foreach(string source in config.Sources){
					TestPackage package = new TestPackage(source);
					ITestRunner runner = engine.GetRunner(package);
					runner.Run(listener, TestFilter.Empty);
				}*/
			} catch(TerminationException e) {
				if(e.ExitCode != TerminationException.SUCCESS_EXIT_CODE) programOutput.Err.WriteLine(e);
				Environment.Exit(e.ExitCode);
			} catch(Exception e) {
				programOutput.Err.WriteLine(e);
				Environment.Exit(TerminationException.ERROR_EXIT_CODE);
			}
			Environment.Exit(TerminationException.SUCCESS_EXIT_CODE);
		}



	}
}

