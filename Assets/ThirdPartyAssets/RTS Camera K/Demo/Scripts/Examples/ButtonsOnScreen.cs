using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class ButtonsOnScreen : MonoBehaviour {

	public FollowUnit followScript;
	public FocusUnit focusScript;
	public string followText = "Follow Unit";

	void OnGUI(){

		if (!followScript.follow) {

			followText = "Follow Unit";

		}

		else{

			followText = "Unfollow Unit";	

		}

		if (GUILayout.Button (followText)) {

			followScript.ChangeFollow();

		}
	
		if (GUILayout.Button ("Focus Unit")) {

			focusScript.Focus();
			
		}

		GUI.DrawTexture (new Rect (Screen.width - 140, Screen.height - 100, 140, 90), Resources.Load ("LabelScene") as Texture2D);

	}
}
