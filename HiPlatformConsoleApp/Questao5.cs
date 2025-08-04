using System.Text;

namespace HiPlatform
{
    public class Questao5 : Respostas
    {
        public override void MostrarRespostas()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Questão 5");
            sb.AppendLine("A análise do código mostra que há risco de condição de corrida, pois as operações de leitura (BuscaConta), verificação (PodeDebitar) e escrita (Atualiza) não estão protegidas por nenhum controle de concorrência. Uma solução adequada é utilizar transações com isolamento serializável e controle de concorrência otimista via campo de versão (RowVersion ou Versao), garantindo as propriedades ACID. Com o bloqueio otimista, o EF Core lançará uma DbUpdateConcurrencyException caso outra transação tenha modificado a entidade entre o carregamento e o SaveChanges. Essa abordagem evita bloqueios prolongados, sendo preferível em cenários com alta concorrência. Portanto, os métodos Creditar e Debitar devem ser executados dentro de uma transação e tratar explicitamente a DbUpdateConcurrencyException, garantindo que as operações sejam atômicas, isoladas e consistentes, mesmo sob concorrência.");

            Console.WriteLine(sb.ToString());
        }
    }
}