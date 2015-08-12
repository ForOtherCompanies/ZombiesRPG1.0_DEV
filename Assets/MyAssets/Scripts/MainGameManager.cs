using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour {
	public GameObject selectedUnit;

	public void PerformAction (RaycastHit hit){
		Debug.Log ("performing action");
		if (hit.transform.tag == "FriendlyUnit"){
			selectedUnit = hit.transform.gameObject;
		}

		if (hit.transform.tag == "WalkableTerrain" && selectedUnit != null){
			selectedUnit.GetComponent<UnitControlAgent>().SetTarget (hit.point);
		}



	}
}
