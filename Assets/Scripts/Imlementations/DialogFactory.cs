using UnityEngine;

public static class DialogFactory {

	public static IDialog Create() {
		switch( Application.platform ) {
			case RuntimePlatform.WebGLPlayer:
				return new WebGLDialog();

			default:
				return DefaultDialog();
		}
		
	}

	static IDialog DefaultDialog() {
		return new GameObject("[DefaultDialogHandler]").AddComponent<DefaultDialog>();
	}
}
