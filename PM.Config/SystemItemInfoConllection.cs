using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PM.Config {
    public class SystemItemInfoConllection : CollectionBase {

        public SystemItemInfoConllection() {
        }

        public SystemItemInfoConllection(SystemItemInfoConllection value) {
            this.AddRange(value);
        }

        public SystemItemInfoConllection(SystemItemInfo[] value) {
            this.AddRange(value);
        }

        public SystemItemInfo this[int index] {
            get {
                return ((SystemItemInfo)(this.List[index]));
            }
        }

        public int Add(SystemItemInfo value) {
            return this.List.Add(value);
        }

        public void AddRange(SystemItemInfo[] value) {
            for (int i = 0; (i < value.Length); i = (i + 1)) {
                this.Add(value[i]);
            }
        }

        public void AddRange(SystemItemInfoConllection value) {
            for (int i = 0; (i < value.Count); i = (i + 1)) {
                this.Add((SystemItemInfo)value.List[i]);
            }
        }

        public bool Contains(SystemItemInfo value) {
            return this.List.Contains(value);
        }

        public void CopyTo(SystemItemInfo[] array, int index) {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(SystemItemInfo value) {
            return this.List.IndexOf(value);
        }

        public void Insert(int index, SystemItemInfo value) {
            List.Insert(index, value);
        }

        public void Remove(SystemItemInfo value) {
            List.Remove(value);
        }

        public new SystemItemInfoCollectionEnumerator GetEnumerator() {
            return new SystemItemInfoCollectionEnumerator(this);
        }
    }

    public class SystemItemInfoCollectionEnumerator : IEnumerator {
        private IEnumerator _enumerator;
        private IEnumerable _temp;


        public SystemItemInfoCollectionEnumerator(SystemItemInfoConllection mappings) {
            _temp = ((IEnumerable)(mappings));
            _enumerator = _temp.GetEnumerator();
        }

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        public SystemItemInfo Current {
            get {
                return ((SystemItemInfo)(_enumerator.Current));
            }
        }

        object IEnumerator.Current {
            get {
                return _enumerator.Current;
            }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns><b>true</b> if the enumerator was successfully advanced to the next element; <b>false</b> if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext() {
            return _enumerator.MoveNext();
        }

        bool IEnumerator.MoveNext() {
            return _enumerator.MoveNext();
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset() {
            _enumerator.Reset();
        }

        void IEnumerator.Reset() {
            _enumerator.Reset();
        }
    }
}
