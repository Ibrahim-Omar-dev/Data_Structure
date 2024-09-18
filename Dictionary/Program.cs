using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Print();

            dic.Set("Sinar", "sinar@gmail.com");
            dic.Set("Elvis", "elvis@gmail.com");
            dic.Print();

            dic.Set("Tane", "tane@gmail.com");
            dic.Set("Gerti", "gerti@gmail.com");
            dic.Set("Arist", "arist@gmail.com");

            dic.Set("rArist", "rarist@gmail.com");
            dic.Set("tArist", "tarist@gmail.com");
            dic.Set("yArist", "yarist@gmail.com");

            dic.Print();

            Console.WriteLine(dic.Get("Tane"));
            Console.WriteLine(dic.Get("Sinar"));
            Console.WriteLine(dic.Get("Elviaaa"));

            dic.Remove("Sinar");
            dic.Remove("Elvis");
            dic.Remove("Tane");
            dic.Remove("Gerti");
            dic.Remove("Arist");
            dic.Print();
            dic.Set("Sinar", "sinar@gmail.com");
            dic.Print();

        }
    }
    public class Dictionary<Tkey, Tvalue>where Tkey:class
    {
        KeyValuePair[] entries;
        int initialSize;
        int entriesCount;
        public Dictionary()
        {
            initialSize = 4;
            entries = new KeyValuePair[initialSize];
            entriesCount = 0;
        }
        public void ResizeOrNot()
        {
            if (entriesCount < entries.Length - 1)
                return;
            int newSize= entries.Length+initialSize;
            Console.WriteLine("[resize] from "
                + this.entries.Length + " to " + newSize);
            KeyValuePair []newArray = new KeyValuePair[newSize];
            Array.Copy(entries, newArray, entries.Length);
            entries = newArray;
        }
        public int Size()
        {
            return entriesCount;
        }
        public void Set(Tkey key, Tvalue value)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (this.entries[i] != null &&
                    this.entries[i].Key == key)
                {
                    entries[i].Value = value;
                    return;
                }
            }
            ResizeOrNot();
            var newPair=new KeyValuePair(key, value);
            entries[entriesCount]=newPair;
            entriesCount++;
        }
        public Tvalue Get(Tkey key)
        {
            for(int i = 0;i < entries.Length; i++)
            {
                if (this.entries[i] != null &&
                    this.entries[i].Key == key)
                
                    return this.entries[i].Value;
            }
            return default(Tvalue);
        }
        public Boolean Remove(Tkey key)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].Key == key && entries[i]!= null)
                {
                    this.entries[i] = this.entries[this.entriesCount - 1];
                    this.entries[this.entriesCount - 1] = null;
                    this.entriesCount--;
                    return true;
                }
            }
            return false;
        }
        public void Print()
        {
            Console.WriteLine("----------");
            Console.WriteLine("[size] " + this.Size());
            for (int i = 0; i < this.entries.Length; i++)
            {
                if (this.entries[i] == null)
                {
                    Console.WriteLine("[" + i + "]");
                    continue;
                }
                else
                {
                    Console.WriteLine("[" + i + "]" + this.entries[i].Key
                      + ":" + this.entries[i].Value);
                }
            }
            Console.WriteLine("==========");
        }
        class KeyValuePair
        {
            Tkey key;
            Tvalue value;
            public Tkey Key
            {
                get { return key; }
            }
            public Tvalue Value
            {
                get { return value; }
                set { this.value = value; }
            }
            public KeyValuePair(Tkey key, Tvalue val)
            {
                this.key = key;
                value = val;
            }
        }

    }
    
}
