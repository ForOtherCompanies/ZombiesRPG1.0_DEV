using UnityEngine;
using System.Collections;

public class FocusUnit : MonoBehaviour {
	
	public GameObject unitToFocus;
	public float smoothSpeed = 1f;
	bool cameraFind = false;
	bool focus = false;
	
	RTSCameraK rtsCameraKScript;
	void Update(){
	
			if (!cameraFind) {
					rtsCameraKScript = Camera.main.GetComponent<RTSCameraK> ();
					cameraFind = true;
			}
	
			if (rtsCameraKScript != null && focus) {
				
				if(rtsCameraKScript.FocusTarget (unitToFocus, 0, -100, smoothSpeed)){

					focus = false;

				}
			}

			

	}

	public void Focus(){

		focus = true;

	}
	
}
