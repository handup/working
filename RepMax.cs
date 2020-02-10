using System;
using System.Collections;

namespace working
{
    public class Excercise{
        public string name{get; set;}
        //logs maxes for all reps
        public double[] log;
        //1RM is convenient to save 
        public RepMax oneRepMax;

        public void lifted(int reps, double weight){
            if(oneRepMax.PR(reps, weight) || RepMax.estimateMax(reps, weight) > log[reps])
                log[reps] = weight;
        }
    }

    public class RepMax
    {
        private double oneRep { get; set; }

        public bool PR(int repCount, double weight){
            double newLift = estimateMax(repCount, weight);
            if( newLift > oneRep){
                oneRep = newLift;
                return true;
            }
            else return false;
        }

        public static double estimateMax(int repCount, double weight){
            //using Epley's formula
            if(repCount > 1)
                return weight*(1 + repCount/30);
            else{
                if(repCount==1) return weight;
                else throw new Exception("Rep range is not a Natural Number");
            }

        }

        public double repCountMax(int repCount){
            if(repCount==1)
                return oneRep;
            else
                return oneRep/(1 + repCount / 30);
        }
    }
}
