using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public Text countText;

	private Rigidbody rb;

	private int count;

	void Start()
	{
		count = 0;
		setCountText ();
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate()
	{
		float moveHorizontal  = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 moveMovement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(moveMovement * speed); 
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}