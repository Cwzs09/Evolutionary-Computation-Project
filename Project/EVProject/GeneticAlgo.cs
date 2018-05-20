using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVProject
{
    struct Chromosome
    {
        public int[] genes;
        public int fitness;
        public double cumAvgFitness; //cumilative of average of fitness value
    }

    delegate void Progress(int progress);
    class GeneticAlgo
    {
        public event Progress progress;
        private const int MAX_FIT = 28;
        private Random random;
        int a;

        public GeneticAlgo(int scale)
        {
            random = new Random((int)DateTime.Now.Ticks);
            this.a = scale;
        }

        public void DoMating(ref List<Chromosome> initPopulation, int generations, double probCrossver, double probMutation, string crossMethod,string mutaMethod)
        {
            int totalFitness = 0;
            CalcFitness(ref initPopulation, ref totalFitness);

            for (int generation = 0; generation < generations; generation++)
            {
                PrepareRuletteWheel(ref initPopulation, totalFitness);
                switch (crossMethod)
                {
                    case "1":
                        Crossover(ref initPopulation, probCrossver);
                        break;
                    case "2":
                        Crossover2(ref initPopulation, probCrossver);
                        break;
                    case "3":
                        Crossover3(ref initPopulation, probCrossver);
                        break;
                    case "4":
                        Crossover4(ref initPopulation, probCrossver);
                        break;
                    default:
                        Crossover2(ref initPopulation, probCrossver);
                        break;
                }
                switch (mutaMethod)
                {
                    case "1":
                        Mutate(ref initPopulation, probMutation);
                        break;
                    case "2":
                        Mutate2(ref initPopulation, probMutation); break;
                    case "3":
                        Mutate3(ref initPopulation, probMutation); break;
                    case "4":
                        Mutate4(ref initPopulation, probMutation); break;
                    default:
                        Mutate(ref initPopulation, probMutation); break;
                }
                Mutate(ref initPopulation, probMutation);
                CalcFitness(ref initPopulation, ref totalFitness);
                if (initPopulation[initPopulation.Count - 1].fitness == 28)
                    break;
                if (progress != null)
                {
                    progress(generation + 1);
                }
            }
            initPopulation.Sort(new FitnessComparator());



        }
        //Crossover1 Start
        public void Crossover(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offspring = new List<Chromosome>();

            for (int i = 0; i < parents.Count; i++)
            {
                if (Assay(probability)) //if the chance is to crossover
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    Chromosome parentY = AssayRuletteWheel(parents);

                    List<int> child = new List<int>();
                    for (int j = 0; j < a; j++)
                    {
                        if (Assay(0.5)) //select from parentX
                        {
                            for (int k = 0; k < parentX.genes.Length; k++)
                            {
                                if (!child.Contains(parentX.genes[k]))//instead of deleting the similar genes from parents select the next non-contained number
                                {
                                    child.Add(parentX.genes[k]);
                                    break;
                                }
                            }
                        }
                        else //select from parentY
                        {
                            for (int k = 0; k < parentY.genes.Length; k++)
                            {
                                if (!child.Contains(parentY.genes[k]))//instead of deleting the similar genes from parents select the next non-contained number
                                {
                                    child.Add(parentY.genes[k]);
                                    break;
                                }
                            }
                        }
                    }
                    Chromosome offSpr = new Chromosome();
                    offSpr.genes = child.ToArray();
                    offspring.Add(offSpr);

                }
                else //else the chance is to clonning
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    offspring.Add(parentX);
                }
            }

            while (offspring.Count > parents.Count)
            {
                offspring.RemoveAt((int)GetRandomVal(0, offspring.Count - 1));
            }

            parents = offspring;
        }//Crossover1 Finish

        //Crossover2 Start

        public void Crossover2(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offspring = new List<Chromosome>();

            for (int i = 0; i < parents.Count/2; i++)
            {
                if (Assay(probability)) //if the chance is to crossover
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    Chromosome parentY = AssayRuletteWheel(parents);

                    List<int> child1 = new List<int>();
                    List<int> child2 = new List<int>();
                    int divide=random.Next(0,a);
                    for (int j = 0; j < a; j++)
                    {

                        if (j<divide)
                        {
                            child1.Add(parentX.genes[j]);
                        }
                        else
                        {
                            for (int k = 0; k < parentY.genes.Length; k++)
                            {
                                if (!child1.Contains(parentY.genes[k]))//instead of deleting the similar genes from parents select the next non-contained number
                                {
                                    child1.Add(parentY.genes[k]);
                                    break;
                                }
                            }
                        }
                        if (j < divide)
                        {
                            child2.Add(parentY.genes[j]);
                        }
                        else
                        {
                            for (int k = 0; k < parentX.genes.Length; k++)
                            {
                                if (!child2.Contains(parentX.genes[k]))//instead of deleting the similar genes from parents select the next non-contained number
                                {
                                    child2.Add(parentX.genes[k]);
                                    break;
                                }
                            }
                        }

                    }
                    Chromosome offSpr = new Chromosome();
                    offSpr.genes = child1.ToArray();
                    offspring.Add(offSpr);
                    offSpr.genes = child2.ToArray();
                    offspring.Add(offSpr);

                }
                else //else the chance is to clonning
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    offspring.Add(parentX);
                    Chromosome parentY = AssayRuletteWheel(parents);
                    offspring.Add(parentY);
                }
            }

            while (offspring.Count > parents.Count)
            {
                offspring.RemoveAt((int)GetRandomVal(0, offspring.Count - 1));
            }

            parents = offspring;
        }//Crossover2 Finish

        //Crossover3 Start

        public void Crossover3(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offspring = new List<Chromosome>();

            for (int i = 0; i < parents.Count/2; i++)
            {
                if (Assay(probability)) //if the chance is to crossover
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    Chromosome parentY = AssayRuletteWheel(parents);
                    
                    List<int> child1 = new List<int>();
                    List<int> child2 = new List<int>();
                    for (int c = 0; c < a; c++)
                    {
                        child1.Add(-1);
                        child2.Add(-1);
                    }
                    int intervalB = random.Next(0, a-1);//Index which starts of interval
                    int intervalF = random.Next(intervalB+1, a);//Index which finish of interval
                    for (int j = intervalB; j < intervalF; j++)
                    {
                        child1[j] = parentX.genes[j];
                        child2[j] = parentY.genes[j];
                    }
                    for (int j = intervalB; j < intervalF; j++)
                    {
                        int index = j;
                        int cross;
                        if (child1.Contains(parentY.genes[index]))
                        {
                            continue;
                        }
                        for (int k = 0; k >= 0; k++)
                        {
                            cross = child1[index];
                            index = Array.IndexOf(parentY.genes, cross);
                            if (child1[index]!=-1)
                            {
                                cross = child1[index];
                                index = Array.IndexOf(parentY.genes, cross);
                            }
                            if (child1[index] == -1)
                            {
                                child1[index] = parentY.genes[j];
                                break;
                            }
                        }
                        int index2 = j;
                        int cross2;
                        if (child2.Contains(parentX.genes[index2]))
                        {
                            continue;
                        }
                        for (int k = 0; k >= 0; k++)
                        {
                            cross2 = child2[index2];
                            index2 = Array.IndexOf(parentX.genes, cross2);
                            if (child2[index2] != -1)
                            {
                                cross2 = child2[index2];
                                index2 = Array.IndexOf(parentX.genes, cross2);
                            }
                            if (child2[index2] == -1)
                            {
                                child2[index2] = parentX.genes[j];
                                break;
                            }
                        }

                    }
                    for (int j = 0; j < a; j++)
                    {
                        if (child1[j]==-1)
                        {
                            for (int k = 0; k < parentY.genes.Length; k++)
                            {
                                if (!child1.Contains(parentY.genes[k]))//instead of deleting the similar genes from parents select the next non-contained number
                                {
                                    child1[j] = parentY.genes[k];
                                    break;
                                }
                            }
                        }
                        if (child2[j] == -1)
                        {
                            for (int k = 0; k < parentX.genes.Length; k++)
                            {
                                if (!child2.Contains(parentX.genes[k]))//instead of deleting the similar genes from parents select the next non-contained number
                                {
                                    child2[j] = parentX.genes[k];
                                    break;
                                }
                            }
                        }
                    }


                    Chromosome offSpr = new Chromosome();
                    offSpr.genes = child1.ToArray();
                    offspring.Add(offSpr);
                    offSpr.genes = child2.ToArray();
                    offspring.Add(offSpr);

                }
                else //else the chance is to clonning
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    offspring.Add(parentX);
                    Chromosome parentY = AssayRuletteWheel(parents);
                    offspring.Add(parentY);
                }
            }

            while (offspring.Count > parents.Count)
            {
                offspring.RemoveAt((int)GetRandomVal(0, offspring.Count - 1));
            }

            parents = offspring;
        }//Crossover3 Finish

        //Crossover4 Start

        public void Crossover4(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offspring = new List<Chromosome>();

            for (int i = 0; i < parents.Count / 2; i++)
            {
                if (Assay(probability)) //if the chance is to crossover
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    Chromosome parentY = AssayRuletteWheel(parents);

                    List<int> child1 = new List<int>();
                    List<int> child2 = new List<int>();
                    for (int c = 0; c < a; c++)
                    {
                        child1.Add(-1);
                        child2.Add(-1);
                    }
                    int index = 0;
                    int cross =parentX.genes[0];
                    int cross2;
                    List<int> position = new List<int>();
                    for (int j = 0; j>0; j++)
                    {
                        cross2 = parentY.genes[index];
                        index = Array.IndexOf(parentX.genes, cross);
                        position.Add(index);
                        if (parentY.genes[index]==cross)
                        {
                            break;
                        }
                    }
                    for (int k = 0; k < a; k++)
                    {
                        if (!position.Contains(k))
                        {
                            child2[k] = parentX.genes[k];
                            child1[k] = parentY.genes[k];
                        }
                    }
                    Chromosome offSpr = new Chromosome();
                    offSpr.genes = child1.ToArray();
                    offspring.Add(offSpr);
                    offSpr.genes = child2.ToArray();
                    offspring.Add(offSpr);

                }
                else //else the chance is to clonning
                {
                    Chromosome parentX = AssayRuletteWheel(parents);
                    offspring.Add(parentX);
                    Chromosome parentY = AssayRuletteWheel(parents);
                    offspring.Add(parentY);
                }
            }

            while (offspring.Count > parents.Count)
            {
                offspring.RemoveAt((int)GetRandomVal(0, offspring.Count - 1));
            }

            parents = offspring;
        }//Crossover4 Finish

        private void PrepareRuletteWheel(ref List<Chromosome> parents, int total)
        {
            int currentTotalFitness = 0;
            for (int i = 0; i < parents.Count; i++)
            {
                currentTotalFitness += parents[i].fitness;
                Chromosome temp = parents[i];
                temp.cumAvgFitness = currentTotalFitness / (double)total;
                parents[i] = temp;
            }
        }

        private Chromosome AssayRuletteWheel(List<Chromosome> parents)
        {
            Chromosome selection = parents[0];
            double probability = random.NextDouble();
            for (int i = 0; i < parents.Count; i++)
            {
                selection = parents[i];
                if (parents[i].cumAvgFitness > probability)
                    break;

            }
            return selection;
        }

        public void Mutate(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offsprings = new List<Chromosome>();

            for (int i = 0; i < parents.Count; i++)
            {
                Chromosome offspring = parents[i];
                for (int mutatePosition = 0; mutatePosition < a; mutatePosition++)
                {
                    if (Assay(probability)) //if the chance is to mutate
                    {
                        int geneIndex1 = random.Next(0, a - 2);
                        int geneIndex2 = random.Next(geneIndex1 + 1, a);
                        for (int k = geneIndex1; k < geneIndex2; k++)
                        {
                            int indexNew = random.Next(k, geneIndex2);
                            int tempItem = offspring.genes[k];
                            offspring.genes[k] = offspring.genes[indexNew];
                            offspring.genes[indexNew] = tempItem;
                        }
                    }
                }

                offsprings.Add(offspring);
            }

            parents = offsprings;
        }

        public void Mutate2(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offsprings = new List<Chromosome>();

            for (int i = 0; i < parents.Count; i++)
            {
                Chromosome offspring = parents[i];
                for (int mutatePosition = 0; mutatePosition < a; mutatePosition++)
                {
                    if (Assay(probability)) //if the chance is to mutate
                    {
                        int geneIndex1 = random.Next(0, a);
                        int geneIndex2 = random.Next(0, a);
                        int tempItem = offspring.genes[geneIndex1];
                        offspring.genes[geneIndex1]=offspring.genes[geneIndex2];
                        offspring.genes[geneIndex2]=tempItem;
                    }
                }

                offsprings.Add(offspring);
            }

            parents = offsprings;
        }

        public void Mutate3(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offsprings = new List<Chromosome>();

            for (int i = 0; i < parents.Count; i++)
            {
                Chromosome offspring = parents[i];
                if (Assay(probability)) //if the chance is to mutate
                {
                    int geneIndex1 = random.Next(0,a-2);
                    int geneIndex2 = random.Next(geneIndex1+1, a);
                    int[] newGenes = new int[a];
                    for (int k = 0; k < a; k++)
                    {
                        if (k == geneIndex1 + 1)
                        {
                            newGenes[k] = offspring.genes[geneIndex2];
                        }
                        else if (k<=geneIndex1)
                        {
                            newGenes[k] = offspring.genes[k];
                        }
                        else if (k <= geneIndex2)
                        {
                            newGenes[k] = offspring.genes[k-1];
                        }
                        else if (k > geneIndex2)
                        {
                            newGenes[k] = offspring.genes[k];
                        }
                    }
                    offspring.genes = newGenes;
                }
                
                offsprings.Add(offspring);
            }

            parents = offsprings;
        }

        public void Mutate4(ref List<Chromosome> parents, double probability)
        {
            List<Chromosome> offsprings = new List<Chromosome>();

            for (int i = 0; i < parents.Count; i++)
            {
                Chromosome offspring = parents[i];
                for (int mutatePosition = 0; mutatePosition < a; mutatePosition++)
                {
                    if (Assay(probability)) //if the chance is to mutate
                    {
                        int geneIndex1 = random.Next(0, a - 2);
                        int geneIndex2 = random.Next(geneIndex1 + 1, a);
                        Array.Reverse(offspring.genes,geneIndex1,geneIndex2-geneIndex1);
                    }
                }

                offsprings.Add(offspring);
            }

            parents = offsprings;
        }

        public double GetRandomVal(double min, double max)
        {
            return min + random.NextDouble() * (max - min);
        }

        private bool Assay(double probability)
        {
            if (random.NextDouble() < probability)
                return true;
            else
                return false;
        }

        public void CalcFitness(ref List<Chromosome> chromosome, ref int totalFitness)
        {
            int collisions = 0;
            totalFitness = 0;
            for (int k = 0; k < chromosome.Count; k++)
            {
                for (int i = 0; i < chromosome[k].genes.Length - 1; i++)
                {
                    int x = i;
                    int y = chromosome[k].genes[i];
                    for (int j = i + 1; j < chromosome[k].genes.Length; j++)
                    {
                        if (Math.Abs(j - x) == Math.Abs(chromosome[k].genes[j] - y))
                            collisions++;
                    }
                }

                Chromosome temp = chromosome[k];
                temp.fitness = MAX_FIT - collisions;
                chromosome[k] = temp;
                totalFitness += chromosome[k].fitness;
                collisions = 0;
            }
        }
    }

    class FitnessComparator : Comparer<Chromosome>
    {
        public override int Compare(Chromosome x, Chromosome y)
        {
            if (x.fitness == y.fitness)
                return 0;
            else if (x.fitness < y.fitness)
                return 1;
            else
                return -1;
        }
    }
}
