using UnityEngine;
using System.Collections;
using System;

public class WebcamToPNG : MonoBehaviour
{
	public GameObject m_screen;

	private WebCamTexture m_WebCamTexture;
	private string _frontCam;
	private string _backCam;

	void Awake(){



		WebCamDevice[] devices = WebCamTexture.devices;    // Return a list of available devices

		for(var i = 0; i < devices.Length; i++){
			if(devices[i].isFrontFacing){
				_backCam = devices [i].name;
				//m_WebCamTexture.deviceName = _frontCam;
			}else{
				_backCam = devices[i].name;
				//m_WebCamTexture.deviceName = _backCam;
			}
		}

		m_WebCamTexture = new WebCamTexture (_backCam, 640, 480, 60);
		m_WebCamTexture.Play();	

		m_screen.GetComponent<Renderer> ().material.mainTexture = m_WebCamTexture;


		if(Application.isMobilePlatform){
			GameObject cameraParent =new GameObject ("camParent");
			cameraParent.transform.position=this.transform.position;
			this.transform.parent=cameraParent.transform;
			cameraParent.transform.Rotate(Vector3.right,90);
		}
		Input.gyro.enabled=true;
	}

	void Update () {
		Quaternion cameraRoation = new Quaternion(Input.gyro.attitude.x,Input.gyro.attitude.y,-Input.gyro.attitude.z,-Input.gyro.attitude.w);
		Debug.Log(Input.gyro.attitude.x+" "+Input.gyro.attitude.y+" "+Input.gyro.attitude.z+" "+Input.gyro.attitude.w);

		this.transform.localRotation=cameraRoation;
		Debug.Log( "as"+cameraRoation);
	}	
}