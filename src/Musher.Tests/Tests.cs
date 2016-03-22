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
        IService _service;

        public Tests()
        {
            IDataProvider dataProvider = new DataProvider(ConfigurationManager.AppSettings["EchoNestApiUrl"], ConfigurationManager.AppSettings["EchoNestApiKey"]);
            _service = new Service(dataProvider);
        }

        [TestMethod]
        public void RecommendationTest()
        {
            RecommendationQueryArgs args = new RecommendationQueryArgs
            {
                Mood = new List<string>() { "angry" }
            };

            var artists = _service.GetArtists(args);
            var songs = _service.GetSongs(args);

            Assert.IsNotNull(artists);
            Assert.IsNotNull(songs);
        }

        [TestMethod]
        public void GetArtistTest()
        {
            var response = _service.GetSimilarArtists("mogwai");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetArtistProfileTest()
        {
            var response = _service.GetArtistProfile("AR6XZ861187FB4CECD");

            Assert.IsNotNull(response);
        }
    }
}
