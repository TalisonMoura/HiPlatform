namespace HiPlatform
{
    public static class Questao3
    {
        private static List<Rua> ObterRuasMaisPopulosas(List<Casa> casas)
        {
            var mapa = new Dictionary<Rua, int>();

            foreach (var casa in casas)
            {
                if (mapa.ContainsKey(casa.Rua))
                {
                    mapa[casa.Rua] += casa.TotalEleitores;
                }
                else
                    mapa.Add(casa.Rua, casa.TotalEleitores);
            }

            return [.. mapa.OrderByDescending(par => par.Value).Select(par => par.Key)];
        }

        public static void MostrarRuasMaisPopulosas()
        {
            var casas = new List<Casa>()
            {
                new(new Rua("12345-678", "Rua A"), 1, 8),
                new(new Rua("23456-789", "Rua B"), 2, 6),
                new(new Rua("34567-890", "Rua C"), 3, 3),
                new(new Rua("52348-688", "Rua D"), 4, 5),
                new(new Rua("24876-209", "Rua E"), 5, 9),
                new(new Rua("34407-150", "Rua F"), 6, 4)
            };

            Console.WriteLine("Questão 3");
            foreach (var rua in ObterRuasMaisPopulosas(casas))
            {
                Console.WriteLine(rua.ToString());
            }
            Console.WriteLine();
        }
    }

    public class Casa
    {
        public Rua Rua { get; private set; }
        public int Numero { get; private set; }
        public int TotalEleitores { get; private set; }

        public Casa(Rua rua, int numero, int totalEleitores)
        {
            Rua = rua;
            Numero = numero;
            TotalEleitores = totalEleitores;
        }
    }

    public class Rua
    {
        public string Cep { get; private set; }
        public string Nome { get; private set; }

        public Rua(string cep, string nome)
        {
            Cep = cep;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Rua: {Nome}, Cep: {Cep}";
        }
    }
}