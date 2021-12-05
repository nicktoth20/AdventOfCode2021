using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day4
    {
        private Parser _parser;
        private BingoDrawer _bingoDrawer;

        public Day4()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            _bingoDrawer = new BingoDrawer
            {
                NumbersToDraw = Array.ConvertAll(lines.First().Split(','), int.Parse).ToList()
            };

            var boards = new List<BingoBoard>();

            for (var x = 2; lines.Count >= x + 5; x += 6)
            {
                boards.Add(LoadBoard(lines.GetRange(x, 5).ToArray()));
            }

            var boardWon = -1;
            var count = -1;
            do
            {

                var number = _bingoDrawer.GetNextNumber();
                MarkNumber(number, boards);
                (boardWon, count) = BoardWon(boards);
            } while (boardWon == -1);

            return count * _bingoDrawer.GetLastNumberDrawn();
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            _bingoDrawer = new BingoDrawer
            {
                NumbersToDraw = Array.ConvertAll(lines.First().Split(','), int.Parse).ToList()
            };

            var boards = new List<BingoBoard>();

            for (var x = 2; lines.Count >= x + 5; x += 6)
            {
                boards.Add(LoadBoard(lines.GetRange(x, 5).ToArray()));
            }

            var boardWon = -1;
            var count = -1;
            do
            {

                var number = _bingoDrawer.GetNextNumber();
                MarkNumber(number, boards);
                if (boards.Count == 1)
                {
                    (boardWon, count) = BoardWon(boards);
                }
                else
                {
                    var boardsToRemove = BoardWonPart2(boards);
                    boardsToRemove = boardsToRemove.OrderByDescending(b => b).ToList();
                    foreach (var boardIndex in boardsToRemove)
                    {
                        boards.RemoveAt(boardIndex);
                    }
                }
            } while (boardWon == -1);
            return count * _bingoDrawer.GetLastNumberDrawn();
        }

        private void MarkNumber(int numberToMark, IEnumerable<BingoBoard> boards)
        {
            foreach (var bingoBoard in boards)
            {
                if (bingoBoard.Board.Any(b => b.Number == numberToMark))
                {
                    bingoBoard.Board.First(b => b.Number == numberToMark).Marked = true;
                }
            }
        }

        private BingoBoard LoadBoard(string[] lines)
        {
            var bingoBoard = new BingoBoard();
            for (var row = 0; row < 5; row++)
            {
                var numbers = Array.ConvertAll(lines[row].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray(), int.Parse);
                for (var column = 0; column < 5; column++)
                {
                    bingoBoard.Board.Add(new BingoMarking(numbers[column], row, column));
                }
            }

            return bingoBoard;
        }

        private (int, int) BoardWon(IEnumerable<BingoBoard> boards)
        {
            var boardIndex = 0;
            foreach (var board in boards)
            {
                var marked = board.Board.Where(x => x.Marked).ToList();
                if (marked.Count() < 5)
                {
                    continue;
                }
                for (var row = 0; row < 5; row++)
                {
                    if (marked.Count(x => x.Row == row) == 5)
                    {
                        return (boardIndex, GetBoardScore(board));
                    }
                }
                for (var column = 0; column < 5; column++)
                {
                    if (marked.Count(x => x.Column == column) == 5)
                    {
                        return (boardIndex, GetBoardScore(board));
                    }
                }

                boardIndex++;
            }
            return (-1, -1);
        }

        private List<int> BoardWonPart2(IList<BingoBoard> boards)
        {
            var boardsToRemove = new HashSet<int>();
            var boardIndex = 0;
            foreach (var board in boards)
            {
                var marked = board.Board.Where(x => x.Marked).ToList();
                if (marked.Count() < 5)
                {
                    continue;
                }
                for (var row = 0; row < 5; row++)
                {
                    if (marked.Count(x => x.Row == row) == 5)
                    {
                        boardsToRemove.Add(boardIndex);
                    }
                }

                for (var column = 0; column < 5; column++)
                {
                    if (marked.Count(x => x.Column == column) == 5)
                    {
                        boardsToRemove.Add(boardIndex);
                    }
                }

                boardIndex++;
            }

            return boardsToRemove.ToList();
        }

        private int GetBoardScore(BingoBoard board)
        {
            return board.Board.Where(x => !x.Marked).Sum(y => y.Number);
        }
    }

    public class BingoDrawer
    {
        public IList<int> NumbersToDraw { get; set; }
        public int CurrentIndex { get; set; }

        public BingoDrawer()
        {
            CurrentIndex = 0;
        }

        public int GetNextNumber()
        {
            var number = NumbersToDraw[CurrentIndex];
            CurrentIndex++;
            return number;
        }

        public int GetLastNumberDrawn()
        {
            return NumbersToDraw[--CurrentIndex];
        }
    }

    public class BingoBoard
    {
        public ICollection<BingoMarking> Board = new List<BingoMarking>();
    }

    public class BingoMarking
    {
        public int Number { get; }
        public int Row { get; }
        public int Column { get; }
        public bool Marked { get; set; }

        public BingoMarking(int number, int row, int column)
        {
            Number = number;
            Marked = false;
            Row = row;
            Column = column;
        }
    }
}
