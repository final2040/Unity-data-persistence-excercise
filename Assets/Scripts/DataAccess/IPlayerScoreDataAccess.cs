using System;

namespace Assets.Scripts.DataAccess
{
    public interface IPlayerScoreDataAccess
    {
        public void Save(ScoreBoard scores);
        public ScoreBoard Load();
    }
}