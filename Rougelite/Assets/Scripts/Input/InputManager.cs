using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
	public readonly InputControls inputControls;
	public bool IsUI => inputControls.UI.enabled;

	public InputManager()
	{
		inputControls = new InputControls();
	}

	public void ToggleActionMap(InputActionMap actionMap)
	{
		inputControls.Disable();
		actionMap.Enable();
	}
}
