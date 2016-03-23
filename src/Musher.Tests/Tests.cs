using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musher.EchoNest.Data;
using Musher.EchoNest.Models;
using Musher.EchoNest.Services;

namespace Musher.Tests
{
    [DeploymentItem(@"..\..\AppSettings.config")]
    [TestClass]
    public class Tests
    {
        IDataProvider _dataProvider = new DataProvider(ConfigurationManager.AppSettings["EchoNestApiUrl"], ConfigurationManager.AppSettings["EchoNestApiKey"]);

        public Tests()
        {
        }

        [TestMethod]
        public void RecommendationTest()
        {
            RecommendationQueryArgs args = new RecommendationQueryArgs
            {
                Mood = new List<string>() { "angry" }
            };

            var service = new RecommendationService(_dataProvider);
            var artists = service.GetArtists(args);
            var songs = service.GetSongs(args);

            Assert.IsNotNull(artists);
            Assert.IsNotNull(songs);
        }

        [TestMethod]
        public void GetArtistTest()
        {
            var service = new ArtistService(_dataProvider);
            var response = service.GetSimilarArtists("mogwai");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetArtistProfileTest()
        {
            var service = new ArtistService(_dataProvider);
            var response = service.GetArtistProfile("AR6XZ861187FB4CECD");

            Assert.IsNotNull(response);
        }
    }
}
