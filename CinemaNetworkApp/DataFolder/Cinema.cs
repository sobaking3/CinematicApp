//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaNetworkApp.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cinema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cinema()
        {
            this.WorkerInfo = new HashSet<WorkerInfo>();
        }
    
        public int IdCinema { get; set; }
        public string CinemaName { get; set; }
        public int IdCinemaPlace { get; set; }
        public int NumberOfHalls { get; set; }
        public System.TimeSpan OpeningTime { get; set; }
        public System.TimeSpan ClosingTime { get; set; }
        public string PhoneOfCinema { get; set; }
        public int IdShedule { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerInfo> WorkerInfo { get; set; }
    }
}
