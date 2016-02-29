using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Collections
{
    public class MyChessBoard : IEnumerable<List<Coordinate>>
    {
        internal Coordinate _start;
        internal Coordinate _arrive;

        internal Coordinate _limit;
        internal List<Coordinate> _locked;
        //da implementare in main Dictionary<string, Coordinate> _award; <==stava anche nel costruttore
        internal List<string> _directions;

        private MyChessBoard() { }
        public MyChessBoard(Coordinate start, Coordinate arrive, Coordinate limit,
         List<Coordinate> locked, List<string> directions) : this()
        {
            _start = start; _arrive = arrive; _limit = limit; _locked = locked; _directions = directions;
        }

        public IEnumerator<List<Coordinate>> GetEnumerator()
        {
            return new MyEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerator : IEnumerator<List<Coordinate>>
    {
        private int index = -1;
        private List<List<Coordinate>> _listMax = new List<List<Coordinate>>();
        private List<List<Coordinate>> final = new List<List<Coordinate>>();
        private MyChessBoard chess;

        public MyEnumerator(MyChessBoard chess)
        {
            this.chess = chess;
            _listMax.Add(new List<Coordinate>() { chess._start });
            SetAll(chess._start, new List<Coordinate>() { chess._start }, 0);
            CheckTheRight();
        }

        private void CheckTheRight()
        {
            foreach(var element in _listMax)
            {
                if (element[element.Count - 1].Equals(chess._arrive))
                    final.Add(element);
            }
        }

        public List<Coordinate> Current
        {
            get
            {
                if (index < final.Count)
                { return final[index]; }
                throw new ArgumentOutOfRangeException();
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            if (index < final.Count-1)
            {
                index++;
                return true;
            }
            return false;
        }

        private void SetAll(Coordinate _first, List<Coordinate> locked, int index)
        {
            var copyListMax = CopyFrom(_listMax[index]);
            int copyIndex = index;

            foreach (var nodePossible in chess._directions)
            {
                List<Coordinate> copyLocked = CopyFrom(locked);
                var possibleCoordinate = MoveByDirection(nodePossible, _first);

                if (possibleCoordinate.x <= chess._limit.x && possibleCoordinate.y <= chess._limit.y &&
                    !chess._locked.Contains(possibleCoordinate, possibleCoordinate) &&
                    !locked.Contains(possibleCoordinate, possibleCoordinate) &&
                    possibleCoordinate.x > 0 && possibleCoordinate.y > 0)
                {
                    if (copyIndex != index)
                    {
                        _listMax.Add(new List<Coordinate>(copyListMax));
                        copyIndex = _listMax.Count - 1;
                    }

                    _listMax[copyIndex].Add(possibleCoordinate);
                    copyLocked.Add(possibleCoordinate);
                    SetAll(possibleCoordinate, copyLocked, copyIndex);
                    index++;
                }
            }
        }
        private Coordinate MoveByDirection(string direction, Coordinate coor)
        {
            #region est 
            if (direction == "nne")
            {
                return coor + new int[] { 1, +2 };
            }

            if (direction == "ene")
            {
                return coor + new int[] { 2, +1 };
            }

            if (direction == "ese")
            {
                return coor + new int[] { 2, -1 };
            }

            if (direction == "sse")
            {
                return coor + new int[] { 1, -2 };
            }
            #endregion

            #region ovest
            if (direction == "nno")
            {
                return coor + new int[] { -1, +2 };
            }

            if (direction == "ono")
            {
                return coor + new int[] { -2, +1 };
            }

            if (direction == "oso")
            {
                return coor + new int[] { -2, -1 };
            }

            if (direction == "sso")
            {
                return coor + new int[] { -1, -2 };
            }
            #endregion

            return new Coordinate(0, 0);
        }
        private T CopyFrom<T>(T list) where T : class, IEnumerable, ICollection, IList, new()
        {
            T result = new T();
            foreach (var n in list)
            {
                result.Add(n);
            }
            return result;
        }

        public void Reset()
        {
            index = -1;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MyEnumerator() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

    public struct Coordinate : IEqualityComparer<Coordinate>
    {
        internal int x;
        internal int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            var obj1 = (Coordinate)obj;
            return this.x == obj1.x && this.y == obj1.y;
        }
        public override string ToString()
        {
            return $"[{x},{y}]";
        }

        #region IEqualityCmparer
        public bool Equals(Coordinate x, Coordinate y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Coordinate obj)
        {
            return (obj.x + obj.y).GetHashCode();
        }
        #endregion

        #region Operator
        public static bool operator ==(Coordinate obj1, Coordinate obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Coordinate obj1, Coordinate obj2)
        {
            if (obj1.Equals(obj2))
            {
                return false;
            }

            return true;
        }

        public static Coordinate operator +(Coordinate obj1, int[] xy)
        {
            return new Coordinate(obj1.x + xy[0], obj1.y + xy[1]);
        }

        public static bool operator >(Coordinate obj1, Coordinate obj2)
        {
            if (obj1.x > obj2.x && obj1.y > obj2.y)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Coordinate obj1, Coordinate obj2)
        {
            if (obj1.x < obj2.x && obj1.y < obj2.y)
            {
                return true;
            }
            return false;
        }
        #endregion
    }

    public static class Adding
    {
        public static Coordinate CreateCoordinateByString(string str)
        {
            char excluded1 = '(';
            char excluded2 = ')';
            char excluded3 = ',';
            List<string> temp = new List<string>();

            str.Trim();

            //if (str[index] == excluded1)                
            string name = "";
            for (int index = 0; index <= str.Count(); index++)
            {
                if (str[index] != excluded1 && str[index] != excluded2 && str[index] != excluded3) //exception
                {
                    name += str[index];
                }

                if (str[index] == excluded3)
                {
                    temp.Add(name);
                    name = "";
                }

                if (str[index] == excluded2)
                {
                    temp.Add(name);
                    break;
                }
            }

            return new Coordinate(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]));
        }

        public static List<Coordinate> CreateLockedCells(string str)
        {
            char excluded1 = '(';
            char excluded2 = ')';
            char excluded3 = ',';
            List<List<string>> lockedString = new List<List<string>>();
            List<Coordinate> locked = new List<Coordinate>();

            str.Trim();

            for (int index = 0; index < str.Count(); index++)
            {
                List<string> temp = new List<string>();
                //if (str[index] == excluded1)                
                string name = "";
                for (; index < str.Count(); index++)
                {
                    if (str[index] != excluded1 && str[index] != excluded2 && str[index] != excluded3) //exception
                    {
                        name += str[index];
                    }

                    if (str[index] == excluded3)
                    {
                        temp.Add(name);
                        name = "";
                    }

                    if (str[index] == excluded2)
                    {
                        temp.Add(name);
                        break;
                    }
                    lockedString.Add(temp);
                }
            }

            foreach (var element in lockedString)
            {
                var x = Convert.ToInt32(element[0]);
                var y = Convert.ToInt32(element[1]);
                locked.Add(new Coordinate(x, y));
            }

            return locked;
        }

        public static List<string> CreateDirections(string str)
        {
            char excluded1 = '(';
            char excluded2 = ')';
            List<string> directions = new List<string>();

            str.Trim();

            for (int index = 0; index < str.Count(); index++)
            {
                //if (str[index] == excluded1)                
                string name = "";
                for (; index < str.Count(); index++)
                {
                    if (str[index] != excluded1 && str[index] != excluded2) //exception
                    {
                        name += str[index];
                    }

                    if (str[index] == excluded2)
                    {
                        directions.Add(name);
                        break;
                    }
                }
            }
            return directions;
        }

        public static Dictionary<string, Coordinate> CreateAwards(string str)
        {
            char excluded1 = '(';
            char excluded2 = ')';
            char excluded3 = ',';
            List<List<string>> all = new List<List<string>>();
            Dictionary<string, Coordinate> finalAll = new Dictionary<string, Coordinate>();

            str.Trim();


            for (int index = 0; index < str.Count(); index++)
            {
                List<string> temp = new List<string>();

                //if (str[index] == excluded1)                
                string name = "";
                for (; index <= str.Count(); index++)
                {
                    if (str[index] != excluded1 && str[index] != excluded2 && str[index] != excluded3) //exception
                    {
                        name += str[index];
                    }

                    if (str[index] == excluded3)
                    {
                        temp.Add(name);
                        name = "";
                    }

                    if (str[index] == excluded2)
                    {
                        temp.Add(name);
                        break;
                    }
                }

                all.Add(temp);
            }

            foreach (var item in all)
            {
                int x = Convert.ToInt32(item[1]);
                int y = Convert.ToInt32(item[2]);
                finalAll.Add(item[0], new Coordinate(x, y));
            }
            return finalAll;
        }
    }
}