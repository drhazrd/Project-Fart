using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope :MonoBehaviour{
	public Animator anim;
	private bool isScoped = false;
	public GameObject scopeOverlay;
	public GameObject weaponCamera;
	public float scopedFOV = 15f;
	public float normFOV;
	public Camera mainCam;
	void Update(){
		if (Input.GetAxis("Aim")<=-.01f){
			isScoped =!isScoped;
			anim.SetBool("Scoped",isScoped);
			if (isScoped){
				StartCoroutine(OnScoped());
			}else{
				OnUnscoped();
				mainCam.fieldOfView = normFOV;
			}
		}
	}
	void OnUnscoped(){
		scopeOverlay.SetActive(false);
		weaponCamera.SetActive(true);
	}
	IEnumerator OnScoped(){
		yield return new WaitForSeconds(.15f);
		scopeOverlay.SetActive(true);
		weaponCamera.SetActive(false);
		normFOV = mainCam.fieldOfView;
		mainCam.fieldOfView = scopedFOV;
	}
}
