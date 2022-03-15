using System;
using System.Collections;

namespace CS_Basics
{
    internal class Program
    {
        public abstract class Wagon : ICloneable
        {
            public virtual void OpenDoors()
            {
                Console.Write("Opening the doors for ");
            }

            public abstract int GetCapacity();

            public virtual void OpenDoors(int doorNumber)
            {
                Console.Write("Openeing the doors " + doorNumber + " for ");
            }

            public void CloseDoors()
            {
                Console.WriteLine("Closing the doors");
            }

            public override string ToString()
            {
                return "Wagon's capacity is ";
            }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public class PassengersWagon : Wagon
        {
            private int passengersCapacity;

            public PassengersWagon(int capacity)
            {
                passengersCapacity = capacity;
            }

            public override int GetCapacity()
            {
                return passengersCapacity;
            }

            public override void OpenDoors()
            {
                base.OpenDoors();
                Console.WriteLine("passengers");
            }

            public override void OpenDoors(int doorNumber)
            {
                base.OpenDoors(doorNumber);
                Console.WriteLine("passengers");
            }

            public override string ToString()
            {
                return GetCapacity().ToString() + " persons";
            }
        }

        public class FreightWagon : Wagon
        {
            private int freightCapacity;

            public FreightWagon(int capacity)
            {
                freightCapacity = capacity;
            }

            public override int GetCapacity()
            {
                return freightCapacity;
            }

            public override void OpenDoors()
            {
                base.OpenDoors();
                Console.WriteLine("freight");
            }

            public override void OpenDoors(int doorNumber)
            {
                base.OpenDoors(doorNumber);
                Console.WriteLine("freight");
            }

            public override string ToString()
            {
                return GetCapacity().ToString() + " packages";
            }
        }

        public class Train : IEnumerable<Wagon>
        {
            private Wagon[] wagons;
            public Wagon[] Wagons { get { return wagons; } set { wagons = value; } }

            public IEnumerator<Wagon> GetEnumerator()
            {
                return new TrainEnum(wagons);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();   
            }
        }

        public class TrainEnum : IEnumerator<Wagon>
        {
            public Wagon[] wagons;
            int position = -1;

            public TrainEnum(Wagon[] wagons)
            {
                this.wagons = wagons;
            }

            public Wagon Current
            {
                get
                {
                    try
                    {
                        return wagons[position];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose() {}

            public bool MoveNext()
            {
                position++;
                return position < wagons.Length;
            }

            public void Reset()
            {
                position = -1;
            }
        }

        static void Main(string[] args)
        {
            Wagon[] wagons = new Wagon[3]
            {
                new PassengersWagon(200),
                new PassengersWagon(300),
                new FreightWagon(100)
            };

            Train wagonsList = new Train { Wagons = wagons };

            foreach(var wagon in wagons)
                Console.WriteLine(wagon.ToString());
            Console.WriteLine();

            var trainEnumerator = new TrainEnum(wagons);
            while(trainEnumerator.MoveNext())
                Console.WriteLine(trainEnumerator.Current.ToString());
            Console.WriteLine();

            Console.WriteLine(wagons[0].ToString());
            Wagon wagon1 = (Wagon) wagons[0].Clone();
            Console.WriteLine(wagon1.ToString());

            
        }
    }
}