using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.xadrez;
try {
    PartidaXadrez partida = new PartidaXadrez();

    Tela.ImprimirTabuleiro(partida.tab);


    Console.ReadLine();
}
catch (TabuleiroException e) {
    Console.WriteLine("Exception: " + e.Message);
}