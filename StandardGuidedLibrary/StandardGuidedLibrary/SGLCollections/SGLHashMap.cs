using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLHashMap<K,V>
    {
        /// <summary>
        /// Entry for lookup.
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        class SGLEntry<X, Y>
        {
            private readonly int HashCode;
            public X Key { get; private set; }
            public Y Value { get; private set; }
            public SGLEntry<X, Y> Next { get; set; }

            public SGLEntry(X key, Y value)
            {
                Key = key;
                Value = value;
            }

            /// <summary>
            /// Sets the next entry.
            /// </summary>
            /// <param name="entry"></param>
            public void SetNext(SGLEntry<X, Y> entry)
            {
                Next = entry;
            }
            /// <summary>
            /// Sets the value of this entry.
            /// </summary>
            /// <param name="value"></param>
            public void SetValue(Y value)
            {
                Value = value;
            }
        }
        /// <summary>
        /// List of entries.
        /// </summary>
        private SGLEntry<K,V>[] Entries;

        public SGLHashMap()
        {
            Entries = new SGLEntry<K,V>[100];
        }
        /// <summary>
        /// Returns true if and only if the key is already specified
        /// which will also in return update the given value with the specified.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Put(K key, V value)
        {
            int initEntryIndex = HashSlingerSlasher(key);
            Console.WriteLine(initEntryIndex + " is the value");
            SGLEntry<K, V> entry = new SGLEntry<K, V>(key, value);

            if (Entries[initEntryIndex] == null || Entries[initEntryIndex].Key.Equals(entry.Key))
            {
                // Either the position is of the same key, or it is not in use
                if (Entries[initEntryIndex] == null)
                {
                    Entries[initEntryIndex] = entry;
                    return false;
                }
                else
                {
                    Entries[initEntryIndex].SetValue(entry.Value);
                    return true;
                }
            }
            else
            {
                SGLEntry<K, V> iter = Entries[initEntryIndex];

                while (iter.Next != null || iter.Next.Key.Equals(entry.Key))
                {
                    iter = iter.Next;
                    Console.WriteLine(iter.Value + "  -  ");
                }

                // There was nothing in the next entry.
                // else, we have this entry already.
                if (iter.Next == null)
                {
                    iter.SetNext(entry);
                    return false;
                }
                else
                {
                    iter.SetValue(entry.Value);
                    return true;
                }
            }

        }
        /// <summary>
        /// simple Hash function.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int HashSlingerSlasher(K key)
        {
            int result = key.GetHashCode() % 100;
            return (result >= 0 ? result : result * -1);
        }
    }
}
