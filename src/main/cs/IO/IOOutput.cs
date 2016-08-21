using System;
using System.IO;


namespace RandomCodeOrg.NetMaven.TestBridge.IO {
	public class IOOutput {

		private readonly TextWriter outWriter;

		public TextWriter Out{
			get{
				return outWriter;
			}
		}

		private readonly TextWriter errWriter;

		public TextWriter Err{
			get{
				return errWriter;
			}
		}

		public IOOutput(TextWriter outWriter, TextWriter errWriter) {
			this.outWriter = outWriter;
			this.errWriter = errWriter;
		}
	}
}

