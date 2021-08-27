using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrizCaracol
{
    public enum Direcao
    {
        Esquerda,
        Cima,
        Baixo,
        Direita
    }

    public class Calculos
    {
        public static Direcao Direcao { get; set; }
        public static int Linhas { get; set; }
        public static int Colunas { get; set; }
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int?[,] Matriz { get; set; }


        public static bool Salvar(int valor)
        {
            int xaux, yaux;

            xaux = X;
            yaux = Y;

            if (Direcao == Direcao.Direita)
            {
                while (!EspacoLivre(xaux, yaux))
                {
                    yaux++;

                    if (!IndicePertenceAMatriz(xaux, yaux))
                    {
                        yaux = Y; //diminui a coluna
                        Direcao = Direcao.Baixo;
                        break;
                    }
                }
            }
            else if (Direcao == Direcao.Baixo)
            {
                while (!EspacoLivre(xaux, yaux))
                {
                    xaux++;

                    if (!IndicePertenceAMatriz(xaux, yaux))
                    {
                        xaux = X; //aumenta a linha
                        Direcao = Direcao.Esquerda;
                        break;
                    }
                }
            }
            else if (Direcao == Direcao.Cima)
            {
                while (!EspacoLivre(xaux, yaux))
                {
                    xaux--;

                    if (!IndicePertenceAMatriz(xaux, yaux))
                    {
                        xaux = X; //aumenta a linha
                        Direcao = Direcao.Direita;
                        break;
                    }
                }
            }
            else
            {
                while (!EspacoLivre(xaux, yaux))
                {
                    yaux--;

                    if (!IndicePertenceAMatriz(xaux, yaux))
                    {
                        yaux = Y;
                        Direcao = Direcao.Cima;
                        break;
                    }
                }
            }

            X = xaux;
            Y = yaux;

            if (Matriz[X, Y] == null)
            {
                Matriz[X, Y] = valor;
                return true;
            }

            return false;
        }

        private static bool IndicePertenceAMatriz(int x, int y)
        {
            if (x >= 0 && x < Linhas && y >= 0 && y < Colunas)
            {
                return true;
            }
            return false;
        }

        private static bool EspacoLivre(int x, int y)
        {
            if (Matriz[x, y] == null)
            {
                return true;
            }
            return false;
        }
    }
}
