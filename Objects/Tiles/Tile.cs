using UnityEngine;

public class Tile {

	// general data
	protected GameObject tileObject;
	public int x;
	public int y;
	public int z;

	public Tile( Vector3 _position, int _x, int _y, int _z, GameObject tileModel, GameObject parent) {
		x = _x;
		y = _y;
		z = _z;

		// assign GameObject
		tileObject = (GameObject) ScriptableObject.Instantiate(tileModel, _position, new Quaternion());
		tileObject.transform.SetParent( parent.transform);
		TileHash.hash.Add(tileObject, this);
	}
}
