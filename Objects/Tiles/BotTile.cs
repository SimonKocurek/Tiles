using UnityEngine;

public class BotTile : Tile {

	private static Material underwaterMat = Resources.Load("Tile/Materials/UnderwaterTile") as Material;

	public BotTile( Vector3 _position, int _z, GameObject tileModel, GameObject parent, int waterHeightLevel ) : base(_position, _z, tileModel, parent) {

		// set bot tile specific data
		if (waterHeightLevel > z) {
			tileObject.GetComponent<Renderer>().material = underwaterMat;
		}
	}
}
