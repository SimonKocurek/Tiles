using UnityEngine;

public class InputHandler {

	private bool moved;
	private float timer;
	private TouchPhase touchPhase;

	public GameObject clickedTile;
	public TopTile clickedTileObject;

	// gets input data
	public void check( Touch inTouch) {
		touchPhase = inTouch.phase;
		// add new time to timer since last press
		timer += Time.deltaTime;

		switch (touchPhase) {
			// inicial touch
			case TouchPhase.Began:
				select(inTouch);
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
				TopTile tempTile = (TopTile)TileData.hash[hit.transform.gameObject];
				if (!tempTile.playerTeritory) {
					clickedTile = hit.transform.gameObject;
					clickedTileObject = (TopTile)TileData.hash[hit.transform.gameObject];

					return true;
				}		
			}
		}

		return false;
	}
}
