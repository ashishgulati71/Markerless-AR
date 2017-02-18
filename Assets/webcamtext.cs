using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcamtext : MonoBehaviour {
	public GameObject webplane;
	float yRotation;
	float xRotation;
	// Use this for initialization
	void Start () {

		if(Application.isMobilePlatform){
			GameObject cameraParent =new GameObject ("camParent");
			cameraParent.transform.position=this.transform.position;
			this.transform.parent=cameraParent.transform;
			cameraParent.transform.Rotate(Vector3.right,90);
		}
		Input.gyro.enabled=true;


		WebCamTexture wt= new WebCamTexture();
		webplane.GetComponent<MeshRenderer>().material.mainTexture=wt;
		wt.Play();
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion cameraRoation = new Quaternion(Input.gyro.rotationRateUnbiased.x,Input.gyro.rotationRateUnbiased.y,-Input.gyro.rotationRateUnbiased.z,0);
		Debug.Log(Input.gyro.rotationRateUnbiased.x+" "+Input.gyro.rotationRateUnbiased.y+" "+Input.gyro.rotationRateUnbiased.z+" ");
	//	Debug.Log(Input.gyro.rotationRateUnbiased.x);
		//this.transform.rotation = Input.gyro.attitude;
		this.transform.localRotation=cameraRoation;
		//Debug.Log( "as"+cameraRoation);
		/*

		yRotation += -Input.gyro.rotationRateUnbiased.y;
		xRotation += -Input.gyro.rotationRateUnbiased.x;
		transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
*/

	}
}
