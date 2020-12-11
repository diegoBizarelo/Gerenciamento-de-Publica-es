using AutoMapper;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementService
{
    public class ConvertClass
    {

        private IMapper _mapper;

        public ConvertClass(IMapper mapper)
        {
            _mapper = mapper;
        }

        /*public AuthorView AuthorModelToView(Author a)
        {
            _mapper.Map
        }*/
    }
}
