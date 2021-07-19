using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EngineCore.Universe.Characters
{
    public class CharactersCollection
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
