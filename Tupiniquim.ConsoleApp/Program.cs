﻿using System;

namespace Tupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //declaração de variáveis
            string str_quadrilatero, str_posicao_inicial, str_movimento;
            int minimo_x = 0, minimo_y = 0, maximo_x, maximo_y, posicao_x_robo, posicao_y_robo; ;
            char bussola;
            bool continuar;
        //entrada de dados
            do
            {
                Console.WriteLine("\r\nTupiniquim I");
                Console.Write("\r\nTamanho da área do quadrilátero, por exemplo 5 5: ");
                str_quadrilatero = Console.ReadLine();
                string[] quadrilatero = str_quadrilatero.Split(' ');
                maximo_x = int.Parse(quadrilatero[0]);
                maximo_y = int.Parse(quadrilatero[1]);

                Console.WriteLine("\r\nInforme a Posição Inicial do Tupiniquim I, por exemplo 1 2 N");
                Console.WriteLine("[N] Norte, [S] Sul, [L] Leste, [O] Oeste");
                Console.Write("Posição Inicial: ");
                str_posicao_inicial = Console.ReadLine().ToUpper();
                string[] posicao_inicial = str_posicao_inicial.Split(' ');
                posicao_x_robo = int.Parse(posicao_inicial[0]);
                posicao_y_robo = int.Parse(posicao_inicial[1]);
                bussola = Convert.ToChar(posicao_inicial[2]);

                Console.WriteLine("\r\nInforme os comandos a serem seguidos pelo Tupiniquim I, por exemplo EMEMEMEMM");
                Console.WriteLine("[M] Mover, [E] Esquerda, [D] Direita");
                Console.Write("Movimentações: ");
                str_movimento = Console.ReadLine().ToUpper();
                char[] ordens = str_movimento.ToCharArray();
            //processamento
                for (int i = 0; i < ordens.Length; i++)
                {
                    if (ordens[i] == 'E')//ir pra esquerda
                    {
                        switch (bussola)
                        {
                            case 'N':
                                bussola = 'O';
                                break;
                            case 'S':
                                bussola = 'L';
                                break;
                            case 'L':
                                bussola = 'N';
                                break;
                            case 'O':
                                bussola = 'S';
                                break;
                        }
                    }
                    if (ordens[i] == 'D')//ir pra direita
                    {
                        switch (bussola)
                        {
                            case 'N':
                                bussola = 'L';
                                break;
                            case 'S':
                                bussola = 'O';
                                break;
                            case 'L':
                                bussola = 'S';
                                break;
                            case 'O':
                                bussola = 'N';
                                break;
                        }
                    }
                    if (ordens[i] == 'M')//mover
                    {
                        if (bussola == 'N' && maximo_y >= (posicao_y_robo + 1))
                        {
                            posicao_y_robo++;
                        }
                        else if (bussola == 'S' && minimo_y <= (posicao_y_robo - 1))
                        {
                            posicao_y_robo--;
                        }
                        else if (bussola == 'L' && maximo_x >= (posicao_x_robo + 1))
                        {
                            posicao_x_robo++;
                        }
                        else if (bussola == 'O' && minimo_x <= (posicao_x_robo - 1))
                        {
                            posicao_x_robo--;
                        }
                    }
                }
            //saida
                Console.WriteLine("\r\nCoordenadas Finais do Tupiniquim I: "+posicao_x_robo + " " + posicao_y_robo + " " + bussola);

                Console.Write("\r\n[S] Adicionar mais um robô para o mapeamento [N] Sair: ");
                char proximo_robo = Convert.ToChar(Console.ReadLine());
                continuar = proximo_robo == 'S';
            } while (continuar == true);
            Console.ReadKey();
        }
    }
}