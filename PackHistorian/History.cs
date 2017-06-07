﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackChronicler.Entity;

namespace PackChronicler {
  public class History : IEnumerable<Pack>,  INotifyCollectionChanged {
    ObservableCollection<Pack> _packs;

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public int Count { get { return _packs.Count; } }

    public History() {
      _packs = new ObservableCollection<Pack>();
      Initialize();
    }

    public History(IEnumerable<Pack> Packs) {
      _packs = new ObservableCollection<Pack>(Packs);
      Initialize();
    }

    private void Initialize() {
      _packs.CollectionChanged += (sender, e) => { OnCollectionChanged(e); };
    }

    public History Ascending { get { return new History(_packs.OrderBy(x => x.Time)); } }

    public void Add(Pack Pack) {
      _packs.Add(Pack);
    }

    public IEnumerator<Pack> GetEnumerator() {
      return _packs.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return _packs.GetEnumerator();
    }

    private void OnCollectionChanged(NotifyCollectionChangedEventArgs Args) {
      CollectionChanged?.Invoke(this, Args);
    }
  }
}
