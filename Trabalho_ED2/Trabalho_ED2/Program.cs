using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Trabalho_ED2.Meusort;

namespace Trabalho_ED2
{
    internal class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            int[] vectorSizes = { 1000, 5000, 10000, 50000, 100000, 500000, 1000000 };
            int[] seeds = { 123, 456, 789, 321, 654 };

            Heapsort heapsort = new Heapsort();
            Radixsort radix = new Radixsort();
            Mergesort merge = new Mergesort();
            Quicksort quick = new Quicksort();
            ArvoreBinaria meu = new ArvoreBinaria();

            Console.WriteLine("============================================================");
            Console.WriteLine("|          Valores Médios                                  |");
            Console.WriteLine("============================================================");
            Console.WriteLine("|   Função         |     Tempo (ms)  | Comparações | Cópias");
            Console.WriteLine("------------------------------------------------------------");

            foreach (int size in vectorSizes)
            {
                long heapTotalTime = 0;
                long radixTotalTime = 0;
                long mergeTotalTime = 0;
                long quickTotalTime = 0;
                long meuTotalTime = 0;

                int heapTotalComparisons = 0;
                int radixTotalComparisons = 0;
                int mergeTotalComparisons = 0;
                long quickTotalComparisons = 0;
                int meuTotalComparisons = 0;

                int heapTotalCopies = 0;
                int radixTotalCopies = 0;
                int mergeTotalCopies = 0;
                long quickTotalCopies = 0;
                int meuTotalCopies = 0;

                int[] vector1 = Generate(size, seeds[0]);
                int[] vector2 = Generate(size, seeds[1]);
                int[] vector3 = Generate(size, seeds[2]);
                int[] vector4 = Generate(size, seeds[3]);
                int[] vector5 = Generate(size, seeds[4]);

                heapTotalTime += MeasureExecutionTime(() => heapsort.OrdenarArray((int[])vector1.Clone(), vector1.Length)).Ticks;
                radixTotalTime += MeasureExecutionTime(() => radix.RadixSort((int[])vector2.Clone(), vector2.Length)).Ticks;
                mergeTotalTime += MeasureExecutionTime(() => merge.OrdenarArray((int[])vector3.Clone(), 0, vector3.Length - 1)).Ticks;
                quickTotalTime += MeasureExecutionTime(() => quick.Ordenar((int[])vector4.Clone(), 0, vector4.Length - 1)).Ticks;
                meuTotalTime += MeasureExecutionTime(() => meu.OrdenarSubdivisoes((int[])vector5.Clone())).Ticks;

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

                double heapAverageMilliseconds = TimeSpan.FromTicks(heapTotalTime / seeds.Length).TotalMilliseconds;
                double radixAverageMilliseconds = TimeSpan.FromTicks(radixTotalTime / seeds.Length).TotalMilliseconds;
                double mergeAverageMilliseconds = TimeSpan.FromTicks(mergeTotalTime / seeds.Length).TotalMilliseconds;
                double quickAverageMilliseconds = TimeSpan.FromTicks(quickTotalTime / seeds.Length).TotalMilliseconds;
                double meuAverageMilliseconds = TimeSpan.FromTicks(meuTotalTime / seeds.Length).TotalMilliseconds;

                int heapAverageComparisons = heapTotalComparisons / seeds.Length;
                int radixAverageComparisons = radixTotalComparisons / seeds.Length;
                int mergeAverageComparisons = mergeTotalComparisons / seeds.Length;
                long quickAverageComparisons = quickTotalComparisons / seeds.Length;
                int meuAverageComparisons = meuTotalComparisons / seeds.Length;

                int heapAverageCopies = heapTotalCopies / seeds.Length;
                int radixAverageCopies = radixTotalCopies / seeds.Length;
                int mergeAverageCopies = mergeTotalCopies / seeds.Length;
                long quickAverageCopies = quickTotalCopies / seeds.Length;
                int meuAverageCopies = meuTotalCopies / seeds.Length;

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine($"|  Vetor de tamanho {size}");
                Console.WriteLine($"|  Heapsort        |  {heapAverageMilliseconds} ms  | {heapAverageComparisons}  | {heapAverageCopies}");
                Console.WriteLine($"|  Radixsort       |  {radixAverageMilliseconds} ms | {radixAverageComparisons} | {radixAverageCopies}");
                Console.WriteLine($"|  Mergesort       |  {mergeAverageMilliseconds} ms | {mergeAverageComparisons} | {mergeAverageCopies}");
                Console.WriteLine($"|  Quicksort       |  {quickAverageMilliseconds} ms | {quickAverageComparisons} | {quickAverageCopies}");
                Console.WriteLine($"|  ArvoreBinaria   |  {meuAverageMilliseconds} ms   | {meuAverageComparisons}   | {meuAverageCopies}");
            }

            Console.WriteLine("============================================================");
            Console.Read();
        }

        static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static int[] Generate(int length, int seed)
        {
            int[] vector = new int[length];
            Random random = new Random(seed);

            for (int i = 0; i < length; i++)
            {
                vector[i] = random.Next(10000);
            }

            return vector;
        }
    }
}
