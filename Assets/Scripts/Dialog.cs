using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dialog {

	public static void Show(string message, Action<bool> onCloseCallback) {
		DialogFactory.Create().Show(message, onCloseCallback);
	}

	public static void Show(string message, Action onOkCallback, Action onCancelCallback) {
		Show(message, (result) => OnCloseHandler(result, onOkCallback, onCancelCallback) );
	}

	static void OnCloseHandler(bool result, Action onPositive, Action onNegative) {
		if( result ) {
			onPositive();
		} else {
			onNegative();
		}
	}
}
