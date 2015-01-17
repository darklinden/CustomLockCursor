using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//#define CustomCursor.MousePosition CCMousePos

public class CustomLockCursor : MonoBehaviour {

	public static Vector3 MousePosition = Vector3.zero;
	public Image cursor;
	public Text status;
	public float MouseSpeed = 30f;
	public float FollowSpeed = 30f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!Screen.lockCursor) {
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}
		else {
			Vector3 p = cursor.rectTransform.position;
			
			p.x += Input.GetAxis ("Mouse X") * MouseSpeed;
			p.y += Input.GetAxis ("Mouse Y") * MouseSpeed;

			if (p.x < 0) p.x = 0;
			if (p.x > Screen.width) p.x = Screen.width;
			if (p.y < 0) p.y = 0;
			if (p.y > Screen.height) p.y = Screen.height;

			cursor.rectTransform.position = Vector3.Lerp(cursor.rectTransform.position, p, Time.deltaTime * FollowSpeed);
			MousePosition = cursor.rectTransform.position;
		}

		status.text = "Mouse Position: " + cursor.rectTransform.position + "\n" + "Mouse Speed: " + MouseSpeed;
	}
}
