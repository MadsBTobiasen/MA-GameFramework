using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MA_GameFramework.Utilities.Interfaces;

namespace MA_GameFramework.Utilities
{
    public class ObjectStore<T>
        where T : IIdentity<int>, IValidate
    {

        #region Fields
        private int _nextId = 0;
        private Dictionary<int, T> _store;
        #endregion

        #region Properties
        /// <summary>
        /// List of Items in the Store.
        /// </summary>
        public List<T> Items => new List<T>(_store.Values);
        /// <summary>
        /// Length of the Store.
        /// </summary>
        public int Length => _store.Count;
        #endregion

        #region Constructors
        public ObjectStore()
        {
            _store = new Dictionary<int, T>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Function that adds an object to the store.
        /// If the object in question, does not have an id (Default value of 0),
        /// an id is assigned to it.
        /// </summary>
        /// <param name="obj">Object to be added.</param>
        public void Add(T obj)
        {

            /**
            * If the object already has an assigned id (Not default value of 0),
            * then the object should be added with a key.
            * Add a guard clause, to exit execution.
            */
            if(obj.Id > 0)
            {
                AddWithKey(obj);
                return;
            } 

            while (_store.ContainsKey(_nextId))
                _nextId++;

            obj.Id = _nextId;
            AddWithKey(obj);

        }

        /// <summary>
        /// Function that adds a collection of objects to the store.
        /// If the object in question, does not have an id (Default value of 0),
        /// an id is assigned to it.
        /// </summary>
        /// <param name="objs">Objects.</param>
        public void Add(params T[] objs)
        {
            foreach (T obj in objs)
                Add(obj);
        }

        /// <summary>
        /// Function that adds a collection of objects to the store.
        /// If the object in question, does not have an id (Default value of 0),
        /// an id is assigned to it.
        /// </summary>
        /// <param name="objs">Objects.</param>
        public void Add(IEnumerable<T> objs)
        {
            foreach (T obj in objs)
                Add(obj);
        }
        
        /// <summary>
        /// Function that adds an object to the store, and dosen't asign it an id.
        /// </summary>
        /// <param name="obj"></param>
        private void AddWithKey(T obj)
        {
            _store.Add(obj.Id, obj);
        }

        /// <summary>
        /// Function that gets an object from the store.
        /// </summary>
        /// <param name="key">Id of the object to get.</param>
        /// <returns>Instance of T or null if not found.</returns>
        public T? Get(int key)
        {
            return _store[key];
        }
        #endregion

    }
}
