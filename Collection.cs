using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
// See also the Queue
namespace Context
{
    public class Collection : ArrayList
    {
        public virtual int AddItem(CollectionItem value)
        {
            value.m_Owner = this;
            return Add(value);
        }
    }
}
