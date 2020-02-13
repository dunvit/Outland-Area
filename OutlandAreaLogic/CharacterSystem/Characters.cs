using System.Collections.Generic;
using System.Linq;
using log4net;
using OutlandAreaLogic.DialogSystems;

namespace OutlandAreaLogic.CharacterSystem
{
    public class Characters
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Dialogs));

        public List<Character> List = new List<Character>();

        public Character GetCharacter(long characterId)
        {
            Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Get character: {characterId}");

            foreach (var character in List.Where(character => character.Id == characterId))
            {
                Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Character found: {characterId}");
                return character;
            }

            var newCharacter = new Character(characterId);

            Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Character added: {characterId}");

            List.Add(newCharacter);

            return newCharacter;
        }

    }
}
