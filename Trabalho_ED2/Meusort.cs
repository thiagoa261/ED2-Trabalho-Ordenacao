using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_ED2
{
    internal class Meusort
    {

        public class NoArvore
        {
            public int Valor;
            public NoArvore Esquerda;
            public NoArvore Direita;

            public NoArvore(int valor)
            {
                Valor = valor;
                Esquerda = null;
                Direita = null;
            }
        }

        public class ArvoreBinaria
        {
            public long Comparisons { get; private set; }
            public long Copies { get; private set; }
            public NoArvore Raiz;

            public void Inserir(int valor)
            {
                Copies++;
                Raiz = InserirNo(Raiz, valor);
            }

            private NoArvore InserirNo(NoArvore raiz, int valor)
            {
                if (raiz == null)
                {
                    Comparisons++;
                    raiz = new NoArvore(valor);
                    return raiz;
                }

                if (valor < raiz.Valor)
                {
                    Comparisons++;
                    Copies++;
                    raiz.Esquerda = InserirNo(raiz.Esquerda, valor);
                }
                else if (valor > raiz.Valor)
                {
                    Comparisons++;
                    Copies ++;
                    raiz.Direita = InserirNo(raiz.Direita, valor);
                }
                return raiz;
            }

            public int[] OrdenarSubdivisoes(int[] array)
            {
                Comparisons = 0;
                Copies = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    Comparisons++;
                    Inserir(array[i]);
                }
                OrdenarSubdivisoes(Raiz);

                int[] arrayOrdenado = PercursoEmOrdem();

                array = arrayOrdenado;
                return arrayOrdenado;
            }

            private void OrdenarSubdivisoes(NoArvore no)
            {
                if (no != null)
                {
                    Comparisons++;
                    OrdenarSubdivisoes(no.Esquerda);
                    OrdenarSubdivisoes(no.Direita);

                    if (no.Esquerda != null && no.Direita != null)
                    {
                        Comparisons++;
                        int valorEsquerda = no.Esquerda.Valor;
                        int valorDireita = no.Direita.Valor;

                        if (valorEsquerda > valorDireita)
                        {
                            Copies += 2;
                            no.Esquerda.Valor = valorDireita;
                            no.Direita.Valor = valorEsquerda;
                        }
                    }
                }
            }

            private int[] PercursoEmOrdem()
            {
                List<int> listaOrdenada = new List<int>();
                PercursoEmOrdem(Raiz, listaOrdenada);
                return listaOrdenada.ToArray();
            }

            private void PercursoEmOrdem(NoArvore no, List<int> listaOrdenada)
            {
                if (no != null)
                {
                    Comparisons++;
                    PercursoEmOrdem(no.Esquerda, listaOrdenada);
                    listaOrdenada.Add(no.Valor);
                    PercursoEmOrdem(no.Direita, listaOrdenada);
                }
            }
        }
    }
}
