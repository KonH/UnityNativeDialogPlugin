using UnityEngine;

public static class DialogFactory {

	public static IDialog Create() {
		return new GameObject("[DefaultDialogHandler]").AddComponent<DefaultDialog>();
	}
}
