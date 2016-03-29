using UnityEngine;

public class TopTile : Tile {

	public int islandId = -1;
	public int ownerId = -1;

	public int x;
	public int y;
	
	public TopTile( Vector3 _position, int _x, int _y, int _z, GameObject tileModel, GameObject parent) : base(_position, _z, tileModel, parent) {
		// x and y are used only with top tiles
		x = _x;
		y = _y;

		// make board data global
		TileData.hash.Add(tileObject, this);
		TileData.tiles[x, y] = this;
	}
}
