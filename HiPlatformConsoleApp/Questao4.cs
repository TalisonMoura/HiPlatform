using System.Text;

namespace HiPlatform
{
    public class Questao4 : Respostas
    {
        public override void MostrarRespostas()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Questão 4");
            sb.AppendLine("a):");
            sb.AppendLine("Sim, é uma boa pratica criar exceções personalizadas pois melhora a clareza, a manutenção e controle do fluxo de erro. Os casos dos quais deveriamos adotar essa pratica, é quando precisamos identificar erros especificos, quando precisamos separar as falhas nativas das de programação, ou até mesmo quando queremos comunicar um contexto semantico sobre o determinado erro. Sem contar que evitamos de expor nosso código fonte, pois é definido um mensagem específica e não é retornado a stack-trace.");
            sb.AppendLine();
            sb.AppendLine("b):");
            sb.AppendLine("Acredito em lugares onde eu possa prever que um erro pode ocorrer, como por exemplo, ao acessar um recurso externo (como uma API ou banco de dados), ou ao realizar operações que dependem de entradas do usuário. Capturar exceções nesses casos permite que o programa trate o erro de forma controlada,  evitando falhas inesperadas e proporcionando uma melhor experiência ao usuário. Além disso, é importante capturar exceções para registrar logs ou realizar ações corretivas quando necessário. É um padrão de programação que evita a propagação de erros e quebre o sistema.");
            sb.AppendLine();
            sb.AppendLine("c):");
            sb.AppendLine("Eu lançaria uma exceção em situações onde o programa encontra uma condição que não pode ser resolvida ou que não faz sentido continuar o fluxo de forma segura ou coerente.Por exemplo, ao tentar acessar um recurso que não existe, como um arquivo que não foi encontrado. Nesses casos, lançar uma exceção permite que o programa trate o erro de forma adequada. Outro exemplo, seria ao validar entradas do usuário, como quando um campo obrigatório está vazio ou quando um valor não atende aos critérios esperados. Ou também, quando o contrato de um método não é respeitado, como passar um argumento inválido ou de tipo errado. Lançar uma exceção nesses casos ajuda a identificar problemas rapidamente e a evitar comportamentos inesperados no codebase.");

            Console.WriteLine(sb.ToString());
        }
    }
}