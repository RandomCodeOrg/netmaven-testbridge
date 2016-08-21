using System;

namespace RandomCodeOrg.NetMaven.TestBridge.Data {
	public interface ILog {


		void Debug(string format, params object[] args);
		void Debug(object arg);

		void Info(string format, params object[] args);
		void Info(object arg);

		void Warn(string format, params object[] args);
		void Warn(object arg);

		void Error(string format, params object[] args);
		void Error(object arg);

	}
}

