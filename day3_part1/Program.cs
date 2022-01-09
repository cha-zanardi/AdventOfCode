// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

// DATA
string[] data = {"00100","11110","10110","10111","10101","01111","00111","11100","10000","11001","00010","01010"};


// Calculate Gamma and Epsilon
void calculate(string[] data){
    string gamma = "";
    string epsilon = "";

    // loop for the length of a binary number (here 5)
    for (int i = 0; i < 5; i++){
        Console.WriteLine("------------ i = " + i + " ------------");

        int numberOfZero = 0;
        int numberOfOne = 0;

        foreach(string line in data){
            Console.WriteLine("*** LINE = " + line + " ***");

            // search for a number in the string and parse it into an integer
            //string resultString = Regex.Match(line, @"\d").Value;
            //int resultStringParsed = Int32.Parse(resultString);

            //Console.WriteLine("resultStringParsed = " + resultStringParsed);

            //int resultString = Char.GetNumericValue(line[i]);
            string resultString = line[i].ToString();
            Console.WriteLine("resultString = " + resultString);

            

            if(resultString == "0"){
                numberOfZero++;
            }
            else if(resultString == "1"){
                numberOfOne++;
            }

        }

        // more "0"
        if(numberOfZero > numberOfOne){
            gamma += "0";
            epsilon += "1";
            Console.WriteLine("ADDING 0 TO GAMMA");
        }
        // more "1"
        else if(numberOfZero < numberOfOne){
            gamma += "1";
            epsilon += "0";
            Console.WriteLine("ADDING 1 TO GAMMA");
        }
    }
    int powerConsumption = 0;
    //int powerConsumption = gamma * epsilon;
    Console.WriteLine("gamma = " + gamma + " epsilon = " + epsilon + " powerConsumption = " + powerConsumption );
}


calculate(data);