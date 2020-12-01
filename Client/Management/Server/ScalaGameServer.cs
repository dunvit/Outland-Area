using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Engine.Layers.Tactical;
using OutlandAreaCommon.Server;
using OutlandAreaCommon.Tactical;
using OutlandAreaLocalServer;

namespace Engine.Management.Server
{
    public class ScalaGameServer: IGameServer
    {
        private Settings _applicationSettings;
        private Action<string> _logger;

        public ScalaGameServer(Settings settings, Action<string> logger)
        {
            _applicationSettings = settings;
            _logger = logger;
        }

        public GameSession Initialization()
        {
            _logger($"Request to server {_applicationSettings.ServerAddress} for generate game session.");
            return GetGameSession(@"/init/10000/10000");
        }

        public void ResumeSession(int id)
        {
            ExecuteRequest(@"/resume/" + id);
        }

        public void PauseSession(int id)
        {
            ExecuteRequest(@"/pause/" + id);
        }

        public void Command(int sessionId, int objectId, int targetObjectId, int memberId, int targetCell, int typeId)
        {
            ExecuteRequest($@"/command/{sessionId}/{objectId}/{targetObjectId}/{memberId}/{targetCell}/{typeId}");
        }

        public void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed,
            int classification, string name)
        {
            
        }

        public void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed,
            int classification, string name, float radius, float damage)
        {
            
        }


        private GameSession GetGameSession(string route)
        {
            var stopwatch = Stopwatch.StartNew();

            // Create a request for the URL.
            var request = WebRequest.Create(_applicationSettings.ServerAddress + route);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            var response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var mapContent = "";
            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (var dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                var reader = new StreamReader(dataStream);
                // Read the content.
                mapContent = reader.ReadToEnd();
                // Display the content.
                //Console.WriteLine(responseFromServer);
            }

            response.Close();

            //mapContent = GetSavedMap("Map_001");

            stopwatch.Stop();

            _logger($"Get game session from server {_applicationSettings.ServerAddress + route} finished for {stopwatch.Elapsed.TotalMilliseconds}.");

            stopwatch.Start();

            var stopwatchParsing = Stopwatch.StartNew();

            var gameSession = Convertor.ToGameSession(mapContent);

            stopwatchParsing.Stop();

            _logger($"Get game session parsing finished for {stopwatchParsing.Elapsed.TotalMilliseconds}. " +
                    $"Game session id = {gameSession.Id}. " +
                    $" Turn = {gameSession.Turn}. " +
                    $" Map objects count is {gameSession.Map.CelestialObjects.Count}.");

            return gameSession;
        }

        public GameSession RefreshGameSession(int id)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger($"Refresh celestial map {id}");

                var gameSession = GetGameSession(@"/status/" + id);

                stopwatch.Stop();

                _logger($"Refresh game session {id} finished for {stopwatch.Elapsed.TotalMilliseconds}");

                return gameSession;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private void ExecuteRequest(string route)
        {
            var stopwatch = Stopwatch.StartNew();

            // Create a request for the URL.
            var request = WebRequest.Create(_applicationSettings.ServerAddress + route);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            var response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var mapContent = "";
            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (var dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                var reader = new StreamReader(dataStream);
                // Read the content.
                mapContent = reader.ReadToEnd();
                // Display the content.
                //Console.WriteLine(responseFromServer);
            }

            response.Close();

            stopwatch.Stop();

            _logger($"Get answer from server finished for {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Start();
        }
    }
}
