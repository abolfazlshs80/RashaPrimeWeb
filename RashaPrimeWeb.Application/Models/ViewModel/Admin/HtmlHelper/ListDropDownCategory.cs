using RashaPrimeWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;

namespace RashaPrimeWeb.Application.Models.ViewModel.Admin.HtmlHelper
{

    public class ListDropDownCategory
    {
        public IEnumerable<GetAllCategoryDto> Category { get; set; }
        public IEnumerable<int> CategoryActive { get; set; }
    }
}
