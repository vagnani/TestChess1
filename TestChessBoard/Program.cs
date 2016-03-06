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
            Console.WriteLine("Direzioni possibili:(nne)(ene)(ese)(sse) o (nno)(ono)(oso)(sso)");
            Console.WriteLine("Usare seguente formalismo: (...) <== parentesi obbligatorie");
            var directions = Adding.CreateDirections(Console.ReadLine());

            //Console.WriteLine("Inserire coordinate premi");
            //Console.WriteLine("Usare seguente formalismo: (x,y,value) <== parentesi obbligatorie");
            //var awards = Adding.CreateAwards(Console.ReadLine());

            MyChessBoard chess = new MyChessBoard
                (
                start, arrive, limit, locked, directions
                );

            do
            {
                Console.WriteLine("passante per qualche nodo?");
                string str = Console.ReadLine().Trim();

                if (str != "no")
                {
                    List<List<Coordinate>> nodeFiltered = new List<List<Coordinate>>();
                    Console.WriteLine("Inserire coordinate da passare");
                    Console.WriteLine("Usare seguente formalismo: (x,y) <== parentesi obbligatorie");
                    var compulsaryNode = Adding.CreateLockedCells(Console.ReadLine());

                    foreach (var list in chess)
                    {
                        bool listAdded = false;
                        foreach (var element in list)
                        {
                            foreach (var MustNode in compulsaryNode)
                            {
                                if (element.Equals(MustNode))
                                {
                                    nodeFiltered.Add(list); listAdded = true; ; break;
                                }
                            }

                            if(listAdded)
                            {
                                break;
                            }
                        }
                    }

                    foreach (var list in nodeFiltered)
                    {
                        string toprint = "";
                        foreach (var node in list)
                        {
                            toprint += node.ToString();
                        }
                        Console.WriteLine(toprint);
                    }
                }

                else
                {
                    foreach (var list in chess)
                    {
                        string toprint = "";
                        foreach (var node in list)
                        {
                            toprint += node.ToString();
                        }
                        Console.WriteLine(toprint);
                    }
                }

                Console.WriteLine("Vuoi continuare?");
                string toContinue = Console.ReadLine();
                if (toContinue == "no")
                {
                    break;
                }
            } while (true);

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