using UnityEngine;
using System.Collections;

public class RTSCameraK : MonoBehaviour
{
		public bool lockMouse = false;
		public bool allowMovement = true;
		public bool mouseMovement = true;
		public float movementSpeedMouse = 200;
		public bool keyMovement = false;
		public float movementSpeedKeys = 200;
		public KeyCode forwardMovementKey = KeyCode.UpArrow;
		public KeyCode backwardMovementKey = KeyCode.DownArrow;
		public KeyCode leftMovementKey = KeyCode.LeftArrow;
		public KeyCode rightMovementKey = KeyCode.RightArrow;


		public bool allowRotation = true;
		public bool mouseRotation = true;
		public bool incrementalRotationSpeed = true;
		public float incrementalMultiplier = 50f;
		public float rotationSpeedMouse = 100;
		public bool incrementalRotationSpeedFollowingTarget = true;
		public float rotationSpeedMouseFollowingTarget = 100f;
		public float incrementalMultiplierFollowingTarget = 2f;
		public bool keyRotation = false;
		public float rotationSpeedKeys = 100;
		public KeyCode leftRotationKey = KeyCode.Q;
		public KeyCode rightRotationKey = KeyCode.E;


		public bool allowZoom = true;
		public bool mouseZoom = true;
		public float zoomSpeedMouse = 200;
		public bool mouseSmoothZoom = true;
		public float mouseZoomSmoothness = 3f;
		public bool keyZoom = false;
		public float zoomSpeedKey = 200;
		public bool keySmoothZoom = true;
		public float keyZoomSmoothness = 3f;
		public KeyCode upZoomKey = KeyCode.KeypadPlus;
		public KeyCode downZoomKey = KeyCode.KeypadMinus;
		public float minZoomHeight = 0;
		public float maxZoomHeight = 600;
		

		public float limitTop = 1000f;	
		public float limitBottom = 1000f;	
		public float limitLeft = 1000f;
		public float limitRight = 1000f;
		

		private float height;
		private float finalHeight;
		private Vector3 position;
		private Vector3 rotation;
		private Quaternion rotationQuaternion;
		private float rotationSpeedFollowingTarget;
		private float direction;
		private float lerpTime = 0f;
		private bool followingObject = false;
		private GameObject targetToFollow;
		private bool resetLerp;
		private bool rotatedFollowing = false;
		

			
		void Start ()
		{

				height = transform.position.y;
			
		
		}
	
		// Update is called once per frame
		void Update ()
		{   
			if (!lockMouse) {
				Movement();
				Rotation();
				Zoom();
			}

			LockMouse ();

		}

		void Movement (){

			position = transform.position;

				if (allowMovement) {

						if (!followingObject) {
								if (mouseMovement) {

										//Move Camera Forward
										if (Input.mousePosition.y >= Screen.height * 0.95) {
					
												position = transform.forward * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;

										}
				
										//Move Camera Backward
										else if (Input.mousePosition.y <= Screen.height / 20) {
												position = -transform.forward * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;

										} 
				
										//Move Camera Left
										if (Input.mousePosition.x <= Screen.width / 20) {
												position = -transform.right * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;
										}
				
										//Move Camera Right
										else if (Input.mousePosition.x >= Screen.width * 0.95) {
												position = transform.right * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;
										}

									Vector3 tmpPos = transform.position;

									//Limit Top/Bottom
									tmpPos.z = Mathf.Clamp(tmpPos.z,-limitBottom,limitTop);
									transform.position = tmpPos;

									//Limit Top/Bottom
									tmpPos.x = Mathf.Clamp(tmpPos.x,-limitLeft,limitRight);
									transform.position = tmpPos;
					
									}
				
							if (keyMovement) {
				
										if (Input.GetKey (forwardMovementKey)) {
												position = transform.forward * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;
										}
				
										//Move Camera Backward
										else if (Input.GetKey (backwardMovementKey)) {
												position = -transform.forward * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;
										} 
				
										//Move Camera Left
										if (Input.GetKey (leftMovementKey)) {
												position = -transform.right * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;
										}
				
										//Move Camera Right
										else if (Input.GetKey (rightMovementKey)) {
												position = transform.right * Time.deltaTime * movementSpeedMouse;
												position.y = 0;
												transform.position += position;
										}
										
					Vector3 tmpPos = transform.position;
					
					//Limit Top/Bottom
					tmpPos.z = Mathf.Clamp(tmpPos.z,-limitBottom,limitTop);
					transform.position = tmpPos;
					
					//Limit Top/Bottom
					tmpPos.x = Mathf.Clamp(tmpPos.x,-limitLeft,limitRight);
					transform.position = tmpPos;
					
				}
			}
		}
				if (followingObject && rotatedFollowing) {

					transform.position = position;

				}
		}

		void Rotation ()
		{

				if (allowRotation) {
					
						if (!followingObject) {
								if (mouseRotation) {
										if (Input.GetKeyDown (KeyCode.Mouse2))
												direction = 0;
				
										if (Input.GetKey (KeyCode.Mouse2)) {
					
									
												direction += Input.GetAxis ("Mouse X");
					
												if (incrementalRotationSpeed) {
														rotation = transform.forward * Time.deltaTime * Mathf.Abs (direction * incrementalMultiplier);
												} else {
														rotation = transform.forward * Time.deltaTime * rotationSpeedMouse;
												}
					
												rotation.z = 0;
												rotation.x = 0;
					

					
												if (direction < 0) {
														transform.eulerAngles += rotation;
												}
					
					
												if (direction > 0) {
														transform.eulerAngles -= rotation;
												}
										}
								} 

								if (keyRotation) {
				
										if (Input.GetKey (leftRotationKey) || Input.GetKey (rightRotationKey)) {
					
					
												rotation = transform.forward * Time.deltaTime * rotationSpeedMouse;
					
					
												rotation.z = 0;
												rotation.x = 0;
					
					
												if (Input.GetKey (leftRotationKey)) {
														transform.eulerAngles += rotation;
												}
					
					
												if (Input.GetKey (rightRotationKey)) {
														transform.eulerAngles -= rotation;
												}
					
										}
				
								}
						}
				}
		if (followingObject) {
			if (mouseRotation) {
				if (Input.GetKeyDown (KeyCode.Mouse2))
					direction = 0;
				
				if (Input.GetKey (KeyCode.Mouse2)) {
					
					
					direction += Input.GetAxis ("Mouse X");
					
					if (incrementalRotationSpeedFollowingTarget) {
						rotationSpeedFollowingTarget = Mathf.Abs (direction * incrementalMultiplierFollowingTarget);
					} else {
						rotationSpeedFollowingTarget = rotationSpeedMouseFollowingTarget;
					}
					
					rotation.z = 0;
					rotation.x = 0;
					
					
					
					if (direction < 0) {
						rotationQuaternion = Quaternion.Euler(0,transform.rotation.eulerAngles.y+rotationSpeedFollowingTarget,0);
						transform.rotation = rotationQuaternion;
						transform.eulerAngles = new Vector3 (Mathf.Clamp (transform.eulerAngles.x, 55, 55),transform.eulerAngles.y, 0);
					}
					
					
					if (direction > 0) {
						rotationQuaternion = Quaternion.Euler(0,transform.rotation.eulerAngles.y-rotationSpeedFollowingTarget,0);
						transform.rotation = rotationQuaternion;
						transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x,55,55),transform.eulerAngles.y,0);
					}

					rotatedFollowing = true;

				}
			} 
			if (keyRotation) {
				
				if (Input.GetKey (leftRotationKey) || Input.GetKey (rightRotationKey)) {
					
					
					rotation = transform.forward * Time.deltaTime * rotationSpeedMouse;
					
					
					rotation.z = 0;
					rotation.x = 0;
					
					
					if (Input.GetKey (leftRotationKey)) {
						transform.eulerAngles += rotation;
					}
					
					
					if (Input.GetKey (rightRotationKey)) {
						transform.eulerAngles -= rotation;
					}
					
				}
				
			}
			}
				
		}

		void Zoom ()
		{

				if (allowZoom) {
			
						if (mouseZoom) {
								if (!mouseSmoothZoom) {
					
										height -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeedMouse;
										height = Mathf.Clamp (height, minZoomHeight, maxZoomHeight);
										float finalHeight = height;
										transform.position = new Vector3 (transform.position.x, finalHeight, transform.position.z);
					
								}
								//Zoom
								if (mouseSmoothZoom) {
					
										height -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeedMouse;
										height = Mathf.Clamp (height, minZoomHeight, maxZoomHeight);
										float finalHeight = Mathf.Lerp (transform.position.y, height, Time.deltaTime * mouseZoomSmoothness);
										transform.position = new Vector3 (transform.position.x, finalHeight, transform.position.z);
					
								}
						}
			
						if (keyZoom) {
								if (!keySmoothZoom) {
					
										if (Input.GetKey (upZoomKey)) {
												height -= 0.05f * zoomSpeedKey;
										}
					
										if (Input.GetKey (downZoomKey)) {
												height -= -0.05f * zoomSpeedKey;
										}
										height = Mathf.Clamp (height, minZoomHeight, maxZoomHeight);
										float finalHeight = height;
										transform.position = new Vector3 (transform.position.x, finalHeight, transform.position.z);
					
								}
								//Zoom
								if (keySmoothZoom) {
					
										if (Input.GetKey (upZoomKey)) {
												height -= 0.05f * zoomSpeedKey;
										}
					
										if (Input.GetKey (downZoomKey)) {
												height -= -0.05f * zoomSpeedKey;
										}
					
										height = Mathf.Clamp (height, minZoomHeight, maxZoomHeight);
										finalHeight = Mathf.Lerp (transform.position.y, height, Time.deltaTime * keyZoomSmoothness);
										transform.position = new Vector3 (transform.position.x, finalHeight, transform.position.z);
										
								}
						}
			
				} 

		}
			
		void LockMouse(){

			if (Input.GetKey (KeyCode.Escape)) {

				lockMouse = true;

			}

			if(Input.GetKeyDown(KeyCode.Mouse0)){

				lockMouse = false;
				
			}

		}

	
		public void FollowTarget(GameObject target, float offsetX, float offsetZ, float smoothSpeed){

			followingObject = true;
			targetToFollow = target;

			if (lerpTime < 1.0f) {
						
			lerpTime += Time.deltaTime / smoothSpeed;
						rotationQuaternion = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0);
						transform.rotation = rotationQuaternion;
						transform.eulerAngles = new Vector3 (Mathf.Clamp (transform.eulerAngles.x, 55, 55), transform.eulerAngles.y, 0);
						position = rotationQuaternion * new Vector3 (offsetX, 0, offsetZ) + targetToFollow.transform.position;
						position.y = finalHeight;
						transform.position = Vector3.Lerp (transform.position,position,lerpTime);

			}

			if (lerpTime > 1.0f) {


				rotationQuaternion = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
				transform.rotation = rotationQuaternion;
				transform.eulerAngles = new Vector3 (Mathf.Clamp (transform.eulerAngles.x, 55, 55),transform.eulerAngles.y, 0);
				position = rotationQuaternion * new Vector3(offsetX, 0, offsetZ) + targetToFollow.transform.position;
				position.y = finalHeight;
				transform.position = position;

						
				}
		}

		public bool StopFollow(){
			bool stopped = false;
			allowMovement = true;
			lerpTime = 0f;
			followingObject = false;
			
			if (lerpTime == 0f) {
				stopped = true;
			}

			return stopped;
		}

		public bool FocusTarget (GameObject target, float offsetX, float offsetZ, float smoothSpeed){

		targetToFollow = target;
		bool ended = false;

				if(lerpTime < 1.0f) {
					lerpTime += Time.deltaTime / smoothSpeed; // Sweeps from 0 to 1 in time seconds
					rotationQuaternion = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0);
					transform.rotation = rotationQuaternion;
					transform.eulerAngles = new Vector3 (Mathf.Clamp (transform.eulerAngles.x, 55, 55), transform.eulerAngles.y, 0);
					position = rotationQuaternion * new Vector3 (offsetX, 0, offsetZ) + targetToFollow.transform.position;
					position.y = finalHeight;
					transform.position = Vector3.Lerp (transform.position,position,lerpTime);
				}

				if(lerpTime > 1.0f) {
					lerpTime = 0f;
					ended = true;
				}

			return ended;
		}
}
