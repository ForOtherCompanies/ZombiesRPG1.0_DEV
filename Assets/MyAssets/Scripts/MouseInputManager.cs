using UnityEngine;
using System.Collections;

public class MouseInputManager : MonoBehaviour {
	//keep public
	public GameObject mainCamera;
	public MainGameManager mainGameManager;

	public void Update (){
		if (Input.GetMouseButtonDown(0)){

			RaycastHit hit;
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)){

				mainGameManager.PerformAction (hit);


			}
		}
	}
}
