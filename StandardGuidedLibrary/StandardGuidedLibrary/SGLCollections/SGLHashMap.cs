using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLHashMap<K, V>
    {
        class HashEntry<L, X>
        {
            public int Key { get; set; }
            public X Value { get; set; }
            public HashEntry<L, X> Next;

            public HashEntry() { }
            public HashEntry(L key, X value)
            {
                Key = key.GetHashCode();
                Value = value;
                Next = null;
            }
        }

        HashEntry<K, V>[] table;

        public SGLHashMap()
        {
            table = new HashEntry<K, V>[Int32.MaxValue];
        }
        public void Put(K key, V value)
        {
            int index = (key.GetHashCode() < 1 ? (key.GetHashCode() * -1)/4 : key.GetHashCode()/4);
            Console.WriteLine("Key HashCode: " + index + " | Value is: " + value.ToString());
            HashEntry<K, V> hashEntry = new HashEntry<K, V>(key, value);
            if (table[index] == null)
            {
                table[index] = hashEntry;
            }
            else
            {
                // collision 
                HashEntry<K, V> tempo = table[index];
                while (tempo.Next == null)
                {
                    // Find the next position available or update an entry.
                    if (tempo.Key == hashEntry.Key)
                    {
                        tempo.Value = hashEntry.Value;
                        Console.WriteLine("Value was stored: Key=" + tempo.Key + " Value=" + tempo.Value);
                        break;
                    }
                    else
                    {
                        tempo = tempo.Next;
                    }
                }
            }
        }
    }
}
