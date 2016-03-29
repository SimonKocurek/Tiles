using UnityEngine;

public class Tile {

	// general data
	public GameObject tileObject;
	public int z;

	public Tile( Vector3 _position, int _z, GameObject tileModel, GameObject parent) {
		z = _z;

		// assign GameObject
		tileObject = (GameObject) ScriptableObject.Instantiate(tileModel, _position, new Quaternion());
		tileObject.transform.SetParent( parent.transform);
	}
}
