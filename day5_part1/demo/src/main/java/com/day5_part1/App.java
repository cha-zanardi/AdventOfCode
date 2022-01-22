package com.day5_part1;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.*;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args ) throws Exception {

        // String inputFile = "inputEX.txt";
        String inputFile = "input.txt";
        File file = new File("src\\main\\resources\\" + inputFile);
        Scanner sc = new Scanner(file);
        String dataList = new String();
    
        while (sc.hasNextLine()) {
            dataList += " " + sc.nextLine();
        }

        if (dataList.isEmpty()) {
            System.out.println("dataList est vide");
        }

        Pattern regex = Pattern.compile("\\d+");
        Matcher matcher = regex.matcher(dataList);
        ArrayList<Integer> datalist2 = new ArrayList<Integer>();
        // Integer i = 0;

        while (matcher.find()) {
            datalist2.add(Integer.valueOf(matcher.group()));
            // System.out.println(matcher.group());
            // i++;
        }


        // for (Integer m : datalist2) {
        //     System.out.print("---");
        //     System.out.print(m);
        //     System.out.println("---");
        // }

        

        Integer matrixSize = matrixSize(datalist2);
        Grid ventsGrid = new Grid(matrixSize);

        // System.out.println(ventsGrid.toString());

        ArrayList<Integer> tmpVectors = new ArrayList<Integer>();

        for (int i = 0; i < datalist2.size(); i++) {
            // System.out.println("---------------------------");
            // System.out.println("itération où i = " + i);
            // System.out.println(datalist2.get(i));

            tmpVectors.add(datalist2.get(i));

            if (tmpVectors.size() == 4) {
                System.out.println("Contenu de tmp = " + tmpVectors.toString());
                ventsGrid.addVector(tmpVectors);
                // System.out.println(ventsGrid.toString());
                System.out.println("--- Vidage tmpVector ---");
                tmpVectors.clear();
            }
        }
        
        System.out.println("matrixSize = " + matrixSize);
        ventsGrid.countOverlaps();

        sc.close();
    }

    public static Integer matrixSize(ArrayList<Integer> dataList){
        Integer biggestNum = 0;
        
        for (Integer i : dataList) {
            if (i > biggestNum) {
                biggestNum = i;
            }
        }
        biggestNum++;

        return biggestNum;
    }


}
