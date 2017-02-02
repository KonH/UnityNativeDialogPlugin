using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultDialog : MonoBehaviour, IDialog {
	string _message;
	Action<bool> _onCloseCallback;
	Rect _rect;
	EventSystem _curEventSystem;

	public void Show(string message, Action<bool> onCloseCallback) {
		_message = message;
		_onCloseCallback = onCloseCallback;
		SetupRect();
		SetBlocking(true);
    }

	void SetupRect() {
		var vertical = (float)Screen.height/3;
		var horizontal = (float)Screen.width/3;
		_rect = new Rect(horizontal, vertical, horizontal, vertical);
	}

	void SetBlocking(bool blocking) {
		if( !_curEventSystem ) {
			_curEventSystem = EventSystem.current;
		}
		if( _curEventSystem ) {
			_curEventSystem.enabled = !blocking;
		}
	}

	void OnGUI() {
		GUILayout.BeginArea(_rect);
		{
			GUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			{
				GUILayout.FlexibleSpace();
				GUILayout.Label(_message);
				GUILayout.BeginHorizontal(); 
				{
					if( GUILayout.Button("OK") ) {
						OnOkClick();
					}
					if( GUILayout.Button("Cancel") ) {
						OnCalcelClick();
					}
				}
				GUILayout.EndHorizontal();
				GUILayout.FlexibleSpace();
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}

	void OnOkClick() {
		Close(true);
	}

	void OnCalcelClick() {
		Close(false);
	}

	void Close(bool condition) {
		if( _onCloseCallback != null ) {
			_onCloseCallback(condition);
		}
		SetBlocking(false);
		Destroy(gameObject);
	}
}
