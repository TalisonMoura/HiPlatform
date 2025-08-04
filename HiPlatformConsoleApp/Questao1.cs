using System.Text;

namespace HiPlatform
{
    public class Questao1 : Respostas
    {
        public override void MostrarRespostas()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Questão 1");
            sb.AppendLine("a):");
            sb.AppendLine("Não existe uma definição correta. Sempre vai depender do objetivo, por exemplo: se eu quero utilizar um tipo de estrutura que seja flexivel para qualquer classe e que essas classes não tem relação direta entre si, pra esse caso a interface é a melhor opção pois ela te permite definir contratos que possua o mesmo comportamento em diferentes classes. Já no caso da classe abstrata por exemplo: eu quero definir uma estrutura lógica onde existe classes que possuem um comportamento hierarquico em comum, em um cenário onde eu tenho cadastro de pessoas, e isso engloba tanto funcionarios quanto clientes. Dentro desse contexto se faz por vencido utilizar classe abstrata, pois funcionario e cliente é uma pessoa, ou seja, todos os comportamentos que pessoa tem funcionário e cliente também, por exemplo: nome, cpf, rg, sexo, data nascimento. Então cliente e funcionário por boa pratica deve herdar esses comportamentos em comum.");
            sb.AppendLine();
            sb.AppendLine("b):");
            sb.AppendLine("Usar heranca ou delegacao a outros objetos? Por que? Cite exemplos. Delegação a outros objetos é quase sempre a melhor forma de se manipular os objetos, pois te permite fazer composição, reutilizar e reduzir o acoplamento pois dessa forma evitamos que outras classes herdem comportamentos que não necessita ou não sabe manipular. Em modelagem de classes utilizamos herança quando ela tem relação do tipo (É um) (exemplo anterior onde funcionário é uma pessoa).");

            Console.WriteLine(sb.ToString());
        }
    }
}