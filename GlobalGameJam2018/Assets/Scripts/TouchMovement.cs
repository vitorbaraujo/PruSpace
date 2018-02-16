using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour {

	// touch offset allows item not shake when it starts to move
	float deltaX;
	float deltaY;

	bool moveAllowed = false;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		Debug.Log("[TouchMovement] RigidBody: " + rb);
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log("[DragScript]: Loopando...");

		// If touch event takes place
		if(Input.touchCount > 0){

			Debug.Log("[DragScript]: Entrou no evento de toque");
			// Get touch to take a deal with
			Touch touch = Input.GetTouch(0);

			// Obtain touch position
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			Debug.Log("[DragScript]: Posição do toque = ["+ touchPos.x + "," + touchPos.y + "]");

			// Processing touch phase
			switch(touch.phase){

				// If you touch the screen
				case TouchPhase.Began:

					// If you touch the item
					if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)) {
						Debug.Log("[DragScript]: Tocou no item");
						// Get the offset between position you touches and center the of the game object
						deltaX = touchPos.x - GameObject.Find("Player").transform.position.x;
						deltaY = touchPos.y - GameObject.Find("Player").transform.position.y;

						moveAllowed = true;
					}
					break;

				// If you move your finger
				case TouchPhase.Moved:
					moveAllowed = true;
					if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed) {
						GameObject.Find("Player").transform.position = new Vector3(touchPos.x, touchPos.y, 0);
						//rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
					}
					break;

				// If you release your finger
				case TouchPhase.Ended:
					moveAllowed = false;
					break;
			}
		}
	}

	void PlayerMovementTouch(){

		Debug.Log("[Player]: Entrou no método de toque");
		// If touch event takes place
		if(Input.touchCount > 0){

			Debug.Log("[Player]: Entrou no evento de toque");
			// Get touch to take a deal with
			Touch touch = Input.GetTouch(0);

			// Obtain touch position
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			Debug.Log("[Player]: Posição do toque = ["+ touchPos.x + "," + touchPos.y + "]");

			// Processing touch phase
			switch(touch.phase){

				// If you touch the screen
				case TouchPhase.Began:

					// If you touch the item
					if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)) {
						Debug.Log("[Player]: Tocou no item");
						// Get the offset between position you touches and center the of the game object
//						deltaX = touchPos.x - gameObject.transform.position.x;
//						deltaY = touchPos.y - gameObject.transform.position.y;

						moveAllowed = true;
					}
					break;

				// If you move your finger
				case TouchPhase.Moved:
					moveAllowed = true;
					Debug.Log("[Player]: Moveu o personagem");
					if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed) {
						gameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
					}
					break;

				// If you release your finger
				case TouchPhase.Ended:
					moveAllowed = false;
					break;
			}
		}
	}
}
