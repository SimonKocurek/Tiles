using UnityEngine;

public class Building {

	protected static Vector3 offset = new Vector3(19.57953455f, - 7.4778505f, 18.571573f);
	public GameObject gameObject;

	public int x;
	public int y;

	public int ownedCount;
	public TopTile[] ownedTiles;

	// fills ownedTiles array with tiles around building
	protected void select(int range) {
		TopTile[] tempOwnedTiles = new TopTile[range * range * 4];
		ownedCount = 0;

		// get temporary large array of owned tiles

		//TODO OPTIMIZE THIS !
		crawl(TileData.tiles[x, y], x, y, range, tempOwnedTiles);

		// transfer data to compact array
		ownedTiles = new TopTile[ownedCount];
		for (int i = 0; i < ownedCount; i ++) {
			ownedTiles[i] = tempOwnedTiles[i];
		}
	}

	private void crawl( TopTile tile, int x, int y, int range, TopTile[] tempOwnedTiles) {
		tempOwnedTiles[ownedCount] = tile;
		ownedCount++;

		if (y % 2 == 0) {
			for (int kernelY = y - 1; kernelY <= y + 1; kernelY++) {

				int offset = 0;
				if (kernelY == y) {
					offset = 1;
				}

				for (int kernelX = x - offset; kernelX <= x + 1; kernelX++) {
					if (kernelY >= 0 && kernelX >= 0 && kernelY < TileData.y && kernelX < TileData.x) {

						TopTile _tile = TileData.tiles[kernelX, kernelY];
						if (_tile != null && _tile.ownerId == -1 && range > 1) {
							crawl(_tile, kernelX, kernelY, range - 1, tempOwnedTiles);
						}
					}
				}
			}
		}
		else {
			for (int kernelY = y - 1; kernelY <= y + 1; kernelY++) {

				int offset = 0;
				if (kernelY == y) {
					offset = 1;
				}

				for (int kernelX = x - 1; kernelX <= x + offset; kernelX++) {
					if (kernelY >= 0 && kernelX >= 0 && kernelY < TileData.y && kernelX < TileData.x) {

						TopTile _tile = TileData.tiles[kernelX, kernelY];
						if (_tile != null && _tile.ownerId == -1 && range > 1) {
							crawl(_tile, kernelX, kernelY, range - 1, tempOwnedTiles);
						}
					}
				}
			}
		}
	}
}
