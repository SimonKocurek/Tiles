using UnityEngine;

public class InputHandler {

	private bool moved;
	private bool selected;
	private float timer;
	private TouchPhase touchPhase;

	private GameObject clickedTile = null;
	private TopTile clickedTileObject = null;

	// gets input data
	public void check( Touch inTouch) {
		touchPhase = inTouch.phase;
		// add new time to timer since last press
		timer += Time.deltaTime;

		switch (touchPhase) {
			// inicial touch
			case TouchPhase.Began:
				selected = select(inTouch);
				timer = 0f;
				moved = false;
				break;

				// finger movement on screen 
			case TouchPhase.Moved:
				moved = true;
				break;
		}
	}

	// touch release was tap
	public bool tap() {
		if (touchPhase == TouchPhase.Ended) {
			if (! moved) {
				moved = true;
				return true;
			}
		}

		return false;
	}

	// user is holding screen
	public bool hold() {
		if (timer > 0.3f) {
			if (!moved) {
				moved = true;
				return true;
			}
		} 

		return false;
	}

	// save clicked tile
	private bool select( Touch tap) {
		RaycastHit hit;

		// raycast to object
		if (Physics.Raycast( Camera.main.ScreenPointToRay(tap.position), out hit)) {
			if (hit.transform.tag == "Top") {
				TopTile tempTile = (TopTile)TileHash.hash[hit.transform.gameObject];
				if (!tempTile.selected) {
					clickedTile = hit.transform.gameObject;
					clickedTileObject = (TopTile)TileHash.hash[hit.transform.gameObject];

					return true;
				}		
			}
		}

		return false;
	}
}
