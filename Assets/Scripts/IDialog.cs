using System;

public interface IDialog {
	void Show(string message, Action<bool> onCloseCallback);
}
