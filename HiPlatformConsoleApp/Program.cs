public class Program
{
    private static void Main(string[] args)
    {
        Questao1();
        Questao2();
        Questao3();
        Questao4();
        Questao5();
    }

    private static void Questao1()
    {
        new HiPlatform.Questao1().MostrarRespostas();
    }

    private static void Questao2()
    {
        HiPlatform.Questao2.MostrarCustoItemCalculado();
    }

    private static void Questao3()
    {
        HiPlatform.Questao3.MostrarRuasMaisPopulosas();
    }

    private static void Questao4()
    {
        new HiPlatform.Questao4().MostrarRespostas();
    }

    private static void Questao5()
    {
        new HiPlatform.Questao5().MostrarRespostas();
    }
}