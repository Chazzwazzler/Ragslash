using UnityEngine;

public static class gameUtilities
{
    static Camera _mainCamera;
	static builder _builder;

	static toolBar _toolBar;

    //Gets the main camera of the scene
    static Camera MainCamera {
		get {
			if (_mainCamera == null) {
				_mainCamera = Camera.main;
			}
			return _mainCamera;
		}
	}

	//Gets the controller for building in the scene
	public static builder Builder {
		get{
			if(_builder == null){
				_builder = GameObject.Find("Game Controller").GetComponent<builder>();
			}
			return _builder;
		}
	}

	public static toolBar ToolBar{
		get{
			if(_toolBar == null){
				_toolBar = GameObject.Find("Game Controller").GetComponent<toolBar>(); 
			}
			return _toolBar;
		}
	}

    //Gets the position of the mouse
    public static Vector2 MouseWorldPos {
		get {
			return MainCamera.ScreenToWorldPoint (Input.mousePosition);
		}
	}

    //Checks if the mouse is over a UI object
    public static bool MouseOverUIObject {
		get{
		return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ();
		}
	}

    //Gets the object under the mouse at select layers
    public static GameObject GetObjectUnderMouse2D () {
		Vector2 mouse = MouseWorldPos;
		var hit = Physics2D.GetRayIntersection (new Ray (new Vector3 (mouse.x, mouse.y, -100), Vector3.forward), float.MaxValue);
		if (hit.collider) {
			return hit.collider.gameObject;
		}
		return null;
	}
}
