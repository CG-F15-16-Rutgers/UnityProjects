using UnityEngine;
using System.Collections;

public class MyController : MonoBehaviour {

	private Animator myAnimator; 
	// Use this for initialization
	void Start () {
	
		myAnimator = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
		myAnimator.SetFloat ("VSpeed", Input.GetAxis ("Vertical")); 
		myAnimator.SetFloat ("HSpeed", Input.GetAxis ("Horizontal")); 

		if(Input.GetKeyDown ("right shift")){
			   myAnimator.SetBool ("Run", !myAnimator.GetBool("Run"));
		}

		//if(Input.GetKey("right shift")){
		//	myAnimator.SetBool ("Run", true);
		//}else{
		//	myAnimator.SetBool ("Run", false);
		//}

		
		if(Input.GetKeyDown ("space")){
			myAnimator.SetBool ("Jump", true);
			Invoke ("StopJumping", 0.1f);
		}

		// hold down the key
		if(Input.GetKey("q")){
			transform.Rotate (Vector3.down * Time.deltaTime * 75.0f);
			if((Input.GetAxis ("Vertical") == 0.0f) && (Input.GetAxis ("Horizontal") == 0.0f)){
				myAnimator.SetBool ("LeftTurn", true);
			}
		}else {
			myAnimator.SetBool ("LeftTurn", false);
		}
		
		
		if(Input.GetKey("e")){
			transform.Rotate (Vector3.up * Time.deltaTime * 75.0f);
			if((Input.GetAxis ("Vertical") ==  0.0f) && (Input.GetAxis ("Horizontal") ==  0.0f)){
				myAnimator.SetBool ("RightTurn", true);
			}
		}else {
			myAnimator.SetBool ("RightTurn", false);
		}
		


	}

	void StopJumping(){
		myAnimator.SetBool ("Jump", false);
	}
}
