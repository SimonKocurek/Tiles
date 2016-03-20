using UnityEngine;

public class WaterController : MonoBehaviour {

	// inspector changes
	[Range(1,10)]public int waterHeightLevel;
	[Range(0f, 1f)]public float waves;

	// cache used variables
	private Vector3 position;
	private Vector3 basePosition;

	void Start() {
		float tileSizeZ = GameObject.Find("Board").GetComponent<BoardController>().tileSize.z;

		waves *= tileSizeZ / 2;
		basePosition = new Vector3(0, (waterHeightLevel * tileSizeZ) + (tileSizeZ / 2), 0);
		position = new Vector3(0, 0, 0);
	}

	// make waves
	void Update() {
		position.y = (Mathf.Sin(Time.time)) * waves + basePosition.y;
		transform.position = position;
	}
}
