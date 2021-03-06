/*
Foundry
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon(R) and CERT(R) are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0194
*/

using Microsoft.Extensions.Caching.Memory;
using System;

namespace Stack.Http.Caching
{
    public class EntityCache<TEntity> : IEntityCache<TEntity>
        where TEntity : class, new()
    {
        IMemoryCache _memoryCache;
        public EntityCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public TEntity Get(string key)
        {
            if (_memoryCache.TryGetValue(key, out TEntity entity))
                return entity;

            return null;
        }

        public void Remove(string key)
        {
            if (_memoryCache.TryGetValue(key, out TEntity entity))
                _memoryCache.Remove(key);
        }

        public TEntity Set(string key, TEntity entity)
        {
            if (entity == null)
            {
                if (Get(key) != null)
                    Remove(key);

                return null;
            }

            return _memoryCache.Set(key, entity);
        }
    }
}

