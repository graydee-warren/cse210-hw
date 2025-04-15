using System;

namespace ExerciseTracking
{
    abstract class Activity
    {
        private DateTime date;
        private int minutes;

        public Activity(DateTime date, int minutes)
        {
            this.date = date;
            this.minutes = minutes;
        }

        protected DateTime Date => date;
        protected int Minutes => minutes;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{date:dd MMM yyyy} {GetType().Name} ({minutes} min)- " +
                   $"Distance: {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}