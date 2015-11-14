using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera camera;
	public float widthCamera;
	// Use this for initialization
	void Start () {
		ResizeOrthoCamera ();
	}

	void ResizeOrthoCamera() 
	{
		float ratioCameraWH = (float)(Screen.width) / Screen.height;
		camera.orthographicSize = widthCamera / ratioCameraWH;
	}
}
