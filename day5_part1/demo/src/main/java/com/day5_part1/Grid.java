package com.day5_part1;

import java.util.ArrayList;

public class Grid {
    
    ArrayList<ArrayList<Integer>> _matrixContent;
    Integer _matrixSize;



    // GETTER SETTER
    public ArrayList<ArrayList<Integer>> get_matrixContent() {
        return _matrixContent;
    }
    public void set_matrixContent(ArrayList<ArrayList<Integer>> _matrixContent) {
        this._matrixContent = _matrixContent;
    }



    // GETTER SETTER
    public Integer get_matrixSize() {
        return _matrixSize;
    }
    public void set_matrixSize(Integer _matrixSize) {
        this._matrixSize = _matrixSize;
    }


    // CONSTRUCTORS
    public Grid(){
        this._matrixContent = new ArrayList<ArrayList<Integer>>();
    }

    public Grid(Integer _matrixSize) {
        this._matrixSize = _matrixSize;
        initMatrix(_matrixSize);
    }



    // METHODS

    public void initMatrix(Integer _matrixSize){
        
        ArrayList<ArrayList<Integer>> tmp_matrixContent = new ArrayList<ArrayList<Integer>>();

        for (int i = 0; i < _matrixSize; i++) {
            ArrayList<Integer> tmp = new ArrayList<Integer>();
            for (int j = 0; j < _matrixSize; j++) {
                tmp.add(0);
            }
            tmp_matrixContent.add(tmp);
        }

        this._matrixContent = tmp_matrixContent;
    }

    
    public void addVector(ArrayList<Integer> vectors){
        Integer x1,y1,x2,y2;

        x1 = vectors.get(0);
        y1 = vectors.get(1);
        x2 = vectors.get(2);
        y2 = vectors.get(3);

        if (x1 == x2) {
            int j = x1;

            if (y1 < y2) {
                for (int i = y1; i <= y2; i++) {
                    int increment = this._matrixContent.get(i).get(j) + 1;
                    this._matrixContent.get(i).set(j, increment);
                }
            }
            else{
                for (int i = y2; i <= y1; i++) {
                    int increment = this._matrixContent.get(i).get(j) + 1;
                    this._matrixContent.get(i).set(j, increment);
                }
            }
        }
        else if (y1 == y2) {
            int i = y1;

            if (x1 < x2) {
                for (int j = x1; j <= x2; j++) {
                    int increment = this._matrixContent.get(i).get(j) + 1;
                    this._matrixContent.get(i).set(j, increment);
                }
            }
            else{
                for (int j = x2; j <= x1; j++) {
                    int increment = this._matrixContent.get(i).get(j) + 1;
                    this._matrixContent.get(i).set(j, increment);
                }
            }
        }
    }

    public void countOverlaps(){
        Integer overlaps = 0;
        for (int i = 0; i < this._matrixSize; i++) {
            for (int j = 0; j < this._matrixSize; j++) {
                if (this._matrixContent.get(i).get(j) >= 2) {
                    overlaps++;
                }
            }
        }
        System.out.println("Number of overlaps = " + overlaps);
    }

    public String toString(){
        String result = "";

        for (int i = 0; i < this._matrixContent.size(); i++) {
            for (int j = 0; j < this._matrixContent.get(i).size() ; j++) {
                result += Integer.toString(this._matrixContent.get(i).get(j)) + " ";
            }
            result += "\n";
        }

        return result;
    }
    

}
