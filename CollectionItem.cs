using System;
using System.Collections.Generic;
using System.Text;

namespace Context
{
    public class CollectionItem
    {
        public Collection m_Owner;
        public CollectionItem(Collection Owner)
        {
            m_Owner = Owner;
        }
    }
}
