public class Grid {
    
    List<List<int>> _matrixContent;
    int _matrixSize;



    // GETTER SETTER
    public List<List<int>> matrixContent {
        get => _matrixContent;
        set => _matrixContent = value;
    }

        public int matrixSize {
        get => _matrixSize;
        set => _matrixSize = value;
    }



    // CONSTRUCTORS
    public Grid(){
        this._matrixContent = new List<List<int>>();
    }

    public Grid(int _matrixSize) {
        this._matrixSize = _matrixSize;
        this._matrixContent = initMatrix(_matrixSize);
    }



    // METHODS

    public List<List<int>> initMatrix(int _matrixSize){
        
        List<List<int>> tmp_matrixContent = new List<List<int>>();

        for (int i = 0; i < _matrixSize; i++) {
            List<int> tmp = new List<int>();
            for (int j = 0; j < _matrixSize; j++) {
                tmp.Add(0);
            }
            tmp_matrixContent.Add(tmp);
        }

        return tmp_matrixContent;
    }

    
    public void addVector(List<int> vectors){
        int x1,y1,x2,y2;

        x1 = vectors.ElementAt(0);
        y1 = vectors.ElementAt(1);
        x2 = vectors.ElementAt(2);
        y2 = vectors.ElementAt(3);

        if (x1 == x2) {
            int j = x1;

            if (y1 == y2) {
                int i = y1;
                int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                this._matrixContent.ElementAt(i)[j] = increment;
            }
            else if (y1 < y2) {
                for (int i = y1; i <= y2; i++) {
                    int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                    this._matrixContent.ElementAt(i)[j] = increment;
                }
            }
            else if (y1 > y2) {
                for (int i = y2; i <= y1; i++) {
                    int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                    this._matrixContent.ElementAt(i)[j] = increment;
                }
            }
        }
        else if (y1 == y2) {
            int i = y1;

            if (x1 == x2) {
                int j = x1;
                int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                this._matrixContent.ElementAt(i)[j] = increment;
            }
            else if (x1 < x2) {
                for (int j = x1; j <= x2; j++) {
                    int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                    this._matrixContent.ElementAt(i)[j] = increment;
                }
            }
            else if (x1 > x2) {
                for (int j = x2; j <= x1; j++) {
                    this._matrixContent.ElementAt(i)[j]++;// = increment;
                }
            }
        }



        else if ((x1 < x2) && (y1 > y2)) {
                int i = y1;
            for (int j = x1; j <= x2; j++) {//un seul for
                int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                this._matrixContent.ElementAt(i)[j] = increment;
                i--;
            }
        }
        else if ((x1 > x2) && (y1 < y2)) {
                int i = y1;
            for (int j = x1; j >= x2; j--) {
                int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                this._matrixContent.ElementAt(i)[j] = increment;
                i++;
            }
        }


        else if ((x1 < x2) && (y1 < y2)) {
                int i = y1;
            for (int j = x1; j <= x2; j++) {
                int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                this._matrixContent.ElementAt(i)[j] = increment;
                i++;
            }
        }
        else if ((x1 > x2) && (y1 > y2)) {
                int i = y2;
            for (int j = x2; j <= x1; j++) {
                int increment = this._matrixContent.ElementAt(i).ElementAt(j) + 1;
                this._matrixContent.ElementAt(i)[j] = increment;
                i++;
            }
        }
    }

    public void countOverlaps(){
        int overlaps = 0;

        for (int i = 0; i < this._matrixSize; i++) {
            for (int j = 0; j < this._matrixSize; j++) {
                
                if (this._matrixContent.ElementAt(i).ElementAt(j) >= 2) {
                    overlaps++;
                }
            }
        }
        Console.WriteLine("Number of overlaps = " + overlaps);
    }

    public String toString(){
        String result = "";

        for (int i = 0; i < this._matrixSize; i++) {
            for (int j = 0; j < this._matrixSize ; j++) {
                result += this._matrixContent.ElementAt(i).ElementAt(j) + " ";
            }
            result += "\n";
        }

        return result;
    }
    

}
