﻿using AutoMapper;
using eAutobus.Services.Interfaces;
using eAutobus.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services
{
    public class BaseService<TModel, TSearch,TDatabase> : IService<TModel, TSearch> where TDatabase: class
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;

        public BaseService(Database.eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TModel> Get(TSearch search)
        {
            var list = _context.Set<TDatabase>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public TModel GetByID(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(entity); 
        }
    }
}