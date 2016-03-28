public class IslandGenerator {

	private int lengthX;
	private int lengthY;
	private int id = 0;

	public IslandGenerator(int _lengthX, int _lengthY) {
		lengthX = _lengthX;
		lengthY = _lengthY;
	}

	// generate island IDs
	public void generate() {
		// go through each tile
		for (int x = 0; x < lengthX; x++) {
			for (int y = 0; y < lengthY; y++) {
				if (validTile(TileData.tiles[x, y])) {
					crawl(TileData.tiles[x, y], x, y);
					id++;
				}
			}
		}
	}

	// crawl whole island for tiles recursively
	private void crawl( TopTile tile, int x, int y) {
		tile.islandId = id;

		if (y % 2 == 0) {
			for (int kernelY = y-1; kernelY <= y+1; kernelY ++) {

				int offset = 0;
				if ( kernelY == y) {
					offset = 1;
				}

				for (int kernelX = x - offset; kernelX <= x+1; kernelX ++) {
					if( kernelY >= 0 && kernelX >= 0 && kernelY < lengthY && kernelX < lengthX) {
						
						tile = TileData.tiles[kernelX, kernelY];
						if (validTile( tile)) {
							crawl( tile, kernelX, kernelY);
						}
					}
				}
			}
		} else {
			for (int kernelY = y-1; kernelY <= y+1; kernelY ++) {
				
				int offset = 0;
				if ( kernelY == y) {
					offset = 1;
				}

				for (int kernelX = x-1 ; kernelX <= x + offset; kernelX ++) {
					if( kernelY >= 0 && kernelX >= 0 && kernelY < lengthY && kernelX < lengthX) {
						
						tile = TileData.tiles[kernelX, kernelY];
						if (validTile( tile)) {
							crawl( tile, kernelX, kernelY);
						}
					}
				}
			} 
		}
	}

	// tile can be island and isn't already
	private bool validTile( TopTile tile) {
		if (tile != null) {
			if (tile.islandId == -1) {
				return true;
			}
		}
		return false;
	}
}
