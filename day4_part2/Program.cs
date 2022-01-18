using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// DATA
string inputFile = "input.txt";
var firstLine = "";
var bingoGrids = "";
int gridSizes = 5;
Regex rx = new Regex(@"\d+");
bool victory = false;
bingoGrid victoriousbingoGrid = new bingoGrid();
int lastCalledNumber = 0;

// lit la premiere ligne du fichier et le reste dans un deuxieme temps
using(StreamReader reader = new StreamReader(inputFile)) {
    firstLine = reader.ReadLine() ?? ""; // L’opérateur de fusion null ?? retourne la valeur de l’opérande de gauche si elle n’est pas null

    bingoGrids = reader.ReadToEnd();
}

List<int> listDrawnNumbers = new List<int>();
MatchCollection CollectionDrawnNumbers = rx.Matches(firstLine);
foreach (Match m in CollectionDrawnNumbers) {
    listDrawnNumbers.Add(Int32.Parse(m.Value));
}


MatchCollection matches = rx.Matches(bingoGrids);
List<bingoGrid> listBingoGrid = initBingoGrids(matches);
List<bingoGrid> listVictoriousBingoGrid = new List<bingoGrid>();


foreach (int drawnNumber in listDrawnNumbers) {
    List<bingoGrid> tmp = new List<bingoGrid>();
    foreach (bingoGrid bg in listBingoGrid) {
        victory = bg.verifyDraw(drawnNumber);
        if (victory == true) {
            lastCalledNumber = drawnNumber;
            listVictoriousBingoGrid.Add(bg);
            tmp.Add(bg);
        }
    }
    foreach(bingoGrid bg in tmp){
        listBingoGrid.Remove(bg);
    }
}

victoriousbingoGrid = listVictoriousBingoGrid.Last();
victoriousbingoGrid.calculateFinalScore(victoriousbingoGrid.lastCalledNumber);








// FUNCTION initBingoGrids: initialize the bingo grids
List<bingoGrid> initBingoGrids(MatchCollection matches){

    int countMatches = 0;
    List<bingoGrid> listBingoGrid = new List<bingoGrid>();

    while(countMatches != matches.Count){

        List<List<int>> gridConstruction = new List<List<int>>(); // creation liste de listes

        for(int j = 0; j < gridSizes; j++){

            List<int> rangee = new List<int>(); //creation liste de int

            for(int k = 0; k < gridSizes; k++){
                rangee.Add(Int32.Parse(matches[countMatches].Value));
                countMatches++;
            }

            gridConstruction.Add(rangee);
        }

        bingoGrid bg = new bingoGrid(gridSizes, gridConstruction);

        listBingoGrid.Add(bg);
        
    }

    return listBingoGrid;
}




class bingoGrid {
    private int _bingoGridSize;
    private List<List<int>> _bingoGridContent;
    private List<List<int>> _victoryMatrix;

    private bool _victorious;

    private int? _lastCalledNumber;

    public bingoGrid(){
        this._bingoGridSize = 0;
        this._bingoGridContent = new List<List<int>>();
        this._victoryMatrix = new List<List<int>>();
        this._victorious = false;
        this._lastCalledNumber = null;
    }

    public bingoGrid(int _bingoGridSize, List<List<int>> _bingoGridContent){
        this._bingoGridSize = _bingoGridSize;
        this._bingoGridContent = _bingoGridContent;
        this._victoryMatrix = initVictoryMatrix(_bingoGridSize);
        this._victorious = false;
        this._lastCalledNumber = null;
    }
    public int bingoGridSize {
        get => _bingoGridSize;
        set => _bingoGridSize = value;
    }

    public List<List<int>> bingoGridContent {
        get => _bingoGridContent;
        set => _bingoGridContent = value;
    }

    public List<List<int>> victoryMatrix {
        get => _victoryMatrix;
        set => _victoryMatrix = value;
    }

    public int? lastCalledNumber {
        get => _lastCalledNumber;
        set => _lastCalledNumber = value;
    }


    public List<List<int>> initVictoryMatrix(int _bingoGridSize){ // initialize the victory Matrix

        List<List<int>> victoryMatrix = new List<List<int>>();
        for (int i = 0; i < _bingoGridSize; i++){
            List<int> rangee = new List<int>();
            for (int j = 0; j < _bingoGridSize; j++){
                rangee.Add(0);
            }
            victoryMatrix.Add(rangee);
        }
        return victoryMatrix;
    }


    public bool verifyDraw(int drawnNumber){ // see if the drawn number is in the grid

        for (int i = 0; i < this.bingoGridContent.Count; i++) {
            for (int j = 0; j < this.bingoGridContent.Count; j++)
            {
                if (this.bingoGridContent[i][j] == drawnNumber) {
                    this.victoryMatrix[i][j] = 1;
                    bool victoire = verifyVictory(this.victoryMatrix);
                    if(victoire == true){
                        this._victorious = true;
                        this._lastCalledNumber = drawnNumber;
                        return true;
                    }
                }
                
            }
        }

        return false;
    }

    public bool verifyVictory(List<List<int>> victoryMatrix){ // verify if the grid is victorious
        int counterONE = 0;

        //verification horizontale
        for (int row = 0; row < this._bingoGridSize; row++) {
            for (int col = 0; col < this._bingoGridSize; col++) {

                if (this.victoryMatrix[row].Contains(0)) {
                    counterONE = 0;
                    break;
                }
                else {
                    counterONE++;
                    if (counterONE == this._bingoGridSize) {
                        Console.WriteLine("victory !");
                        return true;
                    }
                }
                
            }
        }

        //verification verticale
        for(int col = 0; col < this._bingoGridSize; col++) {
            for (int row = 0; row < this._bingoGridSize; row++) {
                if (this.victoryMatrix[row][col] != 1) {
                    counterONE = 0;
                    break;
                }
                else {
                    counterONE++;
                    if (counterONE == this._bingoGridSize) {
                        Console.WriteLine("victory !");
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void calculateFinalScore(int? lastCalledNumber){
        int? result = 0;


        for (int row = 0; row < this._bingoGridSize; row++) {
            for (int col = 0; col < this._bingoGridSize; col++) {

                if (this.victoryMatrix[row][col] != 1) {
                    result += this.bingoGridContent[row][col];
                }
            }
        }

        result *= lastCalledNumber;

        Console.WriteLine("The final score is : " + result);
    }

}

