

using System.Collections;
using System.Text.RegularExpressions;

string inputFile = "inputEx.txt";


// DATA
var data = System.IO.File.ReadAllLines(inputFile);

var dataList = new List<string>(data);


// utilisation d'un streamReader pour lire le fichier source
var bingoDrawnNumbers = "";
var bingoGrids = "";


// lit la premiere ligne du fichier
using(StreamReader reader = new StreamReader(inputFile)) {
    bingoDrawnNumbers = reader.ReadLine() ?? ""; // L’opérateur de fusion null ?? retourne la valeur de l’opérande de gauche si elle n’est pas null

    bingoGrids = reader.ReadToEnd();
}

Console.WriteLine("bingoDrawnNumbers = " + bingoDrawnNumbers);
Console.WriteLine("bingoGrids = " + bingoGrids);

int gridSizes = 5;

Regex rx = new Regex(@"\d+");
MatchCollection matches = rx.Matches(bingoGrids);
Console.WriteLine("--------------------------");
Console.WriteLine("matches = " + matches.ToString());

// bingoGrids = Regex.Match(bingoGrids, @"\d+").Value;
// Console.WriteLine("--------------------------");
// Console.WriteLine("bingoGrids = " + bingoGrids);

List<bingoGrid> listBingoGrid = initBingoGrids(matches);

Console.WriteLine("--------------------------");
Console.WriteLine("listBingoGrid = " + listBingoGrid);





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

    public bingoGrid(int _bingoGridSize, List<List<int>> _bingoGridContent){
        this._bingoGridSize = _bingoGridSize;
        this._bingoGridContent = _bingoGridContent;
        this._victoryMatrix = initVictoryMatrix(_bingoGridSize);
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


    public List<List<int>> initVictoryMatrix(int _bingoGridSize){ // initialize the victory Matrice

        List<List<int>> victoryMatrix = new List<List<int>>();
        for (int i = 0; i < _bingoGridSize; i++){
            List<int> rangee = new List<int>();
            for (int j = 0; j < _bingoGridSize; j++){
                rangee.Add(0);
            }
        }
        return victoryMatrix;
    }


    public void verifyDraw(int drawnNumber, bingoGrid bg){ // see if the drawn number is in the grid

    }

    public void verifyVictory(bingoGrid bg){ // verify if the grid is victorious

    }

    public void printGrid(){ // print the grid

    }


}

