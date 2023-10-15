using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.xadrez;
try {
    PartidaXadrez partida = new PartidaXadrez();

    while (!partida.Terminada) {

        try {
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab);

            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoOrigem(origem);

            bool[,] posicoesPossiveis = partida.tab.GetPecaTab(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);


            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDestino(origem, destino);

            partida.RealizaJogada(origem, destino);
        } catch(TabuleiroException e) {
            Console.WriteLine(e.Message + " Aperte Enter para tentar novamente.");
            Console.ReadLine();
        }
    }


    Console.ReadLine();
}
catch (TabuleiroException e) {
    Console.WriteLine("Exception: " + e.Message);
}