using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //take key with generics
        T Get<T>(string key);

        //get key with object it means value
        object Get(string key);
        //add the Memory Cache as key,value and duration 
        void Add(string key, object value, int duration);

        //is there a key in memory cache
        bool IsAdd(string key);

        //remove the cache after expiration time or noneed it.
        void Remove(string key);

        //we can remove whhen it's name is start letter 'A' or last letter 'c' like that then 
        //it can remove it.
        void RemoveByPattern(string pattern);


    }
}
