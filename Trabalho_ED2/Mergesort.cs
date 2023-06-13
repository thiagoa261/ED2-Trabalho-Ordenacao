using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_ED2
{
    internal class Mergesort
    {
        public long Comparisons { get; private set; }
        public long Copies { get; private set; }

        public int[] OrdenarArray(int[] array, int esquerda, int direita)
        {
            Comparisons = 0;
            Copies = 0;
            if (esquerda < direita)
            {
                Comparisons++;
                int meio = esquerda + (direita - esquerda) / 2;
                OrdenarArray(array, esquerda, meio);
                OrdenarArray(array, meio + 1, direita);

                MesclarArray(array, esquerda, meio, direita);
            }

            return array;
        }

        public void MesclarArray(int[] array, int esquerda, int meio, int direita)
        {
            var tamanhoArrayEsquerda = meio - esquerda + 1;
            var tamanhoArrayDireita = direita - meio;
            var arrayTemporarioEsquerda = new int[tamanhoArrayEsquerda];
            var arrayTemporarioDireita = new int[tamanhoArrayDireita];
            int i, j;

            for (i = 0; i < tamanhoArrayEsquerda; ++i)
            {
                Comparisons++;
                arrayTemporarioEsquerda[i] = array[esquerda + i];
                Copies++;
            }
            for (j = 0; j < tamanhoArrayDireita; ++j)
            {
                Comparisons++;
                arrayTemporarioDireita[j] = array[meio + 1 + j];
                Copies++;
            }
            i = 0;
            j = 0;
            int k = esquerda;

            while (i < tamanhoArrayEsquerda && j < tamanhoArrayDireita)
            {
                Comparisons++;
                if (arrayTemporarioEsquerda[i] <= arrayTemporarioDireita[j])
                {
                    Comparisons++;
                    array[k++] = arrayTemporarioEsquerda[i++];
                    Copies++;
                }
                else
                {
                    array[k++] = arrayTemporarioDireita[j++];
                    Copies++;
                }
            }

            while (i < tamanhoArrayEsquerda)
            {
                Comparisons++;
                array[k++] = arrayTemporarioEsquerda[i++];
                Copies++;
            }

            while (j < tamanhoArrayDireita)
            {
                Comparisons++;
                array[k++] = arrayTemporarioDireita[j++];
                Copies++;
            }
        }
    }
}
