// See https://aka.ms/new-console-template for more information

using System;
using System.Text.RegularExpressions;
using System.IO;

// DATA
var data = System.IO.File.ReadAllLines(@"input.txt");
var dataList = new List<string>(data);



// Calculate the oxygen rating
int calculateOxygen(List<string> dataList){
    string oxygen = "";
    int bitPos = 0;


    while (dataList.Count != 1){

        var dataList0 = new List<string>();
        var dataList1 = new List<string>();

        int numberOfZero = 0;
        int numberOfOne = 0;

        foreach(string line in dataList.ToList()){
            
            string bitString = line[bitPos].ToString();

            if(bitString == "0"){
                numberOfZero++;
                dataList0.Add(line);

            }
            else if(bitString == "1"){
                numberOfOne++;
                dataList1.Add(line);
            }
        }


        // if there are more "1", we keep the 1 list
        if(numberOfOne > numberOfZero){
            dataList = dataList1;
        }

        // if there are more "0", we keep the 0 list
        else if(numberOfZero > numberOfOne){
            dataList = dataList0;
        }

        // if it's equal, we keep the 1 list
        else if(numberOfZero == numberOfOne){
            dataList = dataList1;
        }
        bitPos++;
    }
    
    oxygen = dataList[0];
    
    // Convert binary string to decimal
    int oxygenDecimal = Convert.ToInt32(oxygen, 2);

    Console.WriteLine("oxygenDecimal = " + oxygenDecimal );

    return oxygenDecimal;
}


// Calculate the co2 rating
int calculateCo2(List<string> dataList){
    string co2 = "";
    int bitPos = 0;


    while (dataList.Count != 1){

        var dataList0 = new List<string>();
        var dataList1 = new List<string>();

        int numberOfZero = 0;
        int numberOfOne = 0;

        foreach(string line in dataList.ToList()){
            
            string bitString = line[bitPos].ToString();

            if(bitString == "0"){
                numberOfZero++;
                dataList0.Add(line);

            }
            else if(bitString == "1"){
                numberOfOne++;
                dataList1.Add(line);
            }
        }


        // if there are more "1", we keep the 1 list
        if(numberOfOne < numberOfZero){
            dataList = dataList1;
        }

        // if there are more "0", we keep the 0 list
        else if(numberOfZero < numberOfOne){
            dataList = dataList0;
        }

        // if it's equal, we keep the 0 list
        else if(numberOfZero == numberOfOne){
            dataList = dataList0;
        }
        bitPos++;
    }

    co2 = dataList[0];
    
    // Convert binary string to decimal
    int co2Decimal = Convert.ToInt32(co2, 2);

    Console.WriteLine("co2Decimal = " + co2Decimal );

    return co2Decimal;
}

// Calculate life support rating
void calculateLifeSupport(int oxygenRating, int co2Rating){
    int lifeSupportDecimal = oxygenRating * co2Rating;
    Console.WriteLine("lifeSupportDecimal = " + lifeSupportDecimal );
}


int oxygenRating = calculateOxygen(dataList);
int co2Rating = calculateCo2(dataList);
calculateLifeSupport(oxygenRating, co2Rating);