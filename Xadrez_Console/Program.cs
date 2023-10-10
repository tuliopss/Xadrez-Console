using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.xadrez;
try {
    Tabuleiro tab = new Tabuleiro(8, 8);


    tab.SetPecaTab(new Torre(tab, Cor.Preta), new Posicao(0, 0));
    tab.SetPecaTab(new Torre(tab, Cor.Preta), new Posicao(1, 3));
    tab.SetPecaTab(new Rei(tab, Cor.Preta), new Posicao(0, 1));
    tab.SetPecaTab(new Rei(tab, Cor.Branca), new Posicao(7, 1));

    Tela.ImprimirTabuleiro(tab);

    Console.WriteLine(new PosicaoXadrez('a', 1).ToPosicao());

    Console.ReadLine();
}
catch (TabuleiroException e) {
    Console.WriteLine("Exception: " + e.Message);
}