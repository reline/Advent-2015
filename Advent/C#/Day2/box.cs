namespace present {
	public class Box {

		private int w;
		private int h;
		private int l;

		private int surfaceArea;
		private int volume;

		private int smallestSideArea;
		private int smallestSidePerimeter;

		public Box(int w, int h, int l) {
			this.w = w;
			this.h = h;
			this.l = l;

			this.surfaceArea = calculateSurfaceArea();
			this.volume = calculateVolume();

			calculateSmallestSide();
		}

		private int calculateSurfaceArea() {
			return 2*l*w + 2*w*h + 2*h*l;
		}

		private void calculateSmallestSide() {
			int lowOne;
			int lowTwo;
			if(w < h) {
				lowOne = w;
				if(l < h) {
					lowTwo = l;
				} else {
					lowTwo = h;
				}
			} else {
				lowOne = h;
				if(l < w) {
					lowTwo = l;
				} else {
					lowTwo = w;
				}
			}

			smallestSideArea = lowOne*lowTwo;
			smallestSidePerimeter = lowOne * 2 + lowTwo * 2;
		}

		private int calculateVolume() {
			return w*h*l;
		}

		public int getWrappingPaper() {
			return this.smallestSideArea + this.surfaceArea;
		}

		public int getRibbon() {
			return this.smallestSidePerimeter + this.volume;
		}
	}
}