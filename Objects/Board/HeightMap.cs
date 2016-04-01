public class HeightMap {

	// result
	public int[,] height;

	// dimensions
	private int lengthX;
	private int lengthY;

	public HeightMap(int inputX, int inputY, int maxHeight) {
		lengthX = inputX;
		lengthY = inputY;

		// set random heights
		height = new int[lengthX, lengthY] ;
		for (int x = 0; x < lengthX; x ++) {
			for (int y = 0; y < lengthY; y ++) {
				height[x,y] = UnityEngine.Random.Range(1, maxHeight);
			}
		}
	}

	// smooth heightmap
	public void smooth(int smoothness) {
		for (int i = 0; i < smoothness; i ++) {
			
			int[,] diff = new int[lengthX,lengthY];

			// generate
			for (int x = 0; x < lengthX; x ++) {
				for (int y = 0; y < lengthY; y ++) {
					diff[x,y] = neighbours(x, y);
				}
			}

			// override
			for (int x = 0; x < lengthX; x ++) {
				for (int y = 0; y < lengthY; y ++) {
					height[x,y] = diff[x,y];
				}
			}

		}
	}

	// height of lowest neighbour
	public int lowestNeighbour( int x, int y) {
		int lowest = height[x,y];

		if (y % 2 == 0) {
			for (int kernelY = y-1; kernelY <= y+1; kernelY ++) {
				
				int offset = 0;
				if ( kernelY == y) {
					offset = 1;
				}

				for (int kernelX = x - offset; kernelX <= x+1; kernelX ++) {
					if( kernelY >= 0 && kernelX >= 0 && kernelY < lengthY && kernelX < lengthX) {
						if (height[kernelX, kernelY] < lowest) {
							lowest = height[kernelX, kernelY];
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
						if (height[kernelX, kernelY] < lowest) {
							lowest = height[kernelX, kernelY];
						}
					}
				}
			} 
		}

		return lowest;
	}

	// average height of neighbours
	private int neighbours( int x, int y) {
		int heightSum = 0;
		int neighbourCount = 0;

		if (y % 2 == 0) {
			for (int kernelY = y-1; kernelY <= y+1; kernelY ++) {

				int offset = 0;
				if ( kernelY == y) {
					offset = 1;
				}	

				for (int kernelX = x - offset; kernelX <= x+1; kernelX ++) {

					if ( kernelY != y || kernelX != x) {
						if( kernelY >= 0 && kernelX >= 0 && kernelY < lengthY && kernelX < lengthX) {
							neighbourCount ++;
							heightSum += height[kernelX, kernelY];
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

				for (int kernelX = x-1; kernelX <= x + offset; kernelX ++) {

					if ( kernelY != y || kernelX != x) {
						if( kernelY >= 0 && kernelX >= 0 && kernelY < lengthY && kernelX < lengthX) {
							neighbourCount ++;
							heightSum += height[kernelX, kernelY];
						}
					}
				}
			} 
		}

		return heightSum / neighbourCount;
	}

	// lowest height in heightmap
	public int lowestHeigh() {
		int lowest = int.MaxValue;

		for (int x = 0; x < lengthX; x ++) {
			for (int y = 0; y < lengthY; y ++) {
				if (lowest > height[x,y]) {
					lowest = height[x,y];
				}
			}
		}

		return lowest;
	}
}
