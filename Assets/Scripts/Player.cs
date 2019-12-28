using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float jumpForce = 10f;
	public Rigidbody2D rb;
	public string currentColor;
	public SpriteRenderer sr;
	public Color colorRed;
	public Color colorYellow;
	public Color colorGreen;
	public Color colorBlue;
	// Use this for initialization
	void Start () {
		SetRandomColor ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown (0)) {
			rb.velocity = Vector2.up * jumpForce;
		}
	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "ColorChanger") {
			SetRandomColor ();
			Destroy (col.gameObject);
			return;
		}
		if (col.tag != currentColor) {
			Debug.Log ("Game Over");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
	void SetRandomColor()
	{
		int index = Random.Range (0, 4);
		switch (index) {
		case 0:
			currentColor = "Red";
			sr.color = colorRed;
			break;
		case 1:
			currentColor = "Yellow";
			sr.color = colorYellow;
			break;
		case 2:
			currentColor = "Green";
			sr.color = colorGreen;
			break;
		case 3:
			currentColor = "Blue";
			sr.color = colorBlue;
			break;
		}
	}
}
