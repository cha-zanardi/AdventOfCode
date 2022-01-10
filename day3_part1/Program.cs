// See https://aka.ms/new-console-template for more information

using System;
using System.Text.RegularExpressions;
using System.IO;

// DATA
string[] data = System.IO.File.ReadAllLines(@"input.txt");

// Calculate the power consumption
void calculate(string[] data){
    string gamma = "";
    string epsilon = "";

    // loop for the length of a binary number (here 5)
    for (int i = 0; i < data[0].Length; i++){

        int numberOfZero = 0;
        int numberOfOne = 0;

        foreach(string line in data){

            // Convert the char into string format
            string resultString = line[i].ToString();

            if(resultString == "0"){
                numberOfZero++;
            }
            else if(resultString == "1"){
                numberOfOne++;
            }

        }

        // if more "0", gamma take 0 and epsilon 1
        if(numberOfZero > numberOfOne){
            gamma += "0";
            epsilon += "1";
        }
        // if more "1", gamma take 1 and epsilon 0
        else if(numberOfZero < numberOfOne){
            gamma += "1";
            epsilon += "0";
        }
    }
    
    // Convert binary string to decimal
    int gammaDecimal = Convert.ToInt32(gamma, 2);
    int epsilonDecimal = Convert.ToInt32(epsilon, 2);

    int powerConsumption = gammaDecimal * epsilonDecimal;

    Console.WriteLine("gammaDecimal = " + gammaDecimal + " epsilonDecimal = " + epsilonDecimal + " powerConsumption = " + powerConsumption );
}


calculate(data);