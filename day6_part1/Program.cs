using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// DATA
string inputFile = "input.txt";
string dataList = "";
Regex rx = new Regex(@"\d+");
int numberOfDays = 256;


using(StreamReader reader = new StreamReader(inputFile)) {
    dataList = reader.ReadToEnd();
}

List<int> listFish = new List<int>();
MatchCollection CollectionlistNumbers = rx.Matches(dataList);
foreach (Match m in CollectionlistNumbers) {
    listFish.Add(Int32.Parse(m.Value));
}



// Console.WriteLine("Initial state : " + string.Join(" ",listFish));
for (int i = 1; i <= numberOfDays; i++) {
    
    listFish = increaseFish(listFish);
    // Console.WriteLine("After " + i + " day : " + string.Join(" ",listFish));
}


int fishNumber = listFish.Count();
Console.WriteLine("There are a total of " + fishNumber + " fish after " + numberOfDays + " days.");


// FUNCTION : increase number of fish in the list
List<int> increaseFish(List<int> listFish) {
    int i = 0;
    List<int> tmpListFish = new List<int>();

    foreach (int fish in listFish) {

        if (listFish.ElementAt(i) == 0) { // Each day, a 0 becomes a 6 and adds a new 8 to the end of the list
            tmpListFish.Add(6);
            tmpListFish.Add(8);
        }
        else {
            int decrement = listFish.ElementAt(i) - 1;
            tmpListFish.Add(decrement);
        }

        i++;
    }

    listFish = tmpListFish;
    return listFish;
}