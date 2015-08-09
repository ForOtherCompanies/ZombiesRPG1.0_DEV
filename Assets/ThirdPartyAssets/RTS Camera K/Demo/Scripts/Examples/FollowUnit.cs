using UnityEngine;
using System.Collections;


public class FollowUnit : MonoBehaviour {

	public GameObject unitToFollow;
	public bool follow;
	public float smoothSpeed = 1f;
	bool stopped = false;
	bool cameraFind = false;

	RTSCameraK rtsCameraKScript;
	void Update(){

		if(!cameraFind && follow){
			rtsCameraKScript = Camera.main.GetComponent<RTSCameraK> ();
			cameraFind = true;
		}

		if (rtsCameraKScript != null && follow) {
			stopped = false;
			rtsCameraKScript.FollowTarget(unitToFollow, 0, -100, smoothSpeed);
		}

		if (rtsCameraKScript != null && !follow && !stopped) {
			if(rtsCameraKScript.StopFollow()){
				stopped = true;
			}
		}

		}
	public void ChangeFollow(){

		follow = !follow;

	}

	}
