//using System;
//using MyLibrary.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestChessBoard
//{
//    class Program
//    {
//        static void Main()
//        {
//            string locked = "";
//            string directions = "";

//            Console.WriteLine("Risoluzione problema scacchi");
//            Console.WriteLine("Inserire coordinate limiti campo");
//            Console.Write("Inserire x e y separando con la virgola -->");
//            var limit = Adding.CreateCoordinateByString("("+Console.ReadLine().Trim()+")");
//            Console.WriteLine();

//            Console.WriteLine("Inserire coordinate della posizione di inizio");
//            Console.Write("Inserire x e y separando con la virgola -->");
//            var start = Adding.CreateCoordinateByString("(" + Console.ReadLine().Trim() + ")");
//            Console.WriteLine();

//            Console.WriteLine("Inserire coordinate della posizione di arrivo");
//            Console.Write("Inserire x e y separando con la virgola -->");
//            var arrive = Adding.CreateCoordinateByString("(" + Console.ReadLine().Trim() + ")");
//            Console.WriteLine();

//            Console.WriteLine("Inserire coordinate celle bloccate");
//            do
//            {
//                Console.Write("Inserire x e y separando con la virgola (! =stop) -->");
//                string temp = Console.ReadLine().Trim();
//                if (temp[0] != '!')
//                    locked +="(" + temp + ")";
//                else
//                    break;
//            } while (true);

//            var listLocked = Adding.CreateLockedCells(locked);

//            Console.WriteLine();
//            Console.WriteLine("Inserire direzioni consentite: seguendo la rosa dei venti");
//            Console.WriteLine("Direzioni possibili:(nne)(ene)(ese)(sse)(nno)(ono)(oso)(sso)");
//            do
//            {
//                Console.Write("Inserire direzione (! =stop) -->");
//                string temp = Console.ReadLine().Trim();
//                if (temp[0] != '!')
//                    directions += "(" + temp + ")";
//                else
//                    break;
//            } while (true);

//            var listDirections = Adding.CreateDirections(directions);


//            Console.WriteLine();
//            Console.WriteLine("Possibili percorsi:");
//            Console.WriteLine();


//            //Console.WriteLine("Inserire coordinate premi");
//            //Console.WriteLine("Usare seguente formalismo: (x,y,value) <== parentesi obbligatorie");
//            //var awards = Adding.CreateAwards(Console.ReadLine());

//            MyChessBoard chess = new MyChessBoard
//                (
//                start, arrive, limit, listLocked, listDirections
//                );


//            Console.WriteLine();
//            foreach (var list in chess)
//            {
//                string toprint = "";
//                foreach (var node in list)
//                {
//                    toprint += node.ToString();
//                }
//                Console.WriteLine(toprint);
//            }

//            Console.ReadLine();
//        }
//    }
//}
