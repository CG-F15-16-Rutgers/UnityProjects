using UnityEngine;
using System.Collections;

public class ControlObstacle : MonoBehaviour {
	public float speed = 25;
	private Rigidbody  rb;
	public GameObject go;
	public string jumpButton = "Jump";
	public string horizontalCtrl = "Horizontal";
	public string verticalCtrl = "Vertical";
	public bool selected = false;
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
		//go = GetComponent<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Renderer>().isVisible && Input.GetMouseButtonUp(0)) {
			Vector3 camPos = Camera.main.WorldToScreenPoint(GetComponent<Transform>().position);
			camPos.y = CameraOperator.InvertMouseY(camPos.y);
			selected = CameraOperator.selection.Contains(camPos);
		}
	}

	void FixedUpdate () {

		if (selected == false)
			return;

		float moveHorizontal = Input.GetAxis (horizontalCtrl);
		float moveVertical = Input.GetAxis (verticalCtrl);
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		go.transform.position += movement;
		//rb.AddForce (movement * speed);
	}
}
