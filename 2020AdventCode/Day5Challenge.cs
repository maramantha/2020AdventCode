using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Day5Challenge
    {

        private double _highestSeatID { get; set; }
        public double highestSeatID { get => _highestSeatID; }
        private int _yourSeatID { get; set; }
        public double yourSeatID { get => _yourSeatID; }
        private struct BoardpassData
        {
            public int row;
            public int column;
            public int seatID;
            public string binaryCode;

        }

        private int findRow(string instructInput, int lowerRange = 0, int upperRange = 127)
        {
            if(instructInput != "")
            {
                switch(instructInput[0])
                {
                    case 'F':
                        upperRange = ((upperRange - lowerRange - 1) / 2) + lowerRange;
                        break;
                    case 'B':
                        lowerRange = ((upperRange - lowerRange + 1) / 2 ) + lowerRange;
                        break;
                }
                return findRow(instructInput.Substring(1), lowerRange, upperRange);
            }
            return lowerRange;
        }
        private int findCol(string instructInput, int lowerRange = 0, int upperRange = 7)
        {
            if (instructInput != "")
            {
                switch (instructInput[0])
                {
                    case 'L':
                        upperRange = ((upperRange - lowerRange - 1) / 2) + lowerRange;
                        break;
                    case 'R':
                        lowerRange = ((upperRange - lowerRange + 1) / 2) + lowerRange;
                        break;
                }
                return findCol(instructInput.Substring(1), lowerRange, upperRange);
            }
            return lowerRange;
        }
        private int getSeatID(int row, int col) { return row * 8 + col; }

        private void SeatTester(ref List<BoardpassData> BDC)
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\DataOutput.txt";
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(userFolder))
            {
                string lIneOutput = "Row" + ";" + "Col" + ";" + "ID";
                file.WriteLine(lIneOutput);
                foreach (BoardpassData BD in BDC)
                {
                    lIneOutput = BD.row + ";" + BD.column + ";" + BD.seatID;
                    file.WriteLine(lIneOutput);
                }
            }
        }

        private int seatFinder(ref List<BoardpassData> BDC)
        {
            List<BoardpassData> SortedBDC = BDC.OrderBy(o => o.seatID).ToList();
            int lowerID = 0;

            foreach(BoardpassData BD in SortedBDC)
            {
                if(lowerID ==0)
                {
                    lowerID = BD.seatID;
                }else
                {
                    if(BD.seatID - lowerID > 1)
                    {
                        return BD.seatID - 1;
                        
                    } else
                    {
                        lowerID = BD.seatID;
                    }
                }
            }

            return 0;
        }


        private void buildBDData(ref List<string> BD)
        {
            List<BoardpassData> BDCollector = new List<BoardpassData>();
            foreach(string pass in BD)
            {
                BoardpassData brdPass = new BoardpassData();
                brdPass.binaryCode = pass;
                brdPass.row = findRow(pass.Substring(0, 7));
                brdPass.column = findCol(pass.Substring(7));
                brdPass.seatID = getSeatID(brdPass.row, brdPass.column);
                BDCollector.Add(brdPass);
                if (brdPass.seatID > _highestSeatID)
                {
                    _highestSeatID = brdPass.seatID;
                }
            }
            _yourSeatID = seatFinder(ref BDCollector);
        }


        public Day5Challenge(string[] BoardingPasses)
        {
            List<string> BD = BoardingPasses.ToList<string>();
            buildBDData(ref BD);
        }
    }
}
