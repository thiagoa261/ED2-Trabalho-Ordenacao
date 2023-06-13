using System;

namespace Trabalho_ED2
{
    internal class Quicksort
    {
        public long Comparisons { get; private set; }
        public long Copies { get; private set; }

        public void Ordenar(int[] vetor, int esquerda, int direita)
        {
            if (esquerda < direita)
            {
                int indicePivo = Particionar(vetor, esquerda, direita);
                Ordenar(vetor, esquerda, indicePivo - 1);
                Ordenar(vetor, indicePivo + 1, direita);

                Comparisons++; 
            }
        }

        private int Particionar(int[] vetor, int esquerda, int direita)
        {
            int pivo = vetor[direita];
            int i = esquerda - 1;

            for (int j = esquerda; j <= direita - 1; j++)
            {
                Comparisons++;

                if (vetor[j] < pivo)
                {
                    i++;
                    Trocar(vetor, i, j);

                    Comparisons++;
                    Copies += 3;
                }
            }

            Trocar(vetor, i + 1, direita);
            Copies += 3;

            Copies++;

            return i + 1;
        }

        private void Trocar(int[] vetor, int i, int j)
        {
            int temp = vetor[i];
            vetor[i] = vetor[j];
            vetor[j] = temp;
            Copies += 3;
        }
    }
}
