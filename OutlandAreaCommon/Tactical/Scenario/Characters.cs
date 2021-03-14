using System;
using System.Collections;
using OutlandAreaCommon.Tactical.Scenario.Dialog;

namespace OutlandAreaCommon.Tactical.Scenario
{
    [Serializable]
    public class Characters
    {
        private Hashtable characters = new Hashtable();

        public bool IsExist(long id)
        {
            return characters.ContainsKey(id);
        }

        public void Add(Character character)
        {
            if (IsExist(character.Id) == false)
            {
                characters.Add(character.Id, character);
            }
        }

        public Character Get(long id)
        {
            return (Character)characters[id];
        }
    }
}
