//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kurs_rab
{
    using System;
    using System.Collections.Generic;
    
    public partial class Товары
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Товары()
        {
            this.ПокупкиТоваров = new HashSet<ПокупкиТоваров>();
            this.ТоварыЗаказов = new HashSet<ТоварыЗаказов>();
        }
    
        public int id_товара { get; set; }
        public string Название { get; set; }
        public Nullable<int> Количество { get; set; }
        public Nullable<decimal> Цена { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПокупкиТоваров> ПокупкиТоваров { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ТоварыЗаказов> ТоварыЗаказов { get; set; }
    }
}
