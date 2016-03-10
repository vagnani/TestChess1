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
            Console.WriteLine("Inserire coordinate limiti campo");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var limit = Adding.CreateCoordinateByString(Console.ReadLine());
            //var limit = Adding.CreateCoordinateByString("(8,8)");

            Console.WriteLine("Risoluzione problema scacchi");
            Console.WriteLine("Inserire coordinate della posizione di inizio");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var start = Adding.CreateCoordinateByString(Console.ReadLine());
            //var start = Adding.CreateCoordinateByString("(1,1)");

            Console.WriteLine("Inserire coordinate della posizione di arrivo");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var arrive = Adding.CreateCoordinateByString(Console.ReadLine());
            //var arrive = Adding.CreateCoordinateByString("(8,8)");            

            Console.WriteLine("Inserire coordinate celle bloccate");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var locked = Adding.CreateLockedCells(Console.ReadLine());
            //var locked = Adding.CreateLockedCells("(3,1)(4,4)(4,5)(4,8)(5,2)(5,3)(7,4)(7,5)");

            Console.WriteLine("Inserire direzioni consentite: seguendo la rosa dei venti");
            Console.WriteLine("Direzioni possibili:(nne)(ene)(ese)(sse)(nno)(ono)(oso)(sso)");
            Console.WriteLine("Usare seguente formalismo: (...) <== parentesi obbligatorie");
            var directions = Adding.CreateDirections(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Possibili percorsi:");
            Console.WriteLine();
            //var directions = Adding.CreateDirections("(ono)(nno)(nne)(ene)");

            //Console.WriteLine("Inserire coordinate premi");
            //Console.WriteLine("Usare seguente formalismo: (x,y,value) <== parentesi obbligatorie");
            //var awards = Adding.CreateAwards(Console.ReadLine());

            MyChessBoard chess = new MyChessBoard
                (
                start, arrive, limit, locked, directions
                );


            Console.WriteLine();
            foreach (var list in chess)
            {
                string toprint = "";
                foreach (var node in list)
                {
                    toprint += node.ToString();
                }
                Console.WriteLine(toprint);
            }

            Console.ReadLine();
        }
    }
}

//Esempio:
//(1,1)
//(8,8)
//(8,8)
//(1,5)(3,8)(4,7)(6,2)
//(nne)(ene)(ese)(sse) o (nno)(ono)(oso)(sso)
//(4,6,10)(7,4,15)(3,1,5)