using BracketGenerator.Models;
using BracketGenerator.Tests.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BracketGenerator.Tests
{
    public class BaseTest
    {
        protected List<Team> Teams { get; set; }
        protected readonly SeedDataModel? Data;
        protected readonly EventModel AdvanceEventsModel;

        const string fileName = "..\\..\\..\\Data\\SeedFile.json";
        const string AdvanceEventsFileName = "..\\..\\..\\Data\\AdvanceEvents.json";
        public BaseTest() {
            var jsonSeedDataString = File.ReadAllText(fileName);
            Data = JsonSerializer.Deserialize<SeedDataModel>(jsonSeedDataString)!;
            Teams = new List<Team>();
            SeedData();

            var jsonAdvanceEventsString = File.ReadAllText(AdvanceEventsFileName);
            AdvanceEventsModel = JsonSerializer.Deserialize<EventModel>(jsonAdvanceEventsString)!;
        }

        private void SeedData()
        {
            foreach (var team in Data.R16)
                Teams.Add(new Team { Seed = team.Seed, Name = team.Team });
        }
    }
}
