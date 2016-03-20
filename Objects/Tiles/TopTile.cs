using UnityEngine;

public class TopTile : Tile {

	public int islandId = -1;
	public bool playerTeritory = false;
	
	public TopTile( Vector3 _position, int _x, int _y, int _z, GameObject tileModel, GameObject parent) : base(_position, _x, _y, _z, tileModel, parent) {

	}
}
