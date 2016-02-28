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
            Console.WriteLine("Risoluzione problema scacchi");
            Console.WriteLine("Inserire coordinate inizio");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var start = Adding.CreateCoordinateByString(Console.ReadLine());
            
            Console.WriteLine("Inserire coordinate arrivo");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var arrive = Adding.CreateCoordinateByString(Console.ReadLine());
            
            Console.WriteLine("Inserire coordinate limiti campo");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var limit = Adding.CreateCoordinateByString(Console.ReadLine());

            Console.WriteLine("Inserire coordinate celle bloccate");
            Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
            var locked = Adding.CreateLockedCells(Console.ReadLine());

            Console.WriteLine("Inserire direzioni consentite: seguendo la rosa dei venti");
            Console.WriteLine("Usare seguente formalismo: (...) <== parentesi obbligatorie");
            var directions = Adding.CreateDirections(Console.ReadLine());

            Console.WriteLine("Inserire coordinate premi");
            Console.WriteLine("Usare seguente formalismo: (x,y,value) <== parentesi obbligatorie");
            var awards = Adding.CreateAwards(Console.ReadLine());

            MyChessBoard chess = new MyChessBoard
                (
                start,arrive,limit,locked,awards,directions
                );      
            
            foreach(var list in chess)
            {
                //my implementation
                string toprint = "";
                foreach (var node in list)
                {
                    toprint += node.ToString();
                }
                Console.WriteLine(toprint);
            }
        }
    }
}
