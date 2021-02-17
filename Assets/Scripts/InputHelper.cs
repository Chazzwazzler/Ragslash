//Contains helpful and universal functions that relate to mouse and keyboard input, plus some miscellaneous functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHelper
{
	public static List<GameObject> GetSelectedObjects{
		get{
			return GameObject.Find("Tool Controller").GetComponent<SelectionTool>().selectedObjects;
		}
	}

    public static Camera MainCamera {
		get {
			return Camera.main;
		}
	}

	public static GameObject GetObjectUnderMouse2D {
        get {
            Vector2 mouse = MouseWorldPos;
            var hit = Physics2D.GetRayIntersection (new Ray (new Vector3 (mouse.x, mouse.y, -100), Vector3.forward), float.MaxValue);
            if (hit.collider) {
                return hit.collider.gameObject;
            }
            return null;
        }
	}

    public static bool MouseOverUIObject {
		get{
		return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ();
		}
	}

    public static Vector2 MouseWorldPos {
		get {
			return MainCamera.ScreenToWorldPoint (Input.mousePosition);
		}
	}
}
