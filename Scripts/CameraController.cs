using UnityEngine;

public class CameraController : MonoBehaviour {
	
	[Range(0.05f, 1f)]public float sensitivity;

	private static Vector3 start;
	private static Vector3 end;

	private static Vector3 nextPosition;

	private static float elevation = 6f;

	void Start () {
		// get data about tiles and board
		BoardController board = GameObject.Find("Board").GetComponent<BoardController>();
		Vector3 tileSize = board.tileSize;
		
		// get boundry location of camera movement
		start = new Vector3( (-board.tilesX + 4) * tileSize.x / 2, 0, (-board.tilesY - 7) * tileSize.y / 2);
		end = new Vector3( (board.tilesX - 4) * tileSize.x / 2, 0, (board.tilesY - 7) * tileSize.y / 2);

		// move camera to starting position
		transform.position = new Vector3( 0, (Mathf.Max(GameObject.Find("Water").GetComponent<WaterController>().waterHeightLevel * tileSize.z + tileSize.z / 2, board.maxHeight) + elevation + 2) * tileSize.z, 0);

		// set movement to camera position
		nextPosition = transform.position;
	}

	void Update () {
		phoneInput();
		heightChange();

		// final movement
		transform.position = Vector3.Lerp( transform.position, nextPosition, Time.deltaTime);
	}

	// sets next height according to underneath tile and elevation
	private void heightChange() {
		RaycastHit hit;

		if (Physics.Raycast( new Vector3 (transform.position.x, transform.position.y, transform.position.z), -Vector3.up, out hit)) {
			nextPosition.y = hit.point.y + elevation;
		}
	}

	// get input from touches
	private void phoneInput() {
		Touch[] touches = Input.touches;
		if (touches.Length > 0) {
			if (touches.Length == 1) {
				drag( touches[0]);
			} else if (touches.Length == 2) {
				zoom( touches);
			}
		}
	}

	// change next position according to drag on screen
	private void drag(Touch tap) {
		if (tap.phase == TouchPhase.Moved) {
			nextPosition.x = Mathf.Clamp( nextPosition.x + tap.deltaPosition.x * sensitivity * -1, start.x , end.x);
			nextPosition.z = Mathf.Clamp( nextPosition.z + tap.deltaPosition.y * sensitivity * -1, start.z , end.z);
		}
	}

	// set elevation according to zoom movement on screen
	private void zoom(Touch[] touches) {
		float changeZ = (
			(((touches[0].position - touches[0].deltaPosition) - (touches[1].position - touches[1].deltaPosition)).magnitude) 
			- ((touches[0].position - touches[1].position).magnitude)  
			) * 0.2f;

		elevation = Mathf.Clamp( elevation + changeZ, 3.5f, 7f);
	}
}
