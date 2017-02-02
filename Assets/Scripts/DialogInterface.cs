using UnityEngine;
using UnityEngine.Events;

public class DialogInterface : MonoBehaviour {
	public UnityEvent OnYes;
	public UnityEvent OnNo;

	public void Show(string message) {
		Dialog.Show(message, () => OnYes.Invoke(), () => OnNo.Invoke());
	}
}
