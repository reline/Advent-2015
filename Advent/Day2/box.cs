namespace Namespace {
	public class Box {

		public static int totalWrappingPaper;
		public static int totalRibbon;

		public int w;
		public int h;
		public int l;
		public int smallestSideArea;
		public int surfaceArea;
		public int smallestPerimeter;
		public int ribbon;
		public int volume;

		public Box(int w, int h, int l) {
			this.w = w;
			this.h = h;
			this.l = l;

			findSmallestSide();
			this.surfaceArea = calculateSurfaceArea();
			addWrappingPaper();

			this.volume = calculateVolume();
			this.ribbon = calculateRibbon();
			addRibbon();
		}

		public int calculateSurfaceArea() {
			return 2*l*w + 2*w*h + 2*h*l;
		}

		public void findSmallestSide() {
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
			smallestPerimeter = lowOne * 2 + lowTwo * 2;
		}

		public void addWrappingPaper() {
			totalWrappingPaper += this.smallestSideArea + this.surfaceArea;
		}

		public int calculateVolume() {
			return w*h*l;
		}

		public int calculateRibbon() {
			return this.smallestPerimeter + this.volume;
		}

		public void addRibbon() {
			totalRibbon += ribbon;
		}
	}
}