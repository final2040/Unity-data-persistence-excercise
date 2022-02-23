using Assets.Scripts.DataAccess;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class DataAccessFactory
    {
        public static IPlayerScoreDataAccess ScoreBoard() => new JsonPlayerScoreDataAccess(Application.persistentDataPath + "/scoreBoard.json");
    }
}