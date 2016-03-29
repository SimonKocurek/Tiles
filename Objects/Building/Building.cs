using UnityEngine;

public class Building {

	protected static Vector3 offset = new Vector3(19.57953455f, 7.4778505f, 18.571573f);
	public GameObject gameObject;

	public int x;
	public int y;

	public int ownedCount;
	public TopTile[] ownedTiles;

	protected void select(int range) {
		TopTile[] tempOwnedTiles = new TopTile[range * range];
		ownedCount = 0;

		// get temporary large array of owned tiles
		for (int _x = x - range, endX = x + range; _x <= endX; _x ++) {
			for (int _y = y - range, endY = y + range; _y <= endY; _y ++) {
				if (_x >= 0 && _y >= 0 && _x <= TileData.x && _y <= TileData.y) {
					TopTile tile = TileData.tiles[_x, _y];
					if (tile != null && tile.ownerId == -1) {
						tempOwnedTiles[ownedCount] = tile;
						ownedCount ++;
					}
				}	
			}
		}

		// transfer data to compact array
		ownedTiles = new TopTile[ownedCount];
		for (int i = 0; i < ownedCount; i ++) {
			ownedTiles[i] = tempOwnedTiles[i];
		}
	}
}
