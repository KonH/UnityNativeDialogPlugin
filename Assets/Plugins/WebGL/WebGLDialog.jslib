var webGLDialog = {
	WebGLDialogShow: function(msg)
	{
		return window.confirm(Pointer_stringify(msg));
	}
};

mergeInto(LibraryManager.library, webGLDialog);
