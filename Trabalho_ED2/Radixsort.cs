using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_ED2
{
    internal class Radixsort
    {
        public long Comparisons { get; private set; }
        public long Copies { get; private set; }

        public int[] RadixSort(int[] array, int tamanho)
        {
            Comparisons = 0;
            Copies = 0;
            var maximo = ObterMaximo(array, tamanho);

            for (int expoente = 1; maximo / expoente > 0; expoente *= 10)
            {
                OrdenacaoContagem(array, tamanho, expoente);
                Comparisons++;
            }

            return array;
        }

        public int ObterMaximo(int[] array, int tamanho)
        {
            var maximo = array[0];

            for (int i = 1; i < tamanho; i++)
            {
                Comparisons++;
                if (array[i] > maximo)
                {
                    Copies++;
                    maximo = array[i];
                }
            }

            return maximo;
        }

        public void OrdenacaoContagem(int[] array, int tamanho, int expoente)
        {
            var arraySaida = new int[tamanho];
            var ocorrencias = new int[10];

            for (int i = 0; i < 10; i++)
            {
                ocorrencias[i] = 0;
                Copies++;
                Comparisons++;
            }

            for (int i = 0; i < tamanho; i++)
            {
                ocorrencias[(array[i] / expoente) % 10]++;
                Copies++;
                Comparisons++;
            }

            for (int i = 1; i < 10; i++)
            {
                ocorrencias[i] += ocorrencias[i - 1];
                Copies++;
                Comparisons++;
            }

            for (int i = tamanho - 1; i >= 0; i--)
            {
                arraySaida[ocorrencias[(array[i] / expoente) % 10] - 1] = array[i];
                ocorrencias[(array[i] / expoente) % 10]--;
                Copies++;
                Comparisons++;
            }

            for (int i = 0; i < tamanho; i++)
            {
                array[i] = arraySaida[i];
                Copies++;
                Comparisons++;
            }
        }
    }
}
