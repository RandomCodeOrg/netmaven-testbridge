using System;

using RandomCodeOrg.NetMaven.TestBridge.IO;


namespace RandomCodeOrg.NetMaven.TestBridge.Data {
	public class StdLog : ILog {

		private readonly bool emitDebug;
		private readonly IOOutput output;

		public StdLog(IOOutput output, bool enableDebugOutput) {
			this.emitDebug = enableDebugOutput;
			this.output = output;
		}

		public void Debug(string format, params object[] args) {
			if(!emitDebug)
				return;
			Log("Debug", output.Out, format, args);
		}

		public void Debug(object arg) {
			Debug("{0}", arg);
		}

		public void Info(string format, params object[] args) {
			Log("Info", output.Out, format, args);
		}

		public void Info(object arg) {
			Info("{0}", arg);
		}

		public void Warn(string format, params object[] args) {
			Log("Warn", output.Err, format, args);
		}

		public void Warn(object arg) {
			Warn("{0}", arg);
		}

		public void Error(string format, params object[] args) {
			Log("Error", output.Err, format, args);
		}

		public void Error(object arg) {
			Error("{0}", arg);
		}

		protected virtual void Log(string level, System.IO.TextWriter writer, string format, params object[] args){
			writer.WriteLine("[{0}] {1}", level, string.Format(format, args));
		}

	}
}

