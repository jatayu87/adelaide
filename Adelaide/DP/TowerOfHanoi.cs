using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adelaide.DP
{
    class Disk { 
        public int Value { get; set; }
        public int MoveCount { get; set; }

        public Disk(int diskValue)
        {
            this.Value = diskValue;
        }
    }

    class Tower {
        public int Id { get; set; }
        public int DiscsMovedFrom { get; set; }
        public int DiscsMovedTo { get; set; }
        Stack<Disk> Disks;

        public Tower(int number)
        {
            this.Id = number;
            Disks = new Stack<Disk>();
        }

        public void AddDisk(Disk disk, Boolean isInitialLoad)
        {
            if (Disks.Count != 0 && Disks.Peek().Value <= disk.Value)
            {
                throw new Exception($"Disks.Count()={Disks.Count}" +
                    $"Could not add new disk with value:{disk.Value} on top of Stack with top Disk: {Disks.Peek().Value}");
            }    
                
           Disks.Push(disk);

            if (!isInitialLoad)
            {
                disk.MoveCount = +1;
                Console.WriteLine($"\tDisk with value:{disk.Value} added to Tower:{Id}");
            }
        }

        public Disk RemoveDisk()
        {
            return Disks.Pop();
        }

        public void PrintTower()
        { 
            
        }

    }

    class TowerOfHanoi
    {
        int towerCount = 3;
        Tower[] towers = new Tower[3];

        public void SetUpTowers() 
        {
            for (int i = 0; i < towerCount; i++)
            {
                towers[i] = new Tower(i);
            }
        }
        TowerOfHanoi()
        {
            SetUpTowers();
        }

        public void LoadDisksOnTower(int towerNumber, int diskCount)
        {
            if ((towerNumber > towerCount - 1) || (towerNumber <0))
            {
                throw new Exception($"InValid tower number provided:{towerNumber}" +
                    $"Expected number between 0 & {towerCount-1}");
            }

            for (int i = diskCount; i >0; i--)
            {
                towers[towerNumber].AddDisk(new Disk(i), false);
            }
        }

        private void MoveDisks(int discCount, Tower source, Tower destination, Tower via)
        {
            if (discCount > 0)
            {
                MoveDisks(discCount - 1, source, via, destination);
                var disk = source.RemoveDisk();
                destination.AddDisk(disk, true);
                Console.WriteLine($"Added Disk:{disk.Value} From: {source.Id} To:{destination.Id}");
                source.DiscsMovedFrom = source.DiscsMovedFrom  + 1;
                destination.DiscsMovedTo = destination.DiscsMovedTo + 1;
                MoveDisks(discCount - 1, via, destination, source);
            }
        }

        
        public static void Main(string[] args)
        {
            TowerOfHanoi t = new TowerOfHanoi();
            int sourceTowerNumber = 0;
            int destinationTowerNumber = 1;
            int bufferTowerNumber = 2;
            int discCount = 6;

            t.LoadDisksOnTower(sourceTowerNumber, discCount);
            
            Console.WriteLine($"Source Tower loaded...");
            Console.WriteLine($"Goal: Move disks from Tower: {sourceTowerNumber} to Tower:{destinationTowerNumber} ");
            Console.WriteLine(); Console.WriteLine();

            t.MoveDisks(discCount, t.towers[sourceTowerNumber], t.towers[destinationTowerNumber], t.towers[bufferTowerNumber]);

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Printing Stats on Towers:");
            t.PrintAllTowerMoveStats(sourceTowerNumber, destinationTowerNumber, bufferTowerNumber);

            Console.ReadKey();
        }

        public void PrintAllTowerMoveStats(int source, int destination, int buffer)
        {
            int totalMoves = 0;
            for (int i = 0; i < towerCount; i++)
            {
                Console.WriteLine($"Printing status for Tower:{i}");
                if (i == source) 
                {
                    Console.WriteLine($"\t It's a source Tower");
                }
                else if (i == destination)
                {
                    Console.WriteLine($"\t It's a destination Tower");
                }
                else 
                {
                    Console.WriteLine($"\t It's a buffer Tower");
                }

                Console.WriteLine($"\t Disk moved from count:{towers[i].DiscsMovedFrom}");
                Console.WriteLine($"\t Disk moved to count:{towers[i].DiscsMovedTo}");

                totalMoves = totalMoves + towers[i].DiscsMovedFrom;
            }

            Console.WriteLine($"Total Moves across towers:{totalMoves}");
        }

        //public void PrintAllDiskMoveStats(Tower destination)
        //{
        //    for (int i = 0; i < towerCount; i++)
        //    {
        //        Console.WriteLine($"Printing status for Tower:{i}");
        //        if (i == source)
        //        {
        //            Console.WriteLine($"\t It's a source Tower");
        //        }
        //        else if (i == destination)
        //        {
        //            Console.WriteLine($"\t It's a destination Tower");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"\t It's a buffer Tower");
        //        }

        //        Console.WriteLine($"\t Disk moved from count:{towers[i].DiscsMovedFrom}");
        //        Console.WriteLine($"\t Disk moved to count:{towers[i].DiscsMovedTo}");
        //    }
        //}
    }
}
