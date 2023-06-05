using CSA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using CSA.IStorage;
namespace CSA.IStorage
{
    public class LaptopList :IStorage<Laptop>
    {
        private object _sync = new object();
        private List<Laptop> _LaptopList = new List<Laptop>();
        public Laptop this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectVideoCardException($"No LabData with id {id}");

                    return _LaptopList.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectVideoCardException("Cannot request LabData with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _LaptopList.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<Laptop> All => _LaptopList.Select(x => x).ToList();

        public void Add(Laptop value)
        {
            if (value.Id == Guid.Empty) throw new IncorrectVideoCardException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _LaptopList.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _LaptopList.RemoveAll(x => x.Id == id);
            }
        }
    }
}

