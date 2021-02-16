using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAppAL
{
    class LuckyTicket
    {
        private String _numberTicket { get; set; }
        private LinkedList<char> _line { get; set; }
        private int[] _firstHalf { get; set; }
        private int[] _secondHalf {get; set; }
        
        public LuckyTicket(String st)
        {
            _numberTicket = st;
        }

        public void NumberLengthFormat()
        {
            _line = new LinkedList<char>(_numberTicket.ToCharArray());
            if (_line.Count >= 4 & _line.Count <= 8)
            {
                if (_line.Count % 2 == 1)
                {
                    _line.AddFirst('0');
                }
            }
            else
            {
                Console.WriteLine("This number is not to this game");
            }
        }

        public void NumberFormat()
        {
            _firstHalf = new int[_line.Count / 2];
            _secondHalf = new int[_line.Count / 2];
            int j = _line.Count / 2;
            for (int i = 0 ; i < j ; i++)
            {
                try
                {
                    _firstHalf[i] = int.Parse(_line.First.Value.ToString());
                    _secondHalf[i] = int.Parse(_line.Last.Value.ToString());
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Only Numbers");
                }
                _line.RemoveFirst();
                _line.RemoveLast();
            }
        }

        public bool MagicAlgorithm()
        {
            int sumFirst = _firstHalf.Sum();
            int sumSecond = _secondHalf.Sum();
            if (sumFirst == sumSecond)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            bool t = true;
            while (t == true){
                Console.WriteLine("Enter your ticket number :");
                String numberTicket = Console.ReadLine();
                LuckyTicket ticket = new LuckyTicket(numberTicket);
                ticket.NumberLengthFormat();
                ticket.NumberFormat();
                bool res = ticket.MagicAlgorithm();
                if(res is true)
                {
                    Console.WriteLine("Your ticket is lucky");
                }
                else
                {
                    Console.WriteLine("Your ticket is unlucky");
                }
            }
        }
    }
}
