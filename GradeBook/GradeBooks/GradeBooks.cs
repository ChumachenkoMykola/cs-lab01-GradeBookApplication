using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Standard;
        }
    }
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }
            var sortedGrades = Students.Select(s => s.AverageGrade).OrderByDescending(g => g).ToList();
            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            if (averageGrade >= sortedGrades[threshold - 1])
                return 'A';
            if (averageGrade >= sortedGrades[threshold *2 - 1])
                return 'B';
            if (averageGrade >= sortedGrades[threshold *3 - 1])
                return 'C';
            if (averageGrade >= sortedGrades[threshold * 4 - 1])
                return 'D';
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else base.CalculateStudentStatistics(name);
        }

    }
}