using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_ED2
{
    internal class Heapsort
    {
        public int Comparisons { get; private set; }
        public int Copies { get; private set; }

        public int[] OrdenarArray(int[] array, int tamanho)
        {
            Comparisons = 0;
            Copies = 0;
            if (tamanho <= 1)
                return array;

            for (int i = tamanho / 2 - 1; i >= 0; i--)
            {
                Comparisons++;
                Heapify(array, tamanho, i);
            }

            for (int i = tamanho - 1; i >= 0; i--)
            {
                Comparisons++;
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Copies += 3;
                Heapify(array, i, 0);
            }

            return array;
        }

        private void Heapify(int[] array, int tamanho, int indice)
        {
            var indiceMaior = indice;
            var filhoEsquerda = 2 * indice + 1;
            var filhoDireita = 2 * indice + 2;

            if (filhoEsquerda < tamanho)
            {
                Comparisons++;
                if (array[filhoEsquerda] > array[indiceMaior])
                {
                    indiceMaior = filhoEsquerda;
                }
            }

            if (filhoDireita < tamanho)
            {
                Comparisons++;
                if (array[filhoDireita] > array[indiceMaior])
                {
                    indiceMaior = filhoDireita;
                }
            }

            if (indiceMaior != indice)
            {
                var temp = array[indice];
                array[indice] = array[indiceMaior];
                array[indiceMaior] = temp;
                Copies += 3;

                Heapify(array, tamanho, indiceMaior);
            }
        }
    }
}
