
namespace Xadrez_Console.tabuleiro {
    internal class Tela {
        public static void ImprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.Linhas; i++) {
                for (int j = 0; j < tab.Colunas; j++) {

                    if (tab.GetPecaTab(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        Console.Write(tab.GetPecaTab(i, j) + " ");

                    }
                }
                Console.WriteLine();

            }
        }
    }
}
