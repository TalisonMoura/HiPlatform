namespace HiPlatform
{
    public static class Questao2
    {
        private static void CustoItemCalculado()
        {
            var itens = new List<Item>
            {
                new("Produto A", 30, 10.0, false, 0.1, EVolumeOcupado.Pequeno),
                new("Produto B", 20, 15.0, true, 0.2, EVolumeOcupado.Medio),
                new("Produto C", 10, 20.0, false, 0.3, EVolumeOcupado.Grande),
                new("Produto D", 25, 12.0, true, 0.15, EVolumeOcupado.Pequeno),
                new("Produto E", 15, 18.0, false, 0.25, EVolumeOcupado.Medio),
                new("Produto F", 5, 22.0, true, 0.35, EVolumeOcupado.Grande),
                new("Produto G", 12, 14.0, false, 0.05, EVolumeOcupado.Pequeno),
                new("Produto H", 10, 14.0, false, 0.05, EVolumeOcupado.Pequeno),
            };

            var estoque = new Estoque();
            estoque.AdicionarItens(itens);
            estoque.MostrarCustoAjustado();
        }

        public static void MostrarCustoItemCalculado()
        {
            Console.WriteLine("Questão 2");
            CustoItemCalculado();
            Console.WriteLine();
        }
    }

    public class Estoque
    {
        private List<Item> Itens { get; }

        public Estoque()
        {
            Itens = [];
        }

        public void AdicionarItem(Item item)
        {
            Itens.Add(item);
        }

        public void AdicionarItens(List<Item> itens)
        {
            Itens.AddRange(itens);
        }

        public void MostrarCustoAjustado()
        {
            foreach (var item in Itens)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public class Item
    {
        public string Nome { get; }
        public int Validade { get; }
        public double RiscoExpiracao { get; }
        public double Custo { get; private set; }
        public bool NecessitaRefrigeracao { get; }
        public EVolumeOcupado VolumeOcupado { get; }

        public Item(string nome, int validade, double custo, bool necessitaRefrigeracao, double riscoExpiracao, EVolumeOcupado volumeOcupado)
        {
            Nome = nome;
            Custo = custo;
            Validade = validade;
            VolumeOcupado = volumeOcupado;
            RiscoExpiracao = riscoExpiracao;
            NecessitaRefrigeracao = necessitaRefrigeracao;

            CalcularCustoAjustado();
            HiperMercado.Hi.FormulaMagica(Custo, validade);
        }

        public void CalcularCustoAjustado()
        {
            Custo *= VolumeOcupado switch
            {
                EVolumeOcupado.Medio => 0.05,
                EVolumeOcupado.Grande => 0.1,
                _ => 0.02
            };

            if (NecessitaRefrigeracao)
            {
                Custo += 2.0;
            }

            Custo += RiscoExpiracao * 5;
        }

        public override string ToString()
        {
            return $"Item: {Nome}, Custo: {Custo}";
        }
    }

    public enum EVolumeOcupado
    {
        Pequeno = 1,
        Medio = 2,
        Grande = 3
    }

    public static class HiperMercado
    {
        public static class Hi
        {
            public static double FormulaMagica(double custo, int validade)
            {
                return custo * 1.2 + (validade / 2);
            }
        }
    }
}