using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// DATA
string inputFile = "input.txt";
string dataList = "";
Regex rx = new Regex(@"\d+");


using(StreamReader reader = new StreamReader(inputFile)) {
    dataList = reader.ReadToEnd();
}

List<int> listNumbers = new List<int>();
MatchCollection CollectionlistNumbers = rx.Matches(dataList);
foreach (Match m in CollectionlistNumbers) {
    listNumbers.Add(Int32.Parse(m.Value));
}


foreach (int number in listNumbers)
{
    Console.WriteLine("---");
    Console.WriteLine(number);
    Console.WriteLine("---");
}


int matrixSize = getMatrixSize(listNumbers);
Grid ventsGrid = new Grid(matrixSize);

// Console.WriteLine(ventsGrid.toString());

List<int> tmpVectors = new List<int>();


    
foreach (int num in listNumbers) {
    // Console.WriteLine("---------------------------");
    // Console.WriteLine("itération où num = " + num);
    // Console.WriteLine(listNumbers.ElementAt(num));

    tmpVectors.Add(listNumbers.ElementAt(num));

    if (tmpVectors.Count() == 4) {
        Console.WriteLine("Contenu de tmp = " + tmpVectors.ToString());
        ventsGrid.addVector(tmpVectors);
        // Console.WriteLine(ventsGrid.toString());
        Console.WriteLine("--- Vidage tmpVector ---");
        tmpVectors.Clear();
    }
}
    


Console.WriteLine("matrixSize = " + matrixSize);
ventsGrid.countOverlaps();

    


int getMatrixSize(List<int> dataList){
    int biggestNum = 0;

    foreach (int num in dataList) {
        if (num > biggestNum) {
            biggestNum = num;
        }
    }
    
    biggestNum++;

    return biggestNum;
}