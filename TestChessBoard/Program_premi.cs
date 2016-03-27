using System;
using MyLibrary.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChessBoard
{
    class Program
    {
        static void Main()
        {
            string locked = "";
            string directions = "";
            string awards = "";

            Console.WriteLine("Risoluzione problema scacchi");
            Console.WriteLine();
            Console.WriteLine("Inserire coordinate limiti campo");
            Console.Write("Inserire x e y separando con la virgola -->");
            var limit = Adding.CreateCoordinateByString("(" + Console.ReadLine().Trim() + ")");
            Console.WriteLine();

            Console.WriteLine("Inserire coordinate della posizione di inizio");
            Console.Write("Inserire x e y separando con la virgola -->");
            var start = Adding.CreateCoordinateByString("(" + Console.ReadLine().Trim() + ")");
            Console.WriteLine();

            Console.WriteLine("Inserire coordinate della posizione di arrivo");
            Console.Write("Inserire x e y separando con la virgola -->");
            var arrive = Adding.CreateCoordinateByString("(" + Console.ReadLine().Trim() + ")");
            Console.WriteLine();

            Console.WriteLine("Inserire coordinate celle bloccate");
            do
            {
                Console.Write("Inserire x e y separando con la virgola (! =stop) -->");
                string temp = Console.ReadLine().Trim();
                if (temp[0] != '!')
                    locked += "(" + temp + ")";
                else
                    break;
            } while (true);

            var listLocked = Adding.CreateLockedCells(locked);

            Console.WriteLine();
            Console.WriteLine("Inserire direzioni consentite: seguendo la rosa dei venti");
            Console.WriteLine("Direzioni possibili:(nne)(ene)(ese)(sse)(nno)(ono)(oso)(sso)");
            do
            {
                Console.Write("Inserire direzione (! =stop) -->");
                string temp = Console.ReadLine().Trim();
                if (temp[0] != '!')
                    directions += "(" + temp + ")";
                else
                    break;
            } while (true);

            var listDirections = Adding.CreateDirections(directions);

            Console.WriteLine();
            Console.WriteLine("Inserire coordinate dei premi e penalità, x e y e valore premio separando con la virgola ");            
            do
            {
                Console.Write("Inserire premio (! =stop) -->");
                string temp = Console.ReadLine().Trim();
                if (temp[0] != '!')
                    awards += "(" + temp + ")";
                else
                    break;
            } while (true);

            var listAward = Adding.CreateAwards(awards);

            Console.WriteLine();
            Console.WriteLine("Possibili percorsi:");
            Console.WriteLine();
            

            MyChessBoard chess = new MyChessBoard
                (
                start, arrive, limit, listLocked, listDirections
                );


            Console.WriteLine();
            foreach (var list in chess)
            {
                List<int> containedAwards = new List<int>();
                string toprint = "";
                int sommaPremi = 0;
                foreach (var node in list)
                {
                    toprint += node.ToString();
                    foreach(var premio in listAward)
                    {
                        if(node.Equals(premio.Key))
                        {
                            containedAwards.Add(premio.Value);
                        }
                    }
                }
                Console.Write($"{ toprint} =contiene i premi: ");
                if (containedAwards.Count > 0)
                {
                    foreach (var valore in containedAwards)
                    {
                        Console.Write($"{valore}, ");
                        sommaPremi += valore;
                    }
                    Console.WriteLine($" ={sommaPremi}");
                }
                else
                { Console.WriteLine("nessuno"); }
            }

            Console.ReadLine();
        }
    }
}
