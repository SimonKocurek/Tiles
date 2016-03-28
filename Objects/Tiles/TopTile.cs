using UnityEngine;

public class TopTile : Tile {

	public int islandId = -1;

	public bool playerTeritory = false;
	public int playerId = -1;
	
	public TopTile( Vector3 _position, int _z, GameObject tileModel, GameObject parent) : base(_position, _z, tileModel, parent) {
	}
}
