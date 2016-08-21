using System;



namespace RandomCodeOrg.NetMaven.TestBridge.Data {
	public class ConsoleTestLog : ITestLog {

		public ConsoleTestLog(){
		
		}
			
		private DateTime start;

		public void BeginInvoke(object instance, System.Reflection.MethodBase method) {
			Console.Write("Invoking {0}.{1}...");
			start = DateTime.Now;
		}

		public void EndInvoke(object instance, System.Reflection.MethodBase method, object result) {
			DateTime end = DateTime.Now;
			string output = "[Done]";
			Console.SetCursorPosition(Console.BufferWidth - output.Length, Console.CursorTop);
			Console.WriteLine(output);
		}

	}
}

