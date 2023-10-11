using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.xadrez;
try {
    PartidaXadrez partida = new PartidaXadrez();

    while (!partida.Terminada) {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.tab);

        Console.WriteLine();

        Console.Write("Origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

        bool[,] posicoesPossiveis = partida.tab.GetPecaTab(origem).MovimentosPossiveis();

        Console.Clear();
        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);


        Console.Write("Destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

        partida.ExecutaMovimento(origem, destino);
    }


    Console.ReadLine();
}
catch (TabuleiroException e) {
    Console.WriteLine("Exception: " + e.Message);
}