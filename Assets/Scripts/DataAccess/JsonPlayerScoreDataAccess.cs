using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Assets.Scripts.DataAccess
{
    public class JsonPlayerScoreDataAccess : IPlayerScoreDataAccess
    {
        private readonly string path;

        public JsonPlayerScoreDataAccess(string path)
        {
            this.path = path;
        }
        public void Save(ScoreBoard scores)
        {
            var json = JsonConvert.SerializeObject(scores);
            File.WriteAllText(path, json);
        }

        public ScoreBoard Load()
        {
            ScoreBoard scoreBoard = null;
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                scoreBoard = JsonConvert.DeserializeObject<ScoreBoard>(json);
            }

            return scoreBoard;
        }
    }
}