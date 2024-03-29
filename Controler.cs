using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour 
{

	public CharacterController CharacterController;

	public float movementSpeed = 9.0f;
	public float currentMovementSpeed;
	public float maxMovementSpeedOnWalk = 9.0f;
	public float jumpHeight = 7.0f;
	public float jumpHeightNow = 0f;
	public float sprintSpeed = 7.0f;
	public float sensivity = 3.0f;
	public float myszGoraDol = 0.0f;
	public float zakresMyszkiGoraDol = 90.0f;
	public float szybszeSpadanie = 0f;
	public Player player;
	public bool isSprint;
	public bool isJump;
	
	// Use this for initialization
	void Start () 
	{
		isSprint = false;
		CharacterController = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (isSprint == false)
			movementSpeed = maxMovementSpeedOnWalk;


		mouse();
		keyboard();

	
	}

	private void keyboard()
	{
		float ruchPrzudTyl = Input.GetAxis ("Vertical") * movementSpeed;
		float ruchLewoPrawo = Input.GetAxis ("Horizontal") * movementSpeed;


		//skakanie
		if (CharacterController.isGrounded && Input.GetButton("Jump"))
		{
			jumpHeightNow = jumpHeight;
			isJump = true;
		} 
		else if (!CharacterController.isGrounded)
		{
			jumpHeightNow += Physics.gravity.y * (Time.deltaTime + szybszeSpadanie);
			isJump = false;
		}


		//bieganie
		if (Input.GetKeyDown ("left shift")) 
		{
			movementSpeed += sprintSpeed;
			isSprint = true;
		}
		else if (Input.GetKeyUp ("left shift"))
		{
			movementSpeed -= sprintSpeed;
			isSprint = false;
		}


		Vector3 ruch = new Vector3(ruchLewoPrawo, jumpHeightNow, ruchPrzudTyl);
		ruch = transform.rotation * ruch;

		CharacterController.Move(ruch * Time.deltaTime);

	}

	private void mouse()
	{
		float myszkaLewoPrawo = Input.GetAxis("Mouse X") * sensivity;
		transform.Rotate(0, myszkaLewoPrawo, 0);

		myszGoraDol -= Input.GetAxis ("Mouse Y") * sensivity;
		myszGoraDol = Mathf.Clamp (myszGoraDol, -zakresMyszkiGoraDol, zakresMyszkiGoraDol);
		Camera.main.transform.localRotation = Quaternion.Euler (myszGoraDol, 0, 0);
	}
}
