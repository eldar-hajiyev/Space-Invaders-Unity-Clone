using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveScript : MonoBehaviour {

	public float orthographicSize = 10;
	public float aspect = 1f;

	void Start()
	{
		var cameraMain = Camera.main;
		cameraMain.projectionMatrix = Matrix4x4.Ortho (
			-orthographicSize * aspect, orthographicSize * aspect,
			-orthographicSize, orthographicSize,
			cameraMain.nearClipPlane, cameraMain.farClipPlane);
	}
}
