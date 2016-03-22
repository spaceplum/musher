using System.Collections.Generic;
using System.Linq;
using Musher.EchoNest.Extensions;
using Musher.EchoNest.Models;
using Musher.EchoNest.Responses;
using RestSharp;

namespace Musher.EchoNest.Data
{
    public class DataProvider : IDataProvider
    {
        private readonly ApiClient _apiClient;

        public DataProvider(string apiUrl, string apiKey)
        {
            _apiClient = new ApiClient(apiUrl, apiKey);
        }

        public List<Artist> GetArtists(RecommendationQueryArgs args)
        {
            var request = _apiClient.CreateRequest("artist/search");
            AddSearchArgs(request, args);
            request.TryAddQueryParameter("genre", args.Genre);
            request.AddQueryParameter("sort", "familiarity-desc");
            var response = _apiClient.Execute<ArtistSearchResponse>(request);

            return response.Artists;
        }

        public List<Song> GetSongs(RecommendationQueryArgs args)
        {
            var request = _apiClient.CreateRequest("song/search");
            AddSearchArgs(request, args);
            request.AddQueryParameter("sort", "artist_familiarity-desc");
            var response = _apiClient.Execute<SongSearchResponse>(request);

            return response.Songs;
        }

        public List<Artist> GetSimilarArtists(string name)
        {
            var request = _apiClient.CreateRequest("artist/similar");
            request.AddQueryParameter("name", name);
            var response = _apiClient.Execute<SimilarArtistsResponse>(request);

            return response.Artists;
        }

        public List<Genre> GetGenres()
        {
            var request = _apiClient.CreateRequest("genre/list");
            request.AddQueryParameter("results", "1500"); // There are about 1400 genres
            var response = _apiClient.Execute<GenreListResponse>(request);

            return response.Genres;
        }

        public List<Genre> GetGenres(string artistName)
        {
            var request = _apiClient.CreateRequest("artist/profile");
            request.AddQueryParameter("name", artistName);
            request.AddQueryParameter("bucket", "genre");
            var response = _apiClient.Execute<ArtistProfileResponse>(request);

            return response.Artist.Genres;
        }

        public List<Term> GetTerms(TermType type)
        {
            var request = _apiClient.CreateRequest("artist/list_terms");
            request.AddQueryParameter("type", type.ToString().ToLowerInvariant());
            var response = _apiClient.Execute<ArtistTermsResponse>(request);

            return response.Terms;
        }

        public List<Term> GetArtistTerms(string name, TermType type)
        {
            var request = _apiClient.CreateRequest("artist/terms");
            request.AddQueryParameter("name", name);
            request.AddQueryParameter("type", type.ToString());
            var response = _apiClient.Execute<ArtistTermsResponse>(request);

            return response.Terms;
        }

        public List<Artist> GetArtists(string genre)
        {
            var request = _apiClient.CreateRequest("genre/artists");
            request.AddQueryParameter("name", genre);
            var response = _apiClient.Execute<GenreArtistsResponse>(request);

            return response.Artists;
        }

        public List<Artist> SearchArtists(string name, string genre)
        {
            var request = _apiClient.CreateRequest("artist/search");
            request.TryAddQueryParameter("name", name);
            request.TryAddQueryParameter("genre", genre);
            var response = _apiClient.Execute<ArtistSearchResponse>(request);

            return response.Artists;
        }

        public Artist GetArtistProfile(string name)
        {
            var request = _apiClient.CreateRequest("artist/profile");
            request.AddQueryParameter("name", name);
            request.AddQueryParameter("bucket", "genre");
            request.AddQueryParameter("bucket", "terms");
            request.AddQueryParameter("bucket", "images");
            request.AddQueryParameter("bucket", "biographies");
            var response = _apiClient.Execute<ArtistProfileResponse>(request);

            return response.Artist;
        }

        public Genre GetGenreProfile(string name)
        {
            var request = _apiClient.CreateRequest("genre/profile");
            request.AddQueryParameter("name", name);
            request.AddQueryParameter("bucket", "description");
            request.AddQueryParameter("bucket", "urls");
            var response = _apiClient.Execute<GenreProfileResponse>(request);

            return response.Genres.FirstOrDefault();
        }

        public List<Genre> GetSimilarGenres(string name)
        {
            var request = _apiClient.CreateRequest("genre/similar");
            request.AddQueryParameter("name", name);
            var response = _apiClient.Execute<SimilarGenresResponse>(request);

            return response.Genres;
        }

        private static void AddSearchArgs(RestRequest request, RecommendationQueryArgs args)
        {
            request.AddQueryParameter("rank_type", "familiarity");
            request.TryAddQueryParameter("mood", args.Mood);
            request.TryAddQueryParameter("style", args.Style);

            if (args.StartYear.HasValue)
            {
                request.AddQueryParameter("artist_start_year_after", (args.StartYear - 1).ToString());
                request.AddQueryParameter("artist_end_year_after", args.StartYear.ToString());
            }

            if (args.EndYear.HasValue)
            {
                request.AddQueryParameter("artist_end_year_before", (args.EndYear + 1).ToString());
                request.AddQueryParameter("artist_start_year_before", args.EndYear.ToString());
            }
        }
    }
}
