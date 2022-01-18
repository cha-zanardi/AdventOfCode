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
            ArrayList tmp = new ArrayList<>();
            for (int j = 0; j < _matrixSize; j++) {
                tmp.add(0);
            }
            tmp_matrixContent.add(tmp);
        }

        this._matrixContent = tmp_matrixContent;
    }

    
    public void addVector(Integer a, Integer b){

    }
    

}
