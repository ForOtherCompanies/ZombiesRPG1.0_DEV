using UnityEngine;
using System.Collections;

public class MoveUnit : MonoBehaviour {

	bool tookUnit;
	GameObject unit;
	float lerpTime;
	Vector3 positionToMove;
	bool moving = false;


	void Update() {

		MoveUnitToPoint();

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if(Input.GetMouseButtonDown(0)){
			if(hit.collider.name == "Unit"){
				tookUnit = true;
				unit = hit.collider.gameObject;
			}

			if(hit.collider.name == "Terrain" && tookUnit){
						lerpTime = 0;
						positionToMove = new Vector3(hit.point.x,
					                             	 hit.point.y+14.5f,
						                             hit.point.z);
						moving = true;
				}
			}
		}
	}

	void MoveUnitToPoint(){
			if (moving) {
					if (lerpTime < 1.0f) {
							float distance = Vector3.Distance(positionToMove,unit.transform.position);
				Debug.Log(distance/10);
				lerpTime += Time.deltaTime /(distance*2);
							unit.transform.position = Vector3.Lerp (unit.transform.position, positionToMove, lerpTime);
					}
		}
	}
}

