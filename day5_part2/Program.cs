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


int matrixSize = getMatrixSize(listNumbers);
Grid ventsGrid = new Grid(matrixSize);


List<int> tmpVectors = new List<int>();


    
foreach (int num in listNumbers) {

    tmpVectors.Add(num);

    if (tmpVectors.Count() == 4) {
 
        ventsGrid.addVector(tmpVectors);
        // Console.WriteLine(ventsGrid.toString());
        tmpVectors.Clear();
    }
}
    

ventsGrid.countOverlaps();


int getMatrixSize(List<int> dataList){
    int biggestNum = 0;

    foreach (int num in dataList) {
        if (num > biggestNum) {
            biggestNum = num;
        }
    }

    biggestNum += 1;

    return biggestNum;
}