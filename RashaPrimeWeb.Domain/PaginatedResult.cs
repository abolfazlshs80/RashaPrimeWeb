using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RashaPrimeWeb.Application.Common.Models
{
    public record PaginatedResult<T>
    {
        public List<T> Items { get; set; } // لیست داده‌ها
        public int PageNumber { get; set; } // شماره صفحه
        public int PageSize { get; set; } // تعداد آیتم‌ها در هر صفحه
        public int TotalItems { get; set; } // تعداد کل آیتم‌ها
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize); // تعداد کل صفحات
    }
}
