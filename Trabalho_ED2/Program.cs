using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Trabalho_ED2.Meusort;

namespace Trabalho_ED2 {
    internal class Program {

        static void Main(string[] args) {
            int[] tamanhosVetor = { 1000, 5000, 10000, 50000, 100000, 500000, 1000000 };
            int[] sementes = { 123, 456, 789, 321, 654 };
    
            Heapsort heapsort = new Heapsort();
            Radixsort radix = new Radixsort();
            Mergesort merge = new Mergesort();
            Quicksort quick = new Quicksort();
            ArvoreBinaria meu = new ArvoreBinaria();

            Console.WriteLine("=================================================================");
            Console.WriteLine("|                     Valores Médios                            |");
            Console.WriteLine("=================================================================");
            Console.WriteLine("|   Função         |     Tempo (ms)    |  Comparações  | Cópias |");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (int size in tamanhosVetor) {
                Console.WriteLine($"==%==\nVetor de tamanho: {size}\n==%==");

                long heapTotalTime = 0;
                long radixTotalTime = 0;
                long mergeTotalTime = 0;
                long quickTotalTime = 0;
                long meuTotalTime = 0;

                long heapTotalComparisons = 0;
                long radixTotalComparisons = 0;
                long mergeTotalComparisons = 0;
                long quickTotalComparisons = 0;
                long meuTotalComparisons = 0;

                long heapTotalCopies = 0;
                long radixTotalCopies = 0;
                long mergeTotalCopies = 0;
                long quickTotalCopies = 0;
                long meuTotalCopies = 0;

                foreach (int semente in sementes) {
                    int[] vectorOriginal = Generate(size, semente);

                    int[] copyHeap = new int[vectorOriginal.Length];
                    int[] copyRadix = new int[vectorOriginal.Length];
                    int[] copyMerge = new int[vectorOriginal.Length];
                    int[] copyQuick = new int[vectorOriginal.Length];
                    int[] copyMeu = new int[vectorOriginal.Length];

                    vectorOriginal.CopyTo(copyHeap, 0);
                    vectorOriginal.CopyTo(copyRadix, 0);
                    vectorOriginal.CopyTo(copyMerge, 0);
                    vectorOriginal.CopyTo(copyQuick, 0);
                    vectorOriginal.CopyTo(copyMeu, 0);


                    heapTotalTime += MeasureExecutionTime(() => heapsort.OrdenarArray(copyHeap, copyHeap.Length)).Ticks;
                    radixTotalTime += MeasureExecutionTime(() => radix.RadixSort(copyRadix, copyRadix.Length)).Ticks;
                    mergeTotalTime += MeasureExecutionTime(() => merge.OrdenarArray(copyMerge, 0, copyMerge.Length - 1)).Ticks;
                    quickTotalTime += MeasureExecutionTime(() => quick.Ordenar(copyQuick, 0, copyQuick.Length - 1)).Ticks;
                    meuTotalTime += MeasureExecutionTime(() => meu.OrdenarSubdivisoes(copyMeu)).Ticks;

                    heapTotalComparisons += heapsort.Comparisons;
                    radixTotalComparisons += radix.Comparisons;
                    mergeTotalComparisons += merge.Comparisons;
                    quickTotalComparisons += quick.Comparisons;
                    meuTotalComparisons += meu.Comparisons;

                    heapTotalCopies += heapsort.Copies;
                    radixTotalCopies += radix.Copies;
                    mergeTotalCopies += merge.Copies;
                    quickTotalCopies += quick.Copies;
                    meuTotalCopies += meu.Copies;
                }

                double heapAverageMilliseconds = TimeSpan.FromTicks(heapTotalTime / sementes.Length).TotalMilliseconds;
                double radixAverageMilliseconds = TimeSpan.FromTicks(radixTotalTime / sementes.Length).TotalMilliseconds;
                double mergeAverageMilliseconds = TimeSpan.FromTicks(mergeTotalTime / sementes.Length).TotalMilliseconds;
                double quickAverageMilliseconds = TimeSpan.FromTicks(quickTotalTime / sementes.Length).TotalMilliseconds;
                double meuAverageMilliseconds = TimeSpan.FromTicks(meuTotalTime / sementes.Length).TotalMilliseconds;

                long heapAverageComparisons = heapTotalComparisons / sementes.Length;
                long radixAverageComparisons = radixTotalComparisons / sementes.Length;
                long mergeAverageComparisons = mergeTotalComparisons / sementes.Length;
                long quickAverageComparisons = quickTotalComparisons / sementes.Length;
                long meuAverageComparisons = meuTotalComparisons / sementes.Length;

                long heapAverageCopies = heapTotalCopies / sementes.Length;
                long radixAverageCopies = radixTotalCopies / sementes.Length;
                long mergeAverageCopies = mergeTotalCopies / sementes.Length;
                long quickAverageCopies = quickTotalCopies / sementes.Length;
                long meuAverageCopies = meuTotalCopies / sementes.Length;

                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"|  Heapsort        |  {heapAverageMilliseconds,12:F2} ms  | {heapAverageComparisons,12}  | {heapAverageCopies,7}");
                Console.WriteLine($"|  Radixsort       |  {radixAverageMilliseconds,12:F2} ms  | {radixAverageComparisons,12}  | {radixAverageCopies,7}");
                Console.WriteLine($"|  Mergesort       |  {mergeAverageMilliseconds,12:F2} ms  | {mergeAverageComparisons,12}  | {mergeAverageCopies,7}");
                Console.WriteLine($"|  Quicksort       |  {quickAverageMilliseconds,12:F2} ms  | {quickAverageComparisons,12}  | {quickAverageCopies,7}");
                Console.WriteLine($"|  Meusort         |  {meuAverageMilliseconds,12:F2} ms  | {meuAverageComparisons,12}  | {meuAverageCopies,7}");
                Console.WriteLine("-----------------------------------------------------------------");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            Console.WriteLine("=====================================================================");
            Console.Read();
        }

        static TimeSpan MeasureExecutionTime(Action action) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
            
        static int[] Generate(int length, int seed) {
            Random random = new Random(seed);
            int[] vector = new int[length];

            for (int i = 0; i < length; i++) {
                vector[i] = random.Next(length);
            }

            return vector;
        }
    }
}
