using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(RTSCameraK),true)]
public class RTSCameraKEditor : Editor {
		
		SerializedProperty lockMouse;
		SerializedProperty allowMovement;
		SerializedProperty mouseMovement;
		SerializedProperty movementSpeedMouse;
		SerializedProperty keyMovement;
		SerializedProperty movementSpeedKeys;
		SerializedProperty forwardMovementKey;
		SerializedProperty backwardMovementKey;
		SerializedProperty leftMovementKey;
		SerializedProperty rightMovementKey;
		SerializedProperty allowRotation;
		SerializedProperty mouseRotation;
		SerializedProperty incrementalRotationSpeed;
		SerializedProperty incrementalMultiplier;
		SerializedProperty rotationSpeedMouse;
		SerializedProperty keyRotation;
		SerializedProperty rotationSpeedKeys;
		SerializedProperty leftRotationKey;
		SerializedProperty rightRotationKey;
		SerializedProperty allowZoom;
		SerializedProperty mouseZoom;
		SerializedProperty zoomSpeedMouse;
		SerializedProperty mouseSmoothZoom;
		SerializedProperty mouseZoomSmoothness;
		SerializedProperty keyZoom;
		SerializedProperty zoomSpeedKey;
		SerializedProperty keySmoothZoom;
		SerializedProperty keyZoomSmoothness;
		SerializedProperty upZoomKey;
		SerializedProperty downZoomKey;
		SerializedProperty minZoomHeight;
		SerializedProperty maxZoomHeight;
		SerializedProperty limitTop;
		SerializedProperty limitBottom;
		SerializedProperty limitLeft;
		SerializedProperty limitRight;

		string helpBoxMovement;
		string helpBoxRotation;
		string helpBoxZoom;

		public static Color interfaceColor = Color.white;

		GameObject thisGO;

		bool generalFoldout = false;
		bool movementFoldout = false;
		bool rotationFoldout = false;
		bool zoomFoldout = false;
		bool otherFoldout = false;


		void OnEnable(){
			
		lockMouse = serializedObject.FindProperty ("lockMouse");
		allowMovement = serializedObject.FindProperty ("allowMovement");
		mouseMovement = serializedObject.FindProperty ("mouseMovement");
		movementSpeedMouse = serializedObject.FindProperty ("movementSpeedMouse");
		keyMovement = serializedObject.FindProperty ("keyMovement");
		movementSpeedKeys = serializedObject.FindProperty ("movementSpeedKeys");
		forwardMovementKey = serializedObject.FindProperty ("forwardMovementKey");
		backwardMovementKey = serializedObject.FindProperty ("backwardMovementKey");
		leftMovementKey = serializedObject.FindProperty ("leftMovementKey");
		rightMovementKey = serializedObject.FindProperty ("rightMovementKey");
		allowRotation = serializedObject.FindProperty ("allowRotation");
		mouseRotation = serializedObject.FindProperty ("mouseRotation");
		incrementalRotationSpeed = serializedObject.FindProperty ("incrementalRotationSpeed");
		incrementalMultiplier = serializedObject.FindProperty ("incrementalMultiplier");
		rotationSpeedMouse = serializedObject.FindProperty ("rotationSpeedMouse");
		keyRotation = serializedObject.FindProperty ("keyRotation");
		rotationSpeedKeys = serializedObject.FindProperty ("rotationSpeedKeys");
		leftRotationKey = serializedObject.FindProperty ("leftRotationKey");
		rightRotationKey = serializedObject.FindProperty ("rightRotationKey");
		allowZoom = serializedObject.FindProperty ("allowZoom");
		mouseZoom = serializedObject.FindProperty ("mouseZoom");
		zoomSpeedMouse = serializedObject.FindProperty ("zoomSpeedMouse");
		mouseSmoothZoom = serializedObject.FindProperty ("mouseSmoothZoom");
		mouseZoomSmoothness = serializedObject.FindProperty ("mouseZoomSmoothness");
		keyZoom = serializedObject.FindProperty ("keyZoom");
		zoomSpeedKey = serializedObject.FindProperty ("zoomSpeedKey");
		keySmoothZoom = serializedObject.FindProperty ("keySmoothZoom");
		keyZoomSmoothness = serializedObject.FindProperty ("keyZoomSmoothness");
		upZoomKey = serializedObject.FindProperty ("upZoomKey");
		downZoomKey = serializedObject.FindProperty ("downZoomKey");
		minZoomHeight = serializedObject.FindProperty ("minZoomHeight");
		maxZoomHeight = serializedObject.FindProperty ("maxZoomHeight");

		limitTop = serializedObject.FindProperty ("limitTop");
		limitBottom = serializedObject.FindProperty ("limitBottom");
		limitLeft = serializedObject.FindProperty ("limitLeft");
		limitRight = serializedObject.FindProperty ("limitRight");

		maxZoomHeight = serializedObject.FindProperty ("maxZoomHeight");

		generalFoldout = EditorPrefs.GetBool ("generalFoldout");
		movementFoldout = EditorPrefs.GetBool("movementFoldout");
		rotationFoldout = EditorPrefs.GetBool("rotationFoldout");
		zoomFoldout = EditorPrefs.GetBool("zoomFoldout");
		otherFoldout = EditorPrefs.GetBool("otherFoldout");

		interfaceColor.r = EditorPrefs.GetFloat("ColorR");
		interfaceColor.g = EditorPrefs.GetFloat("ColorG");
		interfaceColor.b = EditorPrefs.GetFloat("ColorB");

		}
		

		public override void OnInspectorGUI() {
	
			

			serializedObject.Update ();


			//Draw the logo
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.Space ();
			EditorGUILayout.LabelField(new GUIContent(Resources.Load("EditorLogo") as Texture2D),GUILayout.Width(180),GUILayout.Height(80));
			EditorGUILayout.Space ();
			EditorGUILayout.EndHorizontal ();
			
			//Restore the UI to the default color
			GUI.color = Color.white;
			
			GUILayout.Space (5);
			
			if (allowMovement.boolValue)
						helpBoxMovement = "Enabled";
				else
						helpBoxMovement = "Disabled";

			if (allowRotation.boolValue)
						helpBoxRotation = "Enabled";
				else
						helpBoxRotation = "Disabled";

			if (allowZoom.boolValue)
						helpBoxZoom = "Enabled";
				else
						helpBoxZoom = "Disabled";

			
			EditorGUILayout.HelpBox ("You have Movement --> " + helpBoxMovement + "\n"+
		                        	 "You have Rotation --> " + helpBoxRotation + "\n"+
		                       		 "You have Zoom --> " + helpBoxZoom ,MessageType.Info);

			
			GUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField ("General Settings", EditorStyles.boldLabel,GUILayout.Width(140));
			generalFoldout = EditorGUILayout.Foldout (generalFoldout,new GUIContent(""));
			GUILayout.EndHorizontal ();

			//If we press the movement foldout ...
			if (generalFoldout) {
				
				EditorPrefs.SetBool("generalFoldout",true);
				
				EditorGUI.indentLevel++;
				
				EditorGUILayout.PropertyField (lockMouse);
				
				EditorGUI.indentLevel--;
				
			}
			
			else 	EditorPrefs.SetBool("generalFoldout",false);
	
			GUILayout.Space (5);

			//Draw the label/foldout for the movement settings
			GUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField ("Movement Settings", EditorStyles.boldLabel,GUILayout.Width(140));
			movementFoldout = EditorGUILayout.Foldout (movementFoldout,new GUIContent(""));
			GUILayout.EndHorizontal ();
			
				//If we press the movement foldout ...
				if (movementFoldout) {

					EditorPrefs.SetBool("movementFoldout",true);

					EditorGUI.indentLevel++;

						EditorGUILayout.PropertyField (allowMovement);

						EditorGUILayout.LabelField ("Mouse", EditorStyles.boldLabel,GUILayout.Width(140));
						EditorGUI.indentLevel++;
							EditorGUILayout.PropertyField (mouseMovement, new GUIContent("Use Mouse"));
							EditorGUILayout.PropertyField (movementSpeedMouse, new GUIContent("Speed"));

						EditorGUI.indentLevel--;

						EditorGUILayout.LabelField ("Keys", EditorStyles.boldLabel,GUILayout.Width(140));
						EditorGUI.indentLevel++;
							EditorGUILayout.PropertyField (keyMovement, new GUIContent("Use Keys"));
							EditorGUILayout.PropertyField (movementSpeedKeys, new GUIContent("Speed"));
							EditorGUILayout.PropertyField (forwardMovementKey, new GUIContent("Forward Key"));
							EditorGUILayout.PropertyField (backwardMovementKey, new GUIContent("Backward Key"));
							EditorGUILayout.PropertyField (leftMovementKey, new GUIContent("Left Key"));
							EditorGUILayout.PropertyField (rightMovementKey, new GUIContent("Right Key"));
						EditorGUI.indentLevel--;

						EditorGUILayout.LabelField ("Limits", EditorStyles.boldLabel,GUILayout.Width(140));
						EditorGUI.indentLevel++;
						EditorGUILayout.PropertyField (limitTop, new GUIContent("Top Limit"));
						EditorGUILayout.PropertyField (limitBottom, new GUIContent("Bottom Limit"));
						EditorGUILayout.PropertyField (limitLeft, new GUIContent("Left Limit"));
						EditorGUILayout.PropertyField (limitRight, new GUIContent("Right Limit"));
									
						EditorGUI.indentLevel--;

					EditorGUI.indentLevel--;

				}

				else 	EditorPrefs.SetBool("movementFoldout",false);

			GUILayout.Space (5);
			
			//Draw the label/foldout for the rotation settings
			GUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField ("Rotation Settings", EditorStyles.boldLabel,GUILayout.Width(140));
			rotationFoldout = EditorGUILayout.Foldout (rotationFoldout,new GUIContent(""));
			GUILayout.EndHorizontal ();
					
				//If we press the movement foldout ...
				if (rotationFoldout) {
					EditorPrefs.SetBool("rotationFoldout",true);
					EditorGUI.indentLevel++;
					
					EditorGUILayout.PropertyField (allowRotation);
					
					EditorGUILayout.LabelField ("Mouse", EditorStyles.boldLabel,GUILayout.Width(140));
					EditorGUI.indentLevel++;
					EditorGUILayout.PropertyField (mouseRotation, new GUIContent("Use Mouse"));
					EditorGUILayout.PropertyField (incrementalRotationSpeed, new GUIContent("Incremental Speed"));
					EditorGUILayout.PropertyField (incrementalMultiplier, new GUIContent("Incremental Multiplier"));
					EditorGUILayout.PropertyField (rotationSpeedMouse, new GUIContent("Speed"));

					EditorGUI.indentLevel--;
					
					EditorGUILayout.LabelField ("Keys", EditorStyles.boldLabel,GUILayout.Width(140));
					EditorGUI.indentLevel++;
					EditorGUILayout.PropertyField (keyRotation, new GUIContent("Use Keys"));
					EditorGUILayout.PropertyField (rotationSpeedKeys, new GUIContent("Speed"));
					EditorGUILayout.PropertyField (leftRotationKey, new GUIContent("Left Key"));
					EditorGUILayout.PropertyField (rightRotationKey, new GUIContent("Right Key"));
					EditorGUI.indentLevel--;
					
					EditorGUI.indentLevel--;
					
				}

		else 	EditorPrefs.SetBool("rotationFoldout",false);

			GUILayout.Space (5);
			
			//Draw the label/foldout for the zoom settings
			GUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField ("Zoom Settings", EditorStyles.boldLabel,GUILayout.Width(140));
			zoomFoldout = EditorGUILayout.Foldout (zoomFoldout,new GUIContent(""));
			GUILayout.EndHorizontal ();


		//If we press the movement foldout ...
		if (zoomFoldout) {
				
						EditorPrefs.SetBool ("zoomFoldout", true);
						EditorGUI.indentLevel++;
			
						EditorGUILayout.PropertyField (allowZoom);
						EditorGUILayout.PropertyField (minZoomHeight, new GUIContent ("Min. Height Allowed"));
						EditorGUILayout.PropertyField (maxZoomHeight, new GUIContent ("Max. Height Allowed"));


						EditorGUILayout.LabelField ("Mouse", EditorStyles.boldLabel, GUILayout.Width (140));
						EditorGUI.indentLevel++;
						EditorGUILayout.PropertyField (mouseZoom, new GUIContent ("Use Mouse"));
						EditorGUILayout.PropertyField (zoomSpeedMouse, new GUIContent ("Speed"));
						EditorGUILayout.PropertyField (mouseSmoothZoom, new GUIContent ("Smooth"));
						EditorGUILayout.PropertyField (mouseZoomSmoothness, new GUIContent ("Smoothness"));
			
						EditorGUI.indentLevel--;
			
						EditorGUILayout.LabelField ("Keys", EditorStyles.boldLabel, GUILayout.Width (140));
						EditorGUI.indentLevel++;
						EditorGUILayout.PropertyField (keyZoom, new GUIContent ("Use Keys"));
						EditorGUILayout.PropertyField (zoomSpeedKey, new GUIContent ("Speed"));
						EditorGUILayout.PropertyField (keySmoothZoom, new GUIContent ("Smooth"));
						EditorGUILayout.PropertyField (keyZoomSmoothness, new GUIContent ("Smoothness"));
						EditorGUILayout.PropertyField (upZoomKey, new GUIContent ("Up Key"));
						EditorGUILayout.PropertyField (downZoomKey, new GUIContent ("Down Key"));
						EditorGUI.indentLevel--;
			
						EditorGUI.indentLevel--;				
				}

			else 	EditorPrefs.SetBool("zoomFoldout",false);

						GUILayout.Space (5);

						//Draw the label/foldout for the zoom settings
						GUILayout.BeginHorizontal ();
						EditorGUILayout.LabelField ("Other Settings", EditorStyles.boldLabel, GUILayout.Width (140));
						otherFoldout = EditorGUILayout.Foldout (otherFoldout, new GUIContent (""));
						GUILayout.EndHorizontal ();
			



				if (otherFoldout) {
						
							EditorPrefs.SetBool("otherFoldout",true);
								//Draw the color field for the interface

								EditorGUI.indentLevel++;
						
								
								if(GUILayout.Button("Help via Email")){
						
								Application.OpenURL("mailto:neo5icekcore@gmail.com?Subject=I need help with: RTSCameraKSystem&body=Please, explain the thing you want to achieve: %0A%0A");

								}

								if(GUILayout.Button("Make a Suggestion")){
									
									Application.OpenURL("mailto:neo5icekcore@gmail.com?Subject=I have a suggestion for: RTSCameraKSystem&body=Please, explain your suggestion: %0A%0A");
									
								}

								if(GUILayout.Button("Rate this asset")){
									
								Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/publisher/1934");
									
								}

								EditorGUI.indentLevel--;

				}

				else 	EditorPrefs.SetBool("otherFoldout",false);

			serializedObject.ApplyModifiedProperties ();
		}
	}


