using System;
using System.Runtime.InteropServices;

public class WebGLDialog : IDialog {
	
	[DllImport("__Internal")]
	static extern bool WebGLDialogShow(string message);

    public void Show(string message, Action<bool> onCloseCallback) {
		var result = WebGLDialogShow(message);
		if( onCloseCallback != null ) {
			onCloseCallback(result);
		}
    }
}
