using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace CatHut
{

    public class SerializableDictionary<TKey, TValue> : IEnumerable<SerializableKeyValuePair<TKey, TValue>>
    {
        protected List<SerializableKeyValuePair<TKey, TValue>> keyValuePairs = new List<SerializableKeyValuePair<TKey, TValue>>();

        public virtual void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException("An element with the same key already exists in the dictionary.");
            }

            keyValuePairs.Add(new SerializableKeyValuePair<TKey, TValue>(key, value));
        }

        public bool Remove(TKey key)
        {
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(keyValuePairs[i].Key, key))
                {
                    keyValuePairs.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TKey> Keys
        {
            get { return keyValuePairs.Select(kvp => kvp.Key); }
        }

        public IEnumerable<TValue> Values
        {
            get { return keyValuePairs.Select(kvp => kvp.Value); }
        }

        public int Count
        {
            get { return keyValuePairs.Count; }
        }

        public TValue this[TKey key]
        {
            get
            {
                foreach (var kvp in keyValuePairs)
                {
                    if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                    {
                        return kvp.Value;
                    }
                }

                throw new KeyNotFoundException("The given key was not found in the dictionary.");
            }

            set
            {
                // �L�[�����݂���ꍇ�͒l���X�V����
                for (int i = 0; i < keyValuePairs.Count; i++)
                {
                    if (EqualityComparer<TKey>.Default.Equals(keyValuePairs[i].Key, key))
                    {
                        keyValuePairs[i] = new SerializableKeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
                }

                // �L�[�����݂��Ȃ��ꍇ�͗v�f��ǉ�����
                Add(key, value);
            }
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var kvp in keyValuePairs)
            {
                if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<SerializableKeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return keyValuePairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // XML�V���A���C�U���v������Add(System.Object)���\�b�h����������
        public void Add(System.Object obj)
        {
            // ������SerializableKeyValuePair<TKey, TValue>�ɃL���X�g����
            SerializableKeyValuePair<TKey, TValue> pair = obj as SerializableKeyValuePair<TKey, TValue>;

            // �L���X�g�Ɏ��s�����ꍇ�͗�O���X���[����
            if (pair == null)
            {
                throw new ArgumentException("Invalid argument type for Add method.");
            }

            // �L���X�g�ɐ��������ꍇ��Add(TKey key, TValue value)���Ăяo��
            Add(pair.Key, pair.Value);
        }
    }
}
