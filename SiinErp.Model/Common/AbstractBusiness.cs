using Microsoft.EntityFrameworkCore;
using SiinErp.Model.Common.Exceptions;
using SiinErp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Common
{
    public abstract class AbstractBusiness<K, T> : IRepository<K, T> where T : class
    {
        private readonly SiinErpContext _Context;

        protected AbstractBusiness(SiinErpContext context)
        {
            _Context = context;
        }

        protected IQueryable<T> GetQuery()
        {
            return _Context.Set<T>();
        }

        public void Create(K id, T entity)
        {
            try
            {
                if (id == null)
                {
                    _Context.Set<T>().Add(entity);
                    _Context.SaveChanges();
                }
                else
                {
                    T obj = Read(id);
                    if (obj == null)
                    {
                        _Context.Set<T>().Add(entity);
                        _Context.SaveChanges();
                    }
                    else
                    {
                        throw new DuplicatedException();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Read(K id)
        {
            try
            {
                var entity = _Context.Set<T>().Find(id);
                if (entity != null)
                {
                    _Context.Entry(entity).State = EntityState.Detached;
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> ReadAll()
        {
            try
            {
                return GetQuery().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(K id)
        {
            try
            {
                T obj = Read(id);
                if (obj == null)
                {
                    throw new NonObjectFoundException();
                }
                else
                {
                    _Context.Set<T>().Remove(obj);
                    _Context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(K id, T entity)
        {
            T obj = Read(id);
            if (obj == null)
            {
                throw new NonObjectFoundException();
            }
            else
            {
                if (obj.Equals(entity))
                {
                    _Context.Set<T>().Update(entity);
                    _Context.SaveChanges();
                }
                else
                {
                    throw new NonEqualObjectException();
                }
            }
        }
    }
}