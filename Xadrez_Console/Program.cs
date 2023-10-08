using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.xadrez;

Tabuleiro tab = new Tabuleiro(8, 8);

tab.SetPecaTab(new Torre(tab, Cor.Preta), new Posicao(0, 0));
tab.SetPecaTab(new Torre(tab, Cor.Preta), new Posicao(1, 3));
tab.SetPecaTab(new Rei(tab, Cor.Preta), new Posicao(2, 4));

Tela.ImprimirTabuleiro(tab);

Console.ReadLine();